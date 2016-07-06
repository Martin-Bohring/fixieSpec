// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace FixieSpec
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Fixie;

    /// <summary>
    /// A class that describes a Fixie <see cref="Convention"/> that picks up
    /// BDD style style specifications.
    /// </summary>
    public class FixieSpecConvention : Convention
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FixieSpecConvention"/> class.
        /// </summary>
        public FixieSpecConvention()
        {
            Methods
                .Where(method => method.IsAssertionStep());

            ClassExecution
                .CreateInstancePerClass()
                .SortCases((firstCase, secondCase) => DeclarationOrderComparer.Default.Compare(firstCase.Method, secondCase.Method));

            CaseExecution
                .Skip(SkipWhenSpecificationIsInconclusive)
                .Skip(SkipWhenAssertionStepIsInconclusive);

            FixtureExecution
                .Wrap(new ExecuteSpecificationSteps(method => method.IsTransitionStep()))
                .Wrap(new ExecuteSpecificationSteps(method => method.IsSetupStep()));
        }

        static bool SkipWhenSpecificationIsInconclusive(Case @case)
        {
            return @case.Method.DeclaringType.Has<InconclusiveAttribute>();
        }

        static bool SkipWhenAssertionStepIsInconclusive(Case @case)
        {
            return @case.Method.Has<InconclusiveAttribute>();
        }

        class ExecuteSpecificationSteps : FixtureBehavior
        {
            readonly Func<MethodInfo, bool> stepSelector;

            public ExecuteSpecificationSteps(Func<MethodInfo, bool> stepPredicate)
            {
                stepSelector = stepPredicate;
            }

            public void Execute(Fixture context, Action next)
            {
                var specificationSteps = context.Class.Type.GetMethods()
                    .Where(stepSelector)
                    .OrderBy(method => method, DeclarationOrderComparer.Default);

                foreach (var specificationStep in specificationSteps)
                {
                    try
                    {
                        specificationStep.Invoke(context.Instance, null);
                    }
                    catch (TargetInvocationException exception)
                    {
                        throw new PreservedException(exception.InnerException);
                    }
                }

                next?.Invoke();
            }
        }
    }
}

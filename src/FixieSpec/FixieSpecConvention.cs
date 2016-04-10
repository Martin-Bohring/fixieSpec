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
    /// A class that describes a Fixie test case convention that mimics
    /// BDD style style test fixtures.
    /// </summary>
    public class FixieSpecConvention : Convention
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FixieSpecConvention"/> class.
        /// </summary>
        public FixieSpecConvention()
        {
            Classes
                .NameEndsWith("Specification")
                .Where(type => type.HasOnlyDefaultConstructor());

            Methods
                .Where(method => method.IsPublic && method.IsVoid())
                .Where(method => method.HasNoParameters())
                .Where(method => method.ScanMethod() == SpecificationStepType.Then);

            ClassExecution
                .CreateInstancePerClass()
                .SortCases((firstCase, secondCase) => new DeclarationOrderComparer<MethodInfo>().Compare(firstCase.Method, secondCase.Method));

            FixtureExecution
                .Wrap<CallSpecificationTransitionSteps>();
        }

        class CallSpecificationTransitionSteps : FixtureBehavior
        {
            public void Execute(Fixture context, Action next)
            {
                var transitionSteps = context.Class.Type.GetMethods()
                    .Where(method => method.ScanMethod() == SpecificationStepType.When)
                    .OrderBy(method => method.MetadataToken);

                foreach (var transitionStep in transitionSteps)
                {
                    try
                    {
                        transitionStep.Invoke(context.Instance, null);
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

// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace FixieSpec
{
    using System;
    using System.Collections.Generic;
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
            Classes
                .NameEndsWith("Specification")
                .Where(type => type.HasOnlyDefaultConstructor());

            Methods
                .Where(method => method.IsPublic && method.IsVoid())
                .Where(method => method.HasNoParameters())
                .Where(method => method.IsAssertionStep());

            ClassExecution
                .CreateInstancePerClass()
                .SortCases((firstCase, secondCase) => DeclarationOrderComparer.Default.Compare(firstCase.Method, secondCase.Method));

            FixtureExecution
                .Wrap<CallSpecificationTransitionSteps>()
                .Wrap<CallSetupSteps>();
        }

        abstract class CallSpecificationSteps : FixtureBehavior
        {
            public void Execute(Fixture context, Action next)
            {
                var specificationSteps = GetSpecificationSteps(context.Class.Type);

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

            protected abstract IEnumerable<MethodInfo> GetSpecificationSteps(Type specificationType);
        }

        class CallSpecificationTransitionSteps : CallSpecificationSteps
        {
            protected override IEnumerable<MethodInfo> GetSpecificationSteps(Type specificationType)
            {
                return specificationType.GetMethods()
                    .Where(method => method.IsTransitionStep())
                    .OrderBy(method => method, DeclarationOrderComparer.Default);
            }
        }

        class CallSetupSteps : CallSpecificationSteps
        {
            protected override IEnumerable<MethodInfo> GetSpecificationSteps(Type specificationType)
            {
                return specificationType.GetMethods()
                    .Where(method => method.IsSetupStep())
                    .OrderBy(method => method, DeclarationOrderComparer.Default);
            }
        }
    }
}

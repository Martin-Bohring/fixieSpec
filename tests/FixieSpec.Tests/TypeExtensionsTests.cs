// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace FixieSpec.Tests
{

    using Shouldly;

    public sealed class TypeExtensionsTests
    {
        public void ShouldDetectDefaultOnlyConstructor()
        {
            typeof(TypeWithDefaultConstructorOnly).HasOnlyDefaultConstructor().ShouldBeTrue();
        }

        public void ShouldNotDetectDefaultOnlyConstructorForTypeWithParameterConstructor()
        {
            typeof(TypeWithParameterConstructorOnly).HasOnlyDefaultConstructor().ShouldBeFalse();
        }

        public void ShouldNotDetectDefaultOnlyConstructorForTypeWithMultipleConstructors()
        {
            typeof(TypeWithDefaultConstructorAndParameterConstructor).HasOnlyDefaultConstructor().ShouldBeFalse();
        }

        public void ShouldDetectParameterOnlyConstructor()
        {
            typeof(TypeWithParameterConstructorOnly).HasOnlyParameterConstructor().ShouldBeTrue();
        }

        public void ShouldNotDetectParameterOnlyConstructorForTypeWithDefaultConstructor()
        {
            typeof(TypeWithDefaultConstructorOnly).HasOnlyParameterConstructor().ShouldBeFalse();
        }

        public void ShouldNotDetectParameterOnlyConstructorForTypeWithMultipleConstructors()
        {
            typeof(TypeWithDefaultConstructorAndParameterConstructor).HasOnlyParameterConstructor().ShouldBeFalse();
        }

        public void ShouldGetInstanceMethods()
        {
            const string NameOfInstanceMethod = "InstanceMethod";

            typeof(TypeWithDefaultConstructorOnly).GetInstanceMethod(NameOfInstanceMethod)
                .Name.ShouldBe(NameOfInstanceMethod);
        }

        class TypeWithDefaultConstructorOnly
        {
            public void InstanceMethod()
            {
            }
        }

        class TypeWithParameterConstructorOnly
        {
            public TypeWithParameterConstructorOnly(
                int firstParameter,
                string secondParameter)
            {
                var firstLocalVariableToAvoidWarning = firstParameter;
                var secondLocalVariableToAvoidWarning = secondParameter;
            }
        }

        class TypeWithDefaultConstructorAndParameterConstructor
        {
            public TypeWithDefaultConstructorAndParameterConstructor()
            {
            }

            public TypeWithDefaultConstructorAndParameterConstructor(
                int firstParameter,
                string secondParameter)
            {
                var firstLocalVariableToAvoidWarning = firstParameter;
                var secondLocalVariableToAvoidWarning = secondParameter;
            }
        }
    }
}

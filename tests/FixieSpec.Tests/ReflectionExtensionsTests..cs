// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace FixieSpec.Tests
{
    using System;
    using System.Reflection;

    using Shouldly;

    public sealed class ReflectionExtensionsTests
    {
        public void ShouldDetectMethodWithoutParameters()
        {
            var methodWithoutParameter = Method<TypeWithDefaultConstructor>("MethodWithOutParameter");

            methodWithoutParameter.HasNoParameters().ShouldBeTrue();
        }

        public void ShouldDetectMethodWithParameter()
        {
            var methodWithParameter = Method<TypeWithDefaultConstructor>("MethodWithParammeter");

            methodWithParameter.HasNoParameters().ShouldBeFalse();
        }

        public void ShouldFailToDetectParametersUsingNullMethod()
        {
            Action act = () => (null as MethodInfo).HasNoParameters();

            act.ShouldThrow<ArgumentNullException>();
        }

        public void ShouldDetectDefaultConstructor()
        {
            typeof(TypeWithDefaultConstructor).HasOnlyDefaultConstructor().ShouldBeTrue();
        }

        public void ShouldNotDetectDefaultConstructorForTypesWithOtherConstructors()
        {
            typeof(TypeWithSingleParameterConstructor).HasOnlyDefaultConstructor().ShouldBeFalse();
        }

        public void ShouldFailToDetectDefaultConstructorUsingNullType()
        {
            Action act = () => (null as Type).HasOnlyDefaultConstructor();

            act.ShouldThrow<ArgumentNullException>();
        }

        public void ShouldDetectSingleParameterConstructor()
        {
            typeof(TypeWithSingleParameterConstructor).HasOnlySingleParameterConstructor().ShouldBeTrue();
        }

        public void ShouldNotDetectSingleParameterConstructorForTypesWithOnlyDefaultConstructor()
        {
            typeof(TypeWithDefaultConstructor).HasOnlySingleParameterConstructor().ShouldBeFalse();
        }

        public void ShouldFailToDetectSingleParameterConstructorUsingNullType()
        {
            Action act = () => (null as Type).HasOnlySingleParameterConstructor();

            act.ShouldThrow<ArgumentNullException>();
        }

        static MethodInfo Method<T>(string methodName)
        {
            return typeof(T).GetInstanceMethod(methodName);
        }

        class TypeWithDefaultConstructor
        {
            public void MethodWithOutParameter()
            {
            }

            public void MethodWithParammeter(int value)
            {
                var notUsed = value;
            }
        }

        class TypeWithSingleParameterConstructor
        {
            public TypeWithSingleParameterConstructor(int singleParameter)
            {
            }
        }
    }
}

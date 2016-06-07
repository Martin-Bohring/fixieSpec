// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace FixieSpec.Tests
{
    using System;

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

        public void ShouldFailToDetectDefaultConstructorOnlyUsingNullType()
        {
            Action act = () => (null as Type).HasOnlyDefaultConstructor();

            act.ShouldThrow<ArgumentNullException>();
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

        public void ShouldFailToDetectSingleParameterConstructorUsingNullType()
        {
            Action act = () => (null as Type).HasOnlyParameterConstructor();

            act.ShouldThrow<ArgumentNullException>();
        }

        class TypeWithDefaultConstructorOnly
        {
        }

        class TypeWithParameterConstructorOnly
        {
            public TypeWithParameterConstructorOnly(
                int firstParameter,
                string secondParameter)
            {
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
            }
        }
    }
}

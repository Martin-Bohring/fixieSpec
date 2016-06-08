// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Domain.Tests
{
    using System;

    using Shouldly;

    public sealed class ActivityIdTests
    {
        public void ShouldFailWhenConstructedUsingEmptyId()
        {
            Action act = () => new ActivityId(Guid.Empty);

            act.ShouldThrow<ArgumentException>();
        }

        public void ShouldSucceedWhenConstructedWithValidId()
        {
            Action act = () => new ActivityId(Guid.NewGuid());

            act.ShouldNotThrow();
        }

        public void ShouldSucceedWhenConstructedWithoutId()
        {
            Action act = () => new ActivityId();

            act.ShouldNotThrow();
        }

        public void ShouldBeEqualWithIdenticalId()
        {
            Guid identicalId = Guid.NewGuid();

            var firstActivityId = new ActivityId(identicalId);
            var secondActivityId = new ActivityId(identicalId);

            firstActivityId.Equals(secondActivityId).ShouldBeTrue();
        }

        public void ShouldNotBeEqualWithDifferentId()
        {
            var firstActivityId = new ActivityId(Guid.NewGuid());
            var secondActivityId = new ActivityId(Guid.NewGuid());

            firstActivityId.Equals(secondActivityId).ShouldBeFalse();
        }

        public void ShouldBeEqualWithSameInstance()
        {
            var activityId = new ActivityId(Guid.NewGuid());

#pragma warning disable RECS0088 // Comparing equal expression for equality is usually useless
            activityId.Equals(activityId).ShouldBeTrue();
#pragma warning restore RECS0088 // Comparing equal expression for equality is usually useless
        }
    }
}

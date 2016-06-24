﻿// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Domain.Tests.Customizations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Ploeh.AutoFixture;

    abstract class PickRandomItemFromFixedSequenceCustomization<TItem> : ICustomization
    {
        readonly Random randomizer = new Random(DateTime.Now.Millisecond);
        readonly IEnumerable<TItem> sequence;

        protected PickRandomItemFromFixedSequenceCustomization(IEnumerable<TItem> sequence)
        {
            this.sequence = sequence;
        }

        public abstract void Customize(IFixture fixture);

        protected TItem PickRandomIngredientFromSequence()
        {
            var randomIndex = randomizer.Next(0, sequence.Count());
            return sequence.ElementAt(randomIndex);
        }
    }
}

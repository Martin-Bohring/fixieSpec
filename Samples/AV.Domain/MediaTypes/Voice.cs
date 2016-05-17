// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace AV.Domain.MediaTypes
{
    /// <summary>
    /// A class that represents a human voice media type.
    /// </summary>
    public class Voice : Audio
    {
        /// <inheritdoc/>
        public override bool IsLive => true;
    }
}

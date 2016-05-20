// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace AV.Domain.MediaTypes.Audio
{
    /// <summary>
    /// A class that represents a music media type.
    /// </summary>
    public class Music : Audio
    {
        /// <inheritdoc/>
        public override bool IsLive => false;
    }
}

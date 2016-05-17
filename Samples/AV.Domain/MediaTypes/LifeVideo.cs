// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace AV.Domain.MediaTypes
{
    /// <summary>
    /// A class that represents a life video media type.
    /// </summary>
    public class LifeVideo : Video
    {
        /// <inheritdoc/>
        public override bool IsLive => true;
    }
}

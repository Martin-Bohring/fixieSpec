// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace AV.Domain.MediaTypes.Audio
{
    /// <summary>
    /// A class that represents an audio silence media type.
    /// </summary>
    /// <remarks>
    /// This is moe a less the null type for <see cref="AudioMediaType"/>´s.
    /// </remarks>
    public class SilenceMediaType : AudioMediaType
    {
        public override bool IsLive => false;
    }
}

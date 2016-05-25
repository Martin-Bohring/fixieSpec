// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Domain
{
    /// <summary>
    /// Describes the role a device plays within an activity.
    /// </summary>
    public enum DeviceRole
    {
        /// <summary>
        /// The media device is not part of any activity.
        /// </summary>
        Idle,

        /// <summary>
        /// The device is used in a background media activity.
        /// </summary>
        /// <example>
        /// A background activity is for example playing music.
        /// </example>
        Background,

        /// <summary>
        /// The device is part of a playback activity
        /// </summary>
        /// <remarks>
        /// Playing a recorded video is an example of a playback activity.
        /// </remarks>
        Playback,

        /// <summary>
        /// The media device is part of a media recording activity.
        /// </summary>
        /// <example>
        /// Recording a video or a voice memo are examples of recording activities.
        /// </example>
        Recording,

        /// <summary>
        /// The media device is part of a communication activity.
        /// </summary>
        /// <example>
        /// A phone call or a video conference or are examples of communication activities.
        /// </example>
        Communication,

        /// <summary>
        /// The device is part of a user prompting activity.
        /// </summary>
        /// <example>
        /// An example is playing a ringtone, indicating an incoming video conference or
        /// text to speech voice output.
        /// </example>
        Prompt,

        /// <summary>
        /// The device is part of an alert activity.
        /// </summary>
        /// <example>
        /// An audio alert is an example of this type of activity.
        /// </example>
        Alert
    }
}

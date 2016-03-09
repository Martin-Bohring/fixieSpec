// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace FixieSpec
{
    using System.Reflection;

    /// <summary>
    /// Scans methods and identifies the type of the methods being scanned.
    /// </summary>
    public static class MethodTypeScanner
    {
        /// <summary>
        /// Scans the method given by <paramref name="methodToScan"/> for its <see cref="MethodType"/>.
        /// </summary>
        /// <param name="methodToScan">
        /// The method to scan.
        /// </param>
        /// <returns>
        /// The type of the scanned method.
        /// </returns>
        public static MethodType ScanMethod(this MethodInfo methodToScan)
        {
            return MethodType.Undefined;
        }
    }
}

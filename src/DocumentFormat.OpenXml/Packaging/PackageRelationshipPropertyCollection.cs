﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using DocumentFormat.OpenXml.Features;
using System;
using System.IO.Packaging;

namespace DocumentFormat.OpenXml.Packaging
{
    /// <summary>
    /// Represents a collection of relationships that are obtained from the package.
    /// </summary>
    internal class PackageRelationshipPropertyCollection : RelationshipCollection
    {
        public Package Package { get; }

        public PackageRelationshipPropertyCollection(Package package, IOpenXmlNamespaceResolver resolver)
            : base(package.GetRelationships(), resolver)
        {
            Package = package;
        }

        internal override void ReplaceRelationship(Uri targetUri, TargetMode targetMode, string strRelationshipType, string strId)
        {
            Package.DeleteRelationship(strId);
            Package.CreateRelationship(targetUri, targetMode, strRelationshipType, strId);
        }

        internal override Package GetPackage()
        {
            return Package;
        }
    }
}

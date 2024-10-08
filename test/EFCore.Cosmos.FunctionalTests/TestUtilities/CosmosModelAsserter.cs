﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

// ReSharper disable once CheckNamespace

namespace Microsoft.EntityFrameworkCore.TestUtilities;

public class CosmosModelAsserter : ModelAsserter
{
    protected CosmosModelAsserter()
    {
    }

    public static new CosmosModelAsserter Instance { get; } = new();

    public override void AssertEqual(
        IEnumerable<IReadOnlyProperty> expectedProperties,
        IEnumerable<IReadOnlyProperty> actualProperties,
        bool assertOrder = false,
        bool compareAnnotations = false)
    {
        expectedProperties = expectedProperties.Where(p => p.Name != "__jObject" && p.Name != "__id" && p.Name != "$type");
        actualProperties = actualProperties.Where(p => p.Name != "__jObject" && p.Name != "__id" && p.Name != "$type");

        base.AssertEqual(expectedProperties, actualProperties, assertOrder, compareAnnotations);
    }
}

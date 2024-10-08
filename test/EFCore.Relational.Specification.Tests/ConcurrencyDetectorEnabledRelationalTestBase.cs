// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

// ReSharper disable InconsistentNaming

namespace Microsoft.EntityFrameworkCore;

#nullable disable

public abstract class ConcurrencyDetectorEnabledRelationalTestBase<TFixture>(TFixture fixture)
    : ConcurrencyDetectorEnabledTestBase<TFixture>(fixture)
    where TFixture : ConcurrencyDetectorTestBase<TFixture>.ConcurrencyDetectorFixtureBase, new()
{
    protected string NormalizeDelimitersInRawString(string sql)
        => (Fixture.TestStore as RelationalTestStore)?.NormalizeDelimitersInRawString(sql) ?? sql;

    [ConditionalTheory]
    [MemberData(nameof(IsAsyncData))]
    public virtual Task FromSql(bool async)
        => ConcurrencyDetectorTest(
            async c => async
                ? await c.Products.FromSqlRaw(NormalizeDelimitersInRawString("select * from [Products]")).ToListAsync()
                : c.Products.FromSqlRaw(NormalizeDelimitersInRawString("select * from [Products]")).ToList());
}

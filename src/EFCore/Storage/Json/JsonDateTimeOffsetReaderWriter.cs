// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Text.Json;

namespace Microsoft.EntityFrameworkCore.Storage.Json;

/// <summary>
///     Reads and writes JSON for <see cref="DateTimeOffset" /> values.
/// </summary>
public sealed class JsonDateTimeOffsetReaderWriter : JsonValueReaderWriter<DateTimeOffset>
{
    private static readonly PropertyInfo InstanceProperty = typeof(JsonDateTimeOffsetReaderWriter).GetProperty(nameof(Instance))!;

    /// <summary>
    ///     The singleton instance of this stateless reader/writer.
    /// </summary>
    public static JsonDateTimeOffsetReaderWriter Instance { get; } = new();

    private JsonDateTimeOffsetReaderWriter()
    {
    }

    /// <inheritdoc />
    public override DateTimeOffset FromJsonTyped(ref Utf8JsonReaderManager manager, object? existingObject = null)
        => manager.CurrentReader.GetDateTimeOffset();

    /// <inheritdoc />
    public override void ToJsonTyped(Utf8JsonWriter writer, DateTimeOffset value)
        => writer.WriteStringValue(value);

    /// <inheritdoc />
    public override Expression ConstructorExpression
        => Expression.Property(null, InstanceProperty);
}

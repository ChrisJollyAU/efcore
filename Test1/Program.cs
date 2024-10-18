#pragma warning disable SA1633
#pragma warning disable SA1649
#pragma warning disable SA1633
#pragma warning disable SA1515
#pragma warning disable SA1516
#pragma warning disable SA1206
#pragma warning disable SA1208
#pragma warning disable SA1402
#pragma warning disable SA1210
#pragma warning disable SA1005
#pragma warning disable SA0001
using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Diagnostics;

await using var context = new MyContext();
await context.Database.MigrateAsync();
#nullable disable
public class MyContext : DbContext
{
    public DbSet<Entity> Entities { get; set; }
    //Microsoft.EntityFrameworkCore.Metadata.Internal.EntityType
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
            .LogTo(Console.WriteLine)
            .UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=Migrations;Integrated Security=SSPI").ConfigureWarnings(builder => builder.Log(RelationalEventId.PendingModelChangesWarning));
}

[Index(nameof(EntityId), IsUnique = true)]
public class Entity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Key { get; set; }

    [Required]
    [MaxLength(50)]
    public required string EntityId { get; set; }
}

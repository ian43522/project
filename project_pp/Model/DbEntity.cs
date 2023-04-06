using System;
using System.ComponentModel.DataAnnotations;

namespace project_pp.Model;
/// <summary>
/// Base class that represents database entity/
/// </summary>
public abstract class DbEntity
{
    /// <summary>
    /// Primary key for database entity.
    /// </summary>
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();
}

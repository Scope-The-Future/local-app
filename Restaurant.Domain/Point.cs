namespace Restaurant.Domain;

using System.ComponentModel.DataAnnotations;

public sealed class Point
{
    public Guid PointId { get; set; }

    [MaxLength(64)]
    public string Code { get; set; } = null!;

    [MaxLength(256)]
    public string Name { get; set; } = null!;

    [MaxLength(256)]
    public string LegalEntity { get; set; } = null!;

    [MaxLength(64)]
    public string Timezone { get; set; } = null!;

    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
}
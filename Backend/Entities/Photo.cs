using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Entities;

[Table("Photos")]
public class Photo
{
    public int Id { get; set; }
    public required string Url { get; set; } = string.Empty;
    public string? PublicId { get; set; }
    public bool IsMain { get; set; }


    public int UserId { get; set; }

    public User User { get; set; } = null!;
}
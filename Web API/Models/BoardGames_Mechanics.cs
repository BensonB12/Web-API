using System.ComponentModel.DataAnnotations;

namespace Web_API.Models;

public class BoardGames_Mechanics
{
    public BoardGame? BoardGame { get; set; }
    public Domain? Domain { get; set; }

    [Key]
    [Required]
    public int BoardgameId { get; set; }

    [Key]
    [Required]
    public int MechanicId { get; set; }

    [Required]
    public DateTime CreatedDate { get; set; }
}

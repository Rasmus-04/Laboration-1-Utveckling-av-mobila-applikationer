using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Laboration_1_Rasmus_Serrestam.Models;

public class ItemCondition
{
    public int Id { get; set; }

    [Required]
    [StringLength(30)]
    public string Name { get; set; } = string.Empty;

    public ICollection<Item> Items { get; set; } = new List<Item>();
}

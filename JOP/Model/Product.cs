using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JOP;

public partial class Product
{
    [Key]
    public int Id { get; set; }

    public int CategoryId { get; set; }

    public string? Name { get; set; }

    public double? Price { get; set; }

    public int? Quality { get; set; }

    public string? Description { get; set; }

    public string? Image { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<TakenProduct> TakenProducts { get; } = new List<TakenProduct>();


}

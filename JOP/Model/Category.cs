using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace JOP;

public partial class Category
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();
    public Category(string name)
    {
        this.Name = name;
    }
    public Category()
    {

    }
}

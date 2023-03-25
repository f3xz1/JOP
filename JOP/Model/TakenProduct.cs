using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace JOP;

public partial class TakenProduct
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public int ProductId { get; set; }

    public virtual User Customer { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}

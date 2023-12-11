using System;
using System.Collections.Generic;

namespace Auth.Database;

public partial class Service
{
    public int IdServices { get; set; }

    public string Service1 { get; set; } = null!;

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();
}

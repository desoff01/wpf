using System;
using System.Collections.Generic;

namespace DataGrid;

public partial class InfoCompany
{
    public int IdInfoCompany { get; set; }

    public int Company { get; set; }

    public int Director { get; set; }

    public virtual Company CompanyNavigation { get; set; } = null!;

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

    public virtual Director DirectorNavigation { get; set; } = null!;
}

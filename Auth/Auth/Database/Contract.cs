using System;
using System.Collections.Generic;

namespace Auth.Database;

public partial class Contract
{
    public int NumberOfContract { get; set; }

    public DateOnly DateOfConclusion { get; set; }

    public DateOnly Deadline { get; set; }

    public int IdServicesService { get; set; }

    public int InfoCompany { get; set; }

    public virtual Service IdServicesServiceNavigation { get; set; } = null!;

    public virtual InfoCompany InfoCompanyNavigation { get; set; } = null!;
}

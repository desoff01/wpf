using System;
using System.Collections.Generic;

namespace Auth.Database;

public partial class Company
{
    public int IdCompanies { get; set; }

    public string NameCompany { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string HeadOfficeCity { get; set; } = null!;

    public virtual ICollection<InfoCompany> InfoCompanies { get; set; } = new List<InfoCompany>();
}

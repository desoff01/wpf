using System;
using System.Collections.Generic;

namespace Auth.Database;

public partial class Director
{
    public int IdDirectors { get; set; }

    public string Family { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Patronymic { get; set; }

    public string ContactNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<InfoCompany> InfoCompanies { get; set; } = new List<InfoCompany>();
}

using System;
using System.Collections.Generic;

namespace Auth.Database;

public partial class User
{
    public int Idlogin { get; set; }

    public string Login { get; set; } = null!;

    public string Passwd { get; set; } = null!;
}

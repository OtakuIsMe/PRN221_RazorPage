using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessObject;

public partial class Hraccount
{
    [Key]
    public string Email { get; set; } = null!;

    public string? Password { get; set; }

    public string? FullName { get; set; }

    public int? MemberRole { get; set; }
}

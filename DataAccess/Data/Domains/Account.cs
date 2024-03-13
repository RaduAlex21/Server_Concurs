using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Enums;

namespace DataAccess.Data.Domains;

[Table("tAccounts")]

public sealed class Account
{
    [ExplicitKey]
    public int IdAccount { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? Nickname { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public Role Role { get; set; }
}

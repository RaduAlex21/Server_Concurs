using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Domains;

[Table("tLocation")]

public class Location
{
    [ExplicitKey]
    public int IdLocation { get; set; }
    public string? Adress { get; set; }
}

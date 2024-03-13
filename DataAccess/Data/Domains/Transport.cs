using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Enums;

namespace DataAccess.Data.Domains;

[Table("tTransport")]

public class Transport
{
    [ExplicitKey]
    public int IdTransport { get; set; }
    public int Id_Account { get; set; }
    public int Id_Location { get; set; }
    public string? StartLocation { get; set; }
    public string? Amount { get; set; } 
    public string? DispatchDate { get; set; }
    public string? DeliveryDate { get; set; }
    public string? EstimateDelivery { get; set; }
    public TransportStatus Status { get; set; }
}
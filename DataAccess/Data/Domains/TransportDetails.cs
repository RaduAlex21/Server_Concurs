using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Enums;

namespace DataAccess.Data.Domains;

public class TransportDetails
{
    public int IdTransport { get; set; }
    public string? StartLocation { get; set; }
    public string? Amount { get; set; }
    public string? DispatchDate { get; set; }
    public string? DeliveryDate { get; set; }
    public TransportStatus Status { get; set; }

}

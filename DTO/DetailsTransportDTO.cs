using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Enums;

namespace DTO;

public class DetailsTransportDTO
{
    public string? StartLocation { get; set; }
    public string? Amount { get; set; }
    public string? DispatchDate { get; set; }
    public string? DeliveryDate { get; set; }
    public TransportStatus Status { get; set; } 
}

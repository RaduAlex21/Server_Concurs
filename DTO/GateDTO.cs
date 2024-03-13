using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Enums;

namespace DTO;

public class GateDTO
{
    public int IdGate { get; set; }
    public int Id_Location { get; set; }
    public GateStatus Status { get; set; }
    public string? Available_Time { get; set; }
    public string? TimeOfUnpacking { get; set; }
}

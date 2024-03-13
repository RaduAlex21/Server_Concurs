using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validators;

public class GateValidator : Validator<GateDTO>, IValidator<GateDTO>
{
    public GateValidator() : base() { }

    public override void Validate(GateDTO value)
    {
        if (value.Id_Location == 0)
            this.Errors.Add("Id_Location null");
        if (value.Status == 0)
            this.Errors.Add("Status null");
        if (string.IsNullOrEmpty(value.Available_Time))
            this.Errors.Add("Available_Time null");
        if (string.IsNullOrEmpty(value.TimeOfUnpacking))
            this.Errors.Add("TimeOfUnpacking null");
    }
}

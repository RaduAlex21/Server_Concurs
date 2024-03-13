using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validators;

public class TransportValidator : Validator<TransportDTO>, IValidator<TransportDTO>
{
    public TransportValidator() : base() { }

    public override void Validate(TransportDTO value)
    {
        if (value.Id_Account == 0)
            this.Errors.Add("Id_Driver null");
        if (value.Id_Location == 0)
            this.Errors.Add("Id_Location null");
        if (string.IsNullOrEmpty(value.StartLocation))
            this.Errors.Add("StartLocation null");
        if (string.IsNullOrEmpty(value.Amount))
            this.Errors.Add("Amount null");
        if (string.IsNullOrEmpty(value.DispatchDate))
            this.Errors.Add("DispatchDate null");
        if (string.IsNullOrEmpty(value.DeliveryDate))
            this.Errors.Add("DeliveryDate null");
        if (string.IsNullOrEmpty(value.EstimateDelivery))
            this.Errors.Add("EstimateDelivery null");
        if (value.Status == 0)
            this.Errors.Add("Status null");
    }
}

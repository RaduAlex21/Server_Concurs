using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validators;

public class LocationValidator : Validator<LocationDTO>, IValidator<LocationDTO>
{
    public LocationValidator() : base() { }

    public override void Validate(LocationDTO value)
    {
        if (string.IsNullOrEmpty(value.Adress))
            this.Errors.Add("Adress null");
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validators;

public abstract class Validator<T> : IValidator<T>
{
    public List<string> Errors { get; protected set; }

    public abstract void Validate(T value);

    public Validator()
    {
        this.Errors = new List<string>();
    }

    public string GetErrors()
    {
        var message = new StringBuilder();
        foreach (var error in this.Errors)
        {
            message.Append(error.ToString() + "\n");
        }
        return message.ToString();
    }
}

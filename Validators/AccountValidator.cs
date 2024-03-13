using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Validators;

public class AccountValidator : Validator<AccountDTO>, IValidator<AccountDTO>
{
    public AccountValidator() : base() { }
    public override void Validate(AccountDTO value)
    {
        if (string.IsNullOrEmpty(value.Username))
            this.Errors.Add("Username null");

        if (string.IsNullOrEmpty(value.Password))
            this.Errors.Add("Password null");

        if (string.IsNullOrEmpty(value.Nickname))
            this.Errors.Add("Nickname null");
       
        if (string.IsNullOrEmpty(value.Email))
            this.Errors.Add("Email null");

        if (string.IsNullOrEmpty(value.PhoneNumber))
            this.Errors.Add("Phonenumber null");

        if (value.Role == 0)
            this.Errors.Add("Role null");
    }
}

using DataAccess.Connection;
using DataAccess.Data.Domains;
using DataAccess.Factory;
using DTO;
using Mappers;
using Services.ModelServices.Contracts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validators;

namespace Services.ModelServices;

public class AccountService : IAccountService
{
    private readonly IFactory factory;
    private readonly IValidator<AccountDTO> validator;

    public AccountService(IFactory factory, IValidator<AccountDTO> validator)
    {
        this.factory = factory;
        this.validator = validator;
    }

    public async Task<bool> DeleteAsync(AccountDTO value)
    { 
        var account = new Account() { IdAccount = value.IdAccount};
        return await this.factory.AccountRepository.DeleteAsync(account);
    }

    public async Task<List<AccountDTO>> GetAllAsync()
    {
        var accounts = await this.factory.AccountRepository.GetAllAsync();
        return ManualMapper.Map(accounts);
    } 

    public async Task<AccountDTO> InsertAsync(AccountDTO value)
    {
        var existentAccount = this.factory.AccountRepository.FirstOrDefaultAsync(x => x.Username == value.Username ||
                                                                                      x.Email == value.Email ||
                                                                                      x.PhoneNumber == value.PhoneNumber);
        if(existentAccount != null)
        {
            throw new Exception("cineva exista");
        }

        this.validator.Validate(value);

        if(this.validator.Errors.Any())
        {
            throw new Exception(this.validator.GetErrors());
        }

        var account = ManualMapper.Map(value);

        var accountDTO = await this.factory.AccountRepository.InsertAsync(account);

        if(accountDTO != null) 
        {
            return ManualMapper.Map(accountDTO); 
        }

        throw new Exception("Eroare la inserare"); 
    }

    public async Task<AccountDTO> UpdateAsync(AccountDTO value)
    {
        var existentAccount = this.factory.AccountRepository.FirstOrDefaultAsync(x => x.IdAccount == value.IdAccount);

        if (existentAccount == null)
        {
            throw new Exception("Cont incorrect");
        }

        this.validator.Validate(value);

        if (this.validator.Errors.Any())
        {
            throw new Exception(this.validator.GetErrors());
        }

        var account = ManualMapper.Map(value);

        var accountDTO = await this.factory.AccountRepository.UpdateAsync(account);

        if (accountDTO != null)
        {
            return ManualMapper.Map(accountDTO);
        }

        throw new Exception("Eroare la update");

    }

    public async Task<AccountDTO> SearchByIdAsync(int id)
    {
        var account = await this.factory.AccountRepository.FirstOrDefaultAsync( x => x.IdAccount == id);

        if (account == null)
            throw new Exception("Account null");

        return ManualMapper.Map(account); 
    }
}
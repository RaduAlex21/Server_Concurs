using Dapper.Contrib.Extensions;
using DataAccess.Connection;
using DataAccess.Data.Domains;
using DataAccess.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Repository;

public sealed class AccountRepository : Repository<Account>, IAccountRepository
{
    protected ISqlDAccess sqlDAccess;

    public AccountRepository(ISqlDAccess sqlDataAcess) : base(sqlDataAcess)
    {   
        this.sqlDAccess = sqlDataAcess;
    }

  /*  public async Task<bool> DeleteAsync(Account value)
    {
        using var connection = new SqlConnection(sqlDAccess.Connection);

        return await connection.DeleteAsync(value);
    }

    public async Task<List<Account>> GetAllAsync()
    {
        using var connection = new SqlConnection(sqlDAccess.Connection);

        var entities = await connection.GetAllAsync<Account>() ?? Enumerable.Empty<Account>();

        return entities.ToList();
    }

    public async Task<Account> InsertAsync(Account value)
    {
        using var connection = new SqlConnection(sqlDAccess.Connection);

        var account = await connection.InsertAsync(value);

        return await connection.GetAsync<Account>(value.IdAccount);
    }

    public async Task<Account> UpdateAsync(Account value)
    {
        using var connection = new SqlConnection(sqlDAccess.Connection);

        if (await connection.UpdateAsync(value))
            return value;

        return null;
    }*/


}

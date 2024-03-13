using DataAccess.Connection;
using DataAccess.Data.Interfaces;
using DataAccess.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Factory;

public class Factory : IFactory
{
    private readonly ISqlDAccess _SQLDataAccess;
    public IAccountRepository AccountRepository => new AccountRepository(_SQLDataAccess);
    public ITransportRepository TransportRepository => new TransportRepository(_SQLDataAccess);
    public IGateRepository GateRepository => new GateRepository(_SQLDataAccess);
    public ILocationRepository LocationRepository => new LocationRepository(_SQLDataAccess);

    public Factory(ISqlDAccess sQLDataAccess)
    {
        _SQLDataAccess = sQLDataAccess;
    }
}

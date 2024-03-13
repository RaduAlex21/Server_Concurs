using DataAccess.Connection;
using DataAccess.Data.Domains;
using DataAccess.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Repository;

public sealed class TransportRepository : Repository<Transport>, ITransportRepository
{
    public TransportRepository(ISqlDAccess sqlDataAccess) : base(sqlDataAccess)
    {

    }
}


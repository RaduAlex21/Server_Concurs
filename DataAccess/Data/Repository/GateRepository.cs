using DataAccess.Connection;
using DataAccess.Data.Domains;
using DataAccess.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Repository;

public sealed class GateRepository : Repository<Gate>, IGateRepository
{
    public GateRepository(ISqlDAccess sqlDataAcess) : base(sqlDataAcess)
    {

    }
}

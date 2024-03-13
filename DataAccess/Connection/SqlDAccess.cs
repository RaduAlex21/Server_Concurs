using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Connection;

public class SqlDAccess : ISqlDAccess
{
    public string Connection { get; private set; }
    public SqlDAccess(string connection)
    {
        this.Connection = connection;
    }
}

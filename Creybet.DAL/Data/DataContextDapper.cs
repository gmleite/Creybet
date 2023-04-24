using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Creybet.DAL.Data;

class DataContextDapper
{
    private readonly IConfiguration _config;
    public DataContextDapper(IConfiguration config)
    {
        _config = config;
    }
}
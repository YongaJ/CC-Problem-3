using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace CCProblem3.Models
{
    public static class DapperORM
    {
        private static string connSTring = @"data source = CCdevdb044; initial catalog = CC; integrated security = True;";

        public static void ExecuteWithoutReturn(string procName, DynamicParameters parameters)
        {
            using (SqlConnection sqlConn = new SqlConnection(connSTring))
            {
                sqlConn.Open();
                sqlConn.Execute(procName, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public static T ExecuteReturnScalar<T>(string procName, DynamicParameters parameters)
        {
            using (SqlConnection sqlConn = new SqlConnection(connSTring))
            {
                sqlConn.Open();
                return (T)Convert.ChangeType( sqlConn.Execute(procName, parameters, commandType: CommandType.StoredProcedure), typeof(T));
            }
        }

        public static IEnumerable<T> ReturnList<T>(string procName, DynamicParameters parameters)
        {
            using (SqlConnection sqlConn = new SqlConnection(connSTring))
            {
                sqlConn.Open();
                return sqlConn.Query<T>(procName, parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
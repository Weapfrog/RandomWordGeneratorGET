using Dapper;
using RandomWordGeneratorGET.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomWordGeneratorGET.Core
{
    public class DapperHelper
    {
        private readonly string ConnectionString;
        SqlConnection conn;
        public DapperHelper()
        {
            ConnectionString = ConnectionHelper.ConnectionString;
            this.conn = new SqlConnection(ConnectionString);
        }
        public List<Words> GetWord()
        {
            try
            {
                if (this.conn.State != System.Data.ConnectionState.Open)
                {
                    this.conn.Close();
                    this.conn.Open();
                }


                return conn.Query<Words>("SELECT TOP 1 * FROM Words ORDER BY WordID DESC", null, null, true, null, System.Data.CommandType.Text).ToList();

            }
            catch (Exception ex)
            {
                this.conn.Close();
                return (new List<Words>());
            }
        }
        public List<Words> GetAllWords()
        {
            try
            {
                if (this.conn.State == System.Data.ConnectionState.Closed)
                    this.conn.Open();

                return conn.Query<Words>("SELECT * FROM Words", null, null, true, null, System.Data.CommandType.Text).ToList();

            }
            catch (Exception ex)
            {
                this.conn.Close();
                return (new List<Words>());
            }

        }
    }
}

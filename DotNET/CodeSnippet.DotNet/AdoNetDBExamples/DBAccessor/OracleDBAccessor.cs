﻿using AdoNetDBExamples.Interfaces;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetDBExamples.DBAccessor
{
    public class OracleDBAccessor : IDBAccessor
    {
        public DbDataReader ExecuteReader(string sql, List<DbParameter> parameters = null)
        {
            OracleConnection connection = new OracleConnection(GetConnectionString());
            OracleCommand command = new OracleCommand(sql, connection);

            command.CommandType = CommandType.Text;
            command.BindByName = true;
            command.Parameters.Clear();

            if (parameters != null)
            {
                foreach (OracleParameter p in parameters)
                    command.Parameters.Add(p);
            }

            connection.Open();

            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public int ExecuteNonQuery(string sql, List<DbParameter> parameters = null)
        {
            using (OracleConnection connection = new OracleConnection(GetConnectionString()))
            {
                using (OracleCommand command = new OracleCommand(sql))
                {
                    command.CommandType = CommandType.Text;
                    command.BindByName = true;
                    command.Parameters.Clear();

                    if (parameters != null)
                    {
                        foreach (OracleParameter p in parameters)
                            command.Parameters.Add(p);
                    }

                    connection.Open();
                    command.Connection = connection;

                    return command.ExecuteNonQuery();
                }
            }
        }

        public DataTable ExecuteSelect(string sql, List<DbParameter> parameters = null)
        {
            using (OracleConnection connection = new OracleConnection(GetConnectionString()))
            {
                using (OracleCommand command = new OracleCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.BindByName = true;
                    command.Parameters.Clear();

                    if (parameters != null)
                    {
                        foreach (OracleParameter p in parameters)
                            command.Parameters.Add(p);
                    }

                    OracleDataAdapter adp = new OracleDataAdapter(command);

                    try
                    {
                        DataTable dt = new DataTable();
                        dt.TableName = "DataTable";

                        adp.Fill(dt);

                        return dt;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        if (adp != null)
                            adp.Dispose();
                    }
                }
            }
        }

        public object ExecuteScalar(string sql, List<DbParameter> parameters = null)
        {
            using (OracleConnection connection = new OracleConnection(GetConnectionString()))
            {
                using (OracleCommand command = new OracleCommand(sql))
                {
                    command.CommandType = CommandType.Text;
                    command.BindByName = true;
                    command.Parameters.Clear();

                    if (parameters != null)
                    {
                        foreach (OracleParameter p in parameters)
                            command.Parameters.Add(p);
                    }

                    connection.Open();
                    command.Connection = connection;

                    return command.ExecuteScalar();
                }
            }
        }

        #region private methods

        private string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString; ;
        }

        #endregion

    }
}

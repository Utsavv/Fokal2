using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Base
{
    public class BaseDAO
    {
        /// <summary>
        /// Closes the command.
        /// </summary>
        /// <param name="command">The command.</param>
        protected void CloseCommand(DbCommand command, bool CloseConnection = true)
        {
            if (command != null)
            {
                if (CloseConnection && command.Connection != null && command.Connection.State != ConnectionState.Closed)
                {
                    command.Connection.Close();
                }

                command.Dispose();
            }
        }

        /// <summary>
        /// Closes the transaction.
        /// </summary>
        /// <param name="transaction">The transaction object.</param>
        protected void CloseTransaction(DbTransaction transaction)
        {
            if (transaction != null)
            {
                if (transaction.Connection != null && transaction.Connection.State != ConnectionState.Closed)
                {
                    transaction.Connection.Close();
                }

                transaction.Dispose();
            }
        }

        /// <summary>
        /// Closes the command.
        /// </summary>
        /// <param name="command">The command.</param>
        protected void CloseCommandOnly(DbCommand command)
        {
            if (command != null)
            {
                //if (command.Connection != null && command.Connection.State != ConnectionState.Closed)
                //{
                //    command.Connection.Close();
                //}

                command.Dispose();
            }
        }

        public DbConnection GetCentralDBConnection()
        {
            return DBInstance.GetCentralServerInstance.CreateConnection();
        }

        public void CloseConnection(DbConnection connection)
        {
            if (connection != null && connection.State != ConnectionState.Closed)
            {
                connection.Close();
            }
        }
    }
}

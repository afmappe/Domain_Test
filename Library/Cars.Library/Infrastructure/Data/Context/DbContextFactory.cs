using System;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Cars.Library.Infrastructure.Data.Context
{
    /// <summary>
    /// Fabrica para la creación de contextos
    /// </summary>
    /// <typeparam name="TContextType">Contexto</typeparam>
    public class DbContextFactory<TContextType> : IDbContextFactory<TContextType>
        where TContextType : DbContext
    {
        public DbContextFactory()
        {
        }

        public TContextType Create()
        {
            string schema = "dbo";

            DbProviderFactory Factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
            DbConnectionStringBuilder connectionStringBuilder = Factory.CreateConnectionStringBuilder();
            connectionStringBuilder.Add("Server", "localhost");
            connectionStringBuilder.Add("Database", "Cars.DataBase");
            connectionStringBuilder.Add("User ID", "ARCHDESA");
            connectionStringBuilder.Add("Password", "ARCH123");

            DbConnection connection = Factory.CreateConnection();
            connection.ConnectionString = connectionStringBuilder.ConnectionString;

            return (TContextType)Activator.CreateInstance(
             typeof(TContextType),
             connection,
             schema);
        }
    }
}
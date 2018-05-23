using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

using System.Threading.Tasks;
using Library.Entities.Interfaces;
using System.Configuration;

using System.Data.SqlClient;

using Dapper;
using Library.Entities.Models;

namespace Library.DAL.Repositories
{
    public class DapperGenericRepository<TEntity> : IRepository<TEntity> where TEntity : BaseModel
    {
        string connectionString;

        public DapperGenericRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["LibraryContext"].ConnectionString;
        }

        public IEnumerable<TEntity> Get()
        {
            var query = $"select * from {typeof(TEntity).Name}s ";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return connection.Query<TEntity>(query);
            }

        }


        public TEntity Get(int id)
        {
            var IdString = nameof(BaseModel.Id);
            var query = $"select * from {typeof(TEntity).Name}s";
            string where=String.Format( " where {0} = {1} ", IdString, id);
           
            if (!string.IsNullOrWhiteSpace(where))
                query += where;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return connection.Query<TEntity>(query).First();
            }
        }

        public void Create(TEntity item)
        {
            
            var columns = GetColumns();
            var stringOfColumns = string.Join(", ", columns);
            var stringOfParameters = string.Join(", ", columns.Select(e => "@" + e));
            var query = $"insert into {typeof(TEntity).Name}s ({stringOfColumns}) values ({stringOfParameters})";

            using (System.Data.IDbConnection db = new SqlConnection(connectionString))
            {
                db.Execute(query, item);
            }

        }

        public void Update(TEntity item)
        {
            var IdString = nameof(BaseModel.Id);
            var columns = GetColumns();
            var stringOfColumns = string.Join(", ", columns.Select(e => $"{e} = @{e}"));
            var query = $"update {typeof(TEntity).Name}s set {stringOfColumns} where {IdString} = @Id";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.Execute(query, item);
            }
        }

        public void Remove(int id)
        {
            var IdString = nameof(BaseModel.Id);

            var query = $"delete from {typeof(TEntity).Name}s where {IdString} = @Id";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.Execute(query, Get(id));
            }
        }

        public IEnumerable<TEntity> Get(string query)
        {

            if (string.IsNullOrWhiteSpace(query))
                return null;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return connection.Query<TEntity>(query);
            }

        }

        private IEnumerable<string> GetColumns()
        {
            var IdString = nameof(BaseModel.Id);

            return typeof(TEntity)
                    .GetProperties()
                    .Where(e => e.Name != IdString && !e.PropertyType.GetTypeInfo().IsGenericType)
                    .Select(e => e.Name);
        }

       
    }
}

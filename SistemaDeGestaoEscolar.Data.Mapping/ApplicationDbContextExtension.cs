using Microsoft.EntityFrameworkCore;
using SistemaDeGestaoEscolar.Common;
using System;

namespace SistemaDeGestaoEscolar.Data.Mapping
{
    public static class ApplicationDbContextExtension
    {
        private static string RemoveGenericType(this string str)
        {
            var ret = str;
            const string token = "<int>";

            if (ret.EndsWith(token))
            {
                ret = ret.Substring(0, ret.IndexOf(token));
            }

            return ret;
        }

        public static void AddSnakeCase(this ModelBuilder modelBuilder, bool useIdentity)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                // padrão de nomenclatura "Table Name"
                var tableName = "";

                if (useIdentity)
                {
                    tableName = entityType.GetTableName();
                }
                else
                {
                    tableName = entityType.DisplayName();
                }
                tableName = tableName.ToSnakeCase().RemoveGenericType();
                entityType.SetTableName(tableName);

                // padrão de nomenclatura de "Primary Key"
                var pk = entityType.FindPrimaryKey();
                if (pk != null)
                {
                    var pkName = $"pk_{tableName}";
                    pk.SetName(pkName);
                }

                foreach (var property in entityType.GetProperties())
                {
                    // padrão de nomenclatura de "Columns"
                    var columnName = property.Name.ToSnakeCase();
                    property.SetColumnName(columnName);

                    // padrão de nomenclatura de "Foreign Keys"
                    foreach (var fk in entityType.FindForeignKeys(property))
                    {
                        var fkName = $"fk_{tableName}_{columnName}";
                        fk.SetConstraintName(fkName);
                    }
                }

                // padrão de nomenclatura de "Indices"
                foreach (var index in entityType.GetIndexes())
                {
                    var indexName = index.GetDatabaseName().ToSnakeCase();

                    if (useIdentity)
                    {
                        var token = "_index";
                        if (indexName.EndsWith(token))
                        {
                            indexName = indexName.Substring(0, indexName.IndexOf(token));
                        }

                        token = "ix_";
                        if (indexName.StartsWith(token))
                        {
                            indexName = indexName.Remove(0, 3);
                        }

                        token = "identity_";
                        if (!indexName.StartsWith(token))
                        {
                            indexName = token + indexName;
                        }
                    }
                    else
                    {
                        indexName = indexName.Remove(0, 3);
                    }

                    index.SetDatabaseName("idx_" + indexName);
                }
            }
        }
    }
}

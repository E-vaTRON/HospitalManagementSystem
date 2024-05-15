using Microsoft.Data.SqlClient;

namespace IdentitySystem.Tests;

public static class SqlDatabaseHelper
{
    public static bool DatabaseExists(string connectionString)
    {
        try
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return true;
            }
        }
        catch (SqlException ex) when (ex.Number == 4060)
        {
            return false;
        }
    }

    public static bool TableExists(string connectionString, string tableName)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();

            using (var command = new SqlCommand($"SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '{tableName}'", connection))
            {
                var count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }
    }

    public static bool CheckTableColumn(string connectionString,
                                        string tableName,
                                        string columnName,
                                        string columnType)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();

            using (var command = new SqlCommand($"SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tableName}' AND COLUMN_NAME = '{columnName}' AND DATA_TYPE = '{columnType}'", connection))
            {
                var count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }
    }
}

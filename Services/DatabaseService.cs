using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarsztatSamochodowy.Utils;

namespace WarsztatSamochodowy.Services
{
    internal class DatabaseService
    {
        private MySqlConnection mySqlConnection;
        private static readonly string connectionString = "server=localhost;user=root;database=warsztat;port=3306;password=password";
        private string sqlCommandString;
        private MySqlCommand sqlCommand;
        public DatabaseService()
        {
            mySqlConnection = new MySqlConnection(connectionString);
            sqlCommand = new MySqlCommand();
            sqlCommand.Connection = mySqlConnection;
            sqlCommandString = "";
        }
        private void executeNonQuery()
        {
            sqlCommand.CommandText = sqlCommandString;
            mySqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            sqlCommand.Parameters.Clear();
        }
        
        public DataTable selectAllToTable(string tableName)
        {
            DataTable dataTable = new DataTable();
            mySqlConnection.Open();
            MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter("SELECT * FROM " + tableName, mySqlConnection);
            mySqlConnection.Close();
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }
        public void insert(string tableName, SortedDictionary<string, string> data)
        {
            sqlCommandString = prepareInsertCommandString(tableName, data);
            fillCommandWithData(data, "");
            executeNonQuery();
        }
        public void update(string tableName, SortedDictionary<string, string> conditions, SortedDictionary<string, string> valuesToSet)
        {
            sqlCommandString = prepareUpdateCommandString(tableName, conditions.Keys.ToList(), valuesToSet.Keys.ToList());
            prepareSqlUpdateCommand(conditions, valuesToSet);
            executeNonQuery();
        }
        public void delete(string tableName, SortedDictionary<string, string> conditions)
        {
            sqlCommandString = prepareDeleteCommandString(tableName, conditions.Keys.ToList());
            fillCommandWithData(conditions, "");
            executeNonQuery();
        }
        
        private string prepareInsertCommandString(string tableName, SortedDictionary<string, string> data)
        {
            StringBuilder commandBuilder = new StringBuilder();
            commandBuilder.Append("INSERT INTO " + tableName + "(");
            commandBuilder.Append(CommandStringBuildingHelper.buildInsertIntoPattern(data.Keys.ToList()));
            commandBuilder.Append(")");
            commandBuilder.Append(" VALUES( ");
            commandBuilder.Append(CommandStringBuildingHelper.buildInsertValuesPattern(data.Keys.ToList()));
            commandBuilder.Append(")");

            return commandBuilder.ToString();
        }
        private string prepareUpdateCommandString(string tableName, List<string> conditions, List<string> attributesToUpdate)
        {
            StringBuilder updateStringBuilder = new StringBuilder();
            updateStringBuilder.Append("UPDATE " + tableName);
            
            updateStringBuilder.Append(" SET ");
            string setClause = CommandStringBuildingHelper.buildUpdatePattern(", ", attributesToUpdate, true, 'u') ;
            updateStringBuilder.Append(setClause);

            updateStringBuilder.Append(" WHERE ");
            string whereClause = CommandStringBuildingHelper.buildUpdatePattern("AND", conditions, true, 's');
            updateStringBuilder.Append(whereClause);

            return updateStringBuilder.ToString();
        }
        private string prepareDeleteCommandString(string tableName, List<string> conditions)
        {
            StringBuilder deleteStringBuilder = new StringBuilder();
            deleteStringBuilder.Append("DELETE FROM " + tableName);
            deleteStringBuilder.Append(" WHERE ");
            deleteStringBuilder.Append(CommandStringBuildingHelper.buildEqualsPattern("AND", conditions, true));

            return deleteStringBuilder.ToString();
        }

        private void fillCommandWithData(SortedDictionary<string, string> data, string identyfingPrefix)
        {
            foreach (var dataEntry in data)
            {
                sqlCommand.Parameters.AddWithValue("@" + identyfingPrefix + dataEntry.Key, dataEntry.Value);
            }
        }
        private void prepareSqlUpdateCommand(SortedDictionary<string, string> conditions, SortedDictionary<string, string> valuesToSet)
        {
            fillCommandWithData(conditions, "s");
            fillCommandWithData(valuesToSet, "u");
        }
        
    }
}

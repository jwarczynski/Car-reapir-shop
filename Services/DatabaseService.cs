﻿using MySqlConnector;
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
    internal class DatabaseService : IDisposable
    {
        public const string TABLE_PARTS = "parts";

        private readonly MySqlConnection mySqlConnection;
        private const string connectionString = "server=localhost;user=root;database=warsztat;port=3306;password=password";
        private static DatabaseService? service = null;

        public DatabaseService()
        {
            // Create and open the connection
            mySqlConnection = new MySqlConnection(connectionString);
            mySqlConnection.Open();
        }

        public void Dispose()
        {
            // Close the connection when the application is shutting down
            mySqlConnection.Close();
        }

        /// <summary>
        /// Returns the DatabaseService object that holds the database connection.
        /// </summary>
        public static DatabaseService Get()
        {
            service ??= new DatabaseService();
            return service;
        }

        public List<List<string?>> Select(string tableName, SortedDictionary<string, string>? conditions = null)
        {
            string sqlCommandString = prepareSelectCommandString(tableName, conditions?.Keys.ToList());
            var sqlCommand = new MySqlCommand(sqlCommandString, mySqlConnection);

            if (conditions != null)
                fillCommandWithData(sqlCommand, conditions);
            sqlCommand.Prepare();

            using var reader = sqlCommand.ExecuteReader();
            List<List<string?>> rows = new();

            while (reader.Read()) { 
                var row = new List<string?>();
                for(int i = 0; i < reader.FieldCount; i++)
                {
                    row.Add(reader.GetValue(i).ToString());
                }
                rows.Add(row);
            }

            return rows;
        }
        
        public DataTable selectAllToTable(string tableName, List<string> attributesNames)
        {
            DataTable dataTable = new DataTable();
            foreach(var attributeName in attributesNames)
            {
                dataTable.Columns.Add(attributeName, typeof(string));
            }

            string[]? row = new string[attributesNames.Count];
            List<List<string?>> rows = Get().Select(tableName);

            foreach(var dataRow in rows)
            {
                for(int i = 0;i< dataRow.Count; ++i)
                {
                    row[i] = dataRow.ElementAt(i);
                }
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

        public void insert(string tableName, SortedDictionary<string, string> data)
        {
            string sqlCommandString = prepareInsertCommandString(tableName, data);
            var sqlCommand = new MySqlCommand(sqlCommandString, mySqlConnection);
            fillCommandWithData(sqlCommand, data);
            sqlCommand.ExecuteNonQuery();
        }

        public void update(string tableName, SortedDictionary<string, string> conditions, SortedDictionary<string, string> valuesToSet)
        {
            string sqlCommandString = prepareUpdateCommandString(tableName, conditions.Keys.ToList(), valuesToSet.Keys.ToList());
            var sqlCommand = new MySqlCommand(sqlCommandString, mySqlConnection);
            prepareSqlUpdateCommand(sqlCommand, conditions, valuesToSet);
            sqlCommand.ExecuteNonQuery();
        }

        public void delete(string tableName, SortedDictionary<string, string> conditions)
        {
            string sqlCommandString = prepareDeleteCommandString(tableName, conditions.Keys.ToList());
            var sqlCommand = new MySqlCommand(sqlCommandString, mySqlConnection);
            fillCommandWithData(sqlCommand, conditions);
            sqlCommand.ExecuteNonQuery();
        }
        
        private string prepareSelectCommandString(string tableName, List<string>? conditions)
        {
            StringBuilder selectStringBuilder = new StringBuilder();
            selectStringBuilder.Append($"SELECT * FROM `{tableName}`");

            if(conditions != null && conditions.Count > 0)
            {
                selectStringBuilder.Append(" WHERE ");
                string whereClause = CommandStringBuildingHelper.buildUpdatePattern("AND", conditions, true, "");
                selectStringBuilder.Append(whereClause);
            }

            return selectStringBuilder.ToString();
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
            string setClause = CommandStringBuildingHelper.buildUpdatePattern(", ", attributesToUpdate, true, "u") ;
            updateStringBuilder.Append(setClause);

            updateStringBuilder.Append(" WHERE ");
            string whereClause = CommandStringBuildingHelper.buildUpdatePattern("AND", conditions, true, "s");
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

        private void fillCommandWithData(MySqlCommand sqlCommand, SortedDictionary<string, string> data, string identyfingPrefix = "")
        {
            sqlCommand ??= new MySqlCommand() { Connection = mySqlConnection };

            foreach (var dataEntry in data)
            {
                sqlCommand.Parameters.AddWithValue("@" + identyfingPrefix + dataEntry.Key, dataEntry.Value);
            }
        }

        private void prepareSqlUpdateCommand(MySqlCommand sqlCommand, SortedDictionary<string, string> conditions, SortedDictionary<string, string> valuesToSet)
        {
            fillCommandWithData(sqlCommand, conditions, "s");
            fillCommandWithData(sqlCommand, valuesToSet, "u");
        }
    }
}

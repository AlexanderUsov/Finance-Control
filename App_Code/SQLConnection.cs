using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Web.Script.Serialization;

/// <summary>
/// Summary description for SQLConnection
/// </summary>

public class Table_Template
{
    public long ID { get; set; }
    public string Nvarchar { get; set; }
    public DateTime Date { get; set; }
    public decimal Decimal { get; set; }
    public bool Boolean { get; set; }
    public int Int { get; set; }
    public DateTime DateTime { get; set; }

}


public class SQLConnection
{

    private string ConnectionString = "";    
    private OleDbConnection connection = new OleDbConnection();

    public SQLConnection()
    {
        ConnectionString = @"Provider=SQLOLEDB;Data Source=DESKTOP-GCP2KJS\NAVDEMO;database=FINCONTROL;User ID=ua;Password=goodluck;";
        //OleDbConnection connection = new OleDbConnection(ConnectionString);
        
        try
         {
          connection.ConnectionString = ConnectionString;
          connection.Open();
         }
        catch (Exception)
         {
         }
    }

    public void RUNSqlString(string InsertSQL)
    {
            OleDbCommand command = new OleDbCommand(InsertSQL);
            command.Connection = connection;

            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
   }


    public string RUN_Sql_Command_With_Recordset_as_Result(string InsertSQL)
    {
        var serializedResult = "";
        var TableTemplate = new List<Table_Template>();
        OleDbCommand command = new OleDbCommand(InsertSQL);        
        command.Connection = connection;
        try
        {
            OleDbDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    TableTemplate.Add(new Table_Template()
                    {
                        ID = reader.GetInt32(0),
                        Nvarchar = reader.GetString(1),
                        //Date = reader.GetDateTime(2),
                        Decimal = reader.GetDecimal(3),
                        Boolean = reader.GetBoolean(4),
                        Int = reader.GetInt32(5),
                        DateTime = reader.GetDateTime(6)
                    });
                    //string ID = reader.GetValue(0).ToString();
                    //string Nvarchar = reader.GetString(1);
                    //[Date]
                    //[Decimal]
                    //[Boolean]
                    //[Int]
                    //[DateTime]                    
                }
            }
            else
            {
                
            }
            reader.Close();
            
        }
        catch (Exception exc)
        {
            Console.WriteLine(exc);
        }

        var serializer = new JavaScriptSerializer();
        serializedResult = serializer.Serialize(TableTemplate);
        return serializedResult;
    }
       
}
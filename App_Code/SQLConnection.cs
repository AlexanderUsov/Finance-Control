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
    public string Date { get; set; }
    public decimal Decimal { get; set; }
    public bool Boolean { get; set; }
    public int Int { get; set; }
    public string DateTime { get; set; }

}

public class WebService_Error
{
    public int Result { get; set; }
    public string SQL_Error_Message { get; set; }
    public string SQL_Error_Procedure { get; set; }
    public string SQL_Error_Line { get; set; }
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

    public void SQLConnection_close()
    {
        connection.Close();
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


    public string RUN_Sql_Table_Template_View(string InsertSQL)
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
                    DateTime date1 = new DateTime();
                    DateTime date3 = new DateTime();
                    DateTime.TryParse(reader.GetString(2), out date1);
                    DateTime date2 = new DateTime(date1.Year, date1.Month, date1.Day);
                    date3 = reader.GetDateTime(6);
                    TableTemplate.Add(new Table_Template()
                    {
                        ID = reader.GetInt32(0),
                        Nvarchar = reader.GetString(1),
                        Date = date2.ToString("yyyyMMdd"),
                        Decimal = reader.GetDecimal(3),
                        Boolean = reader.GetBoolean(4),
                        Int = reader.GetInt32(5),
                        DateTime = date3.ToString("yyyyMMddHHmmss")
                    });

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


    public string RUN_Sql_Table_Template_Add(string InsertSQL, string jsonnewrow)
    {
        int ibool;
        long iDec;
        decimal jDec;
        string strDateTime;
        //var serializedResult = "";
        var ErrorTable = new List<WebService_Error>();

        var TableTemplate = new List<Table_Template>();
        var serializer = new JavaScriptSerializer();
        var deserializedResult = serializer.Deserialize<List<Table_Template>>(jsonnewrow);

        
        jDec = deserializedResult[0].Decimal * 100;
        iDec = Convert.ToInt64(jDec);
       

        if (deserializedResult[0].Boolean == true)
        {
            ibool = 1;
        }
        else
        {
            ibool = 0;
        }

        strDateTime = deserializedResult[0].DateTime.ToString().Substring(0, 8)+ " " + deserializedResult[0].DateTime.ToString().Substring(8,2) + ":" + deserializedResult[0].DateTime.ToString().Substring(10, 2) + ":" + deserializedResult[0].DateTime.ToString().Substring(12, 2);
        InsertSQL = InsertSQL + " '" + deserializedResult[0].Nvarchar.ToString() + "','" + deserializedResult[0].Date.ToString() + "'," + iDec.ToString() + "," + ibool.ToString() + "," + deserializedResult[0].Int.ToString() + ",'" + strDateTime + "'"; 

        
        OleDbCommand command = new OleDbCommand(InsertSQL);
        command.Connection = connection;
        try
        {
            OleDbDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                ErrorTable.Add(new WebService_Error()
                {
                    Result = reader.GetInt32(0),
                    SQL_Error_Message = reader.GetString(1),
                    SQL_Error_Procedure = reader.GetString(2),
                    SQL_Error_Line = reader.GetString(3)                 
                });

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
        
        var serializedResult = serializer.Serialize(ErrorTable);
        return serializedResult;
    }

}
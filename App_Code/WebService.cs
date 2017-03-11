using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{

    public WebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    private string HelloWorld()
    {
        return "Hello World";
    }

    [WebMethod]
    private string SQLConnect(string SQLString = "")
    {
        SQLString = SQLString.Trim(); 
        int StrLen = SQLString.Length;
        SQLConnection SQLCon = new SQLConnection();
        if (SQLString == "" || StrLen == 0)
            SQLString = "insert Test1(Text) values('default')";

        SQLCon.RUNSqlString(SQLString);
           
        return SQLString+StrLen.ToString();    
    }

    // Some examples with Table_Template:
    // Table_Template_View() - return json with Table_Template rows
    // Table_Template_Add(json) - add new row with fields in json
    // Table_Template_Delete(ID) - delete row with Primary Key = ID
    // Table_Template_Edit(ID,json) - update row with Primary Key = ID

    [WebMethod]
    public string Table_Template_View()
    {        
        string SQLString = "sp_Table_Template_View";       
        SQLConnection SQLCon = new SQLConnection();
        var json = SQLCon.RUN_Sql_Table_Template_View(SQLString);
        SQLCon.SQLConnection_close();
        return json;
    }


    [WebMethod]
    public string Table_Template_Add(string json)
    {
        string SQLString = "sp_Table_Template_Add";
        SQLConnection SQLCon = new SQLConnection();
        var jsonresult = SQLCon.RUN_Sql_Table_Template_Add(SQLString,json);
        SQLCon.SQLConnection_close();
        return jsonresult;
    }

}

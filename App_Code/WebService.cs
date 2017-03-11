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



    [WebMethod]
    public string Table_Template_View()
    {
        
        string SQLString = "sp_Table_Template_View";       
        SQLConnection SQLCon = new SQLConnection();
        var json = SQLCon.RUN_Sql_Table_Template_View(SQLString);

        return json;
    }


}

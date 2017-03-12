using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
//ok my friends kkk
public partial class WebServiceHTMLTest : System.Web.UI.Page  
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        ServiceReference1.WebServiceSoapClient WS = new ServiceReference1.WebServiceSoapClient();        
        var serializedResult = WS.Table_Template_View();
        var TableTemplate = new List<Table_Template>();
        var serializer = new JavaScriptSerializer();
        var deserializedResult = serializer.Deserialize<List<Table_Template>>(serializedResult);
        if (deserializedResult.Count > 0)
        {
            DateTime date1 = new DateTime(Int32.Parse(deserializedResult[0].Date.Substring(0, 4)), Int32.Parse(deserializedResult[0].Date.Substring(4, 2)), Int32.Parse(deserializedResult[0].Date.Substring(6, 2)));
            DateTime date2 = new DateTime(Int32.Parse(deserializedResult[0].DateTime.Substring(0, 4)), Int32.Parse(deserializedResult[0].DateTime.Substring(4, 2)), Int32.Parse(deserializedResult[0].DateTime.Substring(6, 2)),
                                          Int32.Parse(deserializedResult[0].DateTime.Substring(8, 2)), Int32.Parse(deserializedResult[0].DateTime.Substring(10, 2)), Int32.Parse(deserializedResult[0].DateTime.Substring(12, 2)));
            Label5.Text = deserializedResult[0].ID.ToString() + " - " + deserializedResult[0].Nvarchar.ToString() + " - " + date1.ToString()
                + " - " + deserializedResult[0].Decimal.ToString() + " - " + deserializedResult[0].Boolean.ToString() + " - " + deserializedResult[0].Int.ToString()
                + " - " + date2.ToString();
        }
        else
        {
            Label5.Text = "Пустая таблица";
        }


    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        ServiceReference1.WebServiceSoapClient WS = new ServiceReference1.WebServiceSoapClient();
        var TableTemplate = new List<Table_Template>();
        var serializer = new JavaScriptSerializer();       
        TableTemplate.Add(new Table_Template()
        {
            Nvarchar = "Следующий элемент",
            Date = "20180101",
            Decimal = 44.19m,
            Boolean = true,
            Int = 87,
            DateTime = "20180401002043"
        });
        var serializedtable = serializer.Serialize(TableTemplate);        
        var serializedserviceresult = WS.Table_Template_Add(serializedtable);
        var deserializedResult = serializer.Deserialize<List<WebService_Error>>(serializedserviceresult);

        if (deserializedResult[0].Result == 1)
        {
            Label4.Text = "Добавлено успешно. ID новой строки = " + deserializedResult[0].ID.ToString();
                }
        else
        {
           Label4.Text = "Возникли ошибки:" + deserializedResult[0].SQL_Error_Message + " / процедура SQL - " + deserializedResult[0].SQL_Error_Procedure + " / строка - " + deserializedResult[0].SQL_Error_Line + " / "; 
        }


    }


    protected void Button3_Click(object sender, EventArgs e)
    {
        long ID = 5;
        ServiceReference1.WebServiceSoapClient WS = new ServiceReference1.WebServiceSoapClient();
        var TableTemplate = new List<Table_Template>();
        var serializer = new JavaScriptSerializer();
        TableTemplate.Add(new Table_Template()
        {
            Nvarchar = "Следующий обновленный элемент",
            Date = "20190101",
            Decimal = 0.19m,
            Boolean = false,
            Int = 79,
            DateTime = "20190401002043"
        });
        var serializedtable = serializer.Serialize(TableTemplate);
        var serializedserviceresult = WS.Table_Template_Edit(serializedtable,ID);
        var deserializedResult = serializer.Deserialize<List<WebService_Error>>(serializedserviceresult);

        if (deserializedResult[0].Result == 1)
        {
            Label8.Text = "Обновлено успешно";
        }
        else
        {
            Label8.Text = "Возникли ошибки:" + deserializedResult[0].SQL_Error_Message + " / процедура SQL - " + deserializedResult[0].SQL_Error_Procedure + " / строка - " + deserializedResult[0].SQL_Error_Line + " / ";
        }

    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        long ID = 10;
        ServiceReference1.WebServiceSoapClient WS = new ServiceReference1.WebServiceSoapClient();
        var serializer = new JavaScriptSerializer();        
        var serializedserviceresult = WS.Table_Template_Delete(ID);
        var deserializedResult = serializer.Deserialize<List<WebService_Error>>(serializedserviceresult);

        if (deserializedResult[0].Result == 1)
        {
            Label10.Text = "Удалено успешно";
        }
        else
        {
            Label10.Text = "Возникли ошибки:" + deserializedResult[0].SQL_Error_Message + " / процедура SQL - " + deserializedResult[0].SQL_Error_Procedure + " / строка - " + deserializedResult[0].SQL_Error_Line + " / ";
        } 
    }
}
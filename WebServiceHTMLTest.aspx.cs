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
        DateTime date1 = new DateTime(Int32.Parse(deserializedResult[0].Date.Substring(0,4)), Int32.Parse(deserializedResult[0].Date.Substring(4, 2)),Int32.Parse(deserializedResult[0].Date.Substring(6, 2)));
        DateTime date2 = new DateTime(Int32.Parse(deserializedResult[0].DateTime.Substring(0, 4)), Int32.Parse(deserializedResult[0].DateTime.Substring(4, 2)), Int32.Parse(deserializedResult[0].DateTime.Substring(6, 2)),
                                      Int32.Parse(deserializedResult[0].DateTime.Substring(8, 2)), Int32.Parse(deserializedResult[0].DateTime.Substring(10, 2)), Int32.Parse(deserializedResult[0].DateTime.Substring(12, 2)));
        Label1.Text = deserializedResult[0].ID.ToString() + " - " + deserializedResult[0].Nvarchar.ToString() + " - " + date1.ToString()
            + " - " + deserializedResult[0].Decimal.ToString() + " - " + deserializedResult[0].Boolean.ToString() + " - " + deserializedResult[0].Int.ToString()    
            + " - " + date2.ToString();
        //Label1.Text = deserializedResult[2].DateTime.ToString();
    }
}
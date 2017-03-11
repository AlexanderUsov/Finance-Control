using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
//ok
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
        Label1.Text = deserializedResult[2].Nvarchar;
        //Label1.Text = deserializedResult[2].DateTime.ToString();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Text = "";
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        SQLConnection SQLCon = new SQLConnection();
        SQLCon.RUNSqlString("insert Test1(Text) values('1')");
        Label1.Text = TextBox1.Text;
    }

    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        DateTime DT;
        
        DT = Calendar1.SelectedDate;
        Label1.Text = DT.ToString("d");
        
    }

    protected void TextBox3_TextChanged(object sender, EventArgs e)
    {

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        ServiceReference1.WebServiceSoapClient WS = new ServiceReference1.WebServiceSoapClient();
        //Label2.Text = WS.Calc(System.Convert.ToDouble(TextBox2.Text), System.Convert.ToDouble(TextBox3.Text)).ToString();
        
    }
}
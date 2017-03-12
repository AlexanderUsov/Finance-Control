<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WebServiceHTMLTest.aspx.cs" Inherits="WebServiceHTMLTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        &nbsp;<asp:Label ID="Label2" runat="server" Text="1. Чтение Table_Template_View"></asp:Label>
    
        <br />
    
        <br />
    
    </div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Старт" />
        <br />
        <br />
        <asp:Label ID="Label5" runat="server" Text="Результат появится тут"></asp:Label>
        <br />
        <p>
            <asp:Label ID="Label3" runat="server" Text="2. Добавление записи Table_Template_Add"></asp:Label>
        </p>
        <asp:Button ID="Button2" runat="server" Text="Старт" OnClick="Button2_Click" />
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Результат появится тут"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label7" runat="server" Text="3. Обновление записи Table_Template_Edit"></asp:Label>
        <br />
        <br />
        <asp:Button ID="Button3" runat="server" Text="Старт" OnClick="Button3_Click" />
        <br />
        <br />
        <asp:Label ID="Label8" runat="server" Text="Результат появится тут"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label9" runat="server" Text="4. Удаление записи Table_Template_Delete"></asp:Label>
        <br />
        <br />
        <asp:Button ID="Button4" runat="server" Text="Старт" OnClick="Button4_Click" />
        <br />
        <br />
        <asp:Label ID="Label10" runat="server" Text="Результат появится тут"></asp:Label>

    </form>
</body>
</html>

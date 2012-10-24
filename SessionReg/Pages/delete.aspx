<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="delete.aspx.cs" Inherits="SessionReg.Pages.Delete" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form runat="server">
    <div>
    
    </div>
        <asp:Button runat="server" Text="<-Back to Main" 
        onclick="Button2_Click" />
        <br /><br />
        <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>
        <br />
        <asp:Button runat="server" Text="Delete" 
        onclick="Button1_Click" />
    </form>
</body>
</html>

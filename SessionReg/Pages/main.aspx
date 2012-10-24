<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="SessionReg.Pages.Main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form runat="server">
    <div>
        <asp:Button runat="server" Text="Create" PostBackUrl="~/Pages/form1.aspx" />
        <asp:Button runat="server" Text="Delete" PostBackUrl="~/Pages/delete.aspx" />
        <asp:Button runat="server" Text="Update" PostBackUrl="~/Pages/update.aspx" />
        <asp:Button runat="server" Text="Client list" PostBackUrl="~/Pages/results.aspx" />
        <asp:Button runat="server" Text="Commit all" OnClick="CommitButtonClick"/>
    </div>
    </form>
</body>
</html>

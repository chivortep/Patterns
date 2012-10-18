<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="form1.aspx.cs" Inherits="SessionReg.form1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="NameLabel" runat="server" Text="Введите Ваше имя:"></asp:Label>
        <asp:TextBox ID="NameTextBox1" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ControlToValidate="NameTextBox1" ID="RequiredFieldValidator1" 
                                    runat="server" ErrorMessage="Поле 'Имя' не может быть пустым">*</asp:RequiredFieldValidator>
        <br /><br />
        <asp:Button ID="Button1" runat="server" Text="Далее" onclick="Button1_Click"/>
    </div>
    </form>
</body>
</html>

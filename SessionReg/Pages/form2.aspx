<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="form2.aspx.cs" Inherits="SessionReg.Pages.Form2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form runat="server">
    <div>
        <asp:Label runat="server" Text="Введите Вашу фамилию:"></asp:Label>
        <asp:TextBox ID="SurnameTextBox1" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ControlToValidate="SurnameTextBox1" runat="server" ErrorMessage="Поле 'Фамилия' не может быть пустым">*</asp:RequiredFieldValidator>
        <br /><br />
        <asp:Button runat="server" Text="Далее" onclick="Button1_Click" />
    </div>
    </form>
</body>
</html>

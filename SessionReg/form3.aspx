<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="form3.aspx.cs" Inherits="SessionReg.form3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="AgeLabel" runat="server" Text="Введите Ваш возраст:"></asp:Label>
        <asp:TextBox ID="AgeTextBox1" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ControlToValidate="AgeTextBox1" ID="RequiredFieldValidator1" 
                                    runat="server" ErrorMessage="Поле 'Возраст' не может быть пустым">*</asp:RequiredFieldValidator>
        <asp:RangeValidator ID="RangeValidator1" ControlToValidate="AgeTextBox1" runat="server"
                            ErrorMessage="Введите возраст (1-99 лет)" Type="Integer" MinimumValue="1" MaximumValue="99"></asp:RangeValidator>
        <br /><br />
        <asp:Button ID="Button1" runat="server" Text="Далее" onclick="Button1_Click" />
    </div>
    </form>
</body>
</html>

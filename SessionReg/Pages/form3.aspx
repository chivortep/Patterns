<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="form3.aspx.cs" Inherits="SessionReg.Pages.Form3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form runat="server">
    <div>
        <asp:Label runat="server" Text="Введите Ваш возраст:"></asp:Label>
        <asp:TextBox ID="AgeTextBox1" x:FieldModifier="private" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ControlToValidate="AgeTextBox1" runat="server" ErrorMessage="Поле 'Возраст' не может быть пустым">*</asp:RequiredFieldValidator>
        <asp:RangeValidator ControlToValidate="AgeTextBox1" runat="server"
                            ErrorMessage="Введите возраст (1-99 лет)" Type="Integer" MinimumValue="1" MaximumValue="99"></asp:RangeValidator>
        <br /><br />
        <asp:Button runat="server" Text="Далее" onclick="Button1_Click" />
    </div>
    </form>
</body>
</html>

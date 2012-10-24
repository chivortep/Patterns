<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="update.aspx.cs" Inherits="SessionReg.Pages.Update" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form runat="server">
    <div>
        <asp:Button runat="server" Text="<-Back to Main" 
            onclick="Button2_Click" />
        <br /><br />
        <asp:ListBox ID="ListBox1" runat="server" OnSelectedIndexChanged="List_SelectedChanged" AutoPostBack="true"></asp:ListBox>
        <asp:Table runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="Name: "></asp:Label>
                    <asp:TextBox ID="nameTextbox" runat="server">
                    </asp:TextBox>
                    <asp:RequiredFieldValidator runat="server"
                        ControlToValidate="nameTextbox" ErrorMessage="Value needed!">*</asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="Surname: "></asp:Label>
                    <asp:TextBox ID="surnameTextbox" runat="server">
                    </asp:TextBox>
                    <asp:RequiredFieldValidator runat="server"
                        ControlToValidate="surnameTextbox" ErrorMessage="Value needed!">*</asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="Age: "></asp:Label>
                    <asp:TextBox ID="ageTextbox" runat="server">
                    </asp:TextBox>
                    <asp:RequiredFieldValidator runat="server"
                        ControlToValidate="ageTextbox" ErrorMessage="Value needed!">*</asp:RequiredFieldValidator>
                    <asp:RangeValidator runat="server" ErrorMessage="Integer value needed!"
                                         ControlToValidate="ageTextbox" MinimumValue="0" MaximumValue="99" Type="Integer"><b>!</b></asp:RangeValidator>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <br />
        <asp:Button runat="server" Text="Update" onclick="Button1_Click" />    
    </div>
    </form>
</body>
</html>

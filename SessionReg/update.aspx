<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="update.aspx.cs" Inherits="SessionReg.update" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="Button2" runat="server" Text="<-Back to Main" 
            onclick="Button2_Click" />
        <br /><br />
        <asp:ListBox ID="ListBox1" runat="server" OnSelectedIndexChanged="list_SelectedChanged" AutoPostBack="true"></asp:ListBox>
        <asp:Table ID="Table1" runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="Name: "></asp:Label>
                    <asp:TextBox ID="nameTextbox" runat="server">
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                        ControlToValidate="nameTextbox" ErrorMessage="Value needed!">*</asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label1" runat="server" Text="Surname: "></asp:Label>
                    <asp:TextBox ID="surnameTextbox" runat="server">
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                        ControlToValidate="surnameTextbox" ErrorMessage="Value needed!">*</asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label2" runat="server" Text="Age: "></asp:Label>
                    <asp:TextBox ID="ageTextbox" runat="server">
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                        ControlToValidate="ageTextbox" ErrorMessage="Value needed!">*</asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Integer value needed!"
                                         ControlToValidate="ageTextbox" MinimumValue="0" MaximumValue="99" Type="Integer"><b>!</b></asp:RangeValidator>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Update" onclick="Button1_Click" />    
    </div>
    </form>
</body>
</html>

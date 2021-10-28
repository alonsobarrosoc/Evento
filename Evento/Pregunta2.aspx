<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pregunta2.aspx.cs" Inherits="Evento.Pregunta2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <br />
            Pregunta 2<br />
            <br />
            Reposte de conferencias<br />
            <br />
            <br />
&nbsp;&nbsp;&nbsp; Seleccione un usuario&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="DropDownList1" runat="server" >
            </asp:DropDownList>
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Generar Reporte" />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>

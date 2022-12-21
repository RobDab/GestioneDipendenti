<%@ Page Title="" Language="C#"  MasterPageFile="~/Page.Master" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="GestioneDipendenti.Payment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2 class="fs-3">Nuovo Versamento verso: <asp:Label ID="EmpNameLabel" runat="server" Text=""></asp:Label></h2>
        <div class="border-bottom border-1 my-4"></div>
        <div>
            <p class="d-inline me-3">Mensilità: </p>
            <asp:DropDownList ID="MeseRifDDL" runat="server">

                <asp:ListItem Value="1" Text="GEN"></asp:ListItem>
                <asp:ListItem Value="2" Text="FEB"></asp:ListItem>
                <asp:ListItem Value="3" Text="MAR"></asp:ListItem>
                <asp:ListItem Value="4" Text="APR"></asp:ListItem>
                <asp:ListItem Value="5" Text="MAG"></asp:ListItem>
                <asp:ListItem Value="6" Text="GIU"></asp:ListItem>
                <asp:ListItem Value="7" Text="LUG"></asp:ListItem>
                <asp:ListItem Value="8" Text="AGO"></asp:ListItem>
                <asp:ListItem Value="9" Text="SET"></asp:ListItem>
                <asp:ListItem Value="10" Text="OTT"></asp:ListItem>
                <asp:ListItem Value="11" Text="NOV"></asp:ListItem>
                <asp:ListItem Value="12" Text="DIC"></asp:ListItem>

            </asp:DropDownList>
            <div>
                <asp:Label ID="Label1" runat="server" Text="Data Versamento"></asp:Label>
<%--                <asp:Calendar ID="Calendar" runat="server"></asp:Calendar>--%>
                <input type="date" id="Calendar" runat="server" />
            </div>
            <div>
                <asp:CheckBox ID="AccontoCB" runat="server" Text="Acconto" />
            </div
            <div>
                <asp:Label ID="Label2" runat="server" Text="Da versare:"></asp:Label>
                <asp:TextBox ID="AmountInput" runat="server" Placeholder="€ -.-"></asp:TextBox>
            </div>
            <asp:Button ID="PaymentBtn" runat="server" Text="Procedi al Versamento" OnClick="PaymentBtn_Click"/>
        </div>
        <div class="d-none" id="Confirm" runat="server">
            <asp:Label ID="ConfirmLbl" runat="server" Text="Controlla i dettagli"></asp:Label>
            <asp:Button ID="ConfirmBtn" runat="server" Text="Effettua Versamento" CssClass="btn btn-warning" OnClick="ConfirmBtn_Click"/>
        </div>
        <asp:Label ID="ExLbl" runat="server" Visible="false" Text=""></asp:Label>
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Page.Master" AutoEventWireup="true" CodeBehind="AllEmployees.aspx.cs" Inherits="GestioneDipendenti.AllEmployees" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="d-flex justify-content-between">
        <h2 class="mt-5 d-inline fs-4">Tutti i Dipendenti</h2>
            <asp:LinkButton ID="AddBtn" CssClass="btn btn-success rounded-circle " Style="height: 50px; width: 50px; font-size: 1.5rem; padding:0.3rem, 0, 0, 0.9rem;" OnClick="AddBtn_Click" runat="server"><i class="bi bi-person-plus-fill"></i></asp:LinkButton>
         </div>
        <br />
        <asp:GridView ID="GridView1" CssClass="w-100 bg-dark text-light border-0 rounded-3 ps-3" runat="server" AutoGenerateColumns="False" ItemType="GestioneDipendenti.Classes.Employee" >
            <Columns>

              <asp:TemplateField HeaderText="Nome">
                  <ItemTemplate>
                      <asp:Label ID="Nome" runat="server" Text="<%# Item.Nome %>"></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>

                <asp:TemplateField HeaderText="Cognome">
                  <ItemTemplate>
                      <asp:Label ID="Cognome" runat="server" Text="<%# Item.Cognome %>"></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>

                <asp:TemplateField HeaderText="Indirizzo">
                  <ItemTemplate>
                      <asp:Label ID="Indirizzo" runat="server" Text="<%# Item.Indirizzo %>"></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>

                <asp:TemplateField HeaderText="Codice F.">
                  <ItemTemplate>
                      <asp:Label ID="CF" runat="server" Text="<%# Item.CF %>"></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>

                <asp:TemplateField HeaderText="Coniugato">
                  <ItemTemplate>
                      <asp:CheckBox ID="ConiugatoCB" Checked="<%# Item.Coniugato %>" runat="server" Enabled="false" />
                  </ItemTemplate>
              </asp:TemplateField>

                <asp:TemplateField HeaderText="Figli A Carico">
                  <ItemTemplate>
                      <asp:Label ID="Figli" runat="server" Text="<%# Item.FigliACarico %>"></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>

                <asp:TemplateField HeaderText="Mansione">
                  <ItemTemplate>
                      <asp:Label ID="Job" runat="server" Text="<%# Item.Mansione %>"></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>

                <asp:TemplateField HeaderText="Spettanti">
                  <ItemTemplate>
                      <asp:Label ID="Credito" runat="server" Text="<%# Item.Credito %>"></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>

                <asp:TemplateField HeaderText="Livello">
                  <ItemTemplate>
                      <asp:Label ID="Level" runat="server" Text="<%# Item.JobLevel %>"></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>

                <asp:TemplateField>
                  <ItemTemplate>
                      <asp:Button ID="PayBtn" runat="server" OnClick="PayBtn_Click" Text="Paga Ora" CommandArgument="<%# Item.Id %>" CssClass="btn btn-warning m-3 text-dark rounded-pill"/>
                  </ItemTemplate>
              </asp:TemplateField>


            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

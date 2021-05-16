<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="AdicionarContatos.aspx.cs" Inherits="TrabalhoPOO_ASPNET.AdicionarContatos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="pnlListaContatos">
        <div class="mdc-data-table">
            <div class="mdc-data-table__table-container">
                <asp:GridView ID="gdvContatos" runat="server" CssClass="mdc-data-table__table" EmptyDataText="Contatos não encontrados." EmptyDataRowStyle-HorizontalAlign="Center"
                        DataKeyNames="id" AutoGenerateColumns="false" EnableModelValidation="true" GridLines="None" Visible="true" HeaderStyle-CssClass="mdc-data-table__header-row" RowStyle-CssClass="mdc-data-table__row">
                    
                    <Columns>
                        <asp:BoundField DataField="nome" HeaderText="Nome" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="mdc-data-table__header-cell" ItemStyle-CssClass="mdc-data-table__cell">
                            <HeaderStyle Width="15%"/>
                        </asp:BoundField>

                        <asp:BoundField DataField="telefone" HeaderText="Telefone" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="mdc-data-table__header-cell" ItemStyle-CssClass="mdc-data-table__cell" >
                             <HeaderStyle Width="25%"/>
                        </asp:BoundField>

                        <asp:BoundField DataField="celular" HeaderText="Celular" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="mdc-data-table__header-cell" ItemStyle-CssClass="mdc-data-table__cell">
                             <HeaderStyle Width="25%"/>
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </asp:Panel>
</asp:Content>

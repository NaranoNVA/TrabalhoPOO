<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="AdicionarContatos.aspx.cs" Inherits="TrabalhoPOO_ASPNET.AdicionarContatos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="pnlListaContatos">
         <div class="form-row table-responsive mt-1">
                <asp:GridView ID="gdvContatos" runat="server" CssClass="table table-hover" EmptyDataText="Contatos não encontrados." EmptyDataRowStyle-HorizontalAlign="Center"
                        DataKeyNames="id" AutoGenerateColumns="false" EnableModelValidation="true" GridLines="None" Visible="true" HeaderStyle-CssClass="mdc-data-table__header-row" RowStyle-CssClass="mdc-data-table__row">
                    
                    <Columns>
                        <asp:BoundField DataField="nome" HeaderText="Nome" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                            <HeaderStyle Width="15%"/>
                        </asp:BoundField>

                        <asp:BoundField DataField="telefone" HeaderText="Telefone" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="" ItemStyle-CssClass="" >
                             <HeaderStyle Width="25%"/>
                        </asp:BoundField>

                        <asp:BoundField DataField="celular" HeaderText="Celular" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                             <HeaderStyle Width="25%"/>
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
        </div>
    </asp:Panel>
</asp:Content>

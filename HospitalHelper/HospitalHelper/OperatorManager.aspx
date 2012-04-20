<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Menu.Master" 
CodeBehind="OperatorManager.aspx.cs" Inherits="HospitalHelper.OperatorManager" %>

 <asp:Content ID="Content1" ContentPlaceHolderID ="ContentPlaceHolder1" runat="server">
        
       
    <form id="form1" runat="server">

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataSourceID="SqlDataSource1" AllowPaging="True" 
        onselectedindexchanged="GridView1_SelectedIndexChanged" PageIndex="1">
        <Columns>
            <asp:BoundField DataField="HID" HeaderText="用户名" SortExpression="HID" />
            <asp:BoundField DataField="PSW" HeaderText="密码" SortExpression="PSW" />
            <asp:CheckBoxField DataField="LIM" HeaderText="管理员" SortExpression="LIM" />
            <asp:CommandField CancelText="取消" DeleteText="删除" EditText="编辑" HeaderText="更新" 
                InsertText="插入" ShowEditButton="True" UpdateText="更新" />
            <asp:CommandField CancelText="取消" DeleteText="删除" EditText="编辑" HeaderText="删除" 
                ShowDeleteButton="True" />
            <asp:TemplateField HeaderText="插入">
                <ItemTemplate>
                    <asp:DetailsView ID="DetailsView2" runat="server" Height="50px" Width="125px">
                    </asp:DetailsView>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="125px">
            </asp:DetailsView>
        </EmptyDataTemplate>
        <PagerSettings FirstPageText="第一页" LastPageText="最后一页" 
            Mode="NumericFirstLast" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:HospitalData %>" 
        SelectCommand="SELECT * FROM [OPERATOR]"></asp:SqlDataSource>
    <br />

    </form>
</asp:Content>
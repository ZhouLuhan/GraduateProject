<%@ Page Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="FindPatient.aspx.cs" Inherits="HospitalHelper.FindPatient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="PID" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="PID" HeaderText="PID" SortExpression="PID" />
            <asp:HyperLinkField DataNavigateUrlFields="PID" 
                DataNavigateUrlFormatString="NewPatient.aspx?PID={0}" DataTextField="PNAME" 
                HeaderText="PNAME" />
            <asp:BoundField DataField="PBIRTHCITY" HeaderText="PBIRTHCITY" 
                SortExpression="PBIRTHCITY" />
            <asp:BoundField DataField="PBIRTHDISTRICT" HeaderText="PBIRTHDISTRICT" 
                SortExpression="PBIRTHDISTRICT" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:HospitalData %>" 
        SelectCommand="SELECT [PID], [PNAME], [PBIRTHCITY], [PBIRTHDISTRICT] FROM [PATIENT]">
    </asp:SqlDataSource>

</asp:Content>
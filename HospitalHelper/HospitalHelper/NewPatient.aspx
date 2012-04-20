<%@ Page Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="NewPatient.aspx.cs" Inherits="HospitalHelper.NewPatient" %>

<asp:Content ID="Content1" ContentPlaceHolderID ="ContentPlaceHolder1" runat="server">

    <asp:Label ID="Lpname" runat="server" Text="姓名"></asp:Label>

    <asp:TextBox ID="Tpname" runat="server"></asp:TextBox>
    &nbsp;<asp:Label ID="Lpmarriage" runat="server" Text="婚姻状况" ></asp:Label>

    <asp:TextBox ID="Tpmarriage" runat="server" ></asp:TextBox>

    &nbsp;<asp:Label ID="Lpfolk" runat="server" Text="民族"></asp:Label>

    <asp:TextBox ID="Tpfolk" runat="server"></asp:TextBox>

    &nbsp;
    <asp:Label ID="Lpnation" runat="server" Text="国籍"></asp:Label>

    <asp:TextBox ID="Tpnation" runat="server"></asp:TextBox>

    <br />
    <asp:Label ID="Lpbirthday" runat="server" Text="出生日期"></asp:Label>

    <asp:TextBox ID="Tpbirthday" runat="server" Width="73px"></asp:TextBox>

&nbsp;

    <asp:TextBox ID="Tpbirthtime" runat="server" Width="75px"></asp:TextBox>
&nbsp;
    <asp:Label ID="Lold" runat="server" Text="年龄"></asp:Label>

    <asp:TextBox ID="Told" runat="server" Width="81px"></asp:TextBox>
&nbsp;

    <asp:Label ID="Lsex" runat="server" Text="性别"></asp:Label>

    <asp:TextBox ID="Tsex" runat="server" Width="96px"></asp:TextBox>

    &nbsp;
    <asp:Label ID="Lprelige" runat="server" Text="宗教信仰"></asp:Label>

    <asp:TextBox ID="Tprelige" runat="server"></asp:TextBox>

    <br />
    <asp:Label ID="Lpid" runat="server" Text="身份证号"></asp:Label>

    <asp:TextBox ID="Tpid" runat="server"></asp:TextBox>

    &nbsp;
    <asp:Label ID="Lpdgree" runat="server" Text="文化程度"></asp:Label>

    <asp:TextBox ID="Tpdgree" runat="server"></asp:TextBox>

    &nbsp;
    <asp:Label ID="Lpeducation" runat="server" Text="受教育年限"></asp:Label>

    <asp:TextBox ID="Tpeducation" runat="server"></asp:TextBox>

    <br />
    <asp:Label ID="Lpbirthcity" runat="server" Text="出生省市"></asp:Label>

    <asp:TextBox ID="Tpbirthcity" runat="server"></asp:TextBox>

    &nbsp;
    <asp:Label ID="Lpbirthdistrict" runat="server" Text="出生区县"></asp:Label>

    <asp:TextBox ID="Tpbirthdistrict" runat="server"></asp:TextBox>

    <asp:Label ID="Lpnativecity" runat="server" Text="籍贯城市"></asp:Label>

    <asp:TextBox ID="Tpnativecity" runat="server"></asp:TextBox>
&nbsp;<asp:Label ID="Lpnativedistrict" runat="server" Text="籍贯区县"></asp:Label>

    <asp:TextBox ID="Tpnativedistrict" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Lpproperty" runat="server" Text="病人性质"></asp:Label>
    <asp:TextBox ID="Tpproperty" runat="server"></asp:TextBox>
    &nbsp;
    <asp:Label ID="Lpfeetype" runat="server" Text="病人费别"></asp:Label>
    <asp:TextBox ID="Tpfeetype" runat="server"></asp:TextBox>
    <asp:Label ID="Lpcardnum" runat="server" Text="卡号"></asp:Label>
    <asp:TextBox ID="Tpcardnum" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Lpanelunit" runat="server" Text="单位信息"></asp:Label>
    <br />
    <asp:Label ID="Lpjob" runat="server" Text="职业"></asp:Label>
    <asp:TextBox ID="Tpjob" runat="server"></asp:TextBox>
    &nbsp;
    <asp:Label ID="Lpworkunit" runat="server" Text="工作单位"></asp:Label>
    <asp:TextBox ID="Tpworkunit" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Lpworkplace" runat="server" Text="地址"></asp:Label>
    <asp:TextBox ID="Tpworkplace" runat="server"></asp:TextBox>
    &nbsp;
    <asp:Label ID="Lpworktel" runat="server" Text="电话"></asp:Label>
    <asp:TextBox ID="Tpworktel" runat="server"></asp:TextBox>
    <asp:Label ID="Lpworkpost" runat="server" Text="邮编"></asp:Label>
    <asp:TextBox ID="Tpworkpost" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Lplacepanel" runat="server" Text="地址信息"></asp:Label>
    <br />
    <asp:Label ID="Lpresidenceplace" runat="server" Text="户口地址"></asp:Label>
    <asp:TextBox ID="Tpresidenceplace" runat="server"></asp:TextBox>
    &nbsp;
    <asp:Label ID="Lphometel" runat="server" Text="电话"></asp:Label>
    <asp:TextBox ID="Tphometel" runat="server"></asp:TextBox>
    &nbsp;
    <asp:Label ID="Lphomepost" runat="server" Text="邮编"></asp:Label>
    <asp:TextBox ID="Tphomepost" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Lphomeplace" runat="server" Text="当前住址"></asp:Label>
    <asp:TextBox ID="Tphomecity" runat="server"></asp:TextBox>
    <asp:Label ID="Lphomecity" runat="server" Text="(省市）"></asp:Label>
    <asp:TextBox ID="Tphomedistrict" runat="server"></asp:TextBox>
    <asp:Label ID="Lphomedistrict" runat="server" Text="（区县）街道"></asp:Label>
    <asp:TextBox ID="Tphomeplace" runat="server"></asp:TextBox>
    
    
    <br />
    <br />
    <asp:Label ID="Lconinfo" runat="server" Text="联系人信息"></asp:Label>
    
    
    <br />
    <asp:Label ID="Lpconname" runat="server" Text="联系人名"></asp:Label>
    
    
    <asp:TextBox ID="Tpconname" runat="server"></asp:TextBox>
    
    
    &nbsp;
    <asp:Label ID="Lpconrelation" runat="server" Text="关系"></asp:Label>
    
    
    <asp:TextBox ID="Tpconrelation" runat="server"></asp:TextBox>
    
    
    <br />
    <asp:Label ID="Lpconplace" runat="server" Text="地址"></asp:Label>
    
    
    <asp:TextBox ID="Tpconplace" runat="server"></asp:TextBox>
    
    
    &nbsp;
    <asp:Label ID="Lpcontel" runat="server" Text="电话"></asp:Label>
    
    
    <asp:TextBox ID="Tpcontel" runat="server"></asp:TextBox>
    
    
    &nbsp;
    <asp:Label ID="Lpconpost" runat="server" Text="邮编"></asp:Label>
    
    
    <asp:TextBox ID="Tpconpost" runat="server"></asp:TextBox>
    
    
    <br />
    <asp:Label ID="Lpconworkunit" runat="server" Text="单位"></asp:Label>
    
    
    <asp:TextBox ID="Tpconworkunit" runat="server"></asp:TextBox>
    
    
    &nbsp;
    <asp:Label ID="Lphistorypeo" runat="server" Text="病史陈述人"></asp:Label>
    
    
    <asp:TextBox ID="Tphistorypeo" runat="server"></asp:TextBox>
    
    
    <br />
    <br />
    <asp:Label ID="Lpcomment" runat="server" Text="备注"></asp:Label>
    
    
    <asp:TextBox ID="Tpcomment" runat="server"></asp:TextBox>
    
    
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:SqlDataSource 
        ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:HospitalData %>" 
        SelectCommand="SELECT * FROM [PATIENT]"></asp:SqlDataSource>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Bsave" runat="server" Text="保存" onclick="Bsave_Click" />
    
    </asp:Content>

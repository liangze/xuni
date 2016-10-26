<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegSuccess.aspx.cs" Inherits="Web.user.shop.RegSuccess" %>

<%@ Register Src="ShopHead.ascx" TagName="ShopHead" TagPrefix="uc1" %>
<%@ Register Src="shopSlider.ascx" TagName="shopSlider" TagPrefix="uc2" %>
<%@ Register Src="Foot.ascx" TagName="Foot" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ע��ɹ�</title>
    <link href="../../style/Shop.css" rel="stylesheet" type="text/css" />
    <link href="../../css/indexcss.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form2" runat="server">
    <div id="Header">
        <!--nav begin-->
        <uc1:shophead id="ShopHead1" runat="server" />
        <!--nav end-->
    </div>
    <div class="ShopBody">
        <div class="slider">
            <!--slider begin-->
            <uc2:shopslider id="shopSlider1" runat="server" />
            <!--slider end-->
        </div>
        <div class="rightBox">
            <div class="box box_width">
                <div class="dataTable">
                    <fieldset class="fieldset">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="">
                            <tr>
                                <td align="left" style="height: 60px;">
                                    <span style="font-size: 25px; color: Green; font-weight: bold;">��ϲ��ע��ɹ���</span>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    ���Ļ�Ա���Ϊ��<span style="color: Green;"><%=usercode %></span>&nbsp;&nbsp;&nbsp;&nbsp;
                                    ע�ἶ��<span style="color: Green;"><%=levelname%></span>&nbsp;&nbsp;&nbsp;&nbsp; ע���<span
                                        style="color: Green;"><%=money%>Ԫ</span>
                                </td>
                            </tr>
                            <%--                <tr>
                    <td align="left">
                        <span style="font-weight: bold;">����ѡ�����¹��ܲ�����</span>
                    </td>
                </tr>--%>
                            <%if (getIntRequest("asd") == 1)
                              {%>
                            <%--                <tr>
                    <td align="left">
                        <span style="padding-left:80px;">��Ҫ��ͨ��Ա����>> <a href="admin/business/Member.aspx">����ͨ��Ա</a></span>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <span style="padding-left:80px;">��Ҫ��ֵE������>> <a href="admin/finance/AddMoney.aspx">��Ҫ��ֵ</a></span>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <span style="padding-left:80px;">��Ҫ����ע���»�Ա����>> <a href="admin/team/MemberTree.aspx?tt=1">ϵ��ͼ</a></span>
                    </td>
                </tr>--%>
                            <%} %>
                            <%if (getIntRequest("asd") == 0)
                              {%>
                            <%--  <tr>
                    <td align="left">
                        <span style="padding-left:80px;">��Ҫ��ֵE������>> <a href="user/finance/Remit.aspx">��Ҫ��ֵ</a></span>
                    </td>
                </tr>
              <tr>
                    <td align="left">
                        <span style="padding-left:80px;">��Ҫ����ע���»�Ա����>> <a href="user/team/MemberTree.aspx?tt=<%=getLoginID() %>">ϵ��ͼ</a></span>
                    </td>
                </tr>--%>
                            <%} %>
                        </table>
                    </fieldset>
                </div>
            </div>
        </div>
    </div>
    <uc3:Foot ID="Foot1" runat="server" />
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegSuccess.aspx.cs" Inherits="Web.RegSuccess" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ע��ɹ�</title>
    <link href="../static/css/style.css" rel="stylesheet" type="text/css" media="all" />
</head>
<body>
    <form id="form2" runat="server">
        <div class="right_content">
            <h2><%=GetLanguage("Register")%></h2>
            <h6><%=GetLanguage("Congratulations")%><%--��ϲ��ע��ɹ���--%></h6>
            <div>&nbsp;</div>
            <div class="filter">
                <div class="row-fluid">
                    <p class="span3">
                        <label><%=GetLanguage("MembershipNumber")%><!--��Ա���-->��</label>
                        <span class="field" style="margin-top: 8px;">
                            <%=strUserCode %>
                        </span>
                    </p>
                    <p class="span3">
                        <label><%=GetLanguage("RegisterLevel")%><!--ע�ἶ��-->��</label>
                        <span class="field" style="margin-top: 8px;">
                            <%=strLevelName%>
                        </span>
                    </p>
                    <p class="span3">
                        <label><%=GetLanguage("RegistrationAmount")%><%--ע����--%>��</label>
                        <span class="field" style="margin-top: 8px;">
                            <%=strRegMoney%>&nbsp;<%=GetLanguage("USD")%>
                        </span>
                    </p>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

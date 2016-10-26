<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegSuccess.aspx.cs" Inherits="Web.RegSuccess" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>×¢²á³É¹¦</title>
    <link href="../static/css/style.css" rel="stylesheet" type="text/css" media="all" />
</head>
<body>
    <form id="form2" runat="server">
        <div class="right_content">
            <h2><%=GetLanguage("Register")%></h2>
            <h6><%=GetLanguage("Congratulations")%><%--¹§Ï²Äú×¢²á³É¹¦£¡--%></h6>
            <div>&nbsp;</div>
            <div class="filter">
                <div class="row-fluid">
                    <p class="span3">
                        <label><%=GetLanguage("MembershipNumber")%><!--»áÔ±±àºÅ-->£º</label>
                        <span class="field" style="margin-top: 8px;">
                            <%=strUserCode %>
                        </span>
                    </p>
                    <p class="span3">
                        <label><%=GetLanguage("RegisterLevel")%><!--×¢²á¼¶±ð-->£º</label>
                        <span class="field" style="margin-top: 8px;">
                            <%=strLevelName%>
                        </span>
                    </p>
                    <p class="span3">
                        <label><%=GetLanguage("RegistrationAmount")%><%--×¢²á½ð¶î--%>£º</label>
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

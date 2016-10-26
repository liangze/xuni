<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LeaveWordsDetail.aspx.cs" Inherits="web.admin.system.LeaveWordsDetail" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link href="../../css/indexcss.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/icon.css" />
    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>

    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
<script src="../Scripts/main-layout.js" type="text/javascript"></script>
</head>
<body>
        <form id="form1" runat="server">
        <div class="mailTop">
            <div class="sendMen">
                <span class=" ico_mail">
                    </span>【<asp:Label ID="lblSendMember" runat="server" Text=""></asp:Label>】发件</div>
            <div class="sendTime cGray">
                <span class=" ico_mailReTime">发送时间：</span><asp:Label ID="lblSendDate" runat="server"
                    Text=""></asp:Label></div>
        </div>
        <div class="mailTop">
            <div class="sendMen">
                <span class=" ico_mail">主题：</span><asp:Label ID="lblSendTitle" runat="server" Text=""></asp:Label></div>
        </div>
        <!--end mailTop-->
        <div class="clear">
        </div>
        <div class="mailCon">
            <div class="reply">
             <asp:Label ID="lblSendContent" runat="server" Text=""></asp:Label>
            </div>
            <!--end reply-->
            <div class="managerReply" id="divNull" runat="server">
                <p class="cRed">
                    目前暂时无回复信息！</p>
            </div>
            <asp:Repeater ID="rpReply" runat="server">
                <ItemTemplate>
                    <div class="managerReply">
                        <h2 class="cGold ico_admin">
                            <%#Eval("UserType").ToString() == "1" ? GetUserCode(Eval("UserID").ToString(), 1) : GetUserCode(Eval("UserID").ToString(), 2)%>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%#Eval("ReTime")%>回复：</h2>
                        <p>
                        </p>
                        <p class="cRed">
                            <%#Eval("ReContent")%></p>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <!--end managerReply-->
            <div class="nextpage cBlack">
                <webdiyer:AspNetPager ID="anpReply" runat="server" SkinID="AspNetPagerSkin" FirstPageText="首页"
                    LastPageText="尾页" NextPageText="下一页" OnPageChanged="anpReply_PageChanged" PrevPageText="上一页"
                    AlwaysShow="True" InputBoxClass="pageinput" NumericButtonCount="3" PageSize="8"
                    ShowInputBox="Never" ShowNavigationToolTip="True" SubmitButtonClass="pagebutton"
                    UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always" SubmitButtonText=""
                    textafterpageindexbox=" 页" textbeforepageindexbox="转到 ">
                </webdiyer:AspNetPager>
            </div>
        </div>
        <div style="padding-left: 10px;" id="mail" runat="server">
            <p>
                回复留言：<asp:Label ID="lblContentError" runat="server" Text="" ForeColor="Red"></asp:Label></p>
            <p>
                <asp:TextBox ID="txtPubContext" runat="server" Height="127px" Width="99%" Style="border: 1px #A4BED4 solid;
                    float: inherit;" TextMode="MultiLine"></asp:TextBox>
            </p>
            <p>
            </p>
            <asp:LinkButton ID="btn_s1" runat="server" class="easyui-linkbutton"   iconcls="icon-ok" onclick="btnRepeat_Click"  > 提 交 </asp:LinkButton>
            <asp:LinkButton ID="LinkButton1" runat="server" class="easyui-linkbutton"   
                    iconcls="icon-back" onclick="btnBack_Click" > 返回 </asp:LinkButton>
        </div>
        </form>
</body>
</html>
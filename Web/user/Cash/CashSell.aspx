<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cashsell.aspx.cs" Inherits="Web.user.Cash.Cashsell" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../../static/css/style.css" rel="stylesheet" type="text/css" media="all" />
    <script src="../../JS/ValidateData.js" type="text/javascript"></script>
</head>
<script language="javascript" type="text/javascript">

    function CheckQuantity() {
        var strNumber = document.getElementById("txtNumber").value;
        var strPrice = document.getElementById("txtPrice").value;
        if ((Trim(strNumber) != "" || Trim(strNumber) != "0") && (Trim(strPrice) != "" || Trim(strPrice) != "0")) {
            document.getElementById("spanAmount").innerHTML = strNumber * strPrice;
        }
        else {
            document.getElementById("spanAmount").innerHTML = "0";
        }
    }

    function CheckData() {
        var strNumber = document.getElementById("txtNumber").value;
        var strUnitNum = document.getElementById("txtUnitNum").value;
        var strThreePassword = document.getElementById("txtThreePassword").value;

        if (Trim(strNumber) == "" || Trim(strNumber) == "0") {
            alert("请输入单件商品数量！");
            return false;
        }

        if (Trim(strUnitNum) == "" || Trim(strUnitNum) == "0") {
            alert("请输入发布件数！");
            return false;
        }
        if (Trim(strThreePassword) == "" || Trim(strThreePassword) == "0") {
            alert("请输入三级密码！");
            return false;
        }
    }
</script>
<body>
    <form id="form1" runat="server" class="stdform">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="right_content">
            <h2><%=GetLanguage("Sale")%></h2>
            <h6><%=GetLanguage("SellerInfo") %><%--卖家信息--%>：</h6>
            <div class="row-fluid">
                <div class="span6">
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("MembershipNumber") %><%--会员编号--%>：
                        </label>
                        <div class="field">
                            <asp:Literal ID="ltUserCode" runat="server"></asp:Literal>
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("Depositary") %><%--开户银行--%>：
                        </label>
                        <div class="field">
                            <asp:Literal ID="ltBankName" runat="server"></asp:Literal>
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("Name")%><%--卖家姓名--%>：
                        </label>
                        <div class="field">
                            <asp:Literal ID="ltTrueName" runat="server"></asp:Literal>
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("BankAccount")%><%--银行帐号--%>：
                        </label>
                        <div class="field">
                            <asp:Literal ID="ltBankAccount" runat="server"></asp:Literal>
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("AccountName")%><%--开户姓名--%>：
                        </label>
                        <div class="field">
                            <asp:Literal ID="ltBankAccountUser" runat="server"></asp:Literal>
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("BankBranch")%><%--银行支行(开户网点)--%>：
                        </label>
                        <div class="field">
                            <asp:Literal ID="ltBankBranch" runat="server"></asp:Literal>
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("QQNumber")%><%--QQ号码--%>：
                        </label>
                        <div class="field">
                            <asp:Literal ID="ltQQnumer" runat="server"></asp:Literal>
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("ContactPhone")%><%--手机号码--%>：
                        </label>
                        <div class="field">
                            <asp:Literal ID="ltPhoneNum" runat="server"></asp:Literal>
                        </div>
                    </div>
                </div>
            </div>
            <h6><%=GetLanguage("ConsignmentInfo")%></h6>
            <div class="row-fluid">
                <div class="span6">
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("GoldBalance")%><%--金币结余--%>：
                        </label>
                        <div class="field">
                            <asp:Literal ID="ltNumber" runat="server"></asp:Literal>
                        </div>
                    </div>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <div class="control-group">
                                <label for="memid">
                                    <span style="color: #f00;">*</span><%=GetLanguage("Quantity")%><%--商品数量--%>：
                                </label>
                                <div class="field">
                                    <asp:TextBox ID="txtNumber" runat="server" onkeydown="this.value=this.value.replace(/\D/g,'')" onKeyPress="this.value=this.value.replace(/\D/g,'')" AutoPostBack="True" OnTextChanged="txtNumber_TextChanged" Width="180px"></asp:TextBox><%=GetLanguage("GoldCoin")%><%--个金币--%>(<%=GetLanguage("Mini")%><%--最少--%><%=getParamInt("Gold1") %><%=GetLanguage("GoldCoin")%><%--个金币--%>)
                                </div>
                            </div>
                            <div class="control-group">
                                <label for="memid">
                                    <span style="color: #f00;">*</span><%=GetLanguage("CommodityPrices")%><%--商品价格--%>：
                                </label>
                                <div class="field">
                                    <asp:TextBox ID="txtPrice" class="input_reg" precision="2" runat="server" onblur="CheckQuantity();" onkeyup="value=value.replace(/[^\d.]/g,'')" onafterpaste="this.value=this.value.replace(/[^\d.]/g,'')" Width="180px"></asp:TextBox>RMB<!--金币-->&nbsp;&nbsp;<%=GetLanguage("LowestPrice")%>:<%=getParamAmount("GoldMin")%>RMB&nbsp;&nbsp;<%=GetLanguage("HighestPrice")%>:<%=getParamAmount("GoldMax")%>RMB<span style="font-size: 12px;" id="spanPrice"></span><span style="font-size: 12px;" id="spanService"></span>
                                </div>
                            </div>
                            <div class="control-group">
                                <label for="memid">
                                    <%=GetLanguage("GoodsAmount")%><%--商品金额--%>：
                                </label>
                                <div class="field">
                                    <span style="font-size: 12px;" id="spanAmount"></span>RMB
                                </div>
                            </div>
                            <div class="control-group" style="display: none;">
                                <label for="memid">
                                    <span style="color: #f00;">*</span>商品标题：
                                </label>
                                <div class="field">
                                    <span style="font-size: 12px;" id="spanTitle"></span>
                                </div>
                            </div>
                            <div class="control-group" style="display: none;">
                                <label for="memid">
                                    <span style="color: #f00;">*</span>发布件数：
                                </label>
                                <div class="field">
                                    <input name="txtUnitNum" type="text" id="txtUnitNum" runat="server" value="1" disabled="disabled" class="input_reg" />件
                                </div>
                            </div>
                            <div class="control-group">
                                <label for="memid">
                                    <span style="color: #f00;">*</span><%=GetLanguage("Factorage")%><%--手续费--%>：
                                </label>
                                <div class="field">
                                    <input name="txtFactorage" type="text" id="txtFactorage" runat="server" disabled="disabled" class="input_reg" /><%=GetLanguage("GoldCoin")%><!--金币-->
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div class="control-group">
                        <label for="memid">
                            <span style="color: #f00;">*</span><%=GetLanguage("ThreePassword")%><%--三级密码--%>：
                        </label>
                        <div class="field">
                            <input name="txtThreePassword" type="password" id="txtThreePassword" runat="server" class="input_reg" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="action">
                <asp:Button ID="btnSubmit" runat="server" Text="提 交" class="btn btn-submit" OnClientClick="CheckData()" OnClick="btnSubmit_Click" />
                &nbsp;<asp:Literal ID="ltWarning" runat="server"></asp:Literal>
            </div>
        </div>
    </form>
</body>
</html>

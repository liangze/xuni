/*********************************************************************************
* Copyright(c)  	2011 ZXHLRJ.COM
 * 创建日期：		2011-12-24 14:30:41 
 * 文 件 名：		IPSConfig.cs 
 * CLR 版本: 		2.0.50727.3625 
 * 创 建 人：		黄炳仪
 * 文件版本：		1.0.0.0
 * 修 改 人： 
 * 修改日期： 
 * 备注描述：         
**********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Xml.Linq;

namespace ThirdPartyPaymentExample.IPS
{
    /// <summary>
    /// 环迅配置页面
    /// 供管理员配置环迅支付环境和相关参数
    /// 配置参数并非使用数据存储而是使用XML配置文件存储,具体请参照Config.xml文件
    /// </summary>
    public partial class IPSConfig : System.Web.UI.Page
    {
        private const string TESTING_ENVIRONMENT = "Testing";
        private const string OFFICIAL_ENVIRONMENT = "Official";
        private const string CONFIG_FILE = @"~/IPS/Config.xml";
        XDocument xDoc = null;

        /// <summary>
        /// 加载配置信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //加载配置项目
                xDoc = XDocument.Load(Server.MapPath(CONFIG_FILE));
                string environment = xDoc.Element("Root").Element("Environment").Value;
                XElement xEle = xDoc.Descendants("IPS").SingleOrDefault(t => t.Attribute("name").Value.Equals(environment));
                rdbTesting.Checked = environment.Equals(TESTING_ENVIRONMENT) ? true : false;
                rdbOfficial.Checked = environment.Equals(OFFICIAL_ENVIRONMENT) ? true : false;
                
                //配置项目清单
                txtAccount.Text = xEle.Element("Account").Value;
                txtCertificate.Text = xEle.Element("Certificate").Value;
                ddlCurrencyType.SelectedValue = xDoc.Element("Root").Element("CurrencyType").Value;
                ddlGatewayType.SelectedValue = xDoc.Element("Root").Element("GatewayType").Value;
                ddlLang.SelectedValue = xDoc.Element("Root").Element("Lang").Value;
                txtOrderReturn.Text = xDoc.Element("Root").Element("MerchantUrl").Value;
                txtOrderFail.Text = xDoc.Element("Root").Element("FailUrl").Value;
                txtOrderError.Text = xDoc.Element("Root").Element("ErrorUrl").Value;
                ddlOrderEncodeType.SelectedValue = xDoc.Element("Root").Element("OrderEncodeType").Value;
                ddlRetEncodeType.SelectedValue = xDoc.Element("Root").Element("RetEncodeType").Value;
                ddlRettype.SelectedValue = xDoc.Element("Root").Element("Rettype").Value;
                txtServerUrl.Text = xDoc.Element("Root").Element("ServerUrl").Value; 
            }
        }

        /// <summary>
        /// 重置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtAccount.Text = "";
            txtCertificate.Text = "";
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                xDoc = XDocument.Load(Server.MapPath(CONFIG_FILE));
                string environment = rdbTesting.Checked ? TESTING_ENVIRONMENT : OFFICIAL_ENVIRONMENT;
                string account = txtAccount.Text.Trim();
                string certificate = txtCertificate.Text.Trim();

                XElement xEle = xDoc.Descendants("IPS").SingleOrDefault(t => t.Attribute("name").Value.Equals(environment));
                xEle.SetElementValue("Account", account);
                xEle.SetElementValue("Certificate", certificate);
                xDoc.Element("Root").Element("Environment").SetValue(environment);
                xDoc.Element("Root").Element("CurrencyType").SetValue(ddlCurrencyType.SelectedValue);
                xDoc.Element("Root").Element("GatewayType").SetValue(ddlGatewayType.SelectedValue);
                xDoc.Element("Root").Element("Lang").SetValue(ddlLang.SelectedValue);
                xDoc.Element("Root").Element("MerchantUrl").SetValue(txtOrderReturn.Text.Trim());
                xDoc.Element("Root").Element("FailUrl").SetValue(txtOrderFail.Text.Trim());
                xDoc.Element("Root").Element("ErrorUrl").SetValue(txtOrderError.Text);
                xDoc.Element("Root").Element("OrderEncodeType").SetValue(ddlOrderEncodeType.SelectedValue);
                xDoc.Element("Root").Element("RetEncodeType").SetValue(ddlRetEncodeType.SelectedValue);
                xDoc.Element("Root").Element("Rettype").SetValue(ddlRettype.SelectedValue);
                xDoc.Element("Root").Element("ServerUrl").SetValue(txtServerUrl.Text.Trim()); 
                xDoc.Save(Server.MapPath(CONFIG_FILE));

                ScriptManager.RegisterClientScriptBlock(btnSave, this.GetType(), "save", "alert('信息保存成功!');", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(btnSave, this.GetType(), "save", "alert('信息保存失败,请重试!');", true);
                throw ex;
            }
            
        }

        /// <summary>
        /// 测试环境
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rdbTesting_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbTesting.Checked)
            {
                FillInfoByEnvironment(TESTING_ENVIRONMENT);
            }
        }

        protected void rdbOfficial_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbOfficial.Checked)
            {
                FillInfoByEnvironment(OFFICIAL_ENVIRONMENT);
            }
        }

        private void FillInfoByEnvironment(string environment)
        {
            xDoc = XDocument.Load(Server.MapPath(CONFIG_FILE));
            XElement xEle = xDoc.Descendants("IPS").SingleOrDefault(t => t.Attribute("name").Value.Equals(environment));
            txtAccount.Text = xEle.Element("Account").Value;
            txtCertificate.Text = xEle.Element("Certificate").Value;
        }
    }
}

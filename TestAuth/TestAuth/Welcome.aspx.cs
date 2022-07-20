using SkillMineAuth;
using System;
using TestAuth.AuthRules;
namespace TestAuth
{
    public partial class Welcome : System.Web.UI.Page
    {
        #region<Private Members>

        /// <summary>
        /// accessToken
        /// </summary>
        private string accessToken = string.Empty;
        /// <summary>
        /// Access_Token_Param
        /// </summary>
        private const string Access_Token_Param = "access_token";
        /// <summary>
        /// introspectUrl
        /// </summary>
        const string introspectUrl = "https://demo-accounts-api.skill-mine.com/token-srv/introspect";
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString[Access_Token_Param] != null && Request.QueryString[Access_Token_Param] != string.Empty)
            {
                this.accessToken = Request.QueryString[Access_Token_Param].ToString();
                this.GetServiceDetails(this.accessToken);
            }
            else
            {
                this.lblResult.Text = "Invalid data while API Call";
            }
        }
        /// <summary>
        /// GetServiceDetails
        /// </summary>
        /// <param name="accessToken"></param>
        private void GetServiceDetails(string accessToken)
        {
            try
            {
                var tokenService = new TokenService();
                var result = tokenService.GetResult(accessToken, RuleHelper.GetRuleObject(), introspectUrl);
                if (result.active == false)
                {
                    this.lblResult.Text = "Unauthorized";
                    return;
                }
                else
                {
                    this.lblResult.Text = "Authorized";
                }
            }
            catch (Exception ex)
            {

                Response.Write(ex.Message);
            }
        }
    }
}
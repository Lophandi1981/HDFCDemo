using System;
using System.Text;
using System.Web.UI;
using TestAuth.UserInfo;
namespace TestAuth
{
    public partial class LoginSuccess : System.Web.UI.Page
    {
        private string accessToken = string.Empty;
        private string userURL = "https://hdfc-accounts-api.skill-mine.com/users-srv/userinfo";
        /// <summary>
        /// Page_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.lblResult.Text = string.Empty;
                if (Session["LoggedIn"] != null)
                {
                    divLogin.Visible = true;
                    divUnAuthorized.Visible = false;
                }
                else
                {
                    divLogin.Visible = false;
                    divUnAuthorized.Visible = true;

                }
            }

        }
        /// <summary>
        /// btngetUserInfo_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btngetUserInfo_Click(object sender, EventArgs e)
        {
            try
            {
                var userService = new UserService();

                string hashValue = HiddenFieldHash.Value;
                if (!string.IsNullOrEmpty(hashValue))
                {
                    string[] splitValues = hashValue.Split('&');
                    string strTokenArray = splitValues[2];
                    if (strTokenArray.Length > 0)
                    {
                        string[] tokenArray = strTokenArray.Split('=');
                        accessToken = tokenArray[1];
                        if (!string.IsNullOrEmpty(accessToken))
                        {
                            var userData = userService.GetUserInfo(userURL, accessToken);
                            if (userData != null)
                            {
                                StringBuilder sbUserData = new StringBuilder();
                                sbUserData.AppendFormat("<br/> Email : {0}", userData.email);
                                sbUserData.AppendFormat("<br/> Name : {0}", userData.name);
                                sbUserData.AppendFormat("<br/> ISub : {0}", userData.isub);
                                sbUserData.AppendFormat("<br/> Created At : {0}", userData.created_at);
                                sbUserData.AppendFormat("<br/> Updated At : {0}", userData.updated_at);
                                sbUserData.AppendFormat("<br/> Last Login time : {0}", userData.last_logged_in_time);
                                sbUserData.AppendFormat("<br/> Email Verfied : {0}", userData.email_verified);
                                lblResult.Text = sbUserData.ToString();
                            }
                            else
                            {
                                throw new Exception("Invalid response");
                            }
                        }
                        else
                        {
                            throw new Exception("Invalid Token");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblResult.Text = ex.Message;
            }
        }
    }
}
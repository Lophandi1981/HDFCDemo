using System;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using TestAuth.UserInfo;
namespace TestAuth
{
    public partial class IssueManagement : System.Web.UI.Page
    {
        #region<Private Members>
      
        /// <summary>
        /// accessToken
        /// </summary>
        private string accessToken = string.Empty;
        private const string Access_Token_Param = "access_token";
        /// <summary>
        /// userURL
        /// </summary>
        private string userURL = "https://hdfc-accounts-api.skill-mine.com/users-srv/userinfo";
        #endregion

        /// <summary>
        /// Page_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString[Access_Token_Param] != null && Request.QueryString[Access_Token_Param] != string.Empty)
                {
                    this.accessToken = Request.QueryString[Access_Token_Param].ToString();                  
                    this.h2APIError.Visible = false;
                    this.h2UserInfo.Visible = true;
                    this.GetUserDetails(this.accessToken);
                }
                else
                {
                    this.h2APIError.Visible = true;
                    this.h2UserInfo.Visible = false;
                    this.lblResult.Text = "Invalid data while API Call";
                }


            }
        }

        /// <summary>
        /// GetUserDetails
        /// </summary>
        /// <param name="strAuthHash"></param>
        private void GetUserDetails(string accessToken)
        {
            try
            {
                var userService = new UserService();
                if (!string.IsNullOrEmpty(accessToken))
                {
                    var task = Task.Run(() =>
                    {
                        return userService.GetUserInfo(userURL, accessToken);
                    });

                    var userData = task.Result;
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
            catch (Exception ex)
            {
                this.h2APIError.Visible = true;
                this.h2UserInfo.Visible = false;
                this.lblResult.Text = ex.Message;
            }
        }
    }
}
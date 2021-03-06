using System;
using System.Configuration;
using System.Web;
using System.Web.UI;

namespace TestAuth
{
    public partial class Home : System.Web.UI.Page
    {
        /// <summary>
        /// loginSuccessURL
        /// </summary>        
        private static string authTransferURL = HttpContext.Current.Request.Url.Scheme + ":" + "//" + HttpContext.Current.Request.Url.Host + ":" + HttpContext.Current.Request.Url.Port + "/IssueManagement.aspx";

        /// <summary>
        /// authURL
        /// </summary>

       // private static string authURL = string.Format("https://hdfc-accounts-api.skill-mine.com/authz-srv/authz?response_type=token&&response_mode=query&scope=openid%20profile%20email%20phone&redirect_uri={0}&flow_id=cf773255-5d29-4d0a-96e9-322026865a5c&client_id=8e28e7b4-cd75-4f54-87ed-c8c34ddf2971", authTransferURL);

        private static string authURL = string.Format("https://hdfc-accounts-api.skill-mine.com/authz-srv/authz?response_type=token&response_mode=query&scope=openid%20profile%20email%20phone&redirect_uri={0}&flow_id=80b9f3e9-ebd8-4925-ab23-ef3517577112&client_id=c748b0bb-3238-4338-ae76-0b9716f70202", authTransferURL);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["LoggedIn"] = null;
            }
        }

       
        /// <summary>
        /// btnRedirect_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRedirect_Click(object sender, EventArgs e)
        {
            try
            {
                Session["LoggedIn"] = "yes";
                Response.Redirect(authURL, true);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}
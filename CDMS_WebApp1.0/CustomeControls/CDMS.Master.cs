using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CDMS_WebApp1._0.CustomeControls
{
    public partial class CDMS : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserId"] != null && Session["UserId"].ToString() != "")
                {
                    UserNameLabel.Text = Session["UserId"].ToString();
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }

            //ResponseLi.Disabled = true;
            //DataLogLi.Disabled = true; 
            //DataViewLi.Disabled = true;
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("Login.aspx");
        }
    }
}






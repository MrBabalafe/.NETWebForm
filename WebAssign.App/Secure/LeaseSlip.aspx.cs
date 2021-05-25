using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAssign.Data;

namespace WebAssign.App.Secure {
    public partial class LeaseSlip : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            //If user isn't logged in but somehow got to this page, redirect them to register / login page
            if(Session["Customer"] == null) {
                Response.Redirect("~/Register");
            }

            Customer cust = (Customer)Session["Customer"];
            //uxCustomerName.Text = $"{cust.FirstName} {cust.LastName}";
        }
    }
}
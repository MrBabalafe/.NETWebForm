using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAssign.Data;

namespace WebAssign.App {
    public partial class Register : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void btnRegister_Click(object sender, EventArgs e) {
            //If user is already registered / in database, then "log in"
            if(AuthenticationManager.Authenticate(uxFirstName.Text, uxLastName.Text) != null) {

                //Add customer object to session, redirect.
                Customer cust = AuthenticationManager.Authenticate(uxFirstName.Text, uxLastName.Text);
                Session["Customer"] = cust;
                Response.Redirect("~/Secure/LeaseSlip");

            //Else if they aren't, then add them to the database.
            } else {
                //Create customer object with data entered.
                Customer cust = new Customer {
                    FirstName = uxFirstName.Text,
                    LastName = uxLastName.Text,
                    Phone = uxPhone.Text,
                    City = uxCity.Text
                };

                //Pass to auth manager to add to db, then add customer to session and redirect.
                AuthenticationManager.Add(cust);
                Session["Customer"] = cust;
                Response.Redirect("~/Secure/LeaseSlip");
            }
            
        }
    }
}
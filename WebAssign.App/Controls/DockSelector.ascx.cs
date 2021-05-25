using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAssign.Data;

namespace WebAssign.App.Controls {
    public partial class DockSelector : System.Web.UI.UserControl {
        DockManager mgr = new DockManager();
        
        protected void Page_Load(object sender, EventArgs e) {
            Customer cust = (Customer)Session["Customer"];

            //Populate Dropdown menu showing all docks
            if (!IsPostBack) {
                uxDocks.DataSource = mgr.GetAllAsListItems();
                uxDocks.DataTextField = "Name";
                uxDocks.DataValueField = "ID";
                uxDocks.DataBind();

                uxLeasedSlips.DataSource = mgr.GetAllLeasedSlips();
                uxLeasedSlips.DataBind();

                uxCustomersLeasedSlips.DataSource = mgr.GetAllLeasedForCustomer(cust.ID);
                uxCustomersLeasedSlips.DataBind();


            }

            

        }

        //When a dock is selected, show associated slips.
        protected void uxDocks_SelectedIndexChanged(object sender, EventArgs e) {
            uxSlips.Visible = true;
            uxSlips.DataSource = mgr.GetAllSlipsForDock(Convert.ToInt32(uxDocks.SelectedValue));
            uxSlips.DataTextField = "ID";
            uxSlips.DataValueField = "ID";
            uxSlips.DataBind();
        }

        protected void uxLeaseButton_Click(object sender, EventArgs e) {
            Customer cust = (Customer)Session["Customer"];
            Lease lease = new Lease { SlipID = Convert.ToInt32(uxSlips.SelectedValue), CustomerID = cust.ID };
            bool added = mgr.AddLease(lease);
            
            //If lease was added refresh page to update gridview, if not then a lease exists for slip. Show error message
            if(added) {
                Response.Redirect("~/Secure/LeaseSlip");
            } else {
                uxError.Visible = true;
            }
            
        }
    }
}
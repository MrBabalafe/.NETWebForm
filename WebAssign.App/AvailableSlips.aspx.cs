using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAssign.Data;

namespace WebAssign.App {
    public partial class AvailableSlips : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

            LoadAvailableSlips();
        }

        private void LoadAvailableSlips() {
            
            var db = new MarinaEntities1();
            var slips = db.Slips.ToList();
            var leases = db.Leases.ToList();
            var leased = new List<Slip>();
            var available = new List<Slip>();

            //Create list of Leased Slips
            foreach (Slip slip in slips) {
                foreach (Lease lease in leases) {
                    if (slip.ID == lease.SlipID && !leased.Contains(slip)) {
                        leased.Add(slip);
                    }
                }
            }

            //If slip isn't leased, then add to list of available slips
            foreach (Slip slip in slips) {
                if (!leased.Contains(slip)) {
                    available.Add(slip);
                }
            }

            //Bind available list to gridview
            uxSlips.DataSource = available;
            uxSlips.DataBind();
        }
    }
}
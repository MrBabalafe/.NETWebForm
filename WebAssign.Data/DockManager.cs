using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAssign.Data {
    public class DockManager {

        public IList GetAllAsListItems() {
            var db = new MarinaEntities1();
            var docks = db.Docks.Select(dock => new { ID = dock.ID, Name = dock.Name}).ToList();
            return docks;
        }

        public IList GetAllSlipsForDock(int dockID) {
            var db = new MarinaEntities1();
            var slips = db.Slips.Where(slip => slip.DockID == dockID).ToList();
            return slips;
        }

        public IList GetAllLeasedSlips() {
            var db = new MarinaEntities1();
            var leased = db.Leases.Select(lease => new { SlipID = lease.SlipID }).ToList();
            return leased;
        }

        public IList GetAllLeasedForCustomer(int customerID) {
            var db = new MarinaEntities1();
            var leased = db.Leases.Where(lease => lease.CustomerID == customerID).ToList();
            return leased;
        }

        public bool AddLease(Lease lease) {
            var db = new MarinaEntities1();

            //Look to see if a lease with that slip ID exists
            var lse = db.Leases.SingleOrDefault(l => l.SlipID == lease.SlipID);

            //If not, then add to DB, if it does then return false
            if(lse == null) {
                db.Leases.Add(lease);
                db.SaveChanges();
                return true;
            } else {
                return false;
            }


        }

    }
}

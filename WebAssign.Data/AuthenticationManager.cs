using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAssign.Data {
    public class AuthenticationManager {

        public static Customer Authenticate(string firstName, string lastName) {

            var db = new MarinaEntities1();
            var auth = db.Customers.SingleOrDefault(a => a.FirstName == firstName && a.LastName == lastName);

            //If customer is already registered return Customer
            if(auth != null) {
                //User exists
                return auth;

            }
            return null;
        }

        public static void Add(Customer cust) {
            var db = new MarinaEntities1();
            db.Customers.Add(cust);
            db.SaveChanges();
        }

    }
}

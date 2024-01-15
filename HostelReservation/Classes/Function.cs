using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostelReservation.Classes
{
    internal class Function
    {
        //customer functions
        #region customer functions
        
        public Customer createcustomer()
        {
            Customer customer = new Customer();
            Console.Write("Enter Customer Name: ");
            customer.FullName = Console.ReadLine();
            Console.Write("Enter Customer City: ");
            customer.City = Console.ReadLine();
            Console.Write("Enter Customer Phone Number: ");
            customer.Phonenumber = Console.ReadLine();
            Console.WriteLine(" *** -- Saved Sucessfuly -- ***");
            customer.Create(customer);
            return customer;
        }
        
        
        #endregion
    }
}

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
        
        public void createcustomer()
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
        }
        public void selectcustomer() 
        { 
            Customer customer = new Customer();
            customer.Read(customer);
        }
        public void updatecustomer()
        {
            Customer customer = new Customer();
            Console.WriteLine("enter the customer id ");
            customer.ID=int.Parse(Console.ReadLine());
            Console.Write("Enter Customer Name: ");
            customer.FullName = Console.ReadLine();
            Console.Write("Enter Customer City: ");
            customer.City = Console.ReadLine();
            Console.Write("Enter Customer Phone Number: ");
            customer.Phonenumber = Console.ReadLine();
            customer.Update(customer);
        }
        public void deletecustomer()
        {
            Customer customer = new Customer();
            Console.WriteLine("enter the customer id ");
            customer.ID = int.Parse(Console.ReadLine());
            customer.Delete(customer);
        }


        #endregion
    }
}

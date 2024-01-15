using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;
using static HostelReservation.DBconnection;

namespace HostelReservation.Classes
{
    internal class Customer :BaseInterface
    {
        //fields
        // test
        private int id;
        private static int nextId = 1;
        private string fname;
        private string fullName;
        private string city;
        private string phonenumber;
        private string zipcode;

        //props
        public int ID { get { return id; } set { id = value; } }
        //public string Fname {
        //    get { return fname; }
        //    set {  fname = value; }
        //}
        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }
        public string City
        {
            get { return city; }
            set { city = value; }
        }
        public string Phonenumber
        {
            get { return phonenumber; }
            set { phonenumber = value; }
        }
        //public string Zipcode {
        //    get { return zipcode; }
        //    set {  zipcode = value; }
        //}


        //method
        public static int Generateid()
        {
            return nextId++;
        }
        public void CreateCustomer()
        {
            //Customer customer = new Customer();
            //customer.ID = Generateid();
            //int ID = Generateid();
            Console.Write("Enter Customer Name: ");
            //string fname = Console.ReadLine();
            FullName = Console.ReadLine();
            //Console.WriteLine("enter customer secound name");
            ////string lname = Console.ReadLine();
            //Lname = Console.ReadLine();
            Console.Write("Enter Customer City: ");
            //string city = Console.ReadLine();
            City = Console.ReadLine();
            Console.Write("Enter Customer Phone Number: ");
            //string phone = Console.ReadLine();
            Phonenumber = Console.ReadLine();
            //Console.WriteLine("enter customer zipcode");
            ////string zipcode = Console.ReadLine();
            //Zipcode = Console.ReadLine();

            //customer.Fname = fname;
            //customer.Lname = lname;
            //customer.City = city;
            //customer.Phonenumber = phone;
            //customer.Zipcode = zipcode;
            Console.WriteLine(" *** -- Saved Sucessfuly -- ***");
            //Program.customers[Program.top++]= customer;
        }

        public void CreateCustomerinDatabase()
        {
            ////DBconnection.OpenConnection();
            CreateCustomer();
            //SqlConnection con =new SqlConnection("Data Source=.;Initial Catalog=Somabay;Integrated Security=True");
            //string AddRooms = $"insert into Customer values('{FullName}' , '{City}' ,'{Phonenumber}') ; SELECT SCOPE_IDENTITY();";
            //using (SqlCommand command = new SqlCommand(AddRooms, con))
            //{
            //    command.Parameters.AddWithValue("@CustomerFullName", FullName);
            //    int x = Convert.ToInt32(command.ExecuteScalar());
            //    Console.WriteLine(x);
            //}

            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-MLSL318\\SQLEXPRESS01;Initial Catalog=Somabay;Integrated Security=True"))
            {
                con.Open();

                string addCustomerQuery = "INSERT INTO Customer  VALUES (@FullName, @City, @Phonenumber); SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(addCustomerQuery, con))
                {
                    command.Parameters.AddWithValue("@FullName", FullName);
                    command.Parameters.AddWithValue("@City", City);
                    command.Parameters.AddWithValue("@Phonenumber", phonenumber);

                    int customerId = Convert.ToInt32(command.ExecuteScalar());
                    Console.WriteLine("Customer ID: " + customerId);
                }
            }
            
        }

        public void Create(object CreateObj)
        {
            Customer customer = new Customer();
            customer= (Customer)CreateObj;


            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-VD76OGN\\SQLEXPRESS01;Initial Catalog=Somabay;Integrated Security=True"))
            {
                con.Open();

                string addCustomerQuery = "INSERT INTO Customer  VALUES (@FullName, @City, @Phonenumber); SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(addCustomerQuery, con))
                {
                    command.Parameters.AddWithValue("@FullName", customer.FullName);
                    command.Parameters.AddWithValue("@City", customer.City);
                    command.Parameters.AddWithValue("@Phonenumber", customer.phonenumber);

                    int customerId = Convert.ToInt32(command.ExecuteScalar());
                    Console.WriteLine("Customer ID: " + customerId);
                }
            }
        }

        public void Read(object ReadObj)
        {
           using(SqlConnection con = new SqlConnection("Data Source=DESKTOP-VD76OGN\\SQLEXPRESS01;Initial Catalog=Somabay;Integrated Security=True"))
            {
                con.Open();
                string selectCustoers = "select *from Customer";
                using(SqlCommand command = new SqlCommand(selectCustoers, con))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int customerid = reader.GetInt32(0);
                            string fullname=reader.GetString(1);
                            string city=reader.GetString(2);
                            string phonenumber=reader.GetString(3);
                            Console.WriteLine($"the customer id is {customerid}" +
                                $" ,Name = {fullname} ," +
                                $" city = {city} ," +
                                $"phone number = {phonenumber}");
                        }
                    }
                    else { Console.WriteLine("NO rows existed"); }
                }
                con.Close();
            }

            
        }

        public void Update(object UpdateObj)
        {
            Customer customer = new Customer();
            customer = (Customer)UpdateObj;
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-VD76OGN\\SQLEXPRESS01;Initial Catalog=Somabay;Integrated Security=True"))
            {
                con.Open();
                string updateCustomer = $"update Customer set CustomerFullName='{customer.FullName}',CustomerCity='{customer.City}',CustomerPhone='{customer.Phonenumber}' where CustomerId={customer.ID}";
                using (SqlCommand command = new SqlCommand(updateCustomer, con))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    Console.WriteLine("**********Updated successfull");
                    reader.Close();
                }
                //string select = $"select * from Customer where CustomerId={customer.ID}";
                //using (SqlCommand command1 = new SqlCommand(select, con))
                //{
                //    SqlDataReader sqlDataReader = command1.ExecuteReader();
                //    if (sqlDataReader.HasRows)
                //    {
                //        int customerid = sqlDataReader.GetInt32(0);
                //        string fullname = sqlDataReader.GetString(1);
                //        string city = sqlDataReader.GetString(2);
                //        string phonenumber = sqlDataReader.GetString(3);
                //        Console.WriteLine($"the customer id is {customerid}" +
                //            $" ,Name = {fullname} ," +
                //            $" city = {city} ," +
                //            $"phone number = {phonenumber}");
                //    }
                //    else { Console.WriteLine("not updated"); }
                //}
                con.Close();
            }
        }
        public void Delete(object DeleteObj)
        {
            Customer customer = new Customer();
            customer = (Customer)DeleteObj;
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-VD76OGN\\SQLEXPRESS01;Initial Catalog=Somabay;Integrated Security=True"))
            {
                con.Open();
                string deleteCustomer = $"delete from Customer where CustomerId={customer.ID}";
                using (SqlCommand command = new SqlCommand(deleteCustomer, con))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    Console.WriteLine("**********Deleted successfull");
                }
                con.Close();
            }
        }
            
        //public void Update(int id,ref int top, Customer[]customers)
        //{
        //    for (int i = 0; i < top; i++) {
        //        if (customers[i] != null && customers[i].ID==id) {
        //            Console.WriteLine("enter the customer fname");
        //            string fname = Console.ReadLine();
        //            Console.WriteLine("enter customer secound name");
        //            string lname = Console.ReadLine();
        //            Console.WriteLine("enter customer city");
        //            string city = Console.ReadLine();
        //            Console.WriteLine("enter customer phone number");
        //            string phone = Console.ReadLine();
        //            Console.WriteLine("enter customer zipcode");
        //            string zipcode = Console.ReadLine();
        //            customers[i].Fname = fname;
        //            customers[i].Lname = lname;
        //            customers[i].City = city;
        //            customers[i].Phonenumber = phone;
        //            customers[i].Zipcode = zipcode;
        //            Console.WriteLine("updated sucessfully");
        //            return;
        //        }
        //    }
        //    Console.WriteLine("the id is not correct or the customer is not existed");
        //}
        //public void Showall(Customer[]customers,ref int top )
        //{
        //    for (int i = 0;i < top;i++)
        //    {
        //        if (customers[i] != null && customers[i].ID !=0) 
        //        { 
        //        Console.WriteLine($"the customer id={customers[i].ID} the name of the customer is {customers[i].Fname+" "+ customers[i].Lname}\n" +
        //            $" from {customers[i].City} and his phone is {customers[i].Phonenumber} and his zipcode is {customers[i].Zipcode}");
        //        }
        //        Console.WriteLine("***************************************************************");
        //    }

        //}
        //public void ShowCustomerById(Customer[] customers, ref int top,int id)
        //{
        //    for (int i = 0; i < top; i++)
        //    {
        //        if (customers[i].ID == id  && customers[i].ID != 0) 
        //        {
        //            Console.WriteLine($"the customer id={customers[i].ID} the name of the customer is {customers[i].Fname + " " + customers[i].Lname}\n" +
        //                $" from {customers[i].City} and his phone is {customers[i].Phonenumber} and his zipcode is {customers[i].Zipcode}");
        //            Console.WriteLine("***********************************************************");
        //            return;
        //        }

        //    }
        //    Console.WriteLine("not existed");
        //}
        //public void DeleteCustomer(int id, Customer[] customers, ref int top)
        //{
        //    for(int i = 0; i<top;i++)
        //    {
        //        if (customers[i].ID == id && customers[i] != null)
        //        {
        //            Console.WriteLine("are you sure you want to delete this id\n if yes press Y  if no press N  ");
        //            char ch = char.Parse(Console.ReadLine());
        //            switch (ch)
        //            {
        //                case 'Y':
        //                    customers[i].ID = 0;
        //                    customers[i].Fname = "";
        //                    customers[i].Lname = "";
        //                    customers[i].City = "";
        //                    customers[i].Phonenumber = "";
        //                    customers[i].Zipcode = "";
        //                    break;
        //                case 'N':break;
        //                default:
        //                    Console.WriteLine("wrong choice");
        //                    break;
        //            }
        //        }
        //    }
        //}
    }
}

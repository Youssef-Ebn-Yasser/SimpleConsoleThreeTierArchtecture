using BusinessLayer;
using System;
using System.Data;


namespace TreeTierArchtecture_project
{
    internal class Program
    {
        public static void testfind(int id)
        {

            clsContacts contacts = clsContacts.find(id);
            if (contacts != null)
            {
                Console.WriteLine($"your firstname is:{contacts.Firstname}");
                Console.WriteLine($"your lastname is :{contacts.lastName}");
                Console.WriteLine($"phone is :{contacts.phone}");
                Console.WriteLine($"email is: {contacts.email}");
                Console.WriteLine($"address: {contacts.address}");
                Console.WriteLine($"countryid :{contacts.countryid}");
                Console.WriteLine($"dateofbirth:{contacts.dateofbirth}");
                Console.WriteLine($"imagepath :{contacts.imagepath}");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("not found this contacts");
            }
        }
        public static void testaddnewcontact()
        {
            clsContacts contact = new clsContacts();

            contact.Firstname = "yasser";
            contact.lastName = "hamada";
            contact.email = "yasser@.com";
            contact.dateofbirth = DateTime.Now;
            contact.address = "13 omar street";
            contact.imagepath = "c-oooo";
            contact.phone = "9997755";
            contact.countryid = 2;
            if (clsContacts.addnewcontacts(contact))
            {
                Console.WriteLine("ADD sucssufully");
            }
            else
            {
                Console.WriteLine("add faild");

            }
        }

        public static void testdelete(int id)
        {
            if (clsContacts.iscontactexist(id))
            {
                if (clsContacts.contactDelete(id))
                {
                    Console.WriteLine("deleted sucsesfully");
                }
                else
                {
                    Console.WriteLine("faild process");
                }
            }
            else
            {
                Console.WriteLine("contact does not exist");
            }
        }

        public static void testupdatecontact(int id)
        {

            clsContacts contact = clsContacts.find(id);

            contact.Firstname = "fade";
            contact.lastName = "ali";
            contact.email = "gogo@.com";
            contact.dateofbirth = DateTime.Now;
            contact.address = "19 omar street";
            contact.imagepath = "c-oooo";
            contact.phone = "9997755";
            contact.countryid = 2;
            contact.ContactId = id;
            if (clsContacts.iscontactexist(id))
            {
                if (clsContacts.contactUpdate(contact))
                {
                    Console.WriteLine("updated done");
                }
                else
                {
                    Console.WriteLine("faild operation");
                }
            }
            else
            {
                Console.WriteLine("contact does not exist");
            }
        }

        public static void testlist()
        {
            DataTable dt = new DataTable();
            dt = clsContacts.showallcontacts();
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Console.WriteLine($"  {row["contactid"]},\t {row["firstname"]}\t  {row["email"]}  ");
                }
            }
        }

        public static void testiscontactexist(int id)
        {
            if (clsContacts.iscontactexist(id))
            {
                Console.WriteLine("yes contact is exist");
            }
            else
            {
                Console.WriteLine("contact is noy exist");
            }

        }
        static void Main(string[] args)
        {

            //  testfind(2);
            //testaddnewcontact();
            // testdelete(21);
            // testupdatecontact(21);
            testlist();
            // testiscontactexist(2);
        }
    }
}
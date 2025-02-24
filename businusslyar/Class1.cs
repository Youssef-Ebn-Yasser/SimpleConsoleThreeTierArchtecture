using DataLayer;
using System;
using System.Data;


namespace BusinessLayer
{
    public class clsContacts
    {
        public int ContactId { get; set; }
        public string Firstname { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public int countryid { get; set; }
        public string address { get; set; }
        public DateTime dateofbirth { get; set; }
        public string imagepath { get; set; }


        clsContacts(int id, string fname, string lname, string email, string phone,
            string address, int countryid, DateTime dateofbirth, string imagepath)
        {
            this.ContactId = id;
            this.Firstname = fname;
            this.lastName = lname;
            this.email = email;
            this.phone = phone;
            this.address = address;
            this.countryid = countryid;
            this.dateofbirth = dateofbirth;
            this.imagepath = imagepath;
        }
        public clsContacts()
        {
            this.ContactId = -1;
            this.Firstname = "";
            this.lastName = "";
            this.email = "";
            this.phone = "";
            this.address = "";
            this.countryid = 0;
            this.dateofbirth = DateTime.Now;
            this.imagepath = "";
        }

        public static clsContacts find(int id)
        {
            string Firstname = " ", lastName = " ", email = " ", phone = " ", address = " ", imagepath = " ";
            int countryid = 0;
            DateTime dateofbirth = DateTime.Now;
            if (clsDataContacts.FindDataContacts(id, ref Firstname, ref lastName
            , ref email, ref phone, ref address, ref countryid, ref dateofbirth, ref imagepath))
            {
                return new clsContacts(id, Firstname, lastName, email, phone, address, countryid, dateofbirth, imagepath);
            }
            else
            {
                return null;
            }
        }
        public static bool addnewcontacts(clsContacts contact)
        {
            int x = clsDataContacts.AddContact(contact.Firstname, contact.lastName, contact.phone, contact.address,
                contact.countryid, contact.email, contact.imagepath, contact.dateofbirth);
            if (x == 1)
            {
                return true;
            }
            return false;
        }

        public static bool contactDelete(int id)
        {
            int x = clsDataContacts.DeleteContact(id);
            if (x != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool contactUpdate(clsContacts contact)
        {
            int x = clsDataContacts.UpdateContact(contact.ContactId, contact.Firstname, contact.lastName, contact.email,
                contact.phone, contact.address, contact.countryid, contact.dateofbirth, contact.imagepath);
            if (x != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static DataTable showallcontacts()
        {
            return clsDataContacts.AllContacts();
        }

        public static bool iscontactexist(int id)
        {
            return clsDataContacts.ContactExist(id);
        }
    }
}
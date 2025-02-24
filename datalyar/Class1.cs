using System;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer
{
    public class clsDataContacts
    {
        private static string connectionstring = "server=DESKTOP-AV50QCU\\MSSQLSERVER01;database=contactsdb;user id=sa;password=123456;";
        public static bool FindDataContacts(int id, ref string fname, ref string lname
            , ref string email, ref string phone, ref string address, ref int countryid, ref DateTime dateofbirth, ref string imagepath)
        {
            bool isfound = false;

            SqlConnection connection = new SqlConnection(connectionstring);
            string query = "select * from contacts where contactid=@contactid";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@contactid", id);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    fname = (string)reader["firstname"];
                    lname = (string)reader["lastname"];
                    phone = (string)reader["phone"];
                    address = (string)reader["address"];
                    email = (string)reader["email"];
                    countryid = (int)reader["countryid"];
                    dateofbirth = (DateTime)reader["dateofbirth"];
                    imagepath = (string)reader["imagepath"];
                }
                reader.Close();
                isfound = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("error", ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return isfound;
        }

        public static int AddContact(string firstname, string lastname, string phone, string address,
                int countryid, string email, string imagepath, DateTime dateofbirth)
        {
            SqlConnection connection = new SqlConnection(connectionstring);
            string query = "insert into contacts(firstname,lastname,phone,address,countryid,email,imagepath,dateofbirth)" +
                "values (@firstname,@lastname,@phone,@address,@countryid,@email,@imagepath,@dateofbirth)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@firstname", firstname);
            command.Parameters.AddWithValue("@lastname", lastname);
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@phone", phone);
            command.Parameters.AddWithValue("@dateofbirth", dateofbirth);
            command.Parameters.AddWithValue("@countryid", countryid);
            command.Parameters.AddWithValue("@imagepath", imagepath);
            command.Parameters.AddWithValue("@address", address);
            int x = 0;
            try
            {
                connection.Open();
                int roweffected = command.ExecuteNonQuery();
                if (roweffected != 0)
                {
                    x = 1;
                }
                else
                {
                    x = 0;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("error", ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return x;
        }


        public static int DeleteContact(int id)
        {
            SqlConnection connection = new SqlConnection(connectionstring);
            string query = "delete from contacts where contactid=@contactid";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@contactid", id);
            int y = 0;
            try
            {
                connection.Open();
                int effectedrow = command.ExecuteNonQuery();
                if (effectedrow != 0)
                {
                    y = 1;
                }
                else
                {
                    y = 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("error", ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return y;
        }

        public static int UpdateContact(int id, string fname, string lname
            , string email, string phone, string address, int countryid, DateTime dateofbirth, string imagepath)
        {
            SqlConnection connection = new SqlConnection(connectionstring);

            string query = @"update contacts set 
                                                    firstname=@fname,
                                                    lastname=@lname,
                                                    email=@email," +
                                                   "phone=@phone," +
                                                   "address=@address," +
                                                   "countryid=@countryid," +
                                                   "dateofbirth=@dateofbirth," +
                                                   "imagepath=@imagepath " +
                                                   "where contactid=@id";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@lname", lname);
            command.Parameters.AddWithValue("@fname", fname);
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@phone", phone);
            command.Parameters.AddWithValue("@address", address);
            command.Parameters.AddWithValue("@dateofbirth", dateofbirth);
            command.Parameters.AddWithValue("@countryid", countryid);
            if (imagepath != "")
            {
                command.Parameters.AddWithValue("@imagepath", imagepath);
            }
            else
            {
                command.Parameters.AddWithValue("@imagepath", System.DBNull.Value);
            }


            int y = 0;
            try
            {
                connection.Open();
                int roweffected = command.ExecuteNonQuery();
                if (roweffected > 0)
                {
                    y = roweffected;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("error", ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return y;
        }

        public static DataTable AllContacts()
        {
            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "select * from contacts";

            SqlCommand command = new SqlCommand(query, connection);

            DataTable dt = new DataTable();
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("error", ex.Message);

            }
            finally
            {
                connection.Close();
            }
            return dt;
        }

        public static bool ContactExist(int id)
        {
            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "select found=1 from contacts where contactid=@id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);
            bool found = false;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                found = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("error", ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return found;
        }
    }
}
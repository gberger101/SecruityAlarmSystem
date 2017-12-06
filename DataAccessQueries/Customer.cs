using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace DataAccessQueries
{
    public class Customer : baseDataAccess
    {
        //NOTE: TODO Should be in ModelCustomer but didn't have time to put it there.

        #region Declarations

        //NOTE: Not all get; set; properties would be public.  But for speed they have been made public.
        //NOTE: Not all get; set; properties would be public.  But for speed they have been made public.
        public string ConsoleID { get; set; } // Client probably has >1 consoles (front-door, back-door, etc.)
        public string ClientID { get; set; }
        public string UserID { get; set; }

        #endregion


        #region Constructors

        public Customer()
        {

        }

        #endregion

        #region Queries

        public Customer getClientIDfromUserID(string p_UserID)
        {
            var customers = ReadJSONFile();
            foreach (Customer customr in customers) // TODO Convert to LINQ 
            {
                if (customr.UserID == p_UserID)
                {
                    return customr;
                }
            }
            return new Customer();
        }

        public bool getClientIDfromPhoneNumber(string p_PhoneNumber)
        {
            // Just add PhoneNumber (property) to class and does not effect anything 
            return true;
        }

        public Customer getClientIDfromConsoleID(string p_ConsoleID)
        {
            var customers = ReadJSONFile();
            foreach (Customer customr in customers) // TODO Convert to LINQ 
            {
                if (customr.ConsoleID == p_ConsoleID)
                {
                    return customr;
                }
            }
            return new Customer();
        }

        public Customer getClientIDfromClientID(string p_ClientID)
        {
            var customers = ReadJSONFile();
            foreach (Customer customr in customers) // TODO Convert to LINQ 
            {
                if (customr.ClientID == p_ClientID)
                {
                    return customr;
                }
            }
            return new Customer();
        }


        #endregion

        #region In REAL life this would be in DataAccessCore 

        /// <summary>
        /// NOTE: TODO In REAL life this would be in DataAccessCore
        /// Never directly call DataAccessCore from anywhere but DataAccessQueries
        /// </summary>
        public List<Customer> ReadJSONFile()
        {
            try
            {
                string json = File.ReadAllText(@"c:\temp\Customers.JSON");
                var customers = JsonConvert.DeserializeObject<List<Customer>>(json);
                return customers;
            }
            catch (System.Exception ex)
            {
                throw; // TODO error logging goes here instead of throw
            }
            return new List<Customer>();
        }

        #endregion


    }

}

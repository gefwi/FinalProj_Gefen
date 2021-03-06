using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;

namespace FinalProj_Gefen.Models.DAL
{
    public class DBServices
    {
      
            public SqlDataAdapter da;
            public DataTable dt;


        //--------------------------------------------------------------------------------------------------
        // This method creates a connection to the database according to the connectionString name in the web.config 
        //--------------------------------------------------------------------------------------------------
        public SqlConnection connect(String conString)
        {

            // read the connection string from the configuration file
            string cStr = WebConfigurationManager.ConnectionStrings[conString].ConnectionString;
            SqlConnection con = new SqlConnection(cStr);
            con.Open();
            return con;
        }

        //---------------------------------------------------------------------------------
        // Create the SqlCommand
        //---------------------------------------------------------------------------------
        private SqlCommand CreateCommand(String CommandSTR, SqlConnection con)
            {

                SqlCommand cmd = new SqlCommand(); // create the command object

                cmd.Connection = con;              // assign the connection to the command object

                cmd.CommandText = CommandSTR;      // can be Select, Insert, Update, Delete 

                cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

                cmd.CommandType = System.Data.CommandType.Text; // the type of the command, can also be stored procedure

                return cmd;
            }

            // TODO : Add a DeleteFlight method
            // TODO : Add a BuildFlightDeleteCommand method

            //--------------------------------------------------------------------------------------------------
            // This method inserts a flight to the student table 
            //--------------------------------------------------------------------------------------------------
            public int Insert(Dogs dog)
            {

                SqlConnection con;
                SqlCommand cmd;

                try
                {
                    con = connect("DBConnectionString"); // create the connection
                }
                catch (Exception ex)
                {
                    // write to log
                    throw (ex);
                }

                String cStr = BuildInsertCommand(dog);      // helper method to build the insert string

                cmd = CreateCommand(cStr, con);             // create the command

                try
                {
                    int numEffected = cmd.ExecuteNonQuery(); // execute the command
                    return numEffected;
                }
                catch (Exception ex)
                {
                    // write to log
                    throw (ex);
                }

                finally
                {
                    if (con != null)
                    {
                        // close the db connection
                        con.Close();
                    }
                }

            }

            //--------------------------------------------------------------------
            // Build the Insert command String
            //--------------------------------------------------------------------
            private String BuildInsertCommand(Dogs dog)
            {
                String command;

                StringBuilder sb = new StringBuilder();
                // use a string builder to create the dynamic string
                sb.AppendFormat("Values('{0}', '{1}','{2}', '{3}','{4}','{5}')", dog.Breed, dog.Name, dog.Age, dog.Image, dog.City, dog.Id);
                String prefix = "INSERT INTO DogsTB" + "([BREED], [NAME], AGE, IMAGE, CITY, ID)";
                command = prefix + sb.ToString();

                return command;
            }


            //--------------------------------------------------------------------
            // Read flights using a DataReader
            //--------------------------------------------------------------------

            public List<Dogs> getByCity(string city)
            {
                SqlConnection con = null;
                List<Dogs> flightList = new List<Dogs>();

                try
                {
                    con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                    String selectSTR = "SELECT * FROM DogsTB where DogsTB.CITY=" +"'"+city+"'";
                    SqlCommand cmd = new SqlCommand(selectSTR, con);

                    // get a reader
                    SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                    while (dr.Read())
                    {   // Read till the end of the data into a row
                        Dogs f = new Dogs();

                        f.Breed = (string)dr["BREED"];
                        f.Name = (string)dr["NAME"];                      
                        f.Age = Convert.ToInt32(dr["AGE"]);
                    f.Image = (string)dr["IMAGE"];
                    f.City = (string)dr["CITY"];
                    f.Id = Convert.ToInt32(dr["ID"]);

                    flightList.Add(f);
                    }

                    return flightList;
                }
                catch (Exception ex)
                {
                    // write to log
                    throw (ex);
                }
                finally
                {
                    if (con != null)
                    {
                        con.Close();
                    }

                }

            }


        }
    }
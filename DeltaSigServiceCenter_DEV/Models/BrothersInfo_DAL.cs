using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DeltaSigServiceCenter_DEV.Models
{
    public class BrothersInfo_DAL
    {
        private SqlDataReader dataReader;

        public List<Brother> getBrothersHours()
        {
            List<Brother> brothersHoursList = new List<Brother>();

            using (SqlConnection conn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = c:\users\grant folgate\documents\visual studio 2015\Projects\DeltaSigServiceCenter_DEV\DeltaSigServiceCenter_DEV\App_Data\DeltaSigServiceData.mdf; Integrated Security = True"))
            {
                SqlCommand cmd = new SqlCommand("ShowTotalsForAll", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                dataReader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        string s_brotherID = dataReader[0].ToString();
                        string fullName = dataReader[1].ToString();
                        string classStanding = dataReader[2].ToString();
                        string email = dataReader[3].ToString();
                        string phoneNum = dataReader[4].ToString();
                        string s_totHours = dataReader[5].ToString();

                        int brotherID = Convert.ToInt32(s_brotherID);
                        int totHours = Convert.ToInt32(s_totHours);

                        brothersHoursList.Add(new Brother
                        {
                            BrotherID = brotherID,
                            FullName = fullName,
                            NumOfHours = totHours,
                            ClassStanding = classStanding,
                            Email = email,
                            PhoneNum = phoneNum
                        });
                    }
                }
            }
            return brothersHoursList;
        }

        public bool checkForExistingBro(Brother potentialBrother)
        {
            string emailAddressCheck = potentialBrother.Email;
            string emailHolder = "";

            using (SqlConnection conn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = c:\users\grant folgate\documents\visual studio 2015\Projects\DeltaSigServiceCenter_DEV\DeltaSigServiceCenter_DEV\App_Data\DeltaSigServiceData.mdf; Integrated Security = True"))
            {
                SqlCommand qry = new SqlCommand("CheckForExistingBrother", conn);
                qry.CommandType = System.Data.CommandType.StoredProcedure;
                qry.Parameters.Add("@Email", System.Data.SqlDbType.NVarChar);
                qry.Parameters["@Email"].Value = emailAddressCheck;
                conn.Open();
                dataReader = qry.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        //should return one item of information (Brother's name)
                        emailHolder = dataReader[0].ToString();
                    }
                }

            }

            if (emailHolder == emailAddressCheck)
            {
                return false;
            }
            else
            {
                if (addNewBrother(potentialBrother) == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        
        public bool addNewBrother(Brother newBrother)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = c:\users\grant folgate\documents\visual studio 2015\Projects\DeltaSigServiceCenter_DEV\DeltaSigServiceCenter_DEV\App_Data\DeltaSigServiceData.mdf; Integrated Security = True"))
            {
                SqlCommand cmd = new SqlCommand("AddNewBrother", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@FullName", System.Data.SqlDbType.NVarChar);
                cmd.Parameters.Add("@Class", System.Data.SqlDbType.NVarChar);
                cmd.Parameters.Add("@Email", System.Data.SqlDbType.NVarChar);
                cmd.Parameters.Add("@PhoneNum", System.Data.SqlDbType.NVarChar);
                cmd.Parameters["@FullName"].Value = newBrother.FullName;
                cmd.Parameters["@Class"].Value = newBrother.ClassStanding;
                cmd.Parameters["@Email"].Value = newBrother.Email;
                cmd.Parameters["@PhoneNum"].Value = newBrother.PhoneNum;
                conn.Open();

                try
                {
                    //attempt to insert into DB
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    return true;
                }
                catch (Exception e)
                {
                    //close the connection ASAP
                    conn.Close();
                    //non-query exception error, can't insert
                    e.GetBaseException();
                    return false;
                }
            }
        }
    }
}
// <copyright file="RequestProcessor.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>

namespace WebApplication1.Value
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Http;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json.Schema;
    using WebApplication1.Models;

    /// <summary>
    ///   <br />
    /// </summary>
    public class ValueProcessor : IValueProcessor
    {
      
        public List<AdminModel> GetAdmindetails()
        {
            try
            {
                // Need to fetch request under same manager  for which user is spn owner.
                //var userManager = Task.Run(async () => await this.graphProcessor.GetManagerEmail(username)).Result;
                string ConnectionString = @"Server=tcp:cera.database.windows.net,1433;Initial Catalog=db_Exam;Persist Security Info=False;User ID=ceraadmin;Password=Cera@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                //Create the SqlConnection object
                IEnumerable<AdminModel> second = Enumerable.Empty<AdminModel>();
                List<AdminModel> resultList = new List<AdminModel>();
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    //Create the SqlCommand object by passing the stored procedure name and connection object as parameters
                    SqlCommand cmd = new SqlCommand("Sp_User", connection)
                    {
                        //Specify the command type as Stored Procedure
                        CommandType = CommandType.StoredProcedure
                    };
                    //Open the Connection
                    connection.Open();
                    //Execute the command i.e. Executing the Stored Procedure using ExecuteReader method
                    //SqlDataReader requires an active and open connection
                    SqlDataReader sdr = cmd.ExecuteReader();
                    //Read the data from the SqlDataReader 
                    //Read() method will returns true as long as data is there in the SqlDataReader
                    while (sdr.Read())
                    {
                        AdminModel model = new AdminModel
                        {
                            Id = sdr["Id"].ToString(),
                            Name = sdr["Name"].ToString(),
                            Technologies = sdr["Technologies"].ToString(),
                            TechnologiesPercentage = sdr["TechnologiesPercentage"].ToString(),
                            Complexity = sdr["Complexity"].ToString(),
                            NoOfQuestions = sdr["NoOfQuestions"].ToString(),
                            TimeDuration = sdr["TimeDuration"].ToString(),
                            Internetreqirement = bool.Parse(sdr["Internetreqirement"].ToString()),
                            UploadDocument = sdr["UploadDocument"].ToString(),
                            PassPercentage = sdr["PassPercentage"].ToString(),
                            CreatedBy = sdr["CreatedBy"].ToString(),
                            // Set other properties as needed
                        };

                        resultList.Add(model);                      
                        //Accessing the data using the string key as index
                        //Console.WriteLine(sdr["Id"] + ",  " + sdr["Name"] + ",  " + sdr["Email"] + ",  " + sdr["Mobile"]);
                        //Accessing the data using the integer index position as key
                        //Console.WriteLine(sdr[0] + ",  " + sdr[1] + ",  " + sdr[2] + ",  " + sdr[3]);
                    }
                }
                
                

                return resultList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<UserModel> GetExamDetails()
        {
            try
            {
                // Need to fetch request under same manager  for which user is spn owner.
                //var userManager = Task.Run(async () => await this.graphProcessor.GetManagerEmail(username)).Result;
                string ConnectionString = @"Server=tcp:cera.database.windows.net,1433;Initial Catalog=db_Exam;Persist Security Info=False;User ID=ceraadmin;Password=Cera@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                //Create the SqlConnection object
                IEnumerable<UserModel> second = Enumerable.Empty<UserModel>();
                List<UserModel> resultList = new List<UserModel>();
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    //Create the SqlCommand object by passing the stored procedure name and connection object as parameters
                    SqlCommand cmd = new SqlCommand("Sp_ExamDetails", connection)
                    {
                        //Specify the command type as Stored Procedure
                        CommandType = CommandType.StoredProcedure
                    };
                    //Open the Connection
                    connection.Open();
                    //Execute the command i.e. Executing the Stored Procedure using ExecuteReader method
                    //SqlDataReader requires an active and open connection
                    SqlDataReader sdr = cmd.ExecuteReader();
                    //Read the data from the SqlDataReader 
                    //Read() method will returns true as long as data is there in the SqlDataReader
                    while (sdr.Read())
                    {
                        UserModel model = new UserModel
                        {
                            Id = sdr["ID"].ToString(),
                            ExamId = sdr["Exam"].ToString(),
                            ExamName = sdr["ExamName"].ToString(),
                            Exambookeddate = DateTime.Parse(sdr["Exambookeddate"].ToString()),
                            Result = sdr["Result"].ToString(),
                            ExamResonse = sdr["ExamResonse"].ToString(),
                            UserAnswers = sdr["UserAnswers"].ToString(),
                            CreatedBy = sdr["CreatedBy"].ToString(),
                            // Set other properties as needed
                        };

                        resultList.Add(model);
                        //Accessing the data using the string key as index
                        //Console.WriteLine(sdr["Id"] + ",  " + sdr["Name"] + ",  " + sdr["Email"] + ",  " + sdr["Mobile"]);
                        //Accessing the data using the integer index position as key
                        //Console.WriteLine(sdr[0] + ",  " + sdr[1] + ",  " + sdr[2] + ",  " + sdr[3]);
                    }
                }



                return resultList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<AdminexamModel> GetExamDropdown()
        {
            try
            {
                // Need to fetch request under same manager  for which user is spn owner.
                //var userManager = Task.Run(async () => await this.graphProcessor.GetManagerEmail(username)).Result;
                string ConnectionString = @"Server=tcp:cera.database.windows.net,1433;Initial Catalog=db_Exam;Persist Security Info=False;User ID=ceraadmin;Password=Cera@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                //Create the SqlConnection object
                IEnumerable<AdminexamModel> second = Enumerable.Empty<AdminexamModel>();
                List<AdminexamModel> resultList = new List<AdminexamModel>();
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    //Create the SqlCommand object by passing the stored procedure name and connection object as parameters
                    SqlCommand cmd = new SqlCommand("Sp_ExamUser", connection)
                    {
                        //Specify the command type as Stored Procedure
                        CommandType = CommandType.StoredProcedure
                    };
                    //Open the Connection
                    connection.Open();
                    //Execute the command i.e. Executing the Stored Procedure using ExecuteReader method
                    //SqlDataReader requires an active and open connection
                    SqlDataReader sdr = cmd.ExecuteReader();
                    //Read the data from the SqlDataReader 
                    //Read() method will returns true as long as data is there in the SqlDataReader
                    while (sdr.Read())
                    {
                        AdminexamModel model = new AdminexamModel
                        {
                            Id = sdr["Id"].ToString(),
                            Name = sdr["Name"].ToString(),                           
                            // Set other properties as needed
                        };

                        resultList.Add(model);                      
                        //Accessing the data using the string key as index
                        //Console.WriteLine(sdr["Id"] + ",  " + sdr["Name"] + ",  " + sdr["Email"] + ",  " + sdr["Mobile"]);
                        //Accessing the data using the integer index position as key
                        //Console.WriteLine(sdr[0] + ",  " + sdr[1] + ",  " + sdr[2] + ",  " + sdr[3]);
                    }
                }
                
                

                return resultList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }   
        
        public List<AdminModel> GetUserbyid(int id)
        {
            try
            {
                // Need to fetch request under same manager  for which user is spn owner.
                //var userManager = Task.Run(async () => await this.graphProcessor.GetManagerEmail(username)).Result;
                string ConnectionString = @"Server=tcp:cera.database.windows.net,1433;Initial Catalog=db_Exam;Persist Security Info=False;User ID=ceraadmin;Password=Cera@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                //Create the SqlConnection object
                IEnumerable<AdminModel> second = Enumerable.Empty<AdminModel>();
                List<AdminModel> resultList = new List<AdminModel>();
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    //Create the SqlCommand object by passing the stored procedure name and connection object as parameters
                    SqlCommand cmd = new SqlCommand("Sp_UserbyId", connection)
                    {
                        //Specify the command type as Stored Procedure
                        CommandType = CommandType.StoredProcedure
                    };
                    //Open the Connection
                    cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.VarChar) { Value = id });

                    connection.Open();
                    //Execute the command i.e. Executing the Stored Procedure using ExecuteReader method
                    //SqlDataReader requires an active and open connection
                    SqlDataReader sdr = cmd.ExecuteReader();
                    //Read the data from the SqlDataReader 
                    //Read() method will returns true as long as data is there in the SqlDataReader
                    while (sdr.Read())
                    {
                        AdminModel model = new AdminModel
                        {
                            Id = sdr["Id"].ToString(),
                            Name = sdr["Name"].ToString(),
                            Technologies = sdr["Technologies"].ToString(),
                            TechnologiesPercentage = sdr["TechnologiesPercentage"].ToString(),
                            Complexity = sdr["Complexity"].ToString(),
                            NoOfQuestions = sdr["NoOfQuestions"].ToString(),
                            TimeDuration = sdr["TimeDuration"].ToString(),
                            Internetreqirement = bool.Parse(sdr["Internetreqirement"].ToString()),
                            UploadDocument = sdr["UploadDocument"].ToString(),
                            PassPercentage = sdr["PassPercentage"].ToString(),
                            CreatedBy = sdr["CreatedBy"].ToString(),
                        // Set other properties as needed
                        };

                        resultList.Add(model);                      
                        //Accessing the data using the string key as index
                        //Console.WriteLine(sdr["Id"] + ",  " + sdr["Name"] + ",  " + sdr["Email"] + ",  " + sdr["Mobile"]);
                        //Accessing the data using the integer index position as key
                        //Console.WriteLine(sdr[0] + ",  " + sdr[1] + ",  " + sdr[2] + ",  " + sdr[3]);
                    }
                }
                
                

                return resultList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public void CreateorUpdateuser(AdminModel model)
        {
            try
            {
                // Need to fetch request under same manager  for which user is spn owner.
                //var userManager = Task.Run(async () => await this.graphProcessor.GetManagerEmail(username)).Result;
                string ConnectionString = @"Server=tcp:cera.database.windows.net,1433;Initial Catalog=db_Exam;Persist Security Info=False;User ID=ceraadmin;Password=Cera@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                //Create the SqlConnection object
                IEnumerable<AdminModel> second = Enumerable.Empty<AdminModel>();
                List<AdminModel> resultList = new List<AdminModel>();
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    //Create the SqlCommand object by passing the stored procedure name and connection object as parameters
                    SqlCommand cmd = new SqlCommand("Sp_CreateUser", connection)
                    {
                        //Specify the command type as Stored Procedure
                        CommandType = CommandType.StoredProcedure
                    };
                    //Open the Connection
                    cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int) { Value = int.Parse(model.Id) });
                    cmd.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar) { Value = model.Name });
                    cmd.Parameters.Add(new SqlParameter("@Technologies", SqlDbType.NVarChar) { Value = model.Technologies });
                    cmd.Parameters.Add(new SqlParameter("@TechnologiesPercentage", SqlDbType.NVarChar) { Value = model.TechnologiesPercentage });
                    cmd.Parameters.Add(new SqlParameter("@Complexity", SqlDbType.NVarChar) { Value = model.Complexity});
                    cmd.Parameters.Add(new SqlParameter("@NoOfQuestions", SqlDbType.Int) { Value = int.Parse(model.NoOfQuestions) });
                    cmd.Parameters.Add(new SqlParameter("@TimeDuration", SqlDbType.Int) { Value = int.Parse(model.TimeDuration) });
                    cmd.Parameters.Add(new SqlParameter("@Internetreqirement", SqlDbType.Bit) { Value = model.Internetreqirement });
                    cmd.Parameters.Add(new SqlParameter("@UploadDocument", SqlDbType.NVarChar) { Value = model.UploadDocument });
                    cmd.Parameters.Add(new SqlParameter("@PassPercentage", SqlDbType.Int) { Value = int.Parse(model.PassPercentage) });
                    cmd.Parameters.Add(new SqlParameter("@CreatedBy", SqlDbType.DateTime) { Value = DateTime.UtcNow });
                    
                    connection.Open();
                    //Execute the command i.e. Executing the Stored Procedure using ExecuteReader method
                    //SqlDataReader requires an active and open connection
                    cmd.ExecuteNonQuery();
                    //Read the data from the SqlDataReader 
                    //Read() method will returns true as long as data is there in the SqlDataReader
                  
                }             
                

                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void CreateorUpdateExamuser(UserModel model)
        {
            try
            {
                // Need to fetch request under same manager  for which user is spn owner.
                //var userManager = Task.Run(async () => await this.graphProcessor.GetManagerEmail(username)).Result;
                string ConnectionString = @"Server=tcp:cera.database.windows.net,1433;Initial Catalog=db_Exam;Persist Security Info=False;User ID=ceraadmin;Password=Cera@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                //Create the SqlConnection object
                IEnumerable<UserModel> second = Enumerable.Empty<UserModel>();
                List<UserModel> resultList = new List<UserModel>();
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    //Create the SqlCommand object by passing the stored procedure name and connection object as parameters
                    SqlCommand cmd = new SqlCommand("Sp_CreateExamUser", connection)
                    {
                        //Specify the command type as Stored Procedure
                        CommandType = CommandType.StoredProcedure
                    };
                    //Open the Connection
                    cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int) { Value = int.Parse(model.Id) });
                    cmd.Parameters.Add(new SqlParameter("@ExamId", SqlDbType.NVarChar) { Value = model.ExamId });
                    cmd.Parameters.Add(new SqlParameter("@ExamName", SqlDbType.NVarChar) { Value = model.ExamName });
                    cmd.Parameters.Add(new SqlParameter("@Exambookeddate", SqlDbType.DateTime) { Value = model.Exambookeddate});
                    cmd.Parameters.Add(new SqlParameter("@Result", SqlDbType.NVarChar) { Value = model.Result });
                    cmd.Parameters.Add(new SqlParameter("@ExamResonse", SqlDbType.NVarChar) { Value = model.ExamResonse });
                    cmd.Parameters.Add(new SqlParameter("@UserAnswers", SqlDbType.NVarChar) { Value = model.UserAnswers });
                    cmd.Parameters.Add(new SqlParameter("@ExamEndTime", SqlDbType.DateTime) { Value = model.ExamEndTime });
                    cmd.Parameters.Add(new SqlParameter("@CreatedBy", SqlDbType.DateTime) { Value = DateTime.UtcNow });

                    connection.Open();
                    //Execute the command i.e. Executing the Stored Procedure using ExecuteReader method
                    //SqlDataReader requires an active and open connection
                    cmd.ExecuteNonQuery();
                    //Read the data from the SqlDataReader 
                    //Read() method will returns true as long as data is there in the SqlDataReader

                }



            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DeleteUserbyid(int Id)
            {
            try
            {
                // Need to fetch request under same manager  for which user is spn owner.
                //var userManager = Task.Run(async () => await this.graphProcessor.GetManagerEmail(username)).Result;
                string ConnectionString = @"Server=tcp:cera.database.windows.net,1433;Initial Catalog=db_Exam;Persist Security Info=False;User ID=ceraadmin;Password=Cera@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                //Create the SqlConnection object
                IEnumerable<AdminModel> second = Enumerable.Empty<AdminModel>();
                List<AdminModel> resultList = new List<AdminModel>();
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    //Create the SqlCommand object by passing the stored procedure name and connection object as parameters
                    SqlCommand cmd = new SqlCommand("Sp_DeleteUserbyId", connection)
                    {
                        //Specify the command type as Stored Procedure
                        CommandType = CommandType.StoredProcedure
                    };
                    //Open the Connection
                    cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int) { Value = Id });                  
                    connection.Open();
                    //Execute the command i.e. Executing the Stored Procedure using ExecuteReader method
                    //SqlDataReader requires an active and open connection
                    cmd.ExecuteNonQuery();
                    //Read the data from the SqlDataReader 
                    //Read() method will returns true as long as data is there in the SqlDataReader
                  
                }             
                

                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <inheritdoc/>
      
    }
}
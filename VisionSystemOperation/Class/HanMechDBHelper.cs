using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using VisionSystemOperation.Device;

namespace VisionSystemOperation.Class
{
    public class HanMechDBHelper
    {
        private SqlConnection dbConnection = null;
        private string connectionString = string.Empty;

        // db connection 
        public SqlConnection Connection()
        {
            if (dbConnection == null || dbConnection.State != System.Data.ConnectionState.Open)
            {   
                dbConnection = new SqlConnection(connectionString);
                dbConnection.Open();
            }
            return dbConnection;
        }

        //connection string set at the begening 
        public HanMechDBHelper(string connStr)
        {
            // OPEN AND RETAIN DB CONNECTION HERE
            connectionString = connStr;
            SqlConnection conn = new SqlConnection(connectionString);
        }

        #region InspectionResult
        // Save data (add or update) inspection result
        public bool SaveInspectionResult(InspectionResultDB inspectionResult)
        {
            try
            {
                string query = "UPDATE InspectionResults SET TactTime = @TactTime, Average = @Average, CarName = @CarName, " +
                               "Result = @Result, LastModifyDate = @LastModifyDate, CameraNum = @CameraNum , ImgPath = @ImgPath , Shift = @Shift " +
                               "WHERE InspectionResultID = @InspectionResultID " +
                               "IF @@ROWCOUNT = 0 " +
                               "INSERT INTO InspectionResults (TactTime, Average, CarName, Result, CreateDate, LastModifyDate, CameraNum, ImgPath, Shift) " +
                               "VALUES (@TactTime, @Average, @CarName, @Result, @CreateDate, @LastModifyDate, @CameraNum, @ImgPath, @Shift)";

                using (SqlCommand sqlCommand = new SqlCommand(query, Connection()))
                {
                    sqlCommand.Parameters.AddWithValue("@InspectionResultID", inspectionResult.InspectionResultID);
                    sqlCommand.Parameters.AddWithValue("@TactTime", inspectionResult.TactTime);
                    sqlCommand.Parameters.AddWithValue("@Average", inspectionResult.Average);
                    sqlCommand.Parameters.AddWithValue("@CarName", inspectionResult.CarName);
                    sqlCommand.Parameters.AddWithValue("@Result", inspectionResult.Result);
                    sqlCommand.Parameters.AddWithValue("@CreateDate", inspectionResult.CreateDate);
                    sqlCommand.Parameters.AddWithValue("@LastModifyDate", inspectionResult.LastModifyDate);
                    sqlCommand.Parameters.AddWithValue("@CameraNum", inspectionResult.CameraNum);
                    sqlCommand.Parameters.AddWithValue("@ImgPath", inspectionResult.ImgPath);
                    sqlCommand.Parameters.AddWithValue("@Shift", inspectionResult.Shift);
                    sqlCommand.CommandType = CommandType.Text;
                    return sqlCommand.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Machine.logger.WriteAsync(eLogType.ERROR, "SaveInspectionResult: " + ex.ToString());
                return false;
            }
        }

        // Get all inspection results
        public List<InspectionResultDB> GetInspectionResults(DateTime? fromDateTime = null, DateTime? toDateTime = null, string vin = "", string okng = "ALL", string[] carInfo = null, string shift="")
        {
            List<InspectionResultDB> inspectionResults = new List<InspectionResultDB>();

            string dateFilter = null, vinFilter = null, carInfoFilter = null, shiftFilter = null;
            string mod = "", eng = "", opt = "";

            DateTime startDate = fromDateTime ?? Machine.startDate;
            DateTime endDate = toDateTime ?? DateTime.Now;

            string okngFilter = okng == "ALL" ? "" : " AND Result = @okng ";

            if (vin != "")
            {
                vinFilter = vin != "" ? " WHERE VinID = @vin" : " ";
            }
            else
            {
                dateFilter = " WHERE CreateDate BETWEEN @startDate AND @endDate ";
            }

            if (carInfo != null)
            {
                if (carInfo[0] != "")
                {
                    carInfoFilter = " AND CarName like @mod ";
                }
                
                if (carInfo[1] != "")
                {
                    carInfoFilter += " AND CarName like @eng ";
                }

                if (carInfo[2] != "")
                {
                    carInfoFilter += " AND CarName like @opt ";
                }


                mod = carInfo[0] == "" ? "" : "%" + carInfo[0] + "%";
                eng = carInfo[1] == "" ? "" : "%" + carInfo[1] + "%";
                opt = carInfo[2] == "" ? "" : "%" + carInfo[2] + "%";
            }

            if(shift != "")
            {
                shift = shift == "DAY" || shift == "D" ? "D" : "N";
                shiftFilter = " AND Shift = @shift ";
                if (shift == "N")
                {
                    shiftFilter = "";
                    endDate = endDate.AddDays(+1);
                    startDate = startDate.Add(System.TimeSpan.Parse(Machine.config.setup.shiftProperty.NightShiftStart));
                    endDate = endDate.Add(System.TimeSpan.Parse(Machine.config.setup.shiftProperty.NightShiftEnd));
                }
            }

            string orderby = " order by TactTime desc ";
            
            try
            {
                string query = "SELECT InspectionResultID, TactTime, Average, CarName, Result, CreateDate, LastModifyDate, CameraNum, VinID, ImgPath, Shift FROM " +
                    "InspectionResults" + dateFilter + vinFilter + okngFilter + carInfoFilter + shiftFilter + orderby;
                using (SqlCommand command = new SqlCommand(query, Connection()))
                {
                    command.Parameters.AddWithValue("@startDate", startDate);
                    command.Parameters.AddWithValue("@endDate", endDate);
                    command.Parameters.AddWithValue("@vin", vin);
                    command.Parameters.AddWithValue("@okng", okng);
                    command.Parameters.AddWithValue("@mod", mod);
                    command.Parameters.AddWithValue("@eng", eng);
                    command.Parameters.AddWithValue("@opt", opt);
                    command.Parameters.AddWithValue("@shift", shift);
                    command.Parameters.AddWithValue("@shiftStart", Machine.config.setup.shiftProperty.NightShiftStart);
                    command.Parameters.AddWithValue("@shiftEnd", Machine.config.setup.shiftProperty.NightShiftEnd);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            InspectionResultDB inspectionResult = new InspectionResultDB()
                            {
                                InspectionResultID = reader.GetInt32(0),
                                TactTime = reader.GetDateTime(1),
                                Average = reader.GetDouble(2),
                                CarName = reader.GetString(3),
                                Result = reader.GetString(4),
                                CreateDate = reader.GetDateTime(5),
                                LastModifyDate = reader.GetDateTime(6),
                                CameraNum = reader.GetInt32(7) + 1,
                                VinID = reader.GetString(8),
                                ImgPath = reader.GetString(9),
                                Shift = reader.GetString(10)=="D"?"DAY":"NIGHT"
                            };
                            inspectionResults.Add(inspectionResult);
                        }
                        return inspectionResults;
                    }
                }
            }
            catch (Exception ex)
            {
                Machine.logger.WriteAsync(eLogType.ERROR, "GetInspectionResults: " + ex.ToString());
                return null;
            }
        }

        // Get inspection result by ID
        public InspectionResultDB GetInspectionResultById(int inspectionResultId)
        {
            InspectionResultDB inspectionResult = null;
            try
            {
                string query = $"SELECT InspectionResultID, TactTime, Average, CarName, Result, CreateDate, LastModifyDate, CameraNum, VinID, ImgPath, Shift FROM InspectionResults WHERE InspectionResultID = {inspectionResultId}";
                using (SqlCommand command = new SqlCommand(query, Connection()))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            inspectionResult = new InspectionResultDB()
                            {
                                InspectionResultID = reader.GetInt32(0),
                                TactTime = reader.GetDateTime(1),
                                Average = reader.GetDouble(2),
                                CarName = reader.GetString(3),
                                Result = reader.GetString(4),
                                CreateDate = reader.GetDateTime(5),
                                LastModifyDate = reader.GetDateTime(6),
                                CameraNum = reader.GetInt32(7),
                                VinID = reader.GetString(8),
                                ImgPath = reader.GetString(9),
                                Shift = reader.GetString(10)
                            };
                        }
                        return inspectionResult;
                    }
                }
            }
            catch (Exception ex)
            {
                Machine.logger.WriteAsync(eLogType.ERROR, "GetInspectionResultById: " + ex.ToString());
                return null;
            }
        }

        // Delete inspection result by ID
        public bool DeleteInspectionResult(int inspectionResultId)
        {
            try
            {
                string query = "DELETE FROM InspectionResults WHERE InspectionResultID = @InspectionResultID";

                using (SqlCommand sqlCommand = new SqlCommand(query, Connection()))
                {
                    sqlCommand.Parameters.AddWithValue("@InspectionResultID", inspectionResultId);
                    return sqlCommand.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Machine.logger.WriteAsync(eLogType.ERROR, "DeleteInspectionResult: " + ex.ToString());
                return false;
            }
        }
        #endregion

        #region ROIResult
        // Save data (add or update) ROI result
        public bool SaveROIResult(ROIResultDB roiResult)
        {
            try
            {
                string query = "UPDATE ROIResults SET InspectionResultID = @InspectionResultID, Score = @Score, RoiName = @RoiName, " +
                               "Result = @Result, TrainRectangleX = @TrainRectangleX, TrainRectangleY = @TrainRectangleY, " +
                               "TrainRectangleHeight = @TrainRectangleHeight, TrainRectangleWidth = @TrainRectangleWidth " +
                               "WHERE ROIResultID = @ROIResultID " +
                               "IF @@ROWCOUNT = 0 " +
                               "INSERT INTO ROIResults (InspectionResultID, Score, RoiName, Result, TrainRectangleX, TrainRectangleY, " +
                               "TrainRectangleHeight, TrainRectangleWidth) " +
                               "VALUES (@InspectionResultID, @Score, @RoiName, @Result, @TrainRectangleX, @TrainRectangleY, " +
                               "@TrainRectangleHeight, @TrainRectangleWidth)";

                using (SqlCommand sqlCommand = new SqlCommand(query, Connection()))
                {
                    sqlCommand.Parameters.AddWithValue("@ROIResultID", roiResult.ROIResultID);
                    sqlCommand.Parameters.AddWithValue("@InspectionResultID", roiResult.InspectionResultID);
                    sqlCommand.Parameters.AddWithValue("@Score", roiResult.Score);
                    sqlCommand.Parameters.AddWithValue("@RoiName", roiResult.RoiName);
                    sqlCommand.Parameters.AddWithValue("@Result", roiResult.Result);
                    sqlCommand.Parameters.AddWithValue("@TrainRectangleX", roiResult.TrainRectangleX);
                    sqlCommand.Parameters.AddWithValue("@TrainRectangleY", roiResult.TrainRectangleY);
                    sqlCommand.Parameters.AddWithValue("@TrainRectangleHeight", roiResult.TrainRectangleHeight);
                    sqlCommand.Parameters.AddWithValue("@TrainRectangleWidth", roiResult.TrainRectangleWidth);
                    sqlCommand.CommandType = CommandType.Text;
                    return sqlCommand.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Machine.logger.WriteAsync(eLogType.ERROR, "SaveROIResult: " + ex.ToString());
                return false;
            }
        }

        // Get all ROI results
        public List<ROIResultDB> GetROIResults()
        {
            List<ROIResultDB> roiResults = new List<ROIResultDB>();
            try
            {
                string query = "SELECT ROIResultID, InspectionResultID, Score, RoiName, Result, TrainRectangleX, TrainRectangleY, " +
                               "TrainRectangleHeight, TrainRectangleWidth FROM ROIResults";
                using (SqlCommand command = new SqlCommand(query, Connection()))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ROIResultDB roiResult = new ROIResultDB()
                            {
                                ROIResultID = reader.GetInt32(0),
                                InspectionResultID = reader.GetInt32(1),
                                Score = reader.GetDouble(2),
                                RoiName = reader.GetString(3),
                                Result = reader.GetString(4),
                                TrainRectangleX = reader.GetInt32(5),
                                TrainRectangleY = reader.GetInt32(6),
                                TrainRectangleHeight = reader.GetInt32(7),
                                TrainRectangleWidth = reader.GetInt32(8)
                            };
                            roiResults.Add(roiResult);
                        }
                        return roiResults;
                    }
                }
            }
            catch (Exception ex)
            {
                Machine.logger.WriteAsync(eLogType.ERROR, "GetROIResults: " + ex.ToString());
                return null;
            }
        }

        // Get ROI result by ID
        public ROIResultDB GetROIResultById(int roiResultId)
        {
            ROIResultDB roiResult = null;
            try
            {
                string query = $"SELECT * FROM ROIResults WHERE ROIResultID = {roiResultId}";
                using (SqlCommand command = new SqlCommand(query, Connection()))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            roiResult = new ROIResultDB()
                            {
                                ROIResultID = reader.GetInt32(0),
                                InspectionResultID = reader.GetInt32(1),
                                Score = reader.GetDouble(2),
                                RoiName = reader.GetString(3),
                                Result = reader.GetString(4),
                                TrainRectangleX = reader.GetInt32(5),
                                TrainRectangleY = reader.GetInt32(6),
                                TrainRectangleHeight = reader.GetInt32(7),
                                TrainRectangleWidth = reader.GetInt32(8)
                            };
                        }
                        return roiResult;
                    }
                }
            }
            catch (Exception ex)
            {
                Machine.logger.WriteAsync(eLogType.ERROR, "GetROIResultById: " + ex.ToString());
                return null;
            }
        }

        // Delete ROI result by ID
        public bool DeleteROIResult(int roiResultId)
        {
            try
            {
                string query = "DELETE FROM ROIResults WHERE ROIResultID = @ROIResultID";

                using (SqlCommand sqlCommand = new SqlCommand(query, Connection()))
                {
                    sqlCommand.Parameters.AddWithValue("@ROIResultID", roiResultId);
                    return sqlCommand.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Machine.logger.WriteAsync(eLogType.ERROR, "DeleteROIResult: " + ex.ToString());
                return false;
            }
        }
        #endregion

        #region InspectionNGResult
        // Save data (add or update) inspection NG result
        public bool SaveInspectionNGResult(InspectionNGResult inspectionNGResult)
        {
            try
            {
                string query = "UPDATE InspectionNGResults SET InspectionResultID = @InspectionResultID, ROIResultID = @ROIResultID " +
                               "WHERE InspectionNGResultID = @InspectionNGResultID " +
                               "IF @@ROWCOUNT = 0 " +
                               "INSERT INTO InspectionNGResults (InspectionResultID, ROIResultID) " +
                               "VALUES (@InspectionResultID, @ROIResultID)";

                using (SqlCommand sqlCommand = new SqlCommand(query, Connection()))
                {
                    sqlCommand.Parameters.AddWithValue("@InspectionNGResultID", inspectionNGResult.InspectionNGResultID);
                    sqlCommand.Parameters.AddWithValue("@InspectionResultID", inspectionNGResult.InspectionResultID);
                    sqlCommand.Parameters.AddWithValue("@ROIResultID", inspectionNGResult.ROIResultID);
                    sqlCommand.CommandType = CommandType.Text;
                    return sqlCommand.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Machine.logger.WriteAsync(eLogType.ERROR, "SaveInspectionNGResult: " + ex.ToString());
                return false;
            }
        }

        // Get all inspection NG results
        public List<InspectionNGResult> GetInspectionNGResults()
        {
            List<InspectionNGResult> inspectionNGResults = new List<InspectionNGResult>();
            try
            {
                string query = "SELECT InspectionNGResultID, InspectionResultID, ROIResultID FROM InspectionNGResults";
                using (SqlCommand command = new SqlCommand(query, Connection()))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            InspectionNGResult inspectionNGResult = new InspectionNGResult()
                            {
                                InspectionNGResultID = reader.GetInt32(0),
                                InspectionResultID = reader.GetInt32(1),
                                ROIResultID = reader.GetInt32(2),
                            };
                            inspectionNGResults.Add(inspectionNGResult);
                        }
                        return inspectionNGResults;
                    }
                }
            }
            catch (Exception ex)
            {
                Machine.logger.WriteAsync(eLogType.ERROR, "GetInspectionNGResults: " + ex.ToString());
                return null;
            }
        }

        // Get inspection NG result by ID
        public InspectionNGResult GetInspectionNGResultById(int inspectionNGResultId)
        {
            InspectionNGResult inspectionNGResult = null;
            try
            {
                string query = $"SELECT * FROM InspectionNGResults WHERE InspectionNGResultID = {inspectionNGResultId}";
                using (SqlCommand command = new SqlCommand(query, Connection()))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            inspectionNGResult = new InspectionNGResult()
                            {
                                InspectionNGResultID = reader.GetInt32(0),
                                InspectionResultID = reader.GetInt32(1),
                                ROIResultID = reader.GetInt32(2),
                            };
                        }
                        return inspectionNGResult;
                    }
                }
            }
            catch (Exception ex)
            {
                Machine.logger.WriteAsync(eLogType.ERROR, "GetInspectionNGResultById: " + ex.ToString());
                return null;
            }
        }

        // Delete inspection NG result by ID
        public bool DeleteInspectionNGResult(int inspectionNGResultId)
        {
            try
            {
                string query = "DELETE FROM InspectionNGResults WHERE InspectionNGResultID = @InspectionNGResultID";

                using (SqlCommand sqlCommand = new SqlCommand(query, Connection()))
                {
                    sqlCommand.Parameters.AddWithValue("@InspectionNGResultID", inspectionNGResultId);
                    return sqlCommand.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Machine.logger.WriteAsync(eLogType.ERROR, "DeleteInspectionNGResult: " + ex.ToString());
                return false;
            }
        }
        #endregion

        #region Insert InspectionResult multiple ROIResults and an InspectionNGResult
        public bool InsertInspectionResult(InspectionResultDB inspectionResult, List<ROIResultDB> roiResults)
        {
            SqlTransaction transaction = null;

            try
            {
                // Start a new database connection
                using (SqlConnection conn = Connection())
                {
                    // Begin a transaction
                    transaction = conn.BeginTransaction();

                    // Insert the InspectionResult
                    string insertInspectionResultQuery = "INSERT INTO InspectionResults (TactTime, CameraNum,  ImgPath, Average, VinID, CarName, Result, Shift, CreateDate, LastModifyDate) " +
                                                         "VALUES (@TactTime, @CameraNum, @ImgPath, @Average, @VinID, @CarName, @Result, @Shift, @CreateDate, @LastModifyDate);" +
                                                         "SELECT CAST(SCOPE_IDENTITY() AS INT);"; // Retrieve the generated InspectionResultID

                    int inspectionResultID;
                    using (SqlCommand cmd = new SqlCommand(insertInspectionResultQuery, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@TactTime", inspectionResult.TactTime);
                        cmd.Parameters.AddWithValue("@CameraNum", inspectionResult.CameraNum);
                        cmd.Parameters.AddWithValue("@ImgPath", inspectionResult.ImgPath);
                        cmd.Parameters.AddWithValue("@Average", inspectionResult.Average);
                        cmd.Parameters.AddWithValue("@VinID", inspectionResult.VinID);
                        cmd.Parameters.AddWithValue("@CarName", inspectionResult.CarName);
                        cmd.Parameters.AddWithValue("@Result", inspectionResult.Result);
                        cmd.Parameters.AddWithValue("@Shift", inspectionResult.Shift);
                        cmd.Parameters.AddWithValue("@CreateDate", inspectionResult.CreateDate);
                        cmd.Parameters.AddWithValue("@LastModifyDate", inspectionResult.LastModifyDate);

                        inspectionResultID = (int)cmd.ExecuteScalar(); // Retrieve the generated ID
                    }

                    // Insert each ROIResult
                    foreach (var roiResult in roiResults)
                    {
                        string insertROIResultQuery = "INSERT INTO ROIResults (InspectionResultID, Score, RoiName, Result, TrainRectangleX, TrainRectangleY, TrainRectangleHeight, TrainRectangleWidth) " +
                                                      "VALUES (@InspectionResultID, @Score, @RoiName, @Result, @TrainRectangleX, @TrainRectangleY, @TrainRectangleHeight, @TrainRectangleWidth);" +
                                                      "SELECT CAST(SCOPE_IDENTITY() AS INT);"; // Retrieve the generated ROIResultID

                        int roiResultID;
                        using (SqlCommand cmd = new SqlCommand(insertROIResultQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@InspectionResultID", inspectionResultID);
                            cmd.Parameters.AddWithValue("@Score", roiResult.Score);
                            cmd.Parameters.AddWithValue("@RoiName", roiResult.RoiName);
                            cmd.Parameters.AddWithValue("@Result", roiResult.Result);
                            cmd.Parameters.AddWithValue("@TrainRectangleX", roiResult.TrainRectangleX);
                            cmd.Parameters.AddWithValue("@TrainRectangleY", roiResult.TrainRectangleY);
                            cmd.Parameters.AddWithValue("@TrainRectangleHeight", roiResult.TrainRectangleHeight);
                            cmd.Parameters.AddWithValue("@TrainRectangleWidth", roiResult.TrainRectangleWidth);

                            roiResultID = (int)cmd.ExecuteScalar(); // Retrieve the generated ROIResultID
                        }

                        // If the ROIResult is "NG", insert in InspectionNGResult
                        if (roiResult.Result == "NG")
                        {
                            string insertInspectionNGResultQuery = "INSERT INTO InspectionNGResults (InspectionResultID, ROIResultID) " +
                                                                   "VALUES (@InspectionResultID, @ROIResultID)";

                            using (SqlCommand cmd = new SqlCommand(insertInspectionNGResultQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@InspectionResultID", inspectionResultID);
                                cmd.Parameters.AddWithValue("@ROIResultID", roiResultID);

                                cmd.ExecuteNonQuery(); // Execute the insert command for InspectionNGResult
                            }
                        }
                    }
                    // Commit the transaction to persist all changes
                    transaction.Commit();
                }

                return true;
            }
            catch (Exception ex)
            {
                // Rollback the transaction in case of any error
                transaction?.Rollback();
                Machine.logger.WriteAsync(eLogType.ERROR, "InsertInspectionResult: " + ex.ToString());
                return false;
            }
        }

        #endregion
    }
}

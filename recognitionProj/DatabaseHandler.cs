using Microsoft.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;

namespace recognitionProj
{
    public class DatabaseHandler
    {
        private readonly string _connectionString;

        public DatabaseHandler(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Execute a manual query
        public void Query(string query)
        {
            using (SqlConnection connection = new(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Database query failed", ex);
                }
            }
        }

        // Insert record using parameterized query
        public void InsertRecord(string tableName, string columns, string[] parameterNames, object[] values)
        {
            string query = $"INSERT INTO {tableName} ({columns}) VALUES ({string.Join(",", parameterNames)})";

            using (SqlConnection connection = new(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new(query, connection))
                    {
                        for (int i = 0; i < parameterNames.Length; i++)
                        {
                            command.Parameters.AddWithValue(parameterNames[i], values[i] ?? DBNull.Value);
                        }
                        command.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Database insert operation failed", ex);
                }
            }
        }

        // Update record using parameterized query
        public void UpdateRecord(string tableName, string setValues, string condition, string[] parameterNames, object[] values)
        {
            string query = $"UPDATE {tableName} SET {setValues} WHERE {condition}";

            using (SqlConnection connection = new(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new(query, connection))
                    {
                        for (int i = 0; i < parameterNames.Length; i++)
                        {
                            command.Parameters.AddWithValue(parameterNames[i], values[i] ?? DBNull.Value);
                        }
                        command.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Database update operation failed", ex);
                }
            }
        }

        // Delete record
        public void DeleteRecord(string tableName, string condition)
        {
            string query = $"DELETE FROM {tableName} WHERE {condition}";

            using (SqlConnection connection = new(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Database delete operation failed", ex);
                }
            }
        }

        // Select records
        public DataTable SelectRecords(string query)
        {
            DataTable dataTable = new();

            using (SqlConnection connection = new(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dataTable.Load(reader);
                        }
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Database select operation failed", ex);
                }
            }

            return dataTable;
        }

        public DataTable SelectRecords(string query, string[] parameterNames, object[] values)
        {
            DataTable dataTable = new();

            using (SqlConnection connection = new(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new(query, connection))
                    {
                        for (int i = 0; i < parameterNames.Length; i++)
                        {
                            command.Parameters.AddWithValue(parameterNames[i], values[i] ?? DBNull.Value);
                        }

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dataTable.Load(reader);
                        }
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Database select operation failed", ex);
                }
            }

            return dataTable;
        }

        // Insert University using parameterized query
        public void InsertUniversity(University university)
        {
            string tableName = "Universities";//todo deal with the primary key
            string columns = "Name, EntryDate, Supervisor, Country, City, Address, Website, CreationDate, StudentAcceptanceDate, StartDate, Type, Language, EducationType, AvailableDegrees, HoursSystem, Faculties, ARWURank, THERank, QSRank, OtherRank, NumOfScopusResearches, ScopusFrom, ScopusTo, Infrastructure, OtherInfo, AcceptanceRecord, SuggestionRecord, Specializations, Accepted";

            string[] parameterNames = new string[]
            {
                "@Name", "@EntryDate", "@Supervisor", "@Country", "@City", "@Address", "@Website", "@CreationDate", "@StudentAcceptanceDate",
                "@StartDate", "@Type", "@Language", "@EducationType", "@AvailableDegrees", "@HoursSystem", "@Faculties", "@ARWURank", "@THERank",
                "@QSRank", "@OtherRank", "@NumOfScopusResearches", "@ScopusFrom", "@ScopusTo", "@Infrastructure", "@OtherInfo", "@AcceptanceRecord",
                "@SuggestionRecord", "@Specializations", "@Accepted"
            };
            //todo red lines here, fix AND REMOVE SUGGESTIOR RECORD
            object[] values = new object[]
            {
                university.Name, university.EntryDate, university.Supervisor, university.Country, university.City, university.Address,
                university.Website, university.CreationDate, university.StudentAcceptanceDate, university.StartDate, university.Type,
                university.Language, university.EducationType, string.Join(',', university.AvailableDegrees), university.HoursSystem,
                string.Join(',', university.Faculties), university.ARWURank, university.THERank, university.QSRank, university.OtherRank,
                university.NumOfScopusResearches, university.ScopusFrom, university.ScopusTo, university.Infrastructure, university.OtherInfo,
                JsonConvert.SerializeObject(university.AcceptanceRecord), JsonConvert.SerializeObject(university.SuggestionRecord),
                JsonConvert.SerializeObject(university.Specializations), university.Accepted
            };

            InsertRecord(tableName, columns, parameterNames, values);
        }

        // Retrieve University
        public University GetUniversity(string uniName)
        {
            string query = $"SELECT * FROM Universities WHERE Name = @Name";
            DataTable dataTable = SelectRecords(query);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];

                return new University(//todo deal with the primary key
                    name: row["Name"].ToString(),
                    entryDate: DateOnly.Parse(row["EntryDate"].ToString()),
                    supervisor: row["Supervisor"].ToString(),
                    country: row["Country"].ToString(),
                    city: row["City"].ToString(),
                    address: row["Address"].ToString(),
                    website: row["Website"].ToString(),
                    creationDate: DateOnly.Parse(row["CreationDate"].ToString()),
                    studentAcceptanceDate: DateOnly.Parse(row["StudentAcceptanceDate"].ToString()),
                    startDate: DateOnly.Parse(row["StartDate"].ToString()),
                    type: row["Type"].ToString(),
                    language: row["Language"].ToString(),
                    educationType: row["EducationType"].ToString(),
                    availableDegrees: row["AvailableDegrees"].ToString().Split(','),
                    hoursSystem: row["HoursSystem"].ToString(),
                    faculties: row["Faculties"].ToString().Split(','),
                    arwuRank: int.Parse(row["ARWURank"].ToString()),
                    theRank: int.Parse(row["THERank"].ToString()),
                    qsRank: int.Parse(row["QSRank"].ToString()),
                    otherRank: row["OtherRank"].ToString(),
                    numOfScopusResearches: int.Parse(row["NumOfScopusResearches"].ToString()),
                    scopusFrom: int.Parse(row["ScopusFrom"].ToString()),
                    scopusTo: int.Parse(row["ScopusTo"].ToString()),
                    infrastructure: row["Infrastructure"].ToString(),
                    otherInfo: row["OtherInfo"].ToString(),
                    acceptanceRecords: JsonConvert.DeserializeObject<AcceptanceRecord[]>(row["AcceptanceRecord"].ToString()),
                    suggestionRecords: JsonConvert.DeserializeObject<SuggestionRecord[]>(row["SuggestionRecord"].ToString()),
                    specializations: JsonConvert.DeserializeObject<Specialization[]>(row["Specializations"].ToString()),
                    accepted: bool.Parse(row["Accepted"].ToString())
                );
            }
            else
            {
                return null;
            }
        }
        // Insert a new specialization record
        public void InsertSpecialization(Specialization specialization)
        {
            string tableName = "Specializations";
            string columns = "[Type], [NumStu], [NumFreeTeachers], [NumPartTimeTeachers], [NumProf], [NumAssociative], [NumAssistant], [NumMusharek], [NumMusa3ed], [NumberLecturers], [NumAssisLecturer], [NumOtherTeachers], [SpecAttachName], [SpecAttachDesc]";

            string[] parameterNames = {
                "@Type", "@NumStu", "@NumFreeTeachers", "@NumPartTimeTeachers", "@NumProf",//TODO RENAME TEACHERS TO PROFS
                "@NumAssociative", "@NumAssistant", "@NumMusharek", "@NumMusa3ed",
                "@NumberLecturers", "@NumAssisLecturer", "@NumOtherTeachers",
                "@SpecAttachName", "@SpecAttachDesc"
            };

            object[] values = {
                specialization.Type, specialization.NumStu, specialization.NumFreeTeachers,//TODO RENAME TEACHERS TO PROFS
                specialization.NumPartTimeTeachers, specialization.NumProf, specialization.NumAssociative,
                specialization.NumAssistant, specialization.NumMusharek, specialization.NumMusa3ed,
                specialization.NumberLecturers, specialization.NumAssisLecturer, specialization.NumOtherTeachers,
                specialization.SpecAttachName, specialization.SpecAttachDesc
            };

            InsertRecord(tableName, columns, parameterNames, values);
        }

        // Fetch a specialization record by InsID
        public Specialization GetSpecialization(int insId)
        {
            string query = $"SELECT * FROM Specializations WHERE [InsID] = @InsID";
            string[] parameterNames = { "@InsID" };
            object[] values = { insId };

            DataTable dataTable = SelectRecords(query, parameterNames, values);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];

                return new Specialization(
                    insId: int.Parse(row["InsID"].ToString()),
                    type: row["Type"].ToString(),
                    numStu: int.Parse(row["NumStu"].ToString()),
                    numFreeTeachers: int.Parse(row["NumFreeTeachers"].ToString()),//TODO RENAME TEACHERS TO PROFS
                    numPartTimeTeachers: int.Parse(row["NumPartTimeTeachers"].ToString()),//TODO RENAME TEACHERS TO PROFS
                    numProf: int.Parse(row["NumProf"].ToString()),
                    numAssociative: int.Parse(row["NumAssociative"].ToString()),
                    numAssistant: int.Parse(row["NumAssistant"].ToString()),
                    numMusharek: int.Parse(row["NumMusharek"].ToString()),
                    numMusa3ed: int.Parse(row["NumMusa3ed"].ToString()),
                    numberLecturers: int.Parse(row["NumberLecturers"].ToString()),
                    numAssisLecturer: int.Parse(row["NumAssisLecturer"].ToString()),
                    numOtherTeachers: int.Parse(row["NumOtherTeachers"].ToString()),
                    specAttachName: row["SpecAttachName"].ToString(),
                    specAttachDesc: row["SpecAttachDesc"].ToString()
                );
            }
            else
            {
                return null;
            }
        }

        

        // Update specialization record
        public void UpdateSpecialization(Specialization specialization)
        {//TODO RENAME TEACHERS TO PROFS
            string query = $"UPDATE Specializations SET [Type] = @Type, [NumStu] = @NumStu, [NumFreeTeachers] = @NumFreeTeachers, " +
                "[NumPartTimeTeachers] = @NumPartTimeTeachers, [NumProf] = @NumProf, [NumAssociative] = @NumAssociative, [NumAssistant] = @NumAssistant, " +
                "[NumMusharek] = @NumMusharek, [NumMusa3ed] = @NumMusa3ed, [NumberLecturers] = @NumberLecturers, [NumAssisLecturer] = @NumAssisLecturer, " +
                "[NumOtherTeachers] = @NumOtherTeachers, [SpecAttachName] = @SpecAttachName, [SpecAttachDesc] = @SpecAttachDesc WHERE [InsID] = @InsID";
            //TODO RENAME TEACHERS TO PROFS
            string[] parameterNames = {
                "@Type", "@NumStu", "@NumFreeTeachers", "@NumPartTimeTeachers", "@NumProf", "@NumAssociative", "@NumAssistant",
                "@NumMusharek", "@NumMusa3ed", "@NumberLecturers", "@NumAssisLecturer", "@NumOtherTeachers", "@SpecAttachName",
                "@SpecAttachDesc", "@InsID"
            };
            //TODO RENAME TEACHERS TO PROFS
            object[] values = {
                specialization.Type, specialization.NumStu, specialization.NumFreeTeachers, specialization.NumPartTimeTeachers,
                specialization.NumProf, specialization.NumAssociative, specialization.NumAssistant, specialization.NumMusharek,
                specialization.NumMusa3ed, specialization.NumberLecturers, specialization.NumAssisLecturer, specialization.NumOtherTeachers,
                specialization.SpecAttachName, specialization.SpecAttachDesc, specialization.InsID
            };
            //TODO RENAME TEACHERS TO PROFS
            UpdateRecord("Specializations", "[Type] = @Type, [NumStu] = @NumStu, [NumFreeTeachers] = @NumFreeTeachers, " +
                "[NumPartTimeTeachers] = @NumPartTimeTeachers, [NumProf] = @NumProf, [NumAssociative] = @NumAssociative, [NumAssistant] = @NumAssistant, " +
                "[NumMusharek] = @NumMusharek, [NumMusa3ed] = @NumMusa3ed, [NumberLecturers] = @NumberLecturers, [NumAssisLecturer] = @NumAssisLecturer, " +
                "[NumOtherTeachers] = @NumOtherTeachers, [SpecAttachName] = @SpecAttachName, [SpecAttachDesc] = @SpecAttachDesc", "[InsID] = @InsID", parameterNames, values);
        }

        // Delete specialization record by InsID
        public void DeleteSpecialization(int insId)
        {
            DeleteRecord("Specializations", $"[InsID] = {insId}");
        }

        // Additional methods for AcademicInfo and other records can follow the same pattern
        public void InsertAcademicInfo(AcademicInfo academicInfo)
        {
            string tableName = "AcademicInfo";
            string columns = "[InsID], [InsTypeID], [InsType], [HighEdu_Rec], [QualityDept_Rec], [StudyLangCitizen], [StudyLangInter], [JointClass], " +
                             "[StudySystem], [MinHours], [MaxHours], [ResearchScopus], [ResearchOthers], [Practicing], [StudyAttendance], " +
                             "[StudentsMove], [StudyAttendanceDesc], [StudentsMoveDesc], [DistanceLearning], [MaxHoursDL], [MaxYearsDL], " +
                             "[MaxSemsDL], [Diploma], [DiplomaTest], [HoursPercentage]";

            string[] parameterNames = {
        "@InsID", "@InsTypeID", "@InsType", "@HighEdu_Rec", "@QualityDept_Rec", "@StudyLangCitizen", "@StudyLangInter", "@JointClass",
        "@StudySystem", "@MinHours", "@MaxHours", "@ResearchScopus", "@ResearchOthers", "@Practicing", "@StudyAttendance", "@StudentsMove",
        "@StudyAttendanceDesc", "@StudentsMoveDesc", "@DistanceLearning", "@MaxHoursDL", "@MaxYearsDL", "@MaxSemsDL", "@Diploma",
        "@DiplomaTest", "@HoursPercentage"
    };

            object[] values = {
        academicInfo.InsID, academicInfo.InsTypeID, academicInfo.InsType, academicInfo.HighEdu_Rec, academicInfo.QualityDept_Rec,
        academicInfo.StudyLangCitizen, academicInfo.StudyLangInter, academicInfo.JointClass, academicInfo.StudySystem,
        academicInfo.MinHours, academicInfo.MaxHours, academicInfo.ResearchScopus, academicInfo.ResearchOthers, academicInfo.Practicing,
        academicInfo.StudyAttendance, academicInfo.StudentsMove, academicInfo.StudyAttendanceDesc, academicInfo.StudentsMoveDesc,
        academicInfo.DistanceLearning, academicInfo.MaxHoursDL, academicInfo.MaxYearsDL, academicInfo.MaxSemsDL, academicInfo.Diploma,
        academicInfo.DiplomaTest, academicInfo.HoursPercentage
    };

            InsertRecord(tableName, columns, parameterNames, values);
        }
        public AcademicInfo GetAcademicInfo(int insID)
        {
            string query = $"SELECT * FROM AcademicInfo WHERE [InsID] = @InsID";
            string[] parameterNames = { "@InsID" };
            object[] values = { insID };

            DataTable dataTable = SelectRecords(query, parameterNames, values);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];

                return new AcademicInfo(
                    insID: int.Parse(row["InsID"].ToString()),
                    insTypeID: row["InsTypeID"] != DBNull.Value ? (int?)int.Parse(row["InsTypeID"].ToString()) : null,
                    insType: row["InsType"].ToString(),
                    highEduRec: row["HighEdu_Rec"] != DBNull.Value ? (int?)int.Parse(row["HighEdu_Rec"].ToString()) : null,
                    qualityDeptRec: row["QualityDept_Rec"] != DBNull.Value ? (int?)int.Parse(row["QualityDept_Rec"].ToString()) : null,
                    studyLangCitizen: row["StudyLangCitizen"].ToString(),
                    studyLangInter: row["StudyLangInter"].ToString(),
                    jointClass: row["JointClass"] != DBNull.Value ? (int?)int.Parse(row["JointClass"].ToString()) : null,
                    studySystem: row["StudySystem"].ToString(),
                    minHours: row["MinHours"] != DBNull.Value ? (int?)int.Parse(row["MinHours"].ToString()) : null,
                    maxHours: row["MaxHours"] != DBNull.Value ? (int?)int.Parse(row["MaxHours"].ToString()) : null,
                    researchScopus: row["ResearchScopus"].ToString(),
                    researchOthers: row["ResearchOthers"].ToString(),
                    practicing: row["Practicing"] != DBNull.Value ? (int?)int.Parse(row["Practicing"].ToString()) : null,
                    studyAttendance: row["StudyAttendance"] != DBNull.Value ? (int?)int.Parse(row["StudyAttendance"].ToString()) : null,
                    studentsMove: row["StudentsMove"] != DBNull.Value ? (int?)int.Parse(row["StudentsMove"].ToString()) : null,
                    studyAttendanceDesc: row["StudyAttendanceDesc"].ToString(),
                    studentsMoveDesc: row["StudentsMoveDesc"].ToString(),
                    distanceLearning: row["DistanceLearning"] != DBNull.Value ? (int?)int.Parse(row["DistanceLearning"].ToString()) : null,
                    maxHoursDL: row["MaxHoursDL"] != DBNull.Value ? (int?)int.Parse(row["MaxHoursDL"].ToString()) : null,
                    maxYearsDL: row["MaxYearsDL"] != DBNull.Value ? (int?)int.Parse(row["MaxYearsDL"].ToString()) : null,
                    maxSemsDL: row["MaxSemsDL"] != DBNull.Value ? (int?)int.Parse(row["MaxSemsDL"].ToString()) : null,
                    diploma: row["Diploma"] != DBNull.Value ? (int?)int.Parse(row["Diploma"].ToString()) : null,
                    diplomaTest: row["DiplomaTest"] != DBNull.Value ? (int?)int.Parse(row["DiplomaTest"].ToString()) : null,
                    hoursPercentage: row["HoursPercentage"] != DBNull.Value ? (int?)int.Parse(row["HoursPercentage"].ToString()) : null
                );
            }
            else
            {
                return null;
            }
        }
        public void UpdateAcademicInfo(AcademicInfo academicInfo)
        {
            string tableName = "AcademicInfo";

            // Set values for the columns that need to be updated
            string setValues = "[InsTypeID] = @InsTypeID, [InsType] = @InsType, [HighEdu_Rec] = @HighEdu_Rec, [QualityDept_Rec] = @QualityDept_Rec, " +
                               "[StudyLangCitizen] = @StudyLangCitizen, [StudyLangInter] = @StudyLangInter, [JointClass] = @JointClass, [StudySystem] = @StudySystem, " +
                               "[MinHours] = @MinHours, [MaxHours] = @MaxHours, [ResearchScopus] = @ResearchScopus, [ResearchOthers] = @ResearchOthers, " +
                               "[Practicing] = @Practicing, [StudyAttendance] = @StudyAttendance, [StudentsMove] = @StudentsMove, [StudyAttendanceDesc] = @StudyAttendanceDesc, " +
                               "[StudentsMoveDesc] = @StudentsMoveDesc, [DistanceLearning] = @DistanceLearning, [MaxHoursDL] = @MaxHoursDL, [MaxYearsDL] = @MaxYearsDL, " +
                               "[MaxSemsDL] = @MaxSemsDL, [Diploma] = @Diploma, [DiplomaTest] = @DiplomaTest, [HoursPercentage] = @HoursPercentage";

            // Define the condition (which record to update)
            string condition = "[InsID] = @InsID";

            // Define the parameters to be used in the SQL query
            string[] parameterNames = {
        "@InsTypeID", "@InsType", "@HighEdu_Rec", "@QualityDept_Rec", "@StudyLangCitizen", "@StudyLangInter", "@JointClass",
        "@StudySystem", "@MinHours", "@MaxHours", "@ResearchScopus", "@ResearchOthers", "@Practicing", "@StudyAttendance",
        "@StudentsMove", "@StudyAttendanceDesc", "@StudentsMoveDesc", "@DistanceLearning", "@MaxHoursDL", "@MaxYearsDL",
        "@MaxSemsDL", "@Diploma", "@DiplomaTest", "@HoursPercentage", "@InsID"
    };

            // Set the values for each parameter
            object[] values = {
        academicInfo.InsTypeID, academicInfo.InsType, academicInfo.HighEdu_Rec, academicInfo.QualityDept_Rec, academicInfo.StudyLangCitizen,
        academicInfo.StudyLangInter, academicInfo.JointClass, academicInfo.StudySystem, academicInfo.MinHours, academicInfo.MaxHours,
        academicInfo.ResearchScopus, academicInfo.ResearchOthers, academicInfo.Practicing, academicInfo.StudyAttendance,
        academicInfo.StudentsMove, academicInfo.StudyAttendanceDesc, academicInfo.StudentsMoveDesc, academicInfo.DistanceLearning,
        academicInfo.MaxHoursDL, academicInfo.MaxYearsDL, academicInfo.MaxSemsDL, academicInfo.Diploma, academicInfo.DiplomaTest,
        academicInfo.HoursPercentage, academicInfo.InsID
    };

            // Call the UpdateRecord method with the appropriate parameters
            UpdateRecord(tableName, setValues, condition, parameterNames, values);
        }

        public void InsertAcceptanceRecord(AcceptanceRecord record)
        {
            string tableName = "AcceptanceRecord";
            string columns = "[IsAccepted], [Date], [Reason]";

            // Convert the list of reasons to a JSON string
            string reasonJson = JsonConvert.SerializeObject(record.Reason);

            string[] parameterNames = { "@IsAccepted", "@Date", "@Reason" };
            object[] values = { record.IsAccepted, record.Date.ToString("yyyy-MM-dd"), reasonJson };

            // Call the InsertRecord method of the DatabaseHandler
            InsertRecord(tableName, columns, parameterNames, values);
        }
        public void UpdateAcceptanceRecord(AcceptanceRecord record, int recordId)
        {
            string tableName = "AcceptanceRecord";

            // Columns to update
            string setValues = "[IsAccepted] = @IsAccepted, [Date] = @Date, [Reason] = @Reason";

            // Condition for which record to update (assuming the table has an ID column)
            string condition = "[RecordID] = @RecordID";

            // Convert the list of reasons to a JSON string
            string reasonJson = JsonConvert.SerializeObject(record.Reason);

            string[] parameterNames = { "@IsAccepted", "@Date", "@Reason", "@RecordID" };
            object[] values = { record.IsAccepted, record.Date.ToString("yyyy-MM-dd"), reasonJson, recordId };

            // Call the UpdateRecord method of the DatabaseHandler
            UpdateRecord(tableName, setValues, condition, parameterNames, values);
        }
        public void DeleteAcceptanceRecord(int recordId)
        {
            string tableName = "AcceptanceRecord";
            string condition = "[RecordID] = @RecordID";

            // Call the DeleteRecord method of the DatabaseHandler
            DeleteRecord(tableName, condition);
        }
        public List<AcceptanceRecord> GetAllAcceptanceRecords()
        {
            string query = "SELECT [IsAccepted], [Date], [Reason] FROM AcceptanceRecord";
            DataTable resultTable = SelectRecords(query);

            List<AcceptanceRecord> records = new();

            foreach (DataRow row in resultTable.Rows)
            {
                bool isAccepted = Convert.ToBoolean(row["IsAccepted"]);
                DateOnly date = DateOnly.Parse(row["Date"].ToString());
                List<string> reason = JsonConvert.DeserializeObject<List<string>>(row["Reason"].ToString());

                records.Add(new AcceptanceRecord(isAccepted, date, reason));
            }

            return records;
        }
        public void InsertExcelAttach(ExcelAttach attachment)
        {
            string tableName = "ExcelAttachment";
            string columns = "[InsID], [AttachID], [AttachName], [AttachDesc]";

            string[] parameterNames = { "@InsID", "@AttachID", "@AttachName", "@AttachDesc" };
            object[] values = { attachment.InsID, attachment.AttachID, attachment.AttachName, attachment.AttachDesc };

            // Call the InsertRecord method of the DatabaseHandler
            InsertRecord(tableName, columns, parameterNames, values);
        }
        public void UpdateExcelAttach(ExcelAttach attachment)
        {
            string tableName = "ExcelAttachment";

            // Columns to update
            string setValues = "[AttachName] = @AttachName, [AttachDesc] = @AttachDesc";

            // Condition for which record to update (based on InsID and AttachID)
            string condition = "[InsID] = @InsID AND [AttachID] = @AttachID";

            string[] parameterNames = { "@AttachName", "@AttachDesc", "@InsID", "@AttachID" };
            object[] values = { attachment.AttachName, attachment.AttachDesc, attachment.InsID, attachment.AttachID };

            // Call the UpdateRecord method of the DatabaseHandler
            UpdateRecord(tableName, setValues, condition, parameterNames, values);
        }

        public void DeleteExcelAttach(int insID, int attachID)
        {
            string tableName = "ExcelAttachment";

            // Condition for which record to delete (based on InsID and AttachID)
            string condition = "[InsID] = @InsID AND [AttachID] = @AttachID";

            // Call the DeleteRecord method of the DatabaseHandler
            DeleteRecord(tableName, condition);
        }
        public List<ExcelAttach> GetAllExcelAttachments()
        {
            string query = "SELECT [InsID], [AttachID], [AttachName], [AttachDesc] FROM ExcelAttachment";
            DataTable resultTable = SelectRecords(query);

            List<ExcelAttach> attachments = new();

            foreach (DataRow row in resultTable.Rows)
            {
                int insID = Convert.ToInt32(row["InsID"]);
                int attachID = Convert.ToInt32(row["AttachID"]);
                string attachName = row["AttachName"].ToString();
                string attachDesc = row["AttachDesc"].ToString();

                attachments.Add(new ExcelAttach(insID, attachID, attachName, attachDesc));
            }

            return attachments;
        }
        public void InsertHospital(Hospitals hospital)
        {
            string tableName = "Hospitals";
            string columns = "[InsID], [HospType], [HospName], [HospMajor]";

            string[] parameterNames = { "@InsID", "@HospType", "@HospName", "@HospMajor" };
            object[] values = { hospital.InsID, hospital.HospType, hospital.HospName, hospital.HospMajor };

            // Call the InsertRecord method of the DatabaseHandler
            InsertRecord(tableName, columns, parameterNames, values);
        }
        public void UpdateHospital(Hospitals hospital)
        {
            string tableName = "Hospitals";

            // Columns to update
            string setValues = "[HospType] = @HospType, [HospName] = @HospName, [HospMajor] = @HospMajor";

            // Condition for which record to update (based on InsID and HospID)
            string condition = "[InsID] = @InsID AND [HospID] = @HospID";

            string[] parameterNames = { "@HospType", "@HospName", "@HospMajor", "@InsID", "@HospID" };
            object[] values = { hospital.HospType, hospital.HospName, hospital.HospMajor, hospital.InsID, hospital.HospID };

            // Call the UpdateRecord method of the DatabaseHandler
            UpdateRecord(tableName, setValues, condition, parameterNames, values);
        }
        public void DeleteHospital(int insID, int hospID)
        {
            string tableName = "Hospitals";

            // Condition for which record to delete (based on InsID and HospID)
            string condition = "[InsID] = @InsID AND [HospID] = @HospID";

            // Call the DeleteRecord method of the DatabaseHandler
            DeleteRecord(tableName, condition);
        }
        public List<Hospitals> GetAllHospitals()
        {
            string query = "SELECT [InsID], [HospID], [HospType], [HospName], [HospMajor] FROM Hospitals";
            DataTable resultTable = SelectRecords(query);

            List<Hospitals> hospitalsList = new();

            foreach (DataRow row in resultTable.Rows)
            {
                int insID = Convert.ToInt32(row["InsID"]);
                int hospID = Convert.ToInt32(row["HospID"]);
                string hospType = row["HospType"].ToString();
                string hospName = row["HospName"].ToString();
                string hospMajor = row["HospMajor"].ToString();

                hospitalsList.Add(new Hospitals(insID, hospID, hospType, hospName, hospMajor));
            }

            return hospitalsList;
        }

    }
}

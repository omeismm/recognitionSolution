﻿using Microsoft.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;
using System.Globalization;

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
        //public void InsertUniversity(University university)
        //{
        //    string tableName = "Universities";//todo deal with the primary key
        //    string columns = "Name, EntryDate, Supervisor, Country, City, Address, Website, CreationDate, StudentAcceptanceDate, StartDate, Type, Language, EducationType, AvailableDegrees, HoursSystem, Faculties, ARWURank, THERank, QSRank, OtherRank, NumOfScopusResearches, ScopusFrom, ScopusTo, Infrastructure, OtherInfo, AcceptanceRecord, SuggestionRecord, Specializations, Accepted";

        //    string[] parameterNames = new string[]
        //    {
        //        "@Name", "@EntryDate", "@Supervisor", "@Country", "@City", "@Address", "@Website", "@CreationDate", "@StudentAcceptanceDate",
        //        "@StartDate", "@Type", "@Language", "@EducationType", "@AvailableDegrees", "@HoursSystem", "@Faculties", "@ARWURank", "@THERank",
        //        "@QSRank", "@OtherRank", "@NumOfScopusResearches", "@ScopusFrom", "@ScopusTo", "@Infrastructure", "@OtherInfo", "@AcceptanceRecord",
        //        "@SuggestionRecord", "@Specializations", "@Accepted"
        //    };
        //    //todo red lines here, fix AND REMOVE SUGGESTIOR RECORD
        //    object[] values = new object[]
        //    {
        //        university.Name, university.EntryDate, university.Supervisor, university.Country, university.City, university.Address,
        //        university.Website, university.CreationDate, university.StudentAcceptanceDate, university.StartDate, university.Type,
        //        university.Language, university.EducationType, string.Join(',', university.AvailableDegrees), university.HoursSystem,
        //        string.Join(',', university.Faculties), university.ARWURank, university.THERank, university.QSRank, university.OtherRank,
        //        university.NumOfScopusResearches, university.ScopusFrom, university.ScopusTo, university.Infrastructure, university.OtherInfo,
        //        JsonConvert.SerializeObject(university.AcceptanceRecord), JsonConvert.SerializeObject(university.SuggestionRecord),
        //        JsonConvert.SerializeObject(university.Specializations), university.Accepted
        //    };

        //    InsertRecord(tableName, columns, parameterNames, values);
        //}

        //// Retrieve University
        //public University GetUniversity(string uniName)
        //{
        //    string query = $"SELECT * FROM Universities WHERE Name = @Name";
        //    DataTable dataTable = SelectRecords(query);

        //    if (dataTable.Rows.Count > 0)
        //    {
        //        DataRow row = dataTable.Rows[0];

        //        return new University(//todo deal with the primary key
        //            name: row["Name"].ToString(),
        //            entryDate: DateOnly.Parse(row["EntryDate"].ToString()),
        //            supervisor: row["Supervisor"].ToString(),
        //            country: row["Country"].ToString(),
        //            city: row["City"].ToString(),
        //            address: row["Address"].ToString(),
        //            website: row["Website"].ToString(),
        //            creationDate: DateOnly.Parse(row["CreationDate"].ToString()),
        //            studentAcceptanceDate: DateOnly.Parse(row["StudentAcceptanceDate"].ToString()),
        //            startDate: DateOnly.Parse(row["StartDate"].ToString()),
        //            type: row["Type"].ToString(),
        //            language: row["Language"].ToString(),
        //            educationType: row["EducationType"].ToString(),
        //            availableDegrees: row["AvailableDegrees"].ToString().Split(','),
        //            hoursSystem: row["HoursSystem"].ToString(),
        //            faculties: row["Faculties"].ToString().Split(','),
        //            arwuRank: int.Parse(row["ARWURank"].ToString()),
        //            theRank: int.Parse(row["THERank"].ToString()),
        //            qsRank: int.Parse(row["QSRank"].ToString()),
        //            otherRank: row["OtherRank"].ToString(),
        //            numOfScopusResearches: int.Parse(row["NumOfScopusResearches"].ToString()),
        //            scopusFrom: int.Parse(row["ScopusFrom"].ToString()),
        //            scopusTo: int.Parse(row["ScopusTo"].ToString()),
        //            infrastructure: row["Infrastructure"].ToString(),
        //            otherInfo: row["OtherInfo"].ToString(),
        //            acceptanceRecords: JsonConvert.DeserializeObject<AcceptanceRecord[]>(row["AcceptanceRecord"].ToString()),
        //            suggestionRecords: JsonConvert.DeserializeObject<SuggestionRecord[]>(row["SuggestionRecord"].ToString()),
        //            specializations: JsonConvert.DeserializeObject<Specialization[]>(row["Specializations"].ToString()),
        //            accepted: bool.Parse(row["Accepted"].ToString())
        //        );
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
        // Insert a new specialization record
        public void InsertSpecialization(Specialization specialization)
        {
            string tableName = "Specializations";
            string columns = "[Type], [NumStu], [NumProf], [NumAssociative], [NumAssistant],[NumProfPractice], [NumberLecturers], [NumAssisLecturer], [NumOtherTeachers], [SpecAttachName], [SpecAttachDesc] , [Color], [NumPhdHolders], [PracticalHours] ,[TheoreticalHours]";

            string[] parameterNames = {
                "@Type", "@NumStu",  "@NumProf",//
                "@NumAssociative", "@NumAssistant", "@NumProfPractice",
                "@NumberLecturers", "@NumAssisLecturer", "@NumOtherTeachers",
                "@SpecAttachName", "@SpecAttachDesc", "@Color", "@NumPhdHolders", "@PracticalHours", "@TheoreticalHours"
            };

            object[] values = {
                specialization.Type, specialization.NumStu,
                specialization.NumProf, specialization.NumAssociative,
                specialization.NumAssistant,specialization.NumProfPractice, 
                specialization.NumberLecturers, specialization.NumAssisLecturer, specialization.NumOtherTeachers,
                specialization.SpecAttachName, specialization.SpecAttachDesc, specialization.Color , specialization.NumPhdHolders, specialization.PracticalHours, specialization.TheoreticalHours
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
                    numProf: int.Parse(row["NumProf"].ToString()),
                    numAssociative: int.Parse(row["NumAssociative"].ToString()),
                    numAssistant: int.Parse(row["NumAssistant"].ToString()),
                    numProfPractice : int.Parse(row["NumProfPractice"].ToString()),
                    //numMusharek: int.Parse(row["NumMusharek"].ToString()),
                    //numMusa3ed: int.Parse(row["NumMusa3ed"].ToString()),
                    numberLecturers: int.Parse(row["NumberLecturers"].ToString()),
                    numAssisLecturer: int.Parse(row["NumAssisLecturer"].ToString()),
                    numOtherTeachers: int.Parse(row["NumOtherTeachers"].ToString()),
                    specAttachName: row["SpecAttachName"].ToString(),
                    specAttachDesc: row["SpecAttachDesc"].ToString(),
                    color: int.Parse(row["Color"].ToString()),
                    numPhdHolders: int.Parse(row["NumPhdHolders"].ToString()),
                    practicalHours: row["PracticalHours"] != DBNull.Value ? (int?)int.Parse(row["PracticalHours"].ToString()) : null,
                    theoreticalHours: row["TheoreticalHours"] != DBNull.Value ? (int?)int.Parse(row["TheoreticalHours"].ToString()) : null
                );
            }
            else
            {
                return null;
            }
        }

        

        // Update specialization record
        public void UpdateSpecialization(Specialization specialization)
        {//
            string query = $"UPDATE Specializations SET [Type] = @Type, [NumStu] = @NumStu,  " +
                " [NumProf] = @NumProf, [NumAssociative] = @NumAssociative, [NumAssistant] = @NumAssistant,[NumProfPractice]=@NumProfPractice, " +
                "[NumberLecturers] = @NumberLecturers, [NumAssisLecturer] = @NumAssisLecturer, " +
                "[NumOtherTeachers] = @NumOtherTeachers, [SpecAttachName] = @SpecAttachName, [SpecAttachDesc] = @SpecAttachDesc , [Color] = @Color , [NumPhdHolders] = @NumPhdHolders, [PracticalHours] = @PracticalHours, [TheoreticalHours] = @TheoreticalHours WHERE [InsID] = @InsID";
            //
            string[] parameterNames = {
                "@Type", "@NumStu", "@NumProf", "@NumAssociative", "@NumAssistant","@NumProfPractice",
                 "@NumberLecturers", "@NumAssisLecturer", "@NumOtherTeachers", "@SpecAttachName",
                "@SpecAttachDesc", "@InsID", "@Color" , "@NumPhdHolders", "@PracticalHours", "@TheoreticalHours"
            };
            //
            object[] values = {
                specialization.Type, specialization.NumStu, 
                specialization.NumProf, specialization.NumAssociative, specialization.NumAssistant,specialization.NumProfPractice,
                specialization.NumberLecturers, specialization.NumAssisLecturer, specialization.NumOtherTeachers,
                specialization.SpecAttachName, specialization.SpecAttachDesc, specialization.InsID, specialization.Color , specialization.NumPhdHolders, specialization.PracticalHours, specialization.TheoreticalHours
            };
            //
            UpdateRecord("Specializations", "[Type] = @Type, [NumStu] = @NumStu,  " +
                " [NumProf] = @NumProf, [NumAssociative] = @NumAssociative, [NumAssistant] = @NumAssistant,[NumProfPractice]=@NumProfPractice,  " +
                "[NumberLecturers] = @NumberLecturers, [NumAssisLecturer] = @NumAssisLecturer, " +
                "[NumOtherTeachers] = @NumOtherTeachers, [SpecAttachName] = @SpecAttachName, [SpecAttachDesc] = @SpecAttachDesc,[Color]=@Color ,[NumPhdHolders]=@NumPhdHolders,[PracticalHours]=@PracticalHours,[TheoreticalHours]=@TheoreticalHours", "[InsID] = @InsID", parameterNames, values);
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
                             "[MaxSemsDL], [Diploma], [DiplomaTest], [HoursPercentage], [EducationType], [AvailableDegrees], [Faculties], [ARWURank], [THERank], [QSRank], [OtherRank], [NumOfScopusResearches], [ScopusFrom], [ScopusTo], [Infrastructure],[Accepted]";

            string[] parameterNames = {
        "@InsID", "@InsTypeID", "@InsType", "@HighEdu_Rec", "@QualityDept_Rec", "@StudyLangCitizen", "@StudyLangInter", "@JointClass",
        "@StudySystem", "@MinHours", "@MaxHours", "@ResearchScopus", "@ResearchOthers", "@Practicing", "@StudyAttendance", "@StudentsMove",
        "@StudyAttendanceDesc", "@StudentsMoveDesc", "@DistanceLearning", "@MaxHoursDL", "@MaxYearsDL", "@MaxSemsDL", "@Diploma",
        "@DiplomaTest", "@HoursPercentage", "@EducationType", "@AvailableDegrees", "@Faculties", "@ARWURank", "@THERank", "@QSRank", "@OtherRank", "@NumOfScopusResearches", "@ScopusFrom", "@ScopusTo", "@Infrastructure", "@Accepted"
    };

            object[] values = {
        academicInfo.InsID, academicInfo.InsTypeID, academicInfo.InsType, academicInfo.HighEdu_Rec, academicInfo.QualityDept_Rec,
        academicInfo.StudyLangCitizen, academicInfo.StudyLangInter, academicInfo.JointClass, academicInfo.StudySystem,
        academicInfo.MinHours, academicInfo.MaxHours, academicInfo.ResearchScopus, academicInfo.ResearchOthers, academicInfo.Practicing,
        academicInfo.StudyAttendance, academicInfo.StudentsMove, academicInfo.StudyAttendanceDesc, academicInfo.StudentsMoveDesc,
        academicInfo.DistanceLearning, academicInfo.MaxHoursDL, academicInfo.MaxYearsDL, academicInfo.MaxSemsDL, academicInfo.Diploma,
        academicInfo.DiplomaTest, academicInfo.HoursPercentage, academicInfo.EducationType, string.Join(',', academicInfo.AvailableDegrees),
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
                    hoursPercentage: row["HoursPercentage"] != DBNull.Value ? (int?)int.Parse(row["HoursPercentage"].ToString()) : null,
                    educationType: row["EducationType"].ToString(),
                    availableDegrees: row["AvailableDegrees"].ToString().Split(','),
                    faculties: row["Faculties"].ToString().Split(','),
arwuRank: row["ARWURank"] != DBNull.Value ? int.Parse(row["ARWURank"].ToString() ?? "0") : 0,
theRank: row["THERank"] != DBNull.Value ? int.Parse(row["THERank"].ToString() ?? "0") : 0,
qsRank: row["QSRank"] != DBNull.Value ? int.Parse(row["QSRank"].ToString() ?? "0") : 0,
otherRank: row["OtherRank"].ToString(),
numOfScopusResearches: row["NumOfScopusResearches"] != DBNull.Value ? int.Parse(row["NumOfScopusResearches"].ToString() ?? "0") : 0,
scopusFrom: row["ScopusFrom"] != DBNull.Value ? int.Parse(row["ScopusFrom"].ToString() ?? "0") : 0,
scopusTo: row["ScopusTo"] != DBNull.Value ? int.Parse(row["ScopusTo"].ToString() ?? "0") : 0,
infrastructure: row["Infrastructure"].ToString(),
accepted: row["Accepted"] != DBNull.Value ? bool.Parse(row["Accepted"].ToString() ?? "false") : false


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
                               "[MaxSemsDL] = @MaxSemsDL, [Diploma] = @Diploma, [DiplomaTest] = @DiplomaTest, [HoursPercentage] = @HoursPercentage, [EducationType] = @EducationType, " +
                               "[AvailableDegrees] = @AvailableDegrees, [Faculties] = @Faculties, [ARWURank] = @ARWURank, [THERank] = @THERank, [QSRank] = @QSRank, " +
                               "[OtherRank] = @OtherRank, [NumOfScopusResearches] = @NumOfScopusResearches, [ScopusFrom] = @ScopusFrom, [ScopusTo] = @ScopusTo, " +
                               "[Infrastructure] = @Infrastructure, [Accepted] = @Accepted";

            // Define the condition (which record to update)
            string condition = "[InsID] = @InsID";

            // Define the parameters to be used in the SQL query
            string[] parameterNames = {
        "@InsTypeID", "@InsType", "@HighEdu_Rec", "@QualityDept_Rec", "@StudyLangCitizen", "@StudyLangInter", "@JointClass",
        "@StudySystem", "@MinHours", "@MaxHours", "@ResearchScopus", "@ResearchOthers", "@Practicing", "@StudyAttendance",
        "@StudentsMove", "@StudyAttendanceDesc", "@StudentsMoveDesc", "@DistanceLearning", "@MaxHoursDL", "@MaxYearsDL",
        "@MaxSemsDL", "@Diploma", "@DiplomaTest", "@HoursPercentage", "@EducationType", "@AvailableDegrees", "@Faculties",
        "@ARWURank", "@THERank", "@QSRank", "@OtherRank", "@NumOfScopusResearches", "@ScopusFrom", "@ScopusTo", "@Infrastructure", "@Accepted", "@InsID"
    };

            // Set the values for each parameter
            object[] values = {
        academicInfo.InsTypeID, academicInfo.InsType, academicInfo.HighEdu_Rec, academicInfo.QualityDept_Rec, academicInfo.StudyLangCitizen,
        academicInfo.StudyLangInter, academicInfo.JointClass, academicInfo.StudySystem, academicInfo.MinHours, academicInfo.MaxHours,
        academicInfo.ResearchScopus, academicInfo.ResearchOthers, academicInfo.Practicing, academicInfo.StudyAttendance,
        academicInfo.StudentsMove, academicInfo.StudyAttendanceDesc, academicInfo.StudentsMoveDesc, academicInfo.DistanceLearning,
        academicInfo.MaxHoursDL, academicInfo.MaxYearsDL, academicInfo.MaxSemsDL, academicInfo.Diploma, academicInfo.DiplomaTest,
        academicInfo.HoursPercentage, academicInfo.EducationType, string.Join(',', academicInfo.AvailableDegrees), string.Join(',', academicInfo.Faculties),
        academicInfo.ARWURank, academicInfo.THERank, academicInfo.QSRank, academicInfo.OtherRank, academicInfo.NumOfScopusResearches,
        academicInfo.ScopusFrom, academicInfo.ScopusTo, academicInfo.Infrastructure, academicInfo.Accepted, academicInfo.InsID
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
        public void InsertInfrastructure(Infrastructure infrastructure)
        {
            string tableName = "Infrastructure";
            string columns = "[InsID], [Area], [Sites], [Terr], [Halls], [Library], [LabsAttach], [Build]";

            string[] parameterNames = { "@InsID", "@Area", "@Sites", "@Terr", "@Halls", "@Library", "@LabsAttach", "@Build" };
            object[] values = { infrastructure.InsID, infrastructure.Area, infrastructure.Sites, infrastructure.Terr, infrastructure.Halls, infrastructure.Library, infrastructure.LabsAttach, infrastructure.Build };

            // Call the InsertRecord method of the DatabaseHandler
            InsertRecord(tableName, columns, parameterNames, values);
        }
        public void UpdateInfrastructure(Infrastructure infrastructure)
        {
            string tableName = "Infrastructure";

            // Columns to update
            string setValues = "[Area] = @Area, [Sites] = @Sites, [Terr] = @Terr, [Halls] = @Halls, [Library] = @Library, [LabsAttach] = @LabsAttach, [Build] = @Build";

            // Condition for which record to update (based on InsID)
            string condition = "[InsID] = @InsID";

            string[] parameterNames = { "@Area", "@Sites", "@Terr", "@Halls", "@Library", "@LabsAttach", "@Build", "@InsID" };
            object[] values = { infrastructure.Area, infrastructure.Sites, infrastructure.Terr, infrastructure.Halls, infrastructure.Library, infrastructure.LabsAttach, infrastructure.Build, infrastructure.InsID };

            // Call the UpdateRecord method of the DatabaseHandler
            UpdateRecord(tableName, setValues, condition, parameterNames, values);
        }
        public void DeleteInfrastructure(int insID)
        {
            string tableName = "Infrastructure";

            // Condition for which record to delete (based on InsID)
            string condition = "[InsID] = @InsID";

            // Call the DeleteRecord method of the DatabaseHandler
            DeleteRecord(tableName, condition);
        }
        public void InsertLibrary(Library library)
        {
            string tableName = "Library";
            string columns = "[InsID], [Area], [Capacity], [ArBooks], [EnBooks], [Papers], [EBooks], [ESubscription]";

            string[] parameterNames = { "@InsID", "@Area", "@Capacity", "@ArBooks", "@EnBooks", "@Papers", "@EBooks", "@ESubscription" };
            object[] values = { library.InsID, library.Area, library.Capacity, library.ArBooks, library.EnBooks, library.Papers, library.EBooks, library.ESubscription };

            // Call the InsertRecord method of the DatabaseHandler
            InsertRecord(tableName, columns, parameterNames, values);
        }
        public void UpdateLibrary(Library library)
        {
            string tableName = "Library";

            // Columns to update
            string setValues = "[Area] = @Area, [Capacity] = @Capacity, [ArBooks] = @ArBooks, [EnBooks] = @EnBooks, [Papers] = @Papers, [EBooks] = @EBooks, [ESubscription] = @ESubscription";

            // Condition for which record to update (based on InsID)
            string condition = "[InsID] = @InsID";

            string[] parameterNames = { "@Area", "@Capacity", "@ArBooks", "@EnBooks", "@Papers", "@EBooks", "@ESubscription", "@InsID" };
            object[] values = { library.Area, library.Capacity, library.ArBooks, library.EnBooks, library.Papers, library.EBooks, library.ESubscription, library.InsID };

            // Call the UpdateRecord method of the DatabaseHandler
            UpdateRecord(tableName, setValues, condition, parameterNames, values);
        }
        public void DeleteLibrary(int insID)
        {
            string tableName = "Library";

            // Condition for which record to delete (based on InsID)
            string condition = "[InsID] = @InsID";

            // Call the DeleteRecord method of the DatabaseHandler
            DeleteRecord(tableName, condition);
        }
        public List<Library> GetAllLibraries()
        {
            string query = "SELECT [InsID], [Area], [Capacity], [ArBooks], [EnBooks], [Papers], [EBooks], [ESubscription] FROM Library";
            DataTable resultTable = SelectRecords(query);

            List<Library> libraryList = new();

            foreach (DataRow row in resultTable.Rows)
            {
                int insID = Convert.ToInt32(row["InsID"]);
                int? area = row["Area"] != DBNull.Value ? Convert.ToInt32(row["Area"]) : (int?)null;
                int? capacity = row["Capacity"] != DBNull.Value ? Convert.ToInt32(row["Capacity"]) : (int?)null;
                int? arBooks = row["ArBooks"] != DBNull.Value ? Convert.ToInt32(row["ArBooks"]) : (int?)null;
                int? enBooks = row["EnBooks"] != DBNull.Value ? Convert.ToInt32(row["EnBooks"]) : (int?)null;
                int? papers = row["Papers"] != DBNull.Value ? Convert.ToInt32(row["Papers"]) : (int?)null;
                int? eBooks = row["EBooks"] != DBNull.Value ? Convert.ToInt32(row["EBooks"]) : (int?)null;
                int? eSubscription = row["ESubscription"] != DBNull.Value ? Convert.ToInt32(row["ESubscription"]) : (int?)null;

                libraryList.Add(new Library(insID, area, capacity, arBooks, enBooks, papers, eBooks, eSubscription));
            }

            return libraryList;
        }
        public void InsertPicture(Pictures picture)
        {
            string tableName = "Pictures";
            string columns = "[InsID], [AttachName], [AttachDesc]";

            string[] parameterNames = { "@InsID", "@AttachName", "@AttachDesc" };
            object[] values = { picture.InsID, picture.AttachName, picture.AttachDesc };

            // Call the InsertRecord method of the DatabaseHandler
            InsertRecord(tableName, columns, parameterNames, values);
        }
        public void UpdatePicture(Pictures picture)
        {
            string tableName = "Pictures";

            // Columns to update
            string setValues = "[AttachName] = @AttachName, [AttachDesc] = @AttachDesc";

            // Condition for which record to update (based on AttachID)
            string condition = "[AttachID] = @AttachID";

            string[] parameterNames = { "@AttachName", "@AttachDesc", "@AttachID" };
            object[] values = { picture.AttachName, picture.AttachDesc, picture.AttachID };

            // Call the UpdateRecord method of the DatabaseHandler
            UpdateRecord(tableName, setValues, condition, parameterNames, values);
        }
        public void DeletePicture(int attachID)
        {
            string tableName = "Pictures";

            // Condition for which record to delete (based on AttachID)
            string condition = "[AttachID] = @AttachID";

            // Call the DeleteRecord method of the DatabaseHandler
            DeleteRecord(tableName, condition);
        }
        public List<Pictures> GetAllPictures()
        {
            string query = "SELECT [InsID], [AttachID], [AttachName], [AttachDesc] FROM Pictures";
            DataTable resultTable = SelectRecords(query);

            List<Pictures> pictureList = new();

            foreach (DataRow row in resultTable.Rows)
            {
                int insID = Convert.ToInt32(row["InsID"]);
                int attachID = Convert.ToInt32(row["AttachID"]);
                string attachName = row["AttachName"].ToString();
                string attachDesc = row["AttachDesc"].ToString();

                pictureList.Add(new Pictures(insID, attachID, attachName, attachDesc));
            }

            return pictureList;
        }
        public void InsertPublicInfo(PublicInfo publicInfo)
        {
            string tableName = "PublicInfo";
            string columns = "[InsID], [InsName], [Provider], [StartDate], [SDateT], [SDateNT], [SupervisorID], [Supervisor], " +
                             "[PreName], [PreDegree], [PreMajor], [Postal], [Phone], [Fax], [Email], [Website], [Vision], " +
                             "[Mission], [Goals], [InsValues], [LastEditDate], [EntryDate], [Country], [City], [Address], [CreationDate], [StudentAcceptanceDate], [OtherInfo]";

            string[] parameterNames = {
        "@InsID", "@InsName", "@Provider", "@StartDate", "@SDateT", "@SDateNT", "@SupervisorID", "@Supervisor",
        "@PreName", "@PreDegree", "@PreMajor", "@Postal", "@Phone", "@Fax", "@Email", "@Website", "@Vision",
        "@Mission", "@Goals", "@InsValues", "@LastEditDate", "@EntryDate", "@Country", "@City", "@Address", "@CreationDate", "@StudentAcceptanceDate", "@OtherInfo"
    };

            object[] values = {
        publicInfo.InsID, publicInfo.InsName, publicInfo.Provider, publicInfo.StartDate, publicInfo.SDateT,
        publicInfo.SDateNT, publicInfo.SupervisorID, publicInfo.Supervisor, publicInfo.PreName, publicInfo.PreDegree,
        publicInfo.PreMajor, publicInfo.Postal, publicInfo.Phone, publicInfo.Fax, publicInfo.Email, publicInfo.Website,
        publicInfo.Vision, publicInfo.Mission, publicInfo.Goals, publicInfo.InsValues, publicInfo.LastEditDate,
        publicInfo.EntryDate, publicInfo.Country, publicInfo.City, publicInfo.Address, publicInfo.CreationDate, publicInfo.StudentAcceptanceDate, publicInfo.OtherInfo
    };

            // Call the InsertRecord method of the DatabaseHandler
            InsertRecord(tableName, columns, parameterNames, values);
        }
        public void UpdatePublicInfo(PublicInfo publicInfo)
        {
            string tableName = "PublicInfo";

            // Columns to update
            string setValues = "[InsName] = @InsName, [Provider] = @Provider, [StartDate] = @StartDate, [SDateT] = @SDateT, " +
                               "[SDateNT] = @SDateNT, [SupervisorID] = @SupervisorID, [Supervisor] = @Supervisor, " +
                               "[PreName] = @PreName, [PreDegree] = @PreDegree, [PreMajor] = @PreMajor, [Postal] = @Postal, " +
                               "[Phone] = @Phone, [Fax] = @Fax, [Email] = @Email, [Website] = @Website, [Vision] = @Vision, " +
                               "[Mission] = @Mission, [Goals] = @Goals, [InsValues] = @InsValues, [LastEditDate] = @LastEditDate" +
                               "[EntryDate] = @EntryDate, [Country] = @Country, [City] = @City, [Address] = @Address, [CreationDate] = @CreationDate, [StudentAcceptanceDate] = @StudentAcceptanceDate, [OtherInfo] = @OtherInfo";


            // Condition for which record to update (based on InsID)
            string condition = "[InsID] = @InsID";

            string[] parameterNames = {
        "@InsName", "@Provider", "@StartDate", "@SDateT", "@SDateNT", "@SupervisorID", "@Supervisor", "@PreName",
        "@PreDegree", "@PreMajor", "@Postal", "@Phone", "@Fax", "@Email", "@Website", "@Vision", "@Mission",
        "@Goals", "@InsValues", "@LastEditDate", "@InsID", "@EntryDate", "@Country", "@City", "@Address", "@CreationDate", "@StudentAcceptanceDate", "@OtherInfo", "@InsID"
    };

            object[] values = {
        publicInfo.InsName, publicInfo.Provider, publicInfo.StartDate, publicInfo.SDateT, publicInfo.SDateNT,
        publicInfo.SupervisorID, publicInfo.Supervisor, publicInfo.PreName, publicInfo.PreDegree, publicInfo.PreMajor,
        publicInfo.Postal, publicInfo.Phone, publicInfo.Fax, publicInfo.Email, publicInfo.Website, publicInfo.Vision,
        publicInfo.Mission, publicInfo.Goals, publicInfo.InsValues, publicInfo.LastEditDate, publicInfo.InsID,
        publicInfo.EntryDate, publicInfo.Country, publicInfo.City, publicInfo.Address, publicInfo.CreationDate, publicInfo.StudentAcceptanceDate, publicInfo.OtherInfo, publicInfo.InsID
    };

            // Call the UpdateRecord method of the DatabaseHandler
            UpdateRecord(tableName, setValues, condition, parameterNames, values);
        }
        public void DeletePublicInfo(int insID)
        {
            string tableName = "PublicInfo";

            // Condition for which record to delete (based on InsID)
            string condition = "[InsID] = @InsID";

            // Call the DeleteRecord method of the DatabaseHandler
            DeleteRecord(tableName, condition);
        }
        public List<PublicInfo> GetAllPublicInfo()
        {
            string query = "SELECT [InsID], [InsName], [Provider], [StartDate], [SDateT], [SDateNT], [SupervisorID], [Supervisor], " +
                           "[PreName], [PreDegree], [PreMajor], [Postal], [Phone], [Fax], [Email], [Website], [Vision], " +
                           "[Mission], [Goals], [InsValues], [LastEditDate] , [EntryDate], [Country], [City], [Address], [CreationDate], [StudentAcceptanceDate], [OtherInfo] FROM PublicInfo";
            DataTable resultTable = SelectRecords(query);

            List<PublicInfo> publicInfoList = new();

            foreach (DataRow row in resultTable.Rows)
            {
                int insID = Convert.ToInt32(row["InsID"]);
                string insName = row["InsName"].ToString();
                string provider = row["Provider"].ToString();
                string startDate = row["StartDate"].ToString();
                string sDateT = row["SDateT"].ToString();
                string sDateNT = row["SDateNT"].ToString();
                int? supervisorID = row["SupervisorID"] != DBNull.Value ? Convert.ToInt32(row["SupervisorID"]) : null;
                string supervisor = row["Supervisor"].ToString();
                string preName = row["PreName"].ToString();
                string preDegree = row["PreDegree"].ToString();
                string preMajor = row["PreMajor"].ToString();
                string postal = row["Postal"].ToString();
                string phone = row["Phone"].ToString();
                string fax = row["Fax"].ToString();
                string email = row["Email"].ToString();
                string website = row["Website"].ToString();
                string vision = row["Vision"].ToString();
                string mission = row["Mission"].ToString();
                string goals = row["Goals"].ToString();
                string insValues = row["InsValues"].ToString();
                string lastEditDate = row["LastEditDate"].ToString();
                
                //todo, when finishing, check if the date is being translated properly everywhere
                
                
                    DateOnly entryDate = DateOnly.ParseExact(row["EntryDate"].ToString(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    string country = row["Country"].ToString();
                    string city = row["City"].ToString();
                    string address = row["Address"].ToString();
                    DateOnly creationDate = DateOnly.ParseExact(row["CreationDate"].ToString(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    DateOnly studentAcceptanceDate = DateOnly.ParseExact(row["StudentAcceptanceDate"].ToString(), "yyyy-MM-dd", CultureInfo.InvariantCulture);

                 
                
                string otherInfo = row["OtherInfo"].ToString();

                publicInfoList.Add(new PublicInfo(insID, insName, provider, startDate, sDateT, sDateNT, supervisorID, supervisor,
                                                  preName, preDegree, preMajor, postal, phone, fax, email, website, vision,
                                                  mission, goals, insValues, lastEditDate, entryDate, country, city, address, creationDate, studentAcceptanceDate, otherInfo));
            }

            return publicInfoList;
        }
        public void InsertStudentsAndStuff(StudentsAndStuff studentsAndStuff)
        {
            string tableName = "StudentsAndStuff";
            string columns = "[InsID], [StudentCitizen], [StudentInter], [StudentJordan], [StudentOverall], [StaffProfessor], " +
                             "[StaffCoProfessor], [StaffAssistantProfessor], [StaffLabSupervisor], [StaffResearcher], " +
                             "[StaffTeacher], [StaffTeacherAssistant], [StaffOthers]";

            string[] parameterNames = {
        "@InsID", "@StudentCitizen", "@StudentInter", "@StudentJordan", "@StudentOverall", "@StaffProfessor",
        "@StaffCoProfessor", "@StaffAssistantProfessor", "@StaffLabSupervisor", "@StaffResearcher", "@StaffTeacher",
        "@StaffTeacherAssistant", "@StaffOthers"
    };

            object[] values = {
        studentsAndStuff.InsID, studentsAndStuff.StudentCitizen, studentsAndStuff.StudentInter, studentsAndStuff.StudentJordan,
        studentsAndStuff.StudentOverall, studentsAndStuff.StaffProfessor, studentsAndStuff.StaffCoProfessor,
        studentsAndStuff.StaffAssistantProfessor, studentsAndStuff.StaffLabSupervisor, studentsAndStuff.StaffResearcher,
        studentsAndStuff.StaffTeacher, studentsAndStuff.StaffTeacherAssistant, studentsAndStuff.StaffOthers
    };

            // Call the InsertRecord method of the DatabaseHandler
            InsertRecord(tableName, columns, parameterNames, values);
        }
        public void UpdateStudentsAndStuff(StudentsAndStuff studentsAndStuff)
        {
            string tableName = "StudentsAndStuff";

            // Columns to update
            string setValues = "[StudentCitizen] = @StudentCitizen, [StudentInter] = @StudentInter, [StudentJordan] = @StudentJordan, " +
                               "[StudentOverall] = @StudentOverall, [StaffProfessor] = @StaffProfessor, [StaffCoProfessor] = @StaffCoProfessor, " +
                               "[StaffAssistantProfessor] = @StaffAssistantProfessor, [StaffLabSupervisor] = @StaffLabSupervisor, " +
                               "[StaffResearcher] = @StaffResearcher, [StaffTeacher] = @StaffTeacher, [StaffTeacherAssistant] = @StaffTeacherAssistant, " +
                               "[StaffOthers] = @StaffOthers";

            // Condition for which record to update (based on InsID)
            string condition = "[InsID] = @InsID";

            string[] parameterNames = {
        "@StudentCitizen", "@StudentInter", "@StudentJordan", "@StudentOverall", "@StaffProfessor", "@StaffCoProfessor",
        "@StaffAssistantProfessor", "@StaffLabSupervisor", "@StaffResearcher", "@StaffTeacher", "@StaffTeacherAssistant",
        "@StaffOthers", "@InsID"
    };

            object[] values = {
        studentsAndStuff.StudentCitizen, studentsAndStuff.StudentInter, studentsAndStuff.StudentJordan, studentsAndStuff.StudentOverall,
        studentsAndStuff.StaffProfessor, studentsAndStuff.StaffCoProfessor, studentsAndStuff.StaffAssistantProfessor,
        studentsAndStuff.StaffLabSupervisor, studentsAndStuff.StaffResearcher, studentsAndStuff.StaffTeacher,
        studentsAndStuff.StaffTeacherAssistant, studentsAndStuff.StaffOthers, studentsAndStuff.InsID
    };

            // Call the UpdateRecord method of the DatabaseHandler
            UpdateRecord(tableName, setValues, condition, parameterNames, values);
        }
        public void DeleteStudentsAndStuff(int insID)
        {
            string tableName = "StudentsAndStuff";

            // Condition for which record to delete (based on InsID)
            string condition = "[InsID] = @InsID";

            // Call the DeleteRecord method of the DatabaseHandler
            DeleteRecord(tableName, condition);
        }
        public List<StudentsAndStuff> GetAllStudentsAndStuff()
        {
            string query = "SELECT [InsID], [StudentCitizen], [StudentInter], [StudentJordan], [StudentOverall], [StaffProfessor], " +
                           "[StaffCoProfessor], [StaffAssistantProfessor], [StaffLabSupervisor], [StaffResearcher], [StaffTeacher], " +
                           "[StaffTeacherAssistant], [StaffOthers] FROM StudentsAndStuff";
            DataTable resultTable = SelectRecords(query);

            List<StudentsAndStuff> studentsAndStuffList = new();

            foreach (DataRow row in resultTable.Rows)
            {
                int insID = Convert.ToInt32(row["InsID"]);
                int? studentCitizen = row["StudentCitizen"] != DBNull.Value ? Convert.ToInt32(row["StudentCitizen"]) : null;
                int? studentInter = row["StudentInter"] != DBNull.Value ? Convert.ToInt32(row["StudentInter"]) : null;
                int? studentJordan = row["StudentJordan"] != DBNull.Value ? Convert.ToInt32(row["StudentJordan"]) : null;
                int? studentOverall = row["StudentOverall"] != DBNull.Value ? Convert.ToInt32(row["StudentOverall"]) : null;
                int? staffProfessor = row["StaffProfessor"] != DBNull.Value ? Convert.ToInt32(row["StaffProfessor"]) : null;
                int? staffCoProfessor = row["StaffCoProfessor"] != DBNull.Value ? Convert.ToInt32(row["StaffCoProfessor"]) : null;
                int? staffAssistantProfessor = row["StaffAssistantProfessor"] != DBNull.Value ? Convert.ToInt32(row["StaffAssistantProfessor"]) : null;
                int? staffLabSupervisor = row["StaffLabSupervisor"] != DBNull.Value ? Convert.ToInt32(row["StaffLabSupervisor"]) : null;
                int? staffResearcher = row["StaffResearcher"] != DBNull.Value ? Convert.ToInt32(row["StaffResearcher"]) : null;
                int? staffTeacher = row["StaffTeacher"] != DBNull.Value ? Convert.ToInt32(row["StaffTeacher"]) : null;
                int? staffTeacherAssistant = row["StaffTeacherAssistant"] != DBNull.Value ? Convert.ToInt32(row["StaffTeacherAssistant"]) : null;
                int? staffOthers = row["StaffOthers"] != DBNull.Value ? Convert.ToInt32(row["StaffOthers"]) : null;

                studentsAndStuffList.Add(new StudentsAndStuff(insID, studentCitizen, studentInter, studentJordan, studentOverall,
                                                              staffProfessor, staffCoProfessor, staffAssistantProfessor, staffLabSupervisor,
                                                              staffResearcher, staffTeacher, staffTeacherAssistant, staffOthers));
            }

            return studentsAndStuffList;
        }
        public void InsertStudyDuration(StudyDuration studyDuration)
        {
            string tableName = "StudyDuration";
            string columns = "[InsID], [DiplomaDegreeMIN], [DiplomaMIN], [BSCDegreeMIN], [BSCMIN], [HigherDiplomaDegreeMIN], " +
                             "[HigherDiplomaMIN], [MasterDegreeMIN], [MasterMIN], [PhDDegreeMIN], [PhDMIN]";

            string[] parameterNames = {
        "@InsID", "@DiplomaDegreeMIN", "@DiplomaMIN", "@BSCDegreeMIN", "@BSCMIN", "@HigherDiplomaDegreeMIN",
        "@HigherDiplomaMIN", "@MasterDegreeMIN", "@MasterMIN", "@PhDDegreeMIN", "@PhDMIN"
    };

            object[] values = {
        studyDuration.InsID, studyDuration.DiplomaDegreeMIN, studyDuration.DiplomaMIN, studyDuration.BSCDegreeMIN,
        studyDuration.BSCMIN, studyDuration.HigherDiplomaDegreeMIN, studyDuration.HigherDiplomaMIN,
        studyDuration.MasterDegreeMIN, studyDuration.MasterMIN, studyDuration.PhDDegreeMIN, studyDuration.PhDMIN
    };

            // Call the InsertRecord method of the DatabaseHandler
            InsertRecord(tableName, columns, parameterNames, values);
        }
        public void UpdateStudyDuration(StudyDuration studyDuration)
        {
            string tableName = "StudyDuration";

            // Columns to update
            string setValues = "[DiplomaDegreeMIN] = @DiplomaDegreeMIN, [DiplomaMIN] = @DiplomaMIN, [BSCDegreeMIN] = @BSCDegreeMIN, " +
                               "[BSCMIN] = @BSCMIN, [HigherDiplomaDegreeMIN] = @HigherDiplomaDegreeMIN, [HigherDiplomaMIN] = @HigherDiplomaMIN, " +
                               "[MasterDegreeMIN] = @MasterDegreeMIN, [MasterMIN] = @MasterMIN, [PhDDegreeMIN] = @PhDDegreeMIN, [PhDMIN] = @PhDMIN";

            // Condition for which record to update (based on InsID)
            string condition = "[InsID] = @InsID";

            string[] parameterNames = {
        "@DiplomaDegreeMIN", "@DiplomaMIN", "@BSCDegreeMIN", "@BSCMIN", "@HigherDiplomaDegreeMIN", "@HigherDiplomaMIN",
        "@MasterDegreeMIN", "@MasterMIN", "@PhDDegreeMIN", "@PhDMIN", "@InsID"
    };

            object[] values = {
        studyDuration.DiplomaDegreeMIN, studyDuration.DiplomaMIN, studyDuration.BSCDegreeMIN, studyDuration.BSCMIN,
        studyDuration.HigherDiplomaDegreeMIN, studyDuration.HigherDiplomaMIN, studyDuration.MasterDegreeMIN,
        studyDuration.MasterMIN, studyDuration.PhDDegreeMIN, studyDuration.PhDMIN, studyDuration.InsID
    };

            // Call the UpdateRecord method of the DatabaseHandler
            UpdateRecord(tableName, setValues, condition, parameterNames, values);
        }
        public void DeleteStudyDuration(int insID)
        {
            string tableName = "StudyDuration";

            // Condition for which record to delete (based on InsID)
            string condition = "[InsID] = @InsID";

            // Call the DeleteRecord method of the DatabaseHandler
            DeleteRecord(tableName, condition);
        }
        public List<StudyDuration> GetAllStudyDurations()
        {
            string query = "SELECT [InsID], [DiplomaDegreeMIN], [DiplomaMIN], [BSCDegreeMIN], [BSCMIN], [HigherDiplomaDegreeMIN], " +
                           "[HigherDiplomaMIN], [MasterDegreeMIN], [MasterMIN], [PhDDegreeMIN], [PhDMIN] FROM StudyDuration";
            DataTable resultTable = SelectRecords(query);

            List<StudyDuration> studyDurationList = new();

            foreach (DataRow row in resultTable.Rows)
            {
                int insID = Convert.ToInt32(row["InsID"]);
                string diplomaDegreeMIN = row["DiplomaDegreeMIN"].ToString();
                string diplomaMIN = row["DiplomaMIN"].ToString();
                string bscDegreeMIN = row["BSCDegreeMIN"].ToString();
                string bscMIN = row["BSCMIN"].ToString();
                string higherDiplomaDegreeMIN = row["HigherDiplomaDegreeMIN"].ToString();
                string higherDiplomaMIN = row["HigherDiplomaMIN"].ToString();
                string masterDegreeMIN = row["MasterDegreeMIN"].ToString();
                string masterMIN = row["MasterMIN"].ToString();
                string phdDegreeMIN = row["PhDDegreeMIN"].ToString();
                string phdMIN = row["PhDMIN"].ToString();

                studyDurationList.Add(new StudyDuration(insID, diplomaDegreeMIN, diplomaMIN, bscDegreeMIN, bscMIN,
                                                        higherDiplomaDegreeMIN, higherDiplomaMIN, masterDegreeMIN, masterMIN,
                                                        phdDegreeMIN, phdMIN));
            }

            return studyDurationList;
        }
        public void InsertUser(Users user)
        {
            string tableName = "Users";
            string columns = "[InsName], [InsCountry], [Email], [Password], [VerificationCode], [Verified], [Clearance], [Speciality]";

            string[] parameterNames = {
                "@InsName", "@InsCountry", "@Email", "@Password", "@VerificationCode", "@Verified", "@Clearance", "@Speciality"
            };

            object[] values = {
                user.InsName ?? (object)DBNull.Value,
                user.InsCountry ?? (object)DBNull.Value,
                user.Email ?? (object)DBNull.Value,
                user.Password ?? (object)DBNull.Value,
                user.VerificationCode ?? (object)DBNull.Value,
                user.Verified ?? (object)DBNull.Value,
                user.Clearance,
                user.Speciality ?? (object)DBNull.Value
            };

            // Call the InsertRecord method of the DatabaseHandler
            InsertRecord(tableName, columns, parameterNames, values);
        }
        public void UpdateUser(Users user)
        {
            string tableName = "Users";

            // Columns to update
            string setValues = "[InsName] = @InsName, [InsCountry] = @InsCountry, [Email] = @Email, [Password] = @Password, " +
                               "[VerificationCode] = @VerificationCode, [Verified] = @Verified , [Clearance] = @Clearance, [Speciality] = @Speciality";

            // Condition for which record to update (based on InsID)
            string condition = "[InsID] = @InsID";

            string[] parameterNames = {
                "@InsName", "@InsCountry", "@Email", "@Password", "@VerificationCode", "@Verified", "@Clearance", "@Speciality", "@InsID"
            };

            object[] values = {
                user.InsName ?? (object)DBNull.Value,
                user.InsCountry ?? (object)DBNull.Value,
                user.Email ?? (object)DBNull.Value,
                user.Password ?? (object)DBNull.Value,
                user.VerificationCode ?? (object)DBNull.Value,
                user.Verified ?? (object)DBNull.Value,
                user.Clearance,
                user.Speciality ?? (object)DBNull.Value,
                user.InsID
            };

            // Call the UpdateRecord method of the DatabaseHandler
            UpdateRecord(tableName, setValues, condition, parameterNames, values);
        }
        public void DeleteUser(int insID)
        {
            string tableName = "Users";

            // Condition for which record to delete (based on InsID)
            string condition = "[InsID] = @InsID";

            // Call the DeleteRecord method of the DatabaseHandler
            DeleteRecord(tableName, condition);
        }
        public List<Users> GetAllUsers()
        {
            string query = "SELECT [InsID], [InsName], [InsCountry], [Email], [Password], [VerificationCode], [Verified], [Clearance], [Speciality] FROM Users";
            DataTable resultTable = SelectRecords(query);

            List<Users> usersList = new();

            foreach (DataRow row in resultTable.Rows)
            {
                int insID = Convert.ToInt32(row["InsID"]);
                string insName = row["InsName"]?.ToString() ?? string.Empty;
                string insCountry = row["InsCountry"]?.ToString() ?? string.Empty;
                string email = row["Email"]?.ToString() ?? string.Empty;
                string password = row["Password"]?.ToString() ?? string.Empty;
                string verificationCode = row["VerificationCode"]?.ToString() ?? string.Empty;
                int? verified = row["Verified"] != DBNull.Value ? Convert.ToInt32(row["Verified"]) : (int?)null;
                int clearance = row["Clearance"] != DBNull.Value ? Convert.ToInt32(row["Clearance"]) : 0;
                string speciality = row["Speciality"]?.ToString() ?? string.Empty;

                usersList.Add(new Users(insID, insName, insCountry, email, password, verificationCode, verified, clearance, speciality));
            }

            return usersList;
        }

        //---------------------------------------
        // 1) InsertAcceptanceRecord
        //---------------------------------------
        public void InsertAcceptanceRecord(int insId, AcceptanceRecord record)
        {
            Console.WriteLine($"[InsertAcceptanceRecord] Called with InsID={insId}, IsAccepted={record.IsAccepted}, Date={record.Date}, ReasonCount={record.Reason.Count}");

            // A) Determine the next RecordNo for this InsID
            int nextRecordNo = 1; // default to 1 if none found
            string countQuery = "SELECT COUNT(*) FROM AcceptanceRecord WHERE InsID=@InsID";

            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(countQuery, conn))
            {
                cmd.Parameters.AddWithValue("@InsID", insId);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                nextRecordNo = count + 1;
            }
            Console.WriteLine($"[InsertAcceptanceRecord] Next recordNo for InsID={insId} is {nextRecordNo}.");

            // B) Convert boolean -> "Accepted" / "Rejected"
            string resultString = record.IsAccepted ? "Accepted" : "Rejected";
            // C) Convert reasons to JSON
            string reasonJson = JsonConvert.SerializeObject(record.Reason);
            // D) Insert the new row
            string insertSql = @"
                INSERT INTO AcceptanceRecord
                    (InsID, RecordNo, DateOfRecord, Result, Message)
                VALUES
                    (@InsID, @RecordNo, @DateOfRecord, @Result, @Message);";

            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(insertSql, conn))
            {
                cmd.Parameters.AddWithValue("@InsID", insId);
                cmd.Parameters.AddWithValue("@RecordNo", nextRecordNo);
                cmd.Parameters.AddWithValue("@DateOfRecord", record.Date.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@Result", resultString);
                cmd.Parameters.AddWithValue("@Message", reasonJson);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            // E) Also update AcademicInfo.Accepted
            //    1 means "true", 0 means "false"
            UpdateAcademicAccepted(insId, record.IsAccepted);
            Console.WriteLine($"[InsertAcceptanceRecord] Insert + academic updated done for InsID={insId}.");
        }

        //---------------------------------------
        // 2) GetAllAcceptanceRecords
        //---------------------------------------
        public List<AcceptanceRecord> GetAllAcceptanceRecordsByInsId(int insId)
        {
            Console.WriteLine($"[GetAllAcceptanceRecords] Called with InsID={insId}.");
            List<AcceptanceRecord> results = new List<AcceptanceRecord>();

            string selectSql = @"
                SELECT RecordNo, DateOfRecord, Result, Message
                FROM AcceptanceRecord
                WHERE InsID=@InsID
                ORDER BY RecordNo ASC;";

            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(selectSql, conn))
            {
                cmd.Parameters.AddWithValue("@InsID", insId);
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int recordNo = reader.GetInt32(0);
                        DateTime dt = reader.GetDateTime(1);
                        string result = reader.GetString(2);
                        string message = reader.GetString(3);

                        bool isAccepted = (result == "Accepted");
                        DateOnly dateOfRecord = DateOnly.FromDateTime(dt);

                        // Convert message back to List<string>
                        List<string> reasons = JsonConvert.DeserializeObject<List<string>>(message);

                        // Rebuild an AcceptanceRecord
                        AcceptanceRecord rec = new AcceptanceRecord(isAccepted, dateOfRecord, reasons);
                        results.Add(rec);
                    }
                }
            }

            Console.WriteLine($"[GetAllAcceptanceRecords] Found {results.Count} record(s) for InsID={insId}.");
            return results;
        }

        //---------------------------------------
        // 3) UpdateAcceptanceRecord (Optional)
        //---------------------------------------
        public void UpdateAcceptanceRecord(int insId, int recordNo, AcceptanceRecord record)
        {
            Console.WriteLine($"[UpdateAcceptanceRecord] Called with InsID={insId}, recordNo={recordNo}.");

            string updateSql = @"
                UPDATE AcceptanceRecord
                SET DateOfRecord=@DateOfRecord, Result=@Result, Message=@Message
                WHERE InsID=@InsID AND RecordNo=@RecordNo;";

            string resultString = record.IsAccepted ? "Accepted" : "Rejected";
            string reasonJson = JsonConvert.SerializeObject(record.Reason);

            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(updateSql, conn))
            {
                cmd.Parameters.AddWithValue("@InsID", insId);
                cmd.Parameters.AddWithValue("@RecordNo", recordNo);
                cmd.Parameters.AddWithValue("@DateOfRecord", record.Date.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@Result", resultString);
                cmd.Parameters.AddWithValue("@Message", reasonJson);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                Console.WriteLine($"[UpdateAcceptanceRecord] Affected rows = {rows} for InsID={insId}, recordNo={recordNo}.");
            }

            // Also update AcademicInfo.Accepted
            UpdateAcademicAccepted(insId, record.IsAccepted);
        }

        //---------------------------------------
        // 4) UpdateAcademicAccepted
        //---------------------------------------
        public void UpdateAcademicAccepted(int insId, bool isAccepted)
        {
            Console.WriteLine($"[UpdateAcademicAccepted] Setting AcademicInfo.Accepted = {isAccepted} for InsID={insId}.");

            string updateSql = @"
                UPDATE AcademicInfo
                SET Accepted=@AcceptedValue
                WHERE InsID=@InsID;";

            int acceptedVal = isAccepted ? 1 : 0;

            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(updateSql, conn))
            {
                cmd.Parameters.AddWithValue("@InsID", insId);
                cmd.Parameters.AddWithValue("@AcceptedValue", acceptedVal);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                Console.WriteLine($"[UpdateAcademicAccepted] Done. Rows affected={rows} for InsID={insId}.");
            }
        }

        

}
}

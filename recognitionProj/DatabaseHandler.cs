using Microsoft.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;




namespace recognitionProj;

public class DatabaseHandler//this class is to create the connection to the database
{
    // Private field to store the connection string
    private readonly string _connectionString;

    // Constructor to initialize connection string
    public DatabaseHandler(string connectionString)
    {
        _connectionString = connectionString;
    }


    

    // You can add more methods to interact with the database (insert, update, etc.)
    public void Query(string query)//manual query
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
                connection.Close();
            }
            catch (SqlException ex)
            {
                // Handle exceptions
                throw new Exception("Database query failed", ex);
            }
        }
    }

    public void InsertRecord(string tableName, string columns, string values)
    {
        string query = $"INSERT INTO {tableName} ({columns}) VALUES ({values})";

        using (SqlConnection connection = new(_connectionString))
        {
            try
            {
                connection.Open();
                using (SqlCommand command = new(query, connection))
                {
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            catch (SqlException ex)
            {
                // Handle exceptions
                throw new Exception("Database insert operation failed", ex);
            }
        }
    }

    public void UpdateRecord(string tableName, string setValues, string condition)
    {
        string query = $"UPDATE {tableName} SET {setValues} WHERE {condition}";

        using (SqlConnection connection = new(_connectionString))
        {
            try
            {
                connection.Open();
                using (SqlCommand command = new(query, connection))
                {
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            catch (SqlException ex)
            {
                // Handle exceptions
                throw new Exception("Database update operation failed", ex);
            }
        }
    }

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
                connection.Close();
            }
            catch (SqlException ex)
            {
                // Handle exceptions
                throw new Exception("Database delete operation failed", ex);
            }
        }
    }

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
                connection.Close();
            }
            catch (SqlException ex)
            {
                // Handle exceptions
                throw new Exception("Database select operation failed", ex);
            }
        }

        return dataTable;
    }
    public void InsertUniversity(University university)
    {

  

        string tableName = "Universities";
        string columns = "Name, EntryDate, Supervisor, Country, City, Address, Website, CreationDate, StudentAcceptanceDate, StartDate, Type, Language, EducationType, AvailableDegrees, HoursSystem, Faculties, ARWURank, THERank, QSRank, OtherRank, NumOfScopusResearches, ScopusFrom, ScopusTo, Infrastructure, OtherInfo, AcceptanceRecord, SuggestionRecord,Specializations , Accepted";
       //there is a red in the next line, something is wrong
        string values = $"'{university.Name}', '{university.EntryDate}', '{university.Supervisor}', '{university.Country}', '{university.City}', '{university.Address}', '{university.Website}', '{university.CreationDate}', '{university.StudentAcceptanceDate}', '{university.StartDate}', '{university.Type}', '{university.Language}', '{university.EducationType}', '{university.AvailableDegrees}', '{university.HoursSystem}', '{university.Faculties}', '{university.ARWURank}', '{university.THERank}', '{university.QSRank}', '{university.OtherRank}', '{university.NumOfScopusResearches}', '{university.ScopusFrom}', '{university.ScopusTo}', '{university.Infrastructure}', '{university.OtherInfo}', '{JsonConvert.SerializeObject(university.AcceptanceRecord)}', '{JsonConvert.SerializeObject(university.SuggestionRecord)}', '{JsonConvert.SerializeObject(university.Specializations)}', '{university.Accepted}'";
        InsertRecord(tableName, columns, values);
    }

    public University GetUniversity(string UniName)
    {
        // Construct the SQL query to fetch the university by its name
        string query = $"SELECT * FROM Universities WHERE Name = '{UniName}'";

        // Fetch the data using the provided SelectRecords method
        DataTable dataTable = SelectRecords(query);

        // Check if the DataTable has any rows (i.e., university was found)
        if (dataTable.Rows.Count > 0)
        {
            // Map the DataRow to a University object using the provided constructor
            DataRow row = dataTable.Rows[0];  // Assuming there is only one row for the university

            return new University(
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
                availableDegrees: row["AvailableDegrees"].ToString().Split(','),  // Assuming it's stored as a comma-separated string
                hoursSystem: row["HoursSystem"].ToString(),
                faculties: row["Faculties"].ToString().Split(','),  // Assuming it's stored as a comma-separated string
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
            return null;  // Return null if no university found
        }
    }

    public void InsertAcademicInfo(AcademicInfo academicInfo)
    {
        string tableName = "AcademicInfo";
        string columns = "[InsID], [InsTypeID], [InsType], [HighEdu_Rec], [QualityDept_Rec], [StudyLangCitizen], [StudyLangInter], [JointClass], [StudySystem], [MinHours], [MaxHours], [ResearchScopus], [ResearchOthers], [Practicing], [StudyAttendance], [StudentsMove], [StudyAttendanceDesc], [StudentsMoveDesc], [DistanceLearning], [MaxHoursDL], [MaxYearsDL], [MaxSemsDL], [Diploma], [DiplomaTest], [HoursPercentage]";
        string values = $"{academicInfo.InsID}, {academicInfo.InsTypeID}, '{academicInfo.InsType}', {academicInfo.HighEdu_Rec}, {academicInfo.QualityDept_Rec}, '{academicInfo.StudyLangCitizen}', '{academicInfo.StudyLangInter}', {academicInfo.JointClass}, '{academicInfo.StudySystem}', {academicInfo.MinHours}, {academicInfo.MaxHours}, '{academicInfo.ResearchScopus}', '{academicInfo.ResearchOthers}', {academicInfo.Practicing}, {academicInfo.StudyAttendance}, {academicInfo.StudentsMove}, '{academicInfo.StudyAttendanceDesc}', '{academicInfo.StudentsMoveDesc}', {academicInfo.DistanceLearning}, {academicInfo.MaxHoursDL}, {academicInfo.MaxYearsDL}, {academicInfo.MaxSemsDL}, {academicInfo.Diploma}, {academicInfo.DiplomaTest}, {academicInfo.HoursPercentage}";
        InsertRecord(tableName, columns, values);
    }

    public AcademicInfo GetAcademicInfo(int insID)
    {
        string query = $"SELECT * FROM AcademicInfo WHERE InsID = {insID}";
        DataTable dataTable = SelectRecords(query);

        if (dataTable.Rows.Count > 0)
        {
            DataRow row = dataTable.Rows[0];

            return new AcademicInfo
            {
                InsID = int.Parse(row["InsID"].ToString()),
                InsTypeID = row["InsTypeID"] != DBNull.Value ? int.Parse(row["InsTypeID"].ToString()) : null,
                InsType = row["InsType"].ToString(),
                HighEdu_Rec = row["HighEdu_Rec"] != DBNull.Value ? int.Parse(row["HighEdu_Rec"].ToString()) : null,
                QualityDept_Rec = row["QualityDept_Rec"] != DBNull.Value ? int.Parse(row["QualityDept_Rec"].ToString()) : null,
                StudyLangCitizen = row["StudyLangCitizen"].ToString(),
                StudyLangInter = row["StudyLangInter"].ToString(),
                JointClass = row["JointClass"] != DBNull.Value ? int.Parse(row["JointClass"].ToString()) : null,
                StudySystem = row["StudySystem"].ToString(),
                MinHours = row["MinHours"] != DBNull.Value ? int.Parse(row["MinHours"].ToString()) : null,
                MaxHours = row["MaxHours"] != DBNull.Value ? int.Parse(row["MaxHours"].ToString()) : null,
                ResearchScopus = row["ResearchScopus"].ToString(),
                ResearchOthers = row["ResearchOthers"].ToString(),
                Practicing = row["Practicing"] != DBNull.Value ? int.Parse(row["Practicing"].ToString()) : null,
                StudyAttendance = row["StudyAttendance"] != DBNull.Value ? int.Parse(row["StudyAttendance"].ToString()) : null,
                StudentsMove = row["StudentsMove"] != DBNull.Value ? int.Parse(row["StudentsMove"].ToString()) : null,
                StudyAttendanceDesc = row["StudyAttendanceDesc"].ToString(),
                StudentsMoveDesc = row["StudentsMoveDesc"].ToString(),
                DistanceLearning = row["DistanceLearning"] != DBNull.Value ? int.Parse(row["DistanceLearning"].ToString()) : null,
                MaxHoursDL = row["MaxHoursDL"] != DBNull.Value ? int.Parse(row["MaxHoursDL"].ToString()) : null,
                MaxYearsDL = row["MaxYearsDL"] != DBNull.Value ? int.Parse(row["MaxYearsDL"].ToString()) : null,
                MaxSemsDL = row["MaxSemsDL"] != DBNull.Value ? int.Parse(row["MaxSemsDL"].ToString()) : null,
                Diploma = row["Diploma"] != DBNull.Value ? int.Parse(row["Diploma"].ToString()) : null,
                DiplomaTest = row["DiplomaTest"] != DBNull.Value ? int.Parse(row["DiplomaTest"].ToString()) : null,
                HoursPercentage = row["HoursPercentage"] != DBNull.Value ? int.Parse(row["HoursPercentage"].ToString()) : null
            };
        }
        else
        {
            return null;
        }
    }










    //we can customize and make our own methods to interact with the database laters

}


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
            string tableName = "Universities";
            string columns = "Name, EntryDate, Supervisor, Country, City, Address, Website, CreationDate, StudentAcceptanceDate, StartDate, Type, Language, EducationType, AvailableDegrees, HoursSystem, Faculties, ARWURank, THERank, QSRank, OtherRank, NumOfScopusResearches, ScopusFrom, ScopusTo, Infrastructure, OtherInfo, AcceptanceRecord, SuggestionRecord, Specializations, Accepted";

            string[] parameterNames = new string[]
            {
                "@Name", "@EntryDate", "@Supervisor", "@Country", "@City", "@Address", "@Website", "@CreationDate", "@StudentAcceptanceDate",
                "@StartDate", "@Type", "@Language", "@EducationType", "@AvailableDegrees", "@HoursSystem", "@Faculties", "@ARWURank", "@THERank",
                "@QSRank", "@OtherRank", "@NumOfScopusResearches", "@ScopusFrom", "@ScopusTo", "@Infrastructure", "@OtherInfo", "@AcceptanceRecord",
                "@SuggestionRecord", "@Specializations", "@Accepted"
            };
            //todo red lines here, fix
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
            string columns = "[Name], [Type], [NumOfStudents], [NumOfFullTimeTeachers], [NumOfPartTimeTeachers], [NumOfOstadh], [NumOfOstadhMusharek], [NumOfOstadhMusa3ed], [NumOfMusharek], [NumOfMusa3ed], [NumberOfLecturers], [NumOfMudaresMusa3ed], [NumOfMudares], [NumOfOtherTeachers], [SpecAttachName], [SpecAttachDesc]";

            string[] parameterNames = {
        "@Name", "@Type", "@NumOfStudents", "@NumOfFullTimeTeachers", "@NumOfPartTimeTeachers",
        "@NumOfOstadh", "@NumOfOstadhMusharek", "@NumOfOstadhMusa3ed", "@NumOfMusharek",
        "@NumOfMusa3ed", "@NumberOfLecturers", "@NumOfMudaresMusa3ed", "@NumOfMudares",
        "@NumOfOtherTeachers", "@SpecAttachName", "@SpecAttachDesc"
    };

            object[] values = {
        specialization.Name, specialization.Type, specialization.NumOfStudents,
        specialization.NumOfFullTimeTeachers, specialization.NumOfPartTimeTeachers,
        specialization.NumOfOstadh, specialization.NumOfOstadhMusharek, specialization.NumOfOstadhMusa3ed,
        specialization.NumOfMusharek, specialization.NumOfMusa3ed, specialization.NumberOfLecturers,
        specialization.NumOfMudaresMusa3ed, specialization.NumOfMudares, specialization.NumOfOtherTeachers,
        specialization.SpecAttachName, specialization.SpecAttachDesc
    };

            // Use the updated InsertRecord method with parameters
            InsertRecord(tableName, columns, parameterNames, values);
        }


        // Fetch a specialization record by name
        public Specialization GetSpecialization(string specName)
        {
            string query = $"SELECT * FROM Specializations WHERE [Name] = @Name";
            string[] parameterNames = { "@Name" };
            object[] values = { specName };

            DataTable dataTable = SelectRecords(query, parameterNames, values);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];

                return new Specialization(
                    name: row["Name"].ToString(),
                    type: row["Type"].ToString(),
                    numOfStudents: int.Parse(row["NumOfStudents"].ToString()),
                    numOfFullTimeTeachers: int.Parse(row["NumOfFullTimeTeachers"].ToString()),
                    numOfPartTimeTeachers: int.Parse(row["NumOfPartTimeTeachers"].ToString()),
                    numOfOstadh: int.Parse(row["NumOfOstadh"].ToString()),
                    numOfOstadhMusharek: int.Parse(row["NumOfOstadhMusharek"].ToString()),
                    numOfOstadhMusa3ed: int.Parse(row["NumOfOstadhMusa3ed"].ToString()),
                    numOfMusharek: int.Parse(row["NumOfMusharek"].ToString()),
                    numOfMusa3ed: int.Parse(row["NumOfMusa3ed"].ToString()),
                    numberOfLecturers: int.Parse(row["NumberOfLecturers"].ToString()),
                    numOfMudaresMusa3ed: int.Parse(row["NumOfMudaresMusa3ed"].ToString()),
                    numOfMudares: int.Parse(row["NumOfMudares"].ToString()),
                    numOfOtherTeachers: int.Parse(row["NumOfOtherTeachers"].ToString()),
                    specAttachName: row["SpecAttachName"].ToString(),
                    specAttachDesc: row["SpecAttachDesc"].ToString()
                );
            }
            else
            {
                return null;
            }
        }


        // Update an existing specialization record
        public void UpdateSpecialization(Specialization specialization)
        {
            string tableName = "Specializations";
            string setValues = "[Type] = @Type, [NumOfStudents] = @NumOfStudents, [NumOfFullTimeTeachers] = @NumOfFullTimeTeachers, [NumOfPartTimeTeachers] = @NumOfPartTimeTeachers, [NumOfOstadh] = @NumOfOstadh, [NumOfOstadhMusharek] = @NumOfOstadhMusharek, [NumOfOstadhMusa3ed] = @NumOfOstadhMusa3ed, [NumOfMusharek] = @NumOfMusharek, [NumOfMusa3ed] = @NumOfMusa3ed, [NumberOfLecturers] = @NumberOfLecturers, [NumOfMudaresMusa3ed] = @NumOfMudaresMusa3ed, [NumOfMudares] = @NumOfMudares, [NumOfOtherTeachers] = @NumOfOtherTeachers, [SpecAttachName] = @SpecAttachName, [SpecAttachDesc] = @SpecAttachDesc";

            string condition = "[Name] = @Name";

            string[] parameterNames = {
        "@Type", "@NumOfStudents", "@NumOfFullTimeTeachers", "@NumOfPartTimeTeachers",
        "@NumOfOstadh", "@NumOfOstadhMusharek", "@NumOfOstadhMusa3ed", "@NumOfMusharek",
        "@NumOfMusa3ed", "@NumberOfLecturers", "@NumOfMudaresMusa3ed", "@NumOfMudares",
        "@NumOfOtherTeachers", "@SpecAttachName", "@SpecAttachDesc", "@Name"
    };

            object[] values = {
        specialization.Type, specialization.NumOfStudents, specialization.NumOfFullTimeTeachers,
        specialization.NumOfPartTimeTeachers, specialization.NumOfOstadh,
        specialization.NumOfOstadhMusharek, specialization.NumOfOstadhMusa3ed,
        specialization.NumOfMusharek, specialization.NumOfMusa3ed, specialization.NumberOfLecturers,
        specialization.NumOfMudaresMusa3ed, specialization.NumOfMudares, specialization.NumOfOtherTeachers,
        specialization.SpecAttachName, specialization.SpecAttachDesc, specialization.Name
    };

            // Use the updated UpdateRecord method with parameters
            UpdateRecord(tableName, setValues, condition, parameterNames, values);
        }

        // Additional methods for AcademicInfo and other records can follow the same pattern
    }
}

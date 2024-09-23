namespace recognitionProj
{
    public class Verifier
    {
        private University _uni;
        private List<string> _message;
        private bool _verified;

        public Verifier(University uni)
        {
            _uni = uni;
            _message = new List<string>();

        }

        public List<string> Message // Change the type of Message to List<string>
        {
            get => _message;
            set => _message = value;
        }

        public University Uni
        {
            get => _uni;
            set => _uni = value;
        }

        public bool Verified
        {
            get => _verified;
            set => _verified = value;

        }

        // Helper function to check if the lab has qualified technicians(article 8)
        private bool _hasQualifiedTechnician(Lab lab)
        {
            foreach (var teacher in lab.Teachers)
            {
                // Assuming _jobTitle or some field indicates a technician
                if (teacher.JobTitle.Equals("Technician") && teacher.EduLevel.Equals("Diploma"))
                {
                    return true;
                }
            }
            return false;
        }

        
        public void Verify()
        {
            if (_uni == null)
            {
                _message.Add("University object is null"); // Append error message to _message

            }
            if (_uni.Name == null)
            {
                _message.Add("University name is null"); // Append error message to _message

            }

            if (_uni.Name == "")
            {
                _message.Add("University name is empty"); // Append error message to _message

            }

            if (_uni.Specializations == null)
            {
                _message.Add("University specializations list is null"); // Append error message to _message

            }


            if (_uni.Specializations.Length == 0)
            {
                _message.Add("University specializations list is empty"); // Append error message to _message

            }

            if (_uni.Teachers == null)
            {
                _message.Add("University teachers list is null"); // Append error message to _message
                return;
            }

            if (_uni.Teachers.Length == 0)
            {
                _message.Add("University teachers list is empty"); // Append error message to _message

            }



            if (_uni.StudentCount == 0)
            {
                _message.Add("University students list is empty"); // Append error message to _message

            }

            if (_uni.Teachers == null)
            {
                _message.Add("University teachers list is null"); // Append error message to _message

            }
            if (_uni.Teachers.Length == 0)//todo why is this not working?????
            {
                _message.Add("University teachers list is empty"); // Append error message to _message

            }

            if (_uni.Specializations == null)
            {
                _message.Add("University specializations list is null"); // Append error message to _message



            }

            if (_uni.Specializations.Length == 0)//todo why is this not working?????
            {
                _message.Add("University specializations list is empty"); // Append error message to _message

            }

            if (!_uni.IsPrepared)
            {

                _message.Add("University is not prepared based on article 12 requirements");
            } // Append error message to _message


            //article 16
            if (_uni.OutstandingFees)
            {
                foreach (AcceptanceRecord record in _uni.AcceptanceRecords)
                {
                    if (!record.IsAccepted&& record.Reason.Contains("University has outstanding fees"))
                    {
                        if (record.Date.AddMonths(6) > DateOnly.FromDateTime(DateTime.Now)) // Change DateTime.Now to DateOnly.FromDateTime(DateTime.Now)
                        {
                            _message.Add("University has outstanding fees and has applied again within 6 months of the last application"); // article 16 of pdf 22222
                        }
                    }
                }

                _message.Add("University has outstanding fees"); // Append error message to _message

            }

            
            foreach (Specialization specialization in _uni.Specializations)
            {
                //article 4
                if (specialization.UniReqCourseHrs < 21 || specialization.UniReqCourseHrs > 27)
                {
                    _message.Add($"Specialization {specialization.Name} has UniReqCourseHrs not between 21 and 27 inclusive");
                }
                //article 4
                if (specialization.ColReqCourseHrs / specialization.TotalHours < 0.15)
                {
                    _message.Add($"Specialization {specialization.Name} has ColReqCourseHrs less than 15% of total hours");

                }
                //article 4
                if ((specialization.SpecReqCourseHrsTheory + specialization.SpecReqCourseHrsPractical) / specialization.TotalHours < 0.6)
                {

                    _message.Add($"Specialization {specialization.Name} has SpecReqCourseHrs less than 60% of total hours");
                }
                //article 4
                if (specialization.SpecReqCourseHrsTheory / (specialization.SpecReqCourseHrsTheory + specialization.SpecReqCourseHrsPractical) < 0.4 || specialization.SpecReqCourseHrsTheory / (specialization.SpecReqCourseHrsTheory + specialization.SpecReqCourseHrsPractical) > 0.5)
                {
                    _message.Add($"Specialization {specialization.Name} has SpecReqCourseHrsTheory not between 40% and 50% of total specialization hours");
                }
                //article 4
                if (specialization.SpecReqCourseHrsPractical / (specialization.SpecReqCourseHrsTheory + specialization.SpecReqCourseHrsPractical) < 0.5 || specialization.SpecReqCourseHrsPractical / (specialization.SpecReqCourseHrsTheory + specialization.SpecReqCourseHrsPractical) > 0.6)
                {
                    _message.Add($"Specialization {specialization.Name} has SpecReqCourseHrsTheory not between 50% and 60% of total specialization hours");
                }
                //article 4
                if (specialization.FreeCourseHrs > 6)
                {
                    _message.Add($"Specialization {specialization.Name} has FreeCourseHrs more than 6 hours");
                }
                //article 4
                //if (specialization.InternshipHrs < 6) // we need to check for the specialization type first (article 4 part b.2)
                //{
                //    _message.Add($"Specialization {specialization.Name} has InternshipHrs less than 6 hours");
                //}
                //article 4
                if (specialization.GradProjectHrs < 3)
                {
                    _message.Add($"Specialization {specialization.Name} has GradProjectHrs less than 3 hours");
                }
                //article 5
                if (specialization.Teachers == null)
                {
                    _message.Add($"Specialization {specialization.Name} has teachers list null");
                }
                //article 5
                if (specialization.Teachers.Length == 0)
                {
                    _message.Add($"Specialization {specialization.Name} has teachers list empty");
                }
                //article 5
                int phdTeachers = 0;
                bool hasAssociateProfessorOrHigher = false;
                int jordanianTeachers = 0;
                int longTermContractTeachers = 0;
                int teachersAboveSeventy = 0;
                bool specialExceptionForRareSpecialization = specialization.HasSpecialException; // Assuming this flag is set for special cases
                foreach (Teacher teacher in specialization.Teachers)
                {
                    //article 5
                    if (teacher.EduLevel == "PhD" && teacher.FullTime)
                    {
                        phdTeachers++;
                    }
                    //article 5
                    if (teacher.JobTitle == "Associate Professor" || teacher.JobTitle == "Professor")
                    {
                        hasAssociateProfessorOrHigher = true;
                    }
                    //article 5
                    if (teacher.SpecializationPracticalExperience == null)
                    {
                        _message.Add($"Teacher {teacher.Name} has specialization practical experience list null");
                    }
                    //article 5
                    if (!teacher.SameField)
                    {
                        _message.Add($"Teacher {teacher.Name} does not have all certificates in the same field");
                    }
                    //article 5
                    if (!teacher.DiverseCert)
                    {
                        _message.Add($"Teacher {teacher.Name} does not have certificates from different places");
                    }
                    //article 5
                    if (!teacher.FivePointFive)
                    {
                        _message.Add($"Teacher {teacher.Name} does not meet requirement 5.5");
                    }
                    //article 5
                    if (teacher.EduLevel == "PhD" && teacher.FullTime)
                    {
                        phdTeachers++;
                    }
                    //article 5
                    if (teacher.JobTitle == "Associate Professor" || teacher.JobTitle == "Professor")
                    {
                        hasAssociateProfessorOrHigher = true;
                    }
                    //article 5
                    // Check if the teacher is Jordanian
                    if (teacher.Jordanian)
                    {
                        jordanianTeachers++;
                    }
                    //article 5
                    // Check if the teacher has a contract longer than 3 years
                    if (teacher.ContractLength >= 3)
                    {
                        longTermContractTeachers++;
                    }
                    //article 5
                    // Check if the teacher is older than 70
                    if (teacher.Age >= 70)
                    {
                        teachersAboveSeventy++;
                    }

                }
                //article 5
                if (phdTeachers < 3)
                {
                    _message.Add($"Specialization {specialization.Name} has less than 3 full-time PhD teachers.");
                }
                //article 5
                if (!hasAssociateProfessorOrHigher)
                {
                    _message.Add($"Specialization {specialization.Name} does not have an Associate Professor or higher.");
                }
                //article 5
                int experiencedTeachers = specialization.Teachers.Count(t => t.SpecializationPracticalExperience.Any(e => e.YearsOfExperience >= 3));
                if ((float)experiencedTeachers / specialization.Teachers.Length < 0.2)
                {
                    _message.Add($"Specialization {specialization.Name} does not have at least 20% of teachers with 3+ years of practical experience.");
                }
                //article 5
                // Verify that at least 75% of teachers in the specialization are Jordanian
                if (!specialExceptionForRareSpecialization && ((float)jordanianTeachers / specialization.Teachers.Length) < 0.75)
                {
                    _message.Add($"Specialization {specialization.Name} has less than 75% Jordanian teachers.");
                }
                //article 5
                // Verify that at least 50% of teachers have contracts longer than 3 years
                if ((float)longTermContractTeachers / specialization.Teachers.Length < 0.5)
                {
                    _message.Add($"Specialization {specialization.Name} has less than 50% of teachers with contracts of 3 years or more.");
                }
                //article 5
                // Check if there are teachers above 70 without special approval
                if (teachersAboveSeventy > 0 && !_uni.HasBoardApprovalForTeachersAboveSeventy)
                {
                    _message.Add($"Specialization {specialization.Name} has teachers above 70 years old without board approval.");
                }
                //article 6
                // New check: Student-to-teacher ratio based on specialization type article 6
                int studentCount = specialization.NumOfStudents;
                int teacherCount = specialization.Teachers.Length;
                //article 6
                if (teacherCount == 0)
                {
                    _message.Add($"Specialization {specialization.Name} has no teachers assigned.");
                    continue; // Skip the ratio check if there are no teachers
                }
                //article 6
                // Determine the maximum allowed ratio based on specialization type
                int maxRatio = specialization.Scientific ? 20 : 25; // 20 for scientific, 25 for humanities
                //article 6
                // Calculate the actual student-to-teacher ratio
                int actualRatio = studentCount / teacherCount;

                if (actualRatio > maxRatio)
                {
                    _message.Add($"Specialization {specialization.Name} exceeds the maximum student-to-teacher ratio of {maxRatio}:1. Actual ratio: {actualRatio}:1.");
                }

                
                // Condition 2: Check the type of students (includes deferred and dropouts)
                // This might require an additional field or logic for student types
                // messages.Add("Consider deferred or dropout students in the count.");
                //article 7
                // Condition 3: Check teacher education levels
                foreach (var teacher in specialization.Teachers)
                {
                    if (teacher.JobTitle == "Assistant Lecturer" && teacher.EduLevel != "PhD")
                    {
                        _message.Add($"{teacher.Name} does not have the required PhD level.");
                    }
                }
                //article 7
                // Condition 4: At least 50% of teachers should be on contracts of 3+ years
                int longContractCount = specialization.Teachers.Count(t => t.ContractLength >= 3);
                if (longContractCount < specialization.Teachers.Length * 0.5)
                {
                    _message.Add("Less than 50% of teachers have contracts of 3 years or more.");
                }
                //article 7
                // Condition 5: Jordanian Teachers (80% for college/university, 75% for specialization)
                int jordanianCount = specialization.Teachers.Count(t => t.Jordanian);
                if (jordanianCount < specialization.Teachers.Length * 0.80)
                {
                    _message.Add("Less than 80% of teachers are Jordanian at the university level.");
                }

                if (jordanianCount < specialization.Teachers.Length * 0.75)
                {
                    _message.Add("Less than 75% of teachers are Jordanian in this specialization.");
                }
                //article 7
                // Condition 6: Exceeding exceptions for non-Jordanians
                // Placeholder for handling exceptions if non-Jordanians are allowed
                //article 7
                // Condition 7: Ensure less than 50% of teachers have only MSc degrees
                int mscCount = specialization.Teachers.Count(t => t.EduLevel == "MSc");
                int phdCount = specialization.Teachers.Count(t => t.EduLevel == "PhD");
                //article 7
                if (mscCount > phdCount)
                {
                    _message.Add("More MSc holders than PhD holders among the full-time staff.");
                }

                //we need to properly understand condition 6 in article 7

                // Other conditions to be added based on additional fields or data:
                // - Teachers with exceptions in rare specializations (handled via _hasSpecialException)
                // - Proportions of certain teacher types per field
                // - Specific research or practical experience requirements (teacher._specializationPracticalExperience)

                //article 8
                foreach (var lab in _uni.Labs)
                {
                    // Check 1: Student to Lab Supervisor Ratio (must not exceed 20:1)
                    if (lab.NumOfStudentsPerLab > 20)
                    {
                        _message.Add($"The student to supervisor ratio in lab {lab.Name} exceeds the maximum allowed (20:1).");
                    }
                    //article 8
                    // Check 2: Maximum Supervisory Load (must not exceed 18 hours per week)
                    // Check 3: Supervisor's Qualifications (must hold a minimum Bachelor's degree)
                    foreach (var teacher in lab.Teachers)
                    {
                        if (teacher.NumOfHours > 18)
                        {
                            _message.Add($"Supervisor {teacher.Name} in lab {lab.Name} exceeds the maximum supervisory load (18 hours per week).");
                        }

                        if (!teacher.EduLevel.Equals("BSc") && lab.Type.Equals("lab"))
                        {
                            _message.Add($"Supervisor {teacher.Name} in lab {lab.Name} does not meet the minimum required qualifications (Bachelor's degree).");
                        }
                    }
                    //article 8
                    // Check 4: Technician qualifications (must hold at least a diploma)
                    if (lab.Type.Equals("workshop") && !_hasQualifiedTechnician(lab))
                    {
                        _message.Add($"Lab {lab.Name} does not have a qualified technician with at least a diploma.");
                    }
                    //article x
                    // Check 5: Lab readiness
                    if (!lab.IsPrepared)
                    {
                        _message.Add($"Lab {lab.Name} is not properly prepared for use.");
                    }
                    //article x
                    // Check 6: Safety equipment
                    if (!lab.HasSafetyEquipment)
                    {
                        _message.Add($"Lab {lab.Name} does not have the required safety equipment.");
                    }
                }

                //todo more verifications
                //after all verificatons are done the next line will be executed
                _uni.AcceptanceRecords.Append(new AcceptanceRecord(_verified, DateOnly.FromDateTime(DateTime.Now), _message)); //this writes the verification result to the acceptance records

            }




        }
    }
}

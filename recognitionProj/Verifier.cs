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
            get { return _message; }
            set { _message = value; }
        }

        public University Uni
        {
            get { return _uni; }
            set { _uni = value; }
        }

        public bool Verified
        {
            get { return _verified; }
            set { _verified = value; }
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
            if (_uni.Teachers.Count == 0)//todo why is this not working?????
            {
                _message.Add("University teachers list is empty"); // Append error message to _message

            }

            if (_uni.Specializations == null)
            {
                _message.Add("University specializations list is null"); // Append error message to _message



            }

            if (_uni.Specializations.Count == 0)//todo why is this not working?????
            {
                _message.Add("University specializations list is empty"); // Append error message to _message

            }

            if (!_uni.IsPrepared)
            {

                _message.Add("University is not prepared based on article 12 requirements");
            } // Append error message to _message

            if (_uni.OutstandingFees)
            {
                foreach (AcceptanceRecord record in _uni.AcceptanceRecords)
                {
                    if (record.IsAccepted == false && record.Reason.Contains("University has outstanding fees"))
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
                if (specialization.UniReqCourseHrs < 21 || specialization.UniReqCourseHrs > 27)
                {
                    _message.Add($"Specialization {specialization.Name} has UniReqCourseHrs not between 21 and 27 inclusive");
                }

                if (specialization.ColReqCourseHrs / specialization.TotalHours < 0.15)
                {
                    _message.Add($"Specialization {specialization.Name} has ColReqCourseHrs less than 15% of total hours");

                }

                if ((specialization.SpecReqCourseHrsTheory + specialization.SpecReqCourseHrsPractical) / specialization.TotalHours < 0.6)
                {

                    _message.Add($"Specialization {specialization.Name} has SpecReqCourseHrs less than 60% of total hours");
                }

                if (specialization.SpecReqCourseHrsTheory / (specialization.SpecReqCourseHrsTheory + specialization.SpecReqCourseHrsPractical) < 0.4 || specialization.SpecReqCourseHrsTheory / (specialization.SpecReqCourseHrsTheory + specialization.SpecReqCourseHrsPractical) > 0.5)
                {
                    _message.Add($"Specialization {specialization.Name} has SpecReqCourseHrsTheory not between 40% and 50% of total specialization hours");
                }

                if (specialization.SpecReqCourseHrsPractical / (specialization.SpecReqCourseHrsTheory + specialization.SpecReqCourseHrsPractical) < 0.5 || specialization.SpecReqCourseHrsPractical / (specialization.SpecReqCourseHrsTheory + specialization.SpecReqCourseHrsPractical) > 0.6)
                {
                    _message.Add($"Specialization {specialization.Name} has SpecReqCourseHrsTheory not between 50% and 60% of total specialization hours");
                }

                if (specialization.FreeCourseHrs > 6)
                {
                    _message.Add($"Specialization {specialization.Name} has FreeCourseHrs more than 6 hours");
                }

                //if (specialization.InternshipHrs < 6) // we need to check for the specialization type first (article 4 part b.2)
                //{
                //    _message.Add($"Specialization {specialization.Name} has InternshipHrs less than 6 hours");
                //}

                if (specialization.GradProjectHrs < 3)
                {
                    _message.Add($"Specialization {specialization.Name} has GradProjectHrs less than 3 hours");
                }

                if (specialization.Teachers == null)
                {
                    _message.Add($"Specialization {specialization.Name} has teachers list null");
                }

                if (specialization.Teachers.Count == 0)
                {
                    _message.Add($"Specialization {specialization.Name} has teachers list empty");
                }
                int phdTeachers = 0;
                bool hasAssociateProfessorOrHigher = false;
                int jordanianTeachers = 0;
                int longTermContractTeachers = 0;
                int teachersAboveSeventy = 0;
                bool specialExceptionForRareSpecialization = specialization.HasSpecialException; // Assuming this flag is set for special cases
                foreach (Teacher teacher in specialization.Teachers)
                {
                    if (teacher.EduLevel == "PhD" && teacher.FullTime)
                    {
                        phdTeachers++;
                    }

                    if (teacher.JobTitle == "Associate Professor" || teacher.JobTitle == "Professor")
                    {
                        hasAssociateProfessorOrHigher = true;
                    }

                    if (teacher.SpecializationPracticalExperience == null)
                    {
                        _message.Add($"Teacher {teacher.Name} has specialization practical experience list null");
                    }

                    if (!teacher.SameField)
                    {
                        _message.Add($"Teacher {teacher.Name} does not have all certificates in the same field");
                    }

                    if (!teacher.DiverseCert)
                    {
                        _message.Add($"Teacher {teacher.Name} does not have certificates from different places");
                    }

                    if (!teacher.FivePointFive)
                    {
                        _message.Add($"Teacher {teacher.Name} does not meet requirement 5.5");
                    }

                    if (teacher.EduLevel == "PhD" && teacher.FullTime)
                    {
                        phdTeachers++;
                    }

                    if (teacher.JobTitle == "Associate Professor" || teacher.JobTitle == "Professor")
                    {
                        hasAssociateProfessorOrHigher = true;
                    }

                    // Check if the teacher is Jordanian
                    if (teacher.Jordanian)
                    {
                        jordanianTeachers++;
                    }

                    // Check if the teacher has a contract longer than 3 years
                    if (teacher.ContractLength >= 3)
                    {
                        longTermContractTeachers++;
                    }

                    // Check if the teacher is older than 70
                    if (teacher.Age >= 70)
                    {
                        teachersAboveSeventy++;
                    }

                }

                if (phdTeachers < 3)
                {
                    _message.Add($"Specialization {specialization.Name} has less than 3 full-time PhD teachers.");
                }

                if (!hasAssociateProfessorOrHigher)
                {
                    _message.Add($"Specialization {specialization.Name} does not have an Associate Professor or higher.");
                }

                int experiencedTeachers = specialization.Teachers.Count(t => t.SpecializationPracticalExperience.Any(e => e.YearsOfExperience >= 3));
                if ((float)experiencedTeachers / specialization.Teachers.Length < 0.2)
                {
                    _message.Add($"Specialization {specialization.Name} does not have at least 20% of teachers with 3+ years of practical experience.");
                }

                // Verify that at least 75% of teachers in the specialization are Jordanian
                if (!specialExceptionForRareSpecialization && ((float)jordanianTeachers / specialization.Teachers.Length) < 0.75)
                {
                    _message.Add($"Specialization {specialization.Name} has less than 75% Jordanian teachers.");
                }

                // Verify that at least 50% of teachers have contracts longer than 3 years
                if ((float)longTermContractTeachers / specialization.Teachers.Length < 0.5)
                {
                    _message.Add($"Specialization {specialization.Name} has less than 50% of teachers with contracts of 3 years or more.");
                }

                // Check if there are teachers above 70 without special approval
                if (teachersAboveSeventy > 0 && !_uni.HasBoardApprovalForTeachersAboveSeventy)
                {
                    _message.Add($"Specialization {specialization.Name} has teachers above 70 years old without board approval.");
                }


                //todo more verifications
                //after all verificatons are done the next line will be executed
                _uni.AcceptanceRecords.Append(new AcceptanceRecord(_verified, DateOnly.FromDateTime(DateTime.Now), _message)); //this writes the verification result to the acceptance records

            }




        }
    }
}

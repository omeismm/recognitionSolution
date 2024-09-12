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

            _message.Add("University is not prepared based on article 12 requirements"); } // Append error message to _message

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

                if (specialization.SpecReqCourseHrsTheory / (specialization.SpecReqCourseHrsTheory + specialization.SpecReqCourseHrsPractical)< 0.4 || specialization.SpecReqCourseHrsTheory / (specialization.SpecReqCourseHrsTheory + specialization.SpecReqCourseHrsPractical) > 0.5)
                {
                    _message.Add($"Specialization {specialization.Name} has SpecReqCourseHrsTheory not between 40% and 50% of total specialization hours");
                }

                if (specialization.SpecReqCourseHrsPractical / (specialization.SpecReqCourseHrsTheory + specialization.SpecReqCourseHrsPractical) < 0.5 || specialization.SpecReqCourseHrsPractical / (specialization.SpecReqCourseHrsTheory + specialization.SpecReqCourseHrsPractical) > 0.6)
                {
                    _message.Add($"Specialization {specialization.Name} has SpecReqCourseHrsTheory not between 50% and 60% of total specialization hours");
                }

                if (specialization.FreeCourseHrs> 6)
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
                //todo more verifications
                //after all verificatons are done the next line will be executed
                _uni.AcceptanceRecords.Append(new AcceptanceRecord(_verified, DateOnly.FromDateTime(DateTime.Now), _message)); //this writes the verification result to the acceptance records

        }




        }
    }

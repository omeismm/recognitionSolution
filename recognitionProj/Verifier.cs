using System;
using System.Diagnostics.Metrics;
using static System.Formats.Asn1.AsnWriter;
using System.Reflection;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Numerics;
using System.Diagnostics.CodeAnalysis;

namespace recognitionProj;

public class Verifier
{
    
    private List<string> _message;
    private bool _verified;
    private bool _Article3;
    private bool _Article4;
    private bool _Article5;
    private bool _Article6;
    private bool _Article7;

    public Verifier()
    {
        
        _message = new List<string>();
        _verified = false;
        _Article3 = false;
        _Article4 = false;
        _Article5 = false;
        _Article6 = false;
        _Article7 = false;

    }

    public List<string> Message // Change the type of Message to List<string>
    {
        get => _message;
        set => _message = value;
    }


    public bool Article3
    {
        get => _Article3;
        set => _Article3 = value;
    }

    public bool Article4
    {
        get => _Article4;
        set => _Article4 = value;
    }

    public bool Article5
    {
        get => _Article5;
        set => _Article5 = value;
    }

    public bool Article6
    {
        get => _Article6;
        set => _Article6 = value;
    }

    public bool Article7
    {
        get => _Article7;
        set => _Article7 = value;
    }

    public bool Verified
    {
        get => _verified;
        set => _verified = value;

    }
    public int PracticalHoursRatioColor(Specialization spec)//helper function for the practical specialization hours ratio
    {
        if (spec.PracticalHours == null || spec.TheoreticalHours == null)
        {
            return 0; // No practical or theoretical hours specified
        }

        double P = spec.PracticalHours ?? 0;
        double T = spec.TheoreticalHours ?? 0;
        double requiredPracticalHours = (P+T)/2; // To achieve a 50% practical ratio

        if (P >= requiredPracticalHours)
        {
            return 2; // Practical hours meet or exceed 50% ratio
        }
        else if (P >= 0.8* requiredPracticalHours)
        {
            return 1; // Practical hours are within 20% of required amount
        }
        else
        {
            return 0; // Does not meet criteria
        }
    }

    //these functions will be used inside aticle 4 to calculate the ratios
    //todo make them return 0 1 or 2 based on the color . not boolean
    public void ScientificBachelorRatio(Specialization spec)
    {
        int doctorates;
        
        float x;
        
            if (spec.Type == "Scientific Bachelor")
            {
                doctorates = 0;
                
                
               doctorates = spec.NumPhdHolders+ spec.NumProf + spec.NumAssociative + spec.NumAssistant;//lecturers must be full time,phdholders must be full time
                x = (float)(doctorates + 0.1 * doctorates + 0.2 * doctorates);
                if (spec.NumStu / x >= 1 / 25)//this color is green, meaning the specialization meets the ratio
                    spec.Color = 2;
                else if (spec.NumStu / x >= 1 / (25+0.2*25))//this color is orange, meaning the specialization is close to meeting the ratio
                    spec.Color = 1;
                else 
                    spec.Color = 0;//this color is red, meaning the specialization does not meet the ratio
                
                
            }
        
       
    }

    public void HumanitarianBachelorRatio(Specialization spec)
    {
        int doctorates;
        float x;
        
            if (spec.Type == "Humanitarian Bachelor")
            {
                doctorates = 0;
                doctorates = spec.NumPhdHolders + spec.NumProf + spec.NumAssociative + spec.NumAssistant;//lecturers must be full time, phdholders must be full time
                x = (float)(doctorates + 0.1 * doctorates + 0.2 * doctorates);

                if (spec.NumStu / x >= 1 / 35)//this color is green, meaning the specialization meets the ratio
                    spec.Color = 2;
                else if (spec.NumStu / x >= 1 / (35 + 0.2 * 35))//this color is orange, meaning the specialization is close to meeting the ratio
                    spec.Color = 1;
                else
                    spec.Color = 0;//this color is red, meaning the specialization does not meet the ratio
            }
        
        
    }

    public void HumnamitarianPracticalBachelorRatio(Specialization spec)
    {
        double doctorates;
        double masters;
        double x;
        double overtime;
        
        
            if (spec.Type == "Humanitarian Practical Bachelor")
            {
                //todo, use PracticalHoursRatioColor
                int PracHoursRatioColor = PracticalHoursRatioColor(spec);
                if (PracHoursRatioColor == 0)
                {
                spec.Color = 0;
                return;

                }
            

                doctorates = 0;
                masters = 0;
                doctorates = spec.NumPhdHolders + spec.NumProf + spec.NumAssociative + spec.NumAssistant;//phdholders must be full time
                masters = spec.NumberLecturers + spec.NumAssisLecturer;
                overtime = Math.Min(doctorates, Math.Floor((doctorates + masters) / 2));
                x = doctorates + Math.Min(doctorates, masters) + Math.Floor(doctorates * 0.1) + overtime;
                //i cannot unterstand the handwriting after this point
                if (spec.NumStu / x >= 1 / 25)//this color is green, meaning the specialization meets the ratio
                    spec.Color = 2;
                else if (spec.NumStu / x >= 1 / (25 + 0.2 * 25))//this color is orange, meaning the specialization is close to meeting the ratio
                    spec.Color = 1;
                else
                    spec.Color = 0;//this color is red, meaning the specialization does not meet the ratio

                if (spec.Color == 2)
                {
                    if (PracHoursRatioColor == 1)
                    {
                        spec.Color = 1;
                        return;

                    }

                }
        }
            
     
    }
        
    
    public void ScientificPracticalBachelorRatio(Specialization spec)
    {
        double doctorates;
        double masters;
        double x;
        double overtime;
        
            if (spec.Type == "Scientific Practical Bachelor")
            {
                //todo, use PracticalHoursRatioColor
                int PracHoursRatioColor = PracticalHoursRatioColor(spec);
                if (PracHoursRatioColor == 0)
                {
                    spec.Color = 0;
                    return;

                }
            doctorates = 0;
            masters = 0;
                doctorates = spec.NumPhdHolders + spec.NumProf + spec.NumAssociative + spec.NumAssistant;//phdholders must be full time
                masters = spec.NumberLecturers + spec.NumAssisLecturer;
                overtime = Math.Min(doctorates ,Math.Floor((doctorates + masters) / 2) );
            x = doctorates + Math.Min(doctorates, masters) + Math.Floor(doctorates * 0.1) + overtime;
                //i cannot unterstand the handwriting after this point
                if (spec.NumStu / x >= 1 / 20)//this color is green, meaning the specialization meets the ratio
                    spec.Color = 2;
                else if (spec.NumStu / x >= 1 / (20 + 0.2 * 20))//this color is orange, meaning the specialization is close to meeting the ratio
                    spec.Color = 1;
                else
                    spec.Color = 0;//this color is red, meaning the specialization does not meet the ratio
                if (spec.Color == 2)
                {
                    if (PracHoursRatioColor == 1)
                    {
                        spec.Color = 1;
                        return;

                    }

                }
        }

        

    }

    
        
    public void HighDiplomaRatio(Specialization spec) 
    {
        
            if (spec.Type == "High Diploma")
            {
                int totalStaff = spec.NumProf + spec.NumAssociative + spec.NumAssistant;

                if (totalStaff == 0)
                {
                    spec.Color = 0; // No staff to calculate ratio
                    return; //break out of function
                }

                // Calculate ratios
                float ProfAssoratio = (float)(spec.NumProf + spec.NumAssociative) / totalStaff; // Combined Ostadh and OstadhMusharek ratio
                float Assistandtratio = (float)spec.NumAssistant / totalStaff; // OstadhMusa3ed ratio

                // Ensure OstadhMusharek or Ostadh is at least 25% and OstadhMusa3ed is at most 75%
                if (ProfAssoratio < 0.25 || Assistandtratio > 0.75)
                {
                    spec.Color = 0; // Violates the ratio conditions
                    return; //break out of function
                }
                else
                {
                    float studentToStaffRatio = (float)spec.NumStu / totalStaff;
                    if (studentToStaffRatio > 20)
                    {
                        if (studentToStaffRatio <= 24) // lenient by 20%
                        {
                            spec.Color = 1; // Close to meeting the ratio
                            return;
                        }
                        else
                        {
                            spec.Color = 0; // Violates the student to staff ratio
                            return;
                        }
                    }
                    else
                    {
                        spec.Color = 2; // Meets the ratio conditions
                    }
                }
            }
        
    }
    //todo:btw for the masters, the pdf does not seperate between the scientific and humanitarian masters
    public void ScientificMastersRatio(Specialization spec) 
    {
        
            if (spec.Type == "Scientific Masters")
            {
                // Calculate total staff
                int totalStaff = spec.NumProf + spec.NumAssistant + spec.NumAssistant;

                if (totalStaff == 0)
                {
                    spec.Color = 0; // Avoid division by zero and ensure there's staff to calculate ratios
                    return; //break out of function
                }

                // Calculate percentages
                float profRatio = (float)spec.NumProf / totalStaff;
                float assosiativeRatio = (float)spec.NumAssistant / totalStaff;
                float assistantRatio = (float)spec.NumAssistant / totalStaff;

                // Ensure the ratios meet the requirements:
                // 1. Ostadh >= 25%
                // 2. OstadhMusa3ed <= 25%
                // 3. Remaining staff should be OstadhMusharek

                if (profRatio < 0.25 || assistantRatio > 0.25 )//may cause a problem
                {
                    spec.Color=0; // Ratio violation
                    return; //break out of function
                }
                else
                 {
                    float studentToStaffRatio = (float)spec.NumStu / totalStaff;
                    if (studentToStaffRatio > 15)
                    {
                        if (studentToStaffRatio <= 18) // lenient by 20%
                        {
                            spec.Color = 1; // Close to meeting the ratio
                            return;
                        }
                        else
                        {
                            spec.Color = 0; // Violates the student to staff ratio
                            return;
                        }
                    }
                    else
                    {
                        spec.Color = 2; // Meets the ratio conditions
                    }
                }
        }
        

        
    }


    public void ScientificPracticalMastersRatio(Specialization spec)
    {
        
            if (spec.Type == "Scientific Practical Masters")
            {
                //todo, use PracticalHoursRatioColor
                int PracHoursRatioColor = PracticalHoursRatioColor(spec);
                if (PracHoursRatioColor == 0)
                {
                    spec.Color = 0;
                    return;

                }
            // Calculate total staff
            int totalStaff = spec.NumProf + spec.NumAssociative + spec.NumAssistant;

                if (totalStaff == 0)
                {
                    spec.Color = 0; // Avoid division by zero and ensure there's staff to calculate ratios
                    return; //break out of function
                }

                // Calculate percentages
                float profRatio = (float)spec.NumProf / totalStaff;
                float associateRatio = (float)spec.NumAssociative / totalStaff;
                float assisRatio = (float)spec.NumAssistant / totalStaff;

                // Ensure the ratios meet the requirements:
                // 1. Ostadh >= 25%
                // 2. OstadhMusa3ed <= 25%
                // 3. Remaining staff should be OstadhMusharek

                if (profRatio < 0.25 || assisRatio > 0.25 ) //May cause a problem.
                {
                    spec.Color=0; // Ratio violation
                }
                else
                {
                float studentToStaffRatio = (float)spec.NumStu / totalStaff;
                if (studentToStaffRatio > 16.5)
                {
                    if (studentToStaffRatio <= 16.5+(0.2*1.65)) // lenient by 20%
                    {
                        spec.Color = 1; // Close to meeting the ratio
                        return;
                    }
                    else
                    {
                        spec.Color = 0; // Violates the student to staff ratio
                        return;
                    }
                }
                    else
                    {
                        spec.Color = 2; // Meets the ratio conditions
                    }
                }
                if (spec.Color == 2)
                {
                    if (PracHoursRatioColor == 1)
                    {
                        spec.Color = 1;
                        return;

                    }

                }
        }
        
    
    }

    public void HumanitarianMastersRatio(Specialization spec)
    {
        
            if (spec.Type == "Humanitarian Masters")
            {
                // Calculate total staff
                int totalStaff = spec.NumProf + spec.NumAssistant + spec.NumAssistant;

                if (totalStaff == 0)
                {
                    spec.Color=0; // Avoid division by zero and ensure there's staff to calculate ratios
                    return; //break out of function
                }

            // Calculate percentages
            float profRatio = (float)spec.NumProf / totalStaff;
            float associateRatio = (float)spec.NumAssistant / totalStaff;
            float assisRatio = (float)spec.NumAssistant / totalStaff;


            // Ensure the ratios meet the requirements:
            // 1. Ostadh >= 25%
            // 2. OstadhMusa3ed <= 25%
            // 3. Remaining staff should be OstadhMusharek

            if (profRatio < 0.25 || assisRatio > 0.25 ) //may cause a problem
                {
                    spec.Color=0; // Ratio violation
                }
                else
                {
                    float studentToStaffRatio = (float)spec.NumStu / totalStaff;
                    if (studentToStaffRatio > 22)
                    {
                        if (studentToStaffRatio <= 22 +(0.2*22)) // lenient by 20%
                        {
                            spec.Color = 1; // Close to meeting the ratio
                            return;
                        }
                        else
                        {
                            spec.Color = 0; // Violates the student to staff ratio
                            return;
                        }
                    }
                    else
                    {
                        spec.Color = 2; // Meets the ratio conditions
                    }
                }

        }
        
        
    }
    
    public void MainMedicalRatio(Specialization spec)
    {
        
            if (spec.Type == "Main Medical")
            {
                //todo math
            float totalStaff = spec.NumPhdHolders + spec.NumProf + spec.NumAssistant + spec.NumAssociative;
            float masters = spec.NumberLecturers + spec.NumAssisLecturer;
            if (masters / totalStaff > 1.2)
            {
                spec.Color = 0;
                return ;
            }
            else
            {
                float studentToStaffRatio = (float)spec.NumStu / totalStaff;
                if (studentToStaffRatio > 25)
                {
                    if (studentToStaffRatio <= 30) // lenient by 20%
                    {
                        spec.Color = 1; // Close to meeting the ratio
                        return;
                    }
                    else
                    {
                        spec.Color = 0; // Violates the student to staff ratio
                        return;
                    }
                }
                else
                {
                    spec.Color = 2; // Meets the ratio conditions
                }
            }
        }
        
        
    }

    public void ResidencyRatio(Specialization spec)
    {
    
            if (spec.Type == "Residency")
            {
            float totalStaff =  spec.NumProf + spec.NumAssistant + spec.NumAssociative;
            float masters = spec.NumberLecturers;
            if (masters / totalStaff > 1.2)
            {
                spec.Color = 0;
                return;
            }
            else
            {
              double   studentToStaffRatio=1;
                if (totalStaff < 50)
                    studentToStaffRatio = (double)spec.NumStu / (1.25 * totalStaff);
                else if (totalStaff >= 50 && totalStaff < 100)
                    studentToStaffRatio =(double) spec.NumStu / (1.25 * 50 + 1.35*(totalStaff - 50));
                else
                    studentToStaffRatio = (double)spec.NumStu / (1.25 * 50 + 1.35 * 50  + 1.5*(totalStaff-100));
                if (studentToStaffRatio > 25)

                {
                    if (studentToStaffRatio <= 30) // lenient by 20%
                    {
                        spec.Color = 1; // Close to meeting the ratio
                        return;
                    }
                    else
                    {
                        spec.Color = 0; // Violates the student to staff ratio
                        return;
                    }
                }
                else
                {
                    spec.Color = 2; // Meets the ratio conditions
                }
            }
        }
        
        
    }

    public void DoctorateRatio(Specialization spec) 
    {
        
            if (spec.Type == "Doctorate")
            {
                // Total staff count, including NumProf, NumAssistant, and NumAssistant
                double totalStaff = spec.NumProf + spec.NumAssociative + spec.NumAssistant;

                if (totalStaff == 0)
                {
                    spec.Color = 0; // If no staff, ratio can't be met
                    return; //break out of function
                }

                

                // Adjust NumProf to meet the minimum required
                if (spec.NumProf/totalStaff<0.5)
                {
                    spec.Color = 0; // Not enough NumProf to meet the minimum requirement
                    return;
                }

                // Adjust NumAssistant to meet the maximum allowed
                if (spec.NumAssistant /totalStaff>0.25)
                {
                    spec.Color = 0; // Too many NumAssistant compared to the allowed maximum
                    return;
                }
    
                  double  studentToStaffRatio = spec.NumStu / totalStaff;
                if (studentToStaffRatio > 15)
                {
                    if (studentToStaffRatio <= 18) // lenient by 20%
                    {
                        spec.Color = 1; // Close to meeting the ratio
                        return;
                    }
                    else
                    {
                        spec.Color = 0; // Violates the student to staff ratio
                        return;
                    }
                }
                else
                {
                    spec.Color = 2; // Meets the ratio conditions
                }
        }

        

        
    }


    public void VerifyArticle3()
    {
        //i.Article 3
        //2 years for diploma


        //3 years for bachelor
   
        //1 year after bachelor for high diploma
   
        //1 year after bachelor for masters
   
        //3 years after masters for doctorate


    }

    public void VerifyArticle4()
    {

        // accredited from home country for bachelor
        //ratios

        //ratios

        //infrastucture

        //atleast 5 years of running(with exception) and reseased a wave of graduates with exception

        //accredited in World Federation for Medical Education.(WFME) for medicine
        //acredited in Association of Dental Education in Europe(ADEE)
        //    - The Commission of Dental Accreditation(CODA)
        //    - The Australian Dental Council(ADC)
        //    - The Commission on Dental Accreditation of Canada(CDAC)
        //    - Accreditation Service for International Schools, Colleges &
        //    Universities(ASIC)
        //    - Accreditation Agency in Health and Social Sciences(Germany) for dental
        //accredited from home country for higher than bachelor

        //ratio

        //ratio

        //scopus or web of science researches

        //exception for american universities in(Council for Higher Education Accreditation - CHEA):-
        //                    -Accrediting Commission for Community and Junior Colleges,
        //                    Western Association of Schools and Colleges(ACCJC).

        //                    - Higher Learning Commission(HLC).

        //                    - Middle States Commission on Higher Education(MSCHE).

        //                    - New England Commission of Higher Education(NECHE).

        //                    - Northwest Commission on Colleges and Universities(NWCCU).

        //                    - Southern Association of Colleges and Schools Commission

        //                    on Colleges(SACSCOC).

        //                    - WASC Senior College and University Commission(WSCUC).
        //medical and dental must be accredited as stated before even if american.
        // if the university has other branches outside the home country, the university must split the recognition report into two


    }

    public void VerifyArticle5()
    {
    //    iii.Article 5
    //accepted for traditional study &same duration
    //at least 1 / 3 of the meetings are live
    //online exams places are accepted
    //Platform for live and lon live information
    }

    public void VerifyArticle6(AcademicInfo aca)
    {
        if (aca.ARWURank >= 700 && aca.QSRank >= 500 && aca.THERank >= 500)
        {
            _Article6 = true;
        }
    }

    public void VerifyArticle7()
    {
    //    v.Article 7(manual)
    //accepted in home country ministry of higher edu for middle diploma
    }

    public Boolean Verify(AcademicInfo aca)//note that this function might need updating like what happened with article 6. any variable we need to check for should be passed as a parameter
    {
        this.VerifyArticle3();
        this.VerifyArticle4();
        this.VerifyArticle5();
        this.VerifyArticle6(aca);
        this.VerifyArticle7();
        if (_Article3 && _Article4 && _Article5 &&  _Article7 || _Article6)
        {
            return true;
        }
        return false;
    }




    
}

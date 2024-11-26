using System;
using System.Diagnostics.Metrics;
using static System.Formats.Asn1.AsnWriter;
using System.Reflection;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Numerics;

namespace recognitionProj;

public class Verifier
{
    private University _uni;
    private List<string> _message;
    private bool _verified;
    private bool _Article3;
    private bool _Article4;
    private bool _Article5;
    private bool _Article6;
    private bool _Article7;

    public Verifier(University uni)
    {
        _uni = uni;
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

    public University Uni
    {
        get => _uni;
        set => _uni = value;
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
    //these functions will be used inside aticle 4 to calculate the ratios
    //todo make them return 0 1 or 2 based on the color . not boolean
    public void ScientificBachelorRatio()//todo (1:25)//page 11
    {
        int doctorates;
        int masters;
        float x;
        foreach (Specialization spec in _uni.Specializations)
        {
            if (spec.Type == "Scientific Bachelor")
            {
                doctorates = 0;
                
                
               doctorates = /*freephHolders + */ spec.NumFreeProf + spec.NumAssociative + spec.NumAssistant;//lecturers must be full time
                x = (float)(doctorates + 0.1 * doctorates + 0.2 * doctorates);
                if (spec.NumStu / x >= 1 / 25)//this color is green, meaning the specialization meets the ratio
                    spec.Color = 2;
                else if (spec.NumStu / x >= 1 / (25+0.2*25))//this color is orange, meaning the specialization is close to meeting the ratio
                    spec.Color = 1;
                else 
                    spec.Color = 0;//this color is red, meaning the specialization does not meet the ratio
                
                
            }
        }
       
    }

    public void HumanitarianBachelorRatio()//todo (1:35)
    {
        int doctorates;
        float x;
        foreach (Specialization spec in _uni.Specializations)
        {
            if (spec.Type == "Humanitarian Bachelor")
            {
                doctorates = 0;
                doctorates = /*freephHolders + */ spec.NumFreeProf + spec.NumAssociative + spec.NumAssistant;//lecturers must be full time
                x = (float)(doctorates + 0.1 * doctorates + 0.2 * doctorates);

                if (spec.NumStu / x >= 1 / 35)//this color is green, meaning the specialization meets the ratio
                    spec.Color = 2;
                else if (spec.NumStu / x >= 1 / (35 + 0.2 * 35))//this color is orange, meaning the specialization is close to meeting the ratio
                    spec.Color = 1;
                else
                    spec.Color = 0;//this color is red, meaning the specialization does not meet the ratio
            }
        }
        
    }

    public void HumnamitarianPracticalBachelorRatio()//todo (1:25)
    {
        double doctorates;
        double masters;
        double x;
        double overtime;
        foreach (Specialization spec in _uni.Specializations)
        {
            if (spec.Type == "Humanitarian Practical Bachelor")
            {
                doctorates = 0;
                masters = 0;
                doctorates =/*freephHolders + */ spec.NumFreeProf + spec.NumAssociative + spec.NumAssistant;
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
            }
            }
     
    }
        
    
    public void ScientificPracticalBachelorRatio()//todo (1:20)
    {
        double doctorates;
        double masters;
        double x;
        double overtime;
        foreach(Specialization spec in _uni.Specializations)
        {
            if (spec.Type == "Scientific Practical Bachelor")
            {
            doctorates = 0;
            masters = 0;
                doctorates =/*freephHolders + */ spec.NumFreeProf + spec.NumAssociative + spec.NumAssistant;
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
            }

        }

    }

    }

    public void HighDiplomaRatio() //todo (1:20) //page 13 // todo change from boolean to green orange red
    {
        foreach (Specialization spec in _uni.Specializations)
        {
            if (spec.Type == "High Diploma")
            {
                int totalStaff = spec.NumOfOstadh + spec.NumOfOstadhMusharek + spec.NumOfOstadhMusa3ed;

                if (totalStaff == 0)
                {
                    spec.Color = 0; // No staff to calculate ratio
                    return; //break out of function
                }

                // Calculate ratios
                float ostadhMusharekRatio = (float)(spec.NumOfOstadh + spec.NumOfOstadhMusharek) / totalStaff; // Combined Ostadh and OstadhMusharek ratio
                float ostadhMusa3edRatio = (float)spec.NumOfOstadhMusa3ed / totalStaff; // OstadhMusa3ed ratio

                // Ensure OstadhMusharek or Ostadh is at least 25% and OstadhMusa3ed is at most 75%
                if (ostadhMusharekRatio < 0.25 || ostadhMusa3edRatio > 0.75)
                {
                    spec.Color = 0; // Violates the ratio conditions
                    return; //break out of function
                }
                else
                {
                    float studentToStaffRatio = (float)spec.NumStu / totalStaff;
                    if (studentToStaffRatio > 20)
                    {
                        if (studentToStaffRatio <= 22) // lenient by 10%
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
    }
    //todo:btw for the masters, the pdf does not seperate between the scientific and humanitarian masters
    public void ScientificMastersRatio() //todo (1:15)//page 13
    {
        foreach (Specialization spec in _uni.Specializations)
        {
            if (spec.Type == "Scientific Masters")
            {
                // Calculate total staff
                int totalStaff = spec.NumOfOstadh + spec.NumOfOstadhMusharek + spec.NumOfOstadhMusa3ed;

                if (totalStaff == 0)
                {
                    spec.Color = 0; // Avoid division by zero and ensure there's staff to calculate ratios
                    return; //break out of function
                }

                // Calculate percentages
                float ostadhPercentage = (float)spec.NumOfOstadh / totalStaff;
                float ostadhMusa3edPercentage = (float)spec.NumOfOstadhMusa3ed / totalStaff;
                float ostadhMusharekPercentage = (float)spec.NumOfOstadhMusharek / totalStaff;

                // Ensure the ratios meet the requirements:
                // 1. Ostadh >= 25%
                // 2. OstadhMusa3ed <= 25%
                // 3. Remaining staff should be OstadhMusharek

                if (ostadhPercentage < 0.25 || ostadhMusa3edPercentage > 0.25 || (ostadhPercentage + ostadhMusa3edPercentage + ostadhMusharekPercentage != 1))
                {
                    spec.Color=0; // Ratio violation
                    return; //break out of function
                }
                else
                {   //todo math still. i did not read what is needed but we should see if the student to staff ratio is met i think
                    spec.Color = 1; //this color is orange, meaning the specialization is close to meeting the ratio
                    spec.Color = 2; // this color is green, meaning the specialization meets the ratio
                }
            }
        }

        
    }


    public void ScientificPracticalMastersRatio()//todo (1:15)//page 13
    {
        foreach(Specialization spec in _uni.Specializations)
        {
            if (spec.Type == "Scientific Practical Masters")
            {
                // Calculate total staff
                int totalStaff = spec.NumOfOstadh + spec.NumOfOstadhMusharek + spec.NumOfOstadhMusa3ed;

                if (totalStaff == 0)
                {
                    spec.Color = 0; // Avoid division by zero and ensure there's staff to calculate ratios
                    return; //break out of function
                }

                // Calculate percentages
                float ostadhPercentage = (float)spec.NumOfOstadh / totalStaff;
                float ostadhMusa3edPercentage = (float)spec.NumOfOstadhMusa3ed / totalStaff;
                float ostadhMusharekPercentage = (float)spec.NumOfOstadhMusharek / totalStaff;

                // Ensure the ratios meet the requirements:
                // 1. Ostadh >= 25%
                // 2. OstadhMusa3ed <= 25%
                // 3. Remaining staff should be OstadhMusharek

                if (ostadhPercentage < 0.25 || ostadhMusa3edPercentage > 0.25 || (ostadhPercentage + ostadhMusa3edPercentage + ostadhMusharekPercentage != 1))
                {
                    spec.Color=0; // Ratio violation
                }
                else
                {
                    //todo math still. i did not read what is needed but we should see if the student to staff ratio is met i think
                    spec.Color = 1; //this color is orange, meaning the specialization is close to meeting the ratio
                    spec.Color = 2; // this color is green, meaning the specialization meets the ratio
                }
            }
        }
    
    }

    public void HumanitarianMastersRatio()//todo (1:20)//page 13
    {
        foreach(Specialization spec in _uni.Specializations)
        {
            if (spec.Type == "Humanitarian Masters")
            {
                // Calculate total staff
                int totalStaff = spec.NumOfOstadh + spec.NumOfOstadhMusharek + spec.NumOfOstadhMusa3ed;

                if (totalStaff == 0)
                {
                    spec.Color=0; // Avoid division by zero and ensure there's staff to calculate ratios
                    return; //break out of function
                }

                // Calculate percentages
                float ostadhPercentage = (float)spec.NumOfOstadh / totalStaff;
                float ostadhMusa3edPercentage = (float)spec.NumOfOstadhMusa3ed / totalStaff;
                float ostadhMusharekPercentage = (float)spec.NumOfOstadhMusharek / totalStaff;

                // Ensure the ratios meet the requirements:
                // 1. Ostadh >= 25%
                // 2. OstadhMusa3ed <= 25%
                // 3. Remaining staff should be OstadhMusharek

                if (ostadhPercentage < 0.25 || ostadhMusa3edPercentage > 0.25 || (ostadhPercentage + ostadhMusa3edPercentage + ostadhMusharekPercentage != 1))
                {
                    spec.Color=0; // Ratio violation
                }
                else
                {
                    //todo math still. i did not read what is needed but we should see if the student to staff ratio is met i think
                    spec.Color = 1; //this color is orange, meaning the specialization is close to meeting the ratio
                    spec.Color = 2; // this color is green, meaning the specialization meets the ratio
                }

            }
        }
        
    }
    
    public void MainMedicalRatio()//todo (1:25)
    {
    foreach(Specialization spec in _uni.Specializations)
        {
            if (spec.Type == "Main Medical")
            {
                //todo math

                spec.Color = 0; //this color is red, meaning the specialization does not meet the ratio
                spec.Color = 1; //this color is orange, meaning the specialization is close to meeting the ratio
                spec.Color = 2; //this color is green, meaning the specialization meets the ratio
            }
        }
        
    }

    public void ResidencyRatio()//todo (1:8)
    {
    foreach(Specialization spec in _uni.Specializations)
        {
            if (spec.Type == "Residency")
            {
                spec.Color = 0; //this color is red, meaning the specialization does not meet the ratio
                spec.Color = 1; //this color is orange, meaning the specialization is close to meeting the ratio
                spec.Color = 2; //this color is green, meaning the specialization meets the ratio
            }
        }
        
    }

    public void DoctorateRatio() // todo(1:10) ratio // page 13
    {
        foreach (Specialization spec in _uni.Specializations)
        {
            if (spec.Type == "Doctorate")
            {
                // Total staff count, including NumOfOstadh, NumOfOstadhMusa3ed, and NumOfOstadhMusharek
                int totalStaff = spec.NumOfOstadh + spec.NumOfOstadhMusa3ed + spec.NumOfOstadhMusharek;

                if (totalStaff == 0)
                {
                    spec.Color = 0; // If no staff, ratio can't be met
                    return; //break out of function
                }

                // Calculate the minimum and maximum limits based on ratios
                int minNumOfOstadh = (int)Math.Ceiling(totalStaff * 0.50); // At least 50% for NumOfOstadh
                int maxNumOfOstadhMusa3ed = (int)Math.Floor(totalStaff * 0.25); // At most 25% for NumOfOstadhMusa3ed

                // Adjust NumOfOstadh to meet the minimum required
                if (spec.NumOfOstadh < minNumOfOstadh)
                {
                    spec.Color = 0; // Not enough NumOfOstadh to meet the minimum requirement
                    return;
                }

                // Adjust NumOfOstadhMusa3ed to meet the maximum allowed
                if (spec.NumOfOstadhMusa3ed > maxNumOfOstadhMusa3ed)
                {
                    spec.Color = 0; // Too many NumOfOstadhMusa3ed compared to the allowed maximum
                    return;
                }

                // Calculate the remaining staff that should be NumOfOstadhMusharek
                int remainingStaff = totalStaff - spec.NumOfOstadh - spec.NumOfOstadhMusa3ed;
                if (remainingStaff != spec.NumOfOstadhMusharek)
                {
                    spec.Color = 0; // Remaining staff doesn't match the expected NumOfOstadhMusharek count
                    return;
                }
                //todo math still. i did not read what is needed but we should see if the student to staff ratio is met i think
                spec.Color = 1; //this color is orange, meaning the specialization is close to meeting the ratio
                spec.Color = 2; //this color is green, meaning the specialization meets the ratio
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

    public void VerifyArticle6()
    {
        if (_uni.ARWURank >= 700 && _uni.QSRank >= 500 && _uni.THERank >= 500)
        {
            _Article6 = true;
        }
    }

    public void VerifyArticle7()
    {
    //    v.Article 7(manual)
    //accepted in home country ministry of higher edu for middle diploma
    }

    public void Verify()
    {
        this.VerifyArticle3();
        this.VerifyArticle4();
        this.VerifyArticle5();
        this.VerifyArticle6();
        this.VerifyArticle7();
        if (_Article3 && _Article4 && _Article5 &&  _Article7 || _Article6)
        {
            _verified = true;
        }
    }




    
}

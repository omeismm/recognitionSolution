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
    public bool ScientificBachelorRatio()//todo (1:25)//page 11
    {
        int doctorates;
        int masters;
        float x;
        foreach (Specialization spec in _uni.Specializations)
        {
            if (spec.Type != "Scientific Bachelor")
            {
                doctorates = 0;
                masters = 0;
                doctorates = doctorates + spec.NumOfOstadh + spec.NumOfMusharek + spec.NumOfMusa3ed + spec.NumberOfLecturers;//lecturers must be full time
                x = (float)(doctorates + 0.1 * doctorates + 0.2 * doctorates);
                //todo more math
            }
        }
        return true;
    }

    public bool HumanitarianBachelorRatio()//todo (1:35)
    {
        foreach(Specialization spec in _uni.Specializations)
        {
            if (spec.Type == "Humanitarian Bachelor")
            {
                //todo math
            }
        }
        return true;
    }

    public bool HumnamitarianPracticalBachelorRatio()//todo (1:25)
    {
        foreach(Specialization spec in _uni.Specializations)
        {
            if (spec.Type == "Humanitarian Practical Bachelor")
            {
                //todo math
                    
                }
            }
        return true;
    }
        

    public bool ScientificPracticalBachelorRatio()//todo (1:20)
    {
        int doctorates;
    int masters;
        float x;
        foreach(Specialization spec in _uni.Specializations)
        {
            if (spec.Type == "Scientific Practical Bachelor")
            {
            doctorates = 0;
            masters = 0;
            doctorates = doctorates + spec.NumOfOstadh + spec.NumOfMusharek +spec.NumOfMusa3ed + spec.NumberOfLecturers;//lecturers must be full time
            masters = spec.NumOfMudaresMusa3ed + spec.NumOfMudares;
            x = doctorates + Math.Min(doctorates, masters) + Math.Floor(doctorates * 0.1) + Math.Floor((doctorates + masters) / 2);
            //i cannot unterstand the handwriting after this point
            }

    }

        return true;
    }

    public bool HighDiplomaRatio() //todo (1:20) //page 13
    {
        foreach (Specialization spec in _uni.Specializations)
        {
            if (spec.Type == "High Diploma")
            {
                int totalStaff = spec.NumOfOstadh + spec.NumOfOstadhMusharek + spec.NumOfOstadhMusa3ed;

                if (totalStaff == 0)
                {
                    return false; // No staff to calculate ratio
                }

                // Calculate ratios
                float ostadhMusharekRatio = (float)(spec.NumOfOstadh + spec.NumOfOstadhMusharek) / totalStaff; // Combined Ostadh and OstadhMusharek ratio
                float ostadhMusa3edRatio = (float)spec.NumOfOstadhMusa3ed / totalStaff; // OstadhMusa3ed ratio

                // Ensure OstadhMusharek or Ostadh is at least 25% and OstadhMusa3ed is at most 75%
                if (ostadhMusharekRatio < 0.25 || ostadhMusa3edRatio > 0.75)
                {
                    return false; // Violates the ratio conditions
                }
            }
        }

        return true; // All specializations meet the ratio requirements
    }

    //todo:btw for the masters, the pdf does not seperate between the scientific and humanitarian masters
    public bool ScientificMastersRatio() //todo (1:15)//page 13
    {
        foreach (Specialization spec in _uni.Specializations)
        {
            if (spec.Type == "Scientific Masters")
            {
                // Calculate total staff
                int totalStaff = spec.NumOfOstadh + spec.NumOfOstadhMusharek + spec.NumOfOstadhMusa3ed;

                if (totalStaff == 0)
                {
                    return false; // Avoid division by zero and ensure there's staff to calculate ratios
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
                    return false; // Ratio violation
                }
            }
        }

        return true; // All specializations meet the required ratios
    }


    public bool ScientificPracticalMastersRatio()//todo (1:15)//page 13
    {
        foreach(Specialization spec in _uni.Specializations)
        {
            if (spec.Type == "Scientific Practical Masters")
            {
                // Calculate total staff
                int totalStaff = spec.NumOfOstadh + spec.NumOfOstadhMusharek + spec.NumOfOstadhMusa3ed;

                if (totalStaff == 0)
                {
                    return false; // Avoid division by zero and ensure there's staff to calculate ratios
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
                    return false; // Ratio violation
                }
            }
        }
        return true;
    }

    public bool HumanitarianMastersRatio()//todo (1:20)//page 13
    {
        foreach(Specialization spec in _uni.Specializations)
        {
            if (spec.Type == "Humanitarian Masters")
            {
                // Calculate total staff
                int totalStaff = spec.NumOfOstadh + spec.NumOfOstadhMusharek + spec.NumOfOstadhMusa3ed;

                if (totalStaff == 0)
                {
                    return false; // Avoid division by zero and ensure there's staff to calculate ratios
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
                    return false; // Ratio violation
                }
            }
        }
        return true;
    }
    
    public bool MainMedicalRatio()//todo (1:25)
    {
    foreach(Specialization spec in _uni.Specializations)
        {
            if (spec.Type == "Main Medical")
            {
                //todo math
            }
        }
        return true;
    }

    public bool ResidencyRatio()//todo (1:8)
    {
    foreach(Specialization spec in _uni.Specializations)
        {
            if (spec.Type == "Residency")
            {
                //todo math
            }
        }
        return true;
    }

    public bool DoctorateRatio() // todo(1:10) ratio // page 13
    {
        foreach (Specialization spec in _uni.Specializations)
        {
            if (spec.Type == "Doctorate")
            {
                // Total staff count, including NumOfOstadh, NumOfOstadhMusa3ed, and NumOfOstadhMusharek
                int totalStaff = spec.NumOfOstadh + spec.NumOfOstadhMusa3ed + spec.NumOfOstadhMusharek;

                if (totalStaff == 0)
                {
                    return false; // If no staff, ratio can't be met
                }

                // Calculate the minimum and maximum limits based on ratios
                int minNumOfOstadh = (int)Math.Ceiling(totalStaff * 0.50); // At least 50% for NumOfOstadh
                int maxNumOfOstadhMusa3ed = (int)Math.Floor(totalStaff * 0.25); // At most 25% for NumOfOstadhMusa3ed

                // Adjust NumOfOstadh to meet the minimum required
                if (spec.NumOfOstadh < minNumOfOstadh)
                {
                    return false; // Not enough NumOfOstadh to meet the minimum requirement
                }

                // Adjust NumOfOstadhMusa3ed to meet the maximum allowed
                if (spec.NumOfOstadhMusa3ed > maxNumOfOstadhMusa3ed)
                {
                    return false; // Too many NumOfOstadhMusa3ed compared to the allowed maximum
                }

                // Calculate the remaining staff that should be NumOfOstadhMusharek
                int remainingStaff = totalStaff - spec.NumOfOstadh - spec.NumOfOstadhMusa3ed;
                if (remainingStaff != spec.NumOfOstadhMusharek)
                {
                    return false; // Remaining staff doesn't match the expected NumOfOstadhMusharek count
                }
            }
        }

        // If all Doctorate specializations pass the checks, return true
        return true;
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

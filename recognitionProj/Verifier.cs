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

# recognitionSolution

made with console web app (razor pages) template

todo:

a. connect the microsoftsql database, create the tables, and access them from c# (ask chatgpt)

    database::
    AdmissionRules//unnecesary

        InsID//unnecesary
        AdmissionRule//unnecesary
        AdmissionDegree//unnecesary

    Library//Send in an excel file(because this field is small, we could make this manually)
    
        InsID
        Area
        Capacity
        ArBooks
        EnBooks
        Papers
        eBooks
        eSubscription

    StudySystem// needed in the frontend that the uni needs to fill (تعليم عن بعد(
    
        InsID
        System

    StudyDuration/needed

        InsID
        DiplomaDegreeMIN
        DiplomaMIN
        BSC_DegreeMIN
        BSC_MIN
        HigherDiplomaDegreeMIN
        HigherDiplomaMIN
        MasterDegreeMIN
        MasterMIN
        PhD_DegreeMIN
        PhD_MIN

    Colleges//send them as an excel file but no data processing will be made
    
        InsID
        CollegeID
        CollegeName

    Programes//send them as an excel file but no data processing will be made

        InsID
        ProgramID
        CollegeID
        CollegeName
        ProgramName
        Degree
        YearsCount
        HoursCount
        StudySystem
        StudyLang
        RecDate

    StudentsCount//unneceary or excel sheet

        InsID//unneceary or excel sheet
        ProgramID//unneceary or excel sheet
        ProgramName//unneceary or excel sheet
        First//unneceary or excel sheet
        Second//unneceary or excel sheet
        Third//unneceary or excel sheet
        Fourth//unneceary or excel sheet
        Fifth//unneceary or excel sheet
        Sixth//unneceary or excel sheet
        Total//unneceary or excel sheet

    HoursCount//unnecesary

        InsID//unnecesary
        ProgramID//unnecesary
        ProgramName//unnecesary
        TheoHours//unnecesary
        PracHours//unnecesary

    sysdiagrams//unnecesary

        name//unnecesary
        principal_id//unnecesary
        diagram_id//unnecesary
        version//unnecesary
        definition//unnecesary

    Staff//excel sheet

        StaffID//excel sheet
        InsID//excel sheet
        ProgramID//excel sheet
        ProgramName//excel sheet
        Name//excel sheet
        Major//excel sheet
        Degree//excel sheet
        DegreeDate//excel sheet
        AcademicRank//excel sheet
        Status//excel sheet
        Nationality//excel sheet
        UnivName//excel sheet

    PhdStaff//excel sheet
    
        StaffID//excel sheet
        InsID//excel sheet
        ProgramID//excel sheet
        ProgramName//excel sheet
        Name//excel sheet
        Major//excel sheet
        Status//excel sheet

    Hospitals//add

        InsID//add
        HospID//add
        HospType//add
        HospName//add
        HospMajor//add

    Labs//excel

        InsID//excel
        CollegeID//excel
        CollegeName//excel
        Comp//excel
        Eng//excel
        Med//excel
        PC//excel
        Total//excel

    Attachments//keep

        InsId//keep
        AttachID//keep
        AttachName//keep
        AttachDesc//keep
        url/keep

    PublicInfo/keep

        InsID/keep
        InsName/keep
        Provider/keep
        StartDate/keep
        SDateT/keep
        SDateNT/keep
        SupervisorID/keep
        Supervisor/keep
        PreName/keep
        PreDegree/keep
        PreMajor/keep
        Postal/keep
        Phone/keep
        Fax/keep
        Email/keep
        Website/keep
        Vision/keep
        Mission/keep
        Goals/keep
        InsValues/keep/keep
        LastEditDate/keep

    AcademicInfo/important

        InsID/important
        InsTypeID/important
        InsType/important
        HighEdu_Rec/important
        QualityDept_Rec/important
        QualityDept_Attach/important
        StudyLangCitizen/important
        StudyLangInter/important
        JointClass/important
        StudySystem/important
        MinHours/important
        MaxHours/important
        ResearchScopus/important
        ResearchOthers/important
        Practicing/important
        StudyAttendance/important
        StudentsMove/important
        StudyAttendanceDesc/important
        StudentsMoveDesc/important
        DistanceLearning/important
        MaxHoursDL/important
        MaxYearsDL/important
        MaxSemsDL/important
        Diploma/important
        DiplomaTest/important
        HoursPercentage/important
        SharedPrograms/important

    Countries/keep untouched

        CountryNO/keep untouched
        CountryNameAR/keep untouched
        CountryNameEN/keep untouched

    USERS//whatever

        InsID//whatever
        InsName//whatever
        InsCountry//whatever
        Email//whatever
        Password//whatever
        VerificationCode//whatever
        Verified//whatever

    StudentsAndStuff/unchanged
        InsID//unchanged
        StudentCitizen//unchanged
        StudentInter//unchanged
        StudentJordan//unchanged
        StudentOverall//unchanged
        StaffProfessor//unchanged
        StaffCoProfessor//unchanged
        StaffAssistantProfessor/unchanged
        StaffLabSupervisor/unchanged
        StaffResearcher//unchanged
        StaffTeacher//unchanged
        StaffTeacherAssistant//unchanged
        StaffOthers/unchanged
    Percentage//unnecesary
    
        InsID//unnecesary
        FullTimeProfessor_Student//unnecesary
        PartTimeProfessor_Student//unnecesary
        FullTimeAssociateProfessor_Student//unnecesary
        PartTimeAssociateProfessor_Student//unnecesary
        FullTimeAssistantProfessor_Student//unnecesary
        PartTimeAssistantProfessor_Student//unnecesary
        Student_FullTimeTeachers//unnecesary
        Student_FullAndPartTimeTeachers//unnecesary
        AssociateProfessor_FullTimeTeachers//unnecesary
        AssistantProfessor_FullTimeTeachers//unnecesary
        Professor_FullTimeTeachers//unnecesary
        PhD_FullTimeTeachers//unnecesary
        Professor_PartTimeTeachers//unnecesary
        PhD_PartTimeTeachers//unnecesary

    MedStaff//excel

        InsID//excel
        Med_Students//excel
        Med_Staff//excel
        Med_Professor//excel
        Med_CoProfessor//excel
        Med_AssistantProfessor//excel
        Med_lecturer//excel
        Med_Teacher//excel
        Med_TeacherAssistant
        Med_FullTimelecturer
        Den_Students//excel
        Den_Staff//excel
        Den_Professor
        Den_CoProfessor//excel
        Den_AssistantProfessor
        Den_lecturer
        Den_Teacher//excel
        Den_TeacherAssistant//excel
        Den_FullTimelecturer

    Infrastructure/keep?
    
        InsID//keep
        Area//keep
        Sites//keep
        Terr//keep
        Halls//keep
        Library//cancel
        Labs//cancel
        Build//keep or not?

    acceptancerecord//new table
        .instid
         i.NoOfRecord
        ii.Date
        iii.Result
        iv.Message

      spec table
      instid
         i.Name
        ii.Type
        iii.NumOfStudents
        iv.NumOfFreeTeachers
        v.NumOfOstadh
        vi.NumOfMusharek
        vii.NumOfOstadhMusa3ed
        viii.NumberOfLecturers
        ix.NumOfMudaresMusa3ed
        x.NumOfOtherTeachers      

b. transfer data from https://rnji.mohe.gov.jo/

c. process data 

    0. read the pdfs and create classes with the variables mentioned in the pdf (current task)

    a.University
        i.Name
        ii.EntryDate
        iii.Supervisor
        iv.Country
        v.City
        vi.Address
        vii.Website
        viii.CreationDate
        ix.StudentAcceptanceDate
        x.StartDate
        xi.Type
        xii.Language
        xiii.EducationType
        xiv.AvailableDegrees
        xv.HoursSystem
        xvi.Faculties
        xvii.ARWURank
        xviii.THERank
        xix.QSRank
        xx.OtherRank
        xxi.NumOfScopusResearches
        xxii.ScopusFrom
        xxiii.ScopusTo
        xxiv.Infrastructure
        xxv.OtherInfo
        xxvi.AcceptanceRecord
        xxvii.SuggestionRecord
        xxviii.Accepted
        
    
    c.AcceptanceRecord
        i.NoOfRecord
        ii.Date
        iii.Result
        iv.Message
        
    d.Specialization
        i.Name
        ii.Type
        iii.NumOfStudents
        iv.NumOfFreeTeachers
        v.NumOfOstadh
        vi.NumOfMusharek
        vii.NumOfOstadhMusa3ed
        viii.NumberOfLecturers
        ix.NumOfMudaresMusa3ed
        x.NumOfOtherTeachers
    e.SuggestionRecord//delete
        i.Date//delete
        ii.Message//delete
    f.DatabaseHandler
    g.Program.cs (main)
    h.Verifier
        i.Article 3
         2 years for diploma
         3 years for bachelor
         1 year after bachelor for high diploma
         1 year after bachelor for masters
         3 years after masters for doctorate
        ii.Article 4
            accredited from home country for bachelor
            ratios
            ratios
            infrastucture
            atleast 5 years of running (with exception) and reseased a wave of graduates with exception
            accredited in World Federation for Medical Education.(WFME) for medicine
            acredited in Association of Dental Education in Europe (ADEE)
                - The Commission of Dental Accreditation (CODA)
                - The Australian Dental Council (ADC)
                - The Commission on Dental Accreditation of Canada (CDAC)
                - Accreditation Service for International Schools, Colleges &
                Universities(ASIC)
                - Accreditation Agency in Health and Social Sciences (Germany) for dental
            accredited from home country for higher than bachelor  
            ratio
            ratio
            scopus or web of science researches
            exception for american universities in(Council for Higher Education Accreditation- CHEA):-
                                - Accrediting Commission for Community and Junior Colleges,
                                Western Association of Schools and Colleges (ACCJC).
                                - Higher Learning Commission (HLC).
                                - Middle States Commission on Higher Education (MSCHE).
                                - New England Commission of Higher Education (NECHE).
                                - Northwest Commission on Colleges and Universities (NWCCU).
                                - Southern Association of Colleges and Schools Commission
                                on Colleges (SACSCOC).
                                - WASC Senior College and University Commission (WSCUC).
            medical and dental must be accredited as stated before even if american.  
            if the university has other branches outside the home country, the university must split the recognition report into two
            
                                
        iii.Article 5
        accepted for traditional study & same duration
        at least 1/3 of the meetings are live
        online exams places are accepted
        Platform for live and lon live information
        
        iv.Article 6
        if the rank is high, we can automatically accept the university
                Academic Ranking of World Universities (ARWU) 700
                QS World University Rankings 500
                Times Higher Education World University Rankings 500
                
        v.Article 7 (manual)
        accepted in home country ministry of higher edu for middle diploma
        v
    i.ExcelSheetHandler
        i.University
        ii.
    
    
    
    1. automatically count number of phd, msc, bsc, and students
    
    2. write the formulas for students to teachers ratio
    
    3. count full time and part time teachers

    4. other conditions in the pdfs
    
d. allow the universities to input their data by making an excel sheet for them to fill out(SANITIZE ALL TEXT INPUTS!!)

e. make an interface or use the existing one frontend (SANITIZE ALL TEXT INPUTS!!)

    a.
    b.
    c.
    d.
    e.
    f.
    g.
    h.
    i.
    j.
    k.
    l.
    m.
    n.
        
    

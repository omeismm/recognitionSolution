# recognitionSolution

made with console web app (razor pages) template

todo:

a. connect the microsoftsql database, create the tables, and access them from c# (ask chatgpt)

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
    e.SuggestionRecord
        i.Date
        ii.Message
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
        
    

USE [master]
GO

CREATE DATABASE [RNJI] ON  PRIMARY 
( NAME = N'RNJI', FILENAME = N'E:\recog\gg database\RNJI.mdf'  )
 LOG ON 
( NAME = N'RNJI_log', FILENAME = N'E:\recog\gg database\RNJI_log.ldf' )
USE [RNJI]
GO
CREATE TABLE [dbo].[AcademicInfo](
	[InsID] [int] NOT NULL,
	[InsTypeID] [int] NULL,
	[InsType] [nvarchar](50) NULL,
	[HighEdu_Rec] [int] NULL,
	[QualityDept_Rec] [int] NULL,
	/*[QualityDept_Attach] [nvarchar](50) NULL,*/
	[StudyLangCitizen] [nvarchar](50) NULL,
	[StudyLangInter] [nvarchar](50) NULL,
	[JointClass] [int] NULL,
	[StudySystem] [nvarchar](50) NULL,
	[MinHours] [int] NULL,
	[MaxHours] [int] NULL,
	[ResearchScopus] [nvarchar](50) NULL,
	[ResearchOthers] [nvarchar](50) NULL,
	[Practicing] [int] NULL,
	[StudyAttendance] [int] NULL,
	[StudentsMove] [int] NULL,
	[StudyAttendanceDesc] [nvarchar](50) NULL,
	[StudentsMoveDesc] [nvarchar](50) NULL,
	[DistanceLearning] [int] NULL,
	[MaxHoursDL] [int] NULL,
	[MaxYearsDL] [int] NULL,
	[MaxSemsDL] [int] NULL,
	[Diploma] [int] NULL,
	[DiplomaTest] [int] NULL,
	[HoursPercentage] [int] NULL,
	/*[SharedPrograms] [int] NULL*/
) 
CREATE TABLE [dbo].[PublicInfo](
	[InsID] [int] NOT NULL,
	[InsName] [nvarchar](100) NULL,
	[Provider] [nvarchar](50) NULL,
	[StartDate] [nvarchar](50) NULL,
	[SDateT] [nvarchar](50) NULL,
	[SDateNT] [nvarchar](50) NULL,
	[SupervisorID] [int] NULL,/*note*/
	[Supervisor] [nvarchar](50) NULL,/*note*/
	[PreName] [nvarchar](50) NULL,
	[PreDegree] [nvarchar](50) NULL,
	[PreMajor] [nvarchar](50) NULL,
	[Postal] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[Fax] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Website] [nvarchar](50) NULL,
	[Vision] [nvarchar](100) NULL,
	[Mission] [nvarchar](100) NULL,
	[Goals] [nvarchar](100) NULL,/*Targeted Obj*/
	[InsValues] [nvarchar](100) NULL,
	[LastEditDate] [nvarchar](50) NULL
) 


CREATE TABLE [dbo].[AdmissionRules](
	[InsID] [int] NOT NULL,
	[AdmissionRule] [nvarchar](100) NULL,
	[AdmissionDegree] [nvarchar](50) NULL
) 
CREATE TABLE [dbo].[Attachments](
	[InsID] [int] NOT NULL,
	[AttachID] [int] IDENTITY(1,1) NOT NULL,
	[AttachName] [nvarchar](100) NULL,
	[AttachDesc] [nvarchar](100) NULL,
 CONSTRAINT [PK_Attachments] PRIMARY KEY CLUSTERED 
(
	[AttachID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)
CREATE TABLE [dbo].[Countries](
	[CountryNO] [int] NOT NULL,
	[CountryNameAR] [nvarchar](50) NULL,
	[CountryNameEN] [nvarchar](50) NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[CountryNO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) 

CREATE TABLE [dbo].[Hospitals](
	[InsID] [int] NOT NULL,
	[HospID] [int] IDENTITY(1,1) NOT NULL,
	[HospType] [nvarchar](50) NULL,
	[HospName] [nvarchar](100) NULL,
	[HospMajor] [nvarchar](100) NULL,
 CONSTRAINT [PK_Hospitals] PRIMARY KEY CLUSTERED 
(
	[HospID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) 

CREATE TABLE [dbo].[Infrastructure](
	[InsID] [int] NOT NULL,
	[Area] [int] NULL,
	[Sites] [int] NULL,
	[Terr] [int] NULL,
	[Halls] [int] NULL,
	[Library] [int] NULL,
	--[Labs] [nvarchar](500) NULL,
	[labs_Attach] [nvarchar] NULL,
	[Build] [nvarchar](500) NULL
) 
CREATE TABLE [dbo].[Library](
	[InsID] [int] NOT NULL,
	[Area] [int] NULL,
	[Capacity] [int] NULL,
	[ArBooks] [int] NULL,
	[EnBooks] [int] NULL,
	[Papers] [int] NULL,
	[eBooks] [int] NULL,
	[eSubscription] [int] NULL
) 
CREATE TABLE [dbo].[USERS](
	[InsID] [int] IDENTITY(1,1) NOT NULL,
	[InsName] [nvarchar](100) NULL,
	[InsCountry] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[VerificationCode] [nvarchar](50) NULL,
	[Verified] [int] NULL,
 CONSTRAINT [PK_USERS] PRIMARY KEY CLUSTERED 
(
	[InsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)
CREATE TABLE [dbo].[Pictures](
	[InsID] [int] NOT NULL,
	[AttachID] [int] IDENTITY(1,1) NOT NULL,
	[AttachName] [nvarchar](100) NULL,
	[AttachDesc] [nvarchar](100) NULL
) 

CREATE TABLE [dbo].[StudentsAndStuff](
	[InsID] [int] NOT NULL,
	[StudentCitizen] [int] NULL,
	[StudentInter] [int] NULL,
	[StudentJordan] [int] NULL,
	[StudentOverall] [int] NULL,
	[StaffProfessor] [int] NULL,
	[StaffCoProfessor] [int] NULL,
	[StaffAssistantProfessor] [int] NULL,
	[StaffLabSupervisor] [int] NULL,
	[StaffResearcher] [int] NULL,
	[StaffTeacher] [int] NULL,
	[StaffTeacherAssistant] [int] NULL,
	[StaffOthers] [int] NULL
)
CREATE TABLE [dbo].[StudyDuration](
	[InsID] [int] NOT NULL,
	[DiplomaDegreeMIN] [nvarchar](50) NULL,
	[DiplomaMIN] [nvarchar](50) NULL,
	[BSC_DegreeMIN] [nvarchar](50) NULL,
	[BSC_MIN] [nvarchar](50) NULL,
	[HigherDiplomaDegreeMIN] [nvarchar](50) NULL,
	[HigherDiplomaMIN] [nvarchar](50) NULL,
	[MasterDegreeMIN] [nvarchar](50) NULL,
	[MasterMIN] [nvarchar](50) NULL,
	[PhD_DegreeMIN] [nvarchar](50) NULL,
	[PhD_MIN] [nvarchar](50) NULL
CREATE TABLE [dbo].[Specializations](
    [InsID] [int] NOT NULL ,  -- معرف الكيان
    [Type] [nvarchar](50) NOT NULL, -- نوع الكيان
    [NumStu] [int] NOT NULL, -- عدد الطلاب
    [NumFreeTeachers] [int] NOT NULL, -- عدد المدرسين المتفرغين (Full-Time Teachers)
    [NumPartTimeTeachers] [int] NOT NULL, -- عدد المدرسين غير المتفرغين (Part-Time Teachers)
    [NumProf] [int] NOT NULL, -- عدد الأساتذة (Professors)
    [NumAssociative] [int] NOT NULL, -- عدد الأساتذة المشاركين (Associate Professors)
    [NumAssistant] [int] NOT NULL, -- عدد الأساتذة المساعدين (Assistant Professors)
    [NumMusharek] [int] NOT NULL, -- عدد المشاركين (Musharek Professors)
    [NumMusa3ed] [int] NOT NULL, -- عدد المساعدين (Musa3ed Professors)
    [NumberLecturers] [int] NOT NULL, -- عدد المدرسين (Lecturers)
    [NumAssisLecturer] [int] NOT NULL, -- عدد المدرسين المساعدين (Assistant Lecturers)
    [NumOtherTeachers] [int] NOT NULL, -- عدد المدرسين الآخرين (Other Teachers)
    [SpecAttachName] [nvarchar](100) NOT NULL, -- اسم المرفق
    [SpecAttachDesc] [nvarchar](100) NOT NULL -- وصف المرفق
);

CREATE TABLE [dbo].[ExcelAttach](
[InsID] [int] NOT NULL,
[AttachID] [int] IDENTITY(1,1) NOT NULL,
[AttachName] [nvarchar](100) NULL,
[AttachDesc] [nvarchar](100) NULL,

)
CREATE TABLE [dbo].[AcceptanceRecord](
[InsID] [int] NOT NULL,
[RecordNo] [int] NOT NULL,
[DateOfRecord][date] NOT NULL,
[Result] [nvarchar] NOT NULL,
[Message] [nvarchar](200),
)

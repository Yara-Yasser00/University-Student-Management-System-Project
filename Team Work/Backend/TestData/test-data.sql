-- =========================================================================
-- USMS - Test data (FCAI only)
-- Fake rows to try the system locally. Never run this on a real database.
-- Names, codes, rooms and times follow the UI-UX prototype where it has them.
--
-- How to run:
--   1. Update-Database (the seed data - colleges, grade scale, credit rules,
--      permissions - is inserted by the migration).
--   2. SQL Server Object Explorer -> right-click the USMS database -> New Query
--      -> paste this file -> Execute.
--   Run it once on a fresh database. To run it again: Drop-Database,
--   Update-Database, then run it again.
--
-- Fixed IDs used below:
--   Department  1 CS, 2 IS, 3 IT, 4 AI
--   Person      1-7 instructors, 11-14 teaching assistants,
--               21 University Admin, 22 College Admin (FCAI), 101-108 students
--   AcademicTerm 1 = 2025/2026 Second (past), 2 = 2026/2027 First (current)
--   PasswordHash values are placeholders: sign-in works only after the API
--   sets real hashes.
-- =========================================================================

SET XACT_ABORT ON;
BEGIN TRANSACTION;


-- ======================================================================
-- Group 1 - Organisation: departments and rooms
-- ======================================================================
SET IDENTITY_INSERT [Department] ON;
INSERT INTO [Department] ([DepartmentID], [CollegeCode], [Code], [Name], [HeadStaffID], [Status]) VALUES
    (1, N'FCAI', N'CS', N'Computer Science', NULL, N'Active'),
    (2, N'FCAI', N'IS', N'Information Systems', NULL, N'Active'),
    (3, N'FCAI', N'IT', N'Information Technology', NULL, N'Active'),
    (4, N'FCAI', N'AI', N'Artificial Intelligence', NULL, N'Active');
SET IDENTITY_INSERT [Department] OFF;

INSERT INTO [Room] ([RoomCode], [Building], [Type], [Capacity], [CollegeCode]) VALUES
    (N'CS-106', N'FCAI Building', N'LectureHall', 120, N'FCAI'),
    (N'CS-112', N'FCAI Building', N'LectureHall', 120, N'FCAI'),
    (N'CS-118', N'FCAI Building', N'LectureHall', 150, N'FCAI'),
    (N'CS-204', N'FCAI Building', N'LectureHall', 150, N'FCAI'),
    (N'CS-206', N'FCAI Building', N'LectureHall', 100, N'FCAI'),
    (N'CS-211', N'FCAI Building', N'LectureHall', 100, N'FCAI'),
    (N'CS-220', N'FCAI Building', N'Classroom', 40, N'FCAI'),
    (N'CS-221', N'FCAI Building', N'Classroom', 40, N'FCAI'),
    (N'CS-Lab 1', N'FCAI Building', N'Lab', 30, N'FCAI'),
    (N'CS-Lab 2', N'FCAI Building', N'Lab', 30, N'FCAI'),
    (N'CS-Lab 3', N'FCAI Building', N'Lab', 30, N'FCAI'),
    (N'HU-031', N'FCAI Building', N'Classroom', 60, N'FCAI'),
    (N'Main Hall 2', N'Main Building', N'ExamHall', 300, NULL);


-- ======================================================================
-- Group 2 - People
-- ======================================================================
SET IDENTITY_INSERT [Person] ON;
INSERT INTO [Person] ([PersonID], [NameEn], [NameAr], [Gender], [Nationality], [NationalID], [DateOfBirth], [PlaceOfBirth], [Mobile], [Address], [EmergencyName], [EmergencyPhone]) VALUES
    (1, N'Khaled Mahmoud', N'خالد محمود', N'Male', N'Egyptian', N'29900000000001', N'1968-03-14', N'Hurghada', N'01000000001', N'Hurghada, Red Sea', NULL, NULL),
    (2, N'Amr Nassar', N'عمرو نصار', N'Male', N'Egyptian', N'29900000000002', N'1979-06-02', N'Hurghada', N'01003384472', N'Hurghada, Red Sea', N'Heba Nassar', N'01114829930'),
    (3, N'Rania El-Sayed', N'رانيا السيد', N'Female', N'Egyptian', N'29900000000003', N'1984-11-20', N'Hurghada', N'01000000003', N'Hurghada, Red Sea', NULL, NULL),
    (4, N'Hala Sami', N'هالة سامي', N'Female', N'Egyptian', N'29900000000004', N'1982-01-09', N'Hurghada', N'01000000004', N'Hurghada, Red Sea', NULL, NULL),
    (5, N'Nabil Farouk', N'نبيل فاروق', N'Male', N'Egyptian', N'29900000000005', N'1971-08-17', N'Hurghada', N'01002284361', N'Hurghada, Red Sea', NULL, NULL),
    (6, N'Laila Mostafa', N'ليلى مصطفى', N'Female', N'Egyptian', N'29900000000006', N'1987-04-25', N'Hurghada', N'01015081924', N'Hurghada, Red Sea', NULL, NULL),
    (7, N'Nader Adel', N'نادر عادل', N'Male', N'Egyptian', N'29900000000007', N'1976-12-03', N'Hurghada', N'01003388814', N'Hurghada, Red Sea', NULL, NULL),
    (11, N'Nour Ashraf', N'نور أشرف', N'Female', N'Egyptian', N'29900000000011', N'1998-05-11', N'Hurghada', N'01000000011', N'Hurghada, Red Sea', NULL, NULL),
    (12, N'Karim Fathy', N'كريم فتحي', N'Male', N'Egyptian', N'29900000000012', N'1997-09-30', N'Hurghada', N'01000000012', N'Hurghada, Red Sea', NULL, NULL),
    (13, N'Mai Samir', N'مي سمير', N'Female', N'Egyptian', N'29900000000013', N'1998-02-14', N'Hurghada', N'01000000013', N'Hurghada, Red Sea', NULL, NULL),
    (14, N'Omar Reda', N'عمر رضا', N'Male', N'Egyptian', N'29900000000014', N'1999-07-07', N'Hurghada', N'01000000014', N'Hurghada, Red Sea', NULL, NULL),
    (21, N'Hany Abbas', N'هاني عباس', N'Male', N'Egyptian', N'29900000000021', N'1975-10-10', N'Hurghada', N'01005551840', N'Hurghada, Red Sea', N'Laila Abbas', N'01226401187'),
    (22, N'Sara Adel', N'سارة عادل', N'Female', N'Egyptian', N'29900000000022', N'1988-03-03', N'Hurghada', N'01028846031', N'Hurghada, Red Sea', N'Mohamed Adel', N'01009124410'),
    (101, N'Mariam Khaled Hassan', N'مريم خالد حسن', N'Female', N'Egyptian', N'29900000000101', N'2004-05-18', N'Alexandria, Egypt', N'01064429081', N'14 El-Horreya Avenue', N'Khaled Hassan', N'01022217803'),
    (102, N'Salma Younis Maged', N'سلمى يونس ماجد', N'Female', N'Egyptian', N'29900000000102', N'2003-07-09', N'Hurghada', N'01100000102', N'Hurghada, Red Sea', NULL, NULL),
    (103, N'Ahmed Tarek Mansour', N'أحمد طارق منصور', N'Male', N'Egyptian', N'29900000000103', N'2003-01-27', N'Hurghada', N'01100000103', N'Hurghada, Red Sea', NULL, NULL),
    (104, N'Nada Mohamed Fawzy', N'ندى محمد فوزي', N'Female', N'Egyptian', N'29900000000104', N'2003-09-15', N'Hurghada', N'01100000104', N'Hurghada, Red Sea', NULL, NULL),
    (105, N'Omar Adel Fouad', N'عمر عادل فؤاد', N'Male', N'Egyptian', N'29900000000105', N'2004-04-02', N'Hurghada', N'01100000105', N'Hurghada, Red Sea', NULL, NULL),
    (106, N'Malak Osama Helmy', N'ملك أسامة حلمي', N'Female', N'Egyptian', N'29900000000106', N'2004-12-21', N'Hurghada', N'01100000106', N'Hurghada, Red Sea', NULL, NULL),
    (107, N'Hussein Ali Mahmoud', N'حسين علي محمود', N'Male', N'Egyptian', N'29900000000107', N'2008-06-30', N'Hurghada', N'01100000107', N'Hurghada, Red Sea', NULL, NULL),
    (108, N'Dina Samy Morsy', N'دينا سامي مرسي', N'Female', N'Egyptian', N'29900000000108', N'2002-03-12', N'Hurghada', N'01100000108', N'Hurghada, Red Sea', NULL, NULL);
SET IDENTITY_INSERT [Person] OFF;

INSERT INTO [Staff] ([StaffID], [DepartmentID], [StaffType], [AcademicRank], [Specialization], [Office], [Status]) VALUES
    (1, 1, N'Instructor', N'Professor', N'Software Engineering', N'Dean Office', N'Active'),
    (2, 2, N'Instructor', N'AssociateProfessor', N'Database Systems & Data Engineering', N'Faculty Building B · Room 214', N'Active'),
    (3, 1, N'Instructor', N'Professor', N'Operating Systems', N'CS-305', N'Active'),
    (4, 1, N'Instructor', N'Lecturer', N'Mathematics', N'IT-102', N'Active'),
    (5, 4, N'Instructor', N'Professor', N'Machine Learning', N'AI-101', N'Active'),
    (6, 2, N'Instructor', N'Lecturer', N'Business Intelligence', N'IS-214', N'Active'),
    (7, 3, N'Instructor', N'AssociateProfessor', N'Network Security', N'CS-301', N'Active'),
    (11, 2, N'TeachingAssistant', N'TeachingAssistant', NULL, N'TA Room 1', N'Active'),
    (12, 1, N'TeachingAssistant', N'AssistantLecturer', NULL, N'TA Room 1', N'Active'),
    (13, 2, N'TeachingAssistant', N'TeachingAssistant', NULL, N'TA Room 2', N'Active'),
    (14, 2, N'TeachingAssistant', N'TeachingAssistant', NULL, N'TA Room 2', N'Active');

-- Dean and heads of department (set after the staff exist)
UPDATE [College] SET [DeanStaffID] = 1 WHERE [CollegeCode] = N'FCAI';
UPDATE [Department] SET [HeadStaffID] = 3 WHERE [DepartmentID] = 1;
UPDATE [Department] SET [HeadStaffID] = 2 WHERE [DepartmentID] = 2;
UPDATE [Department] SET [HeadStaffID] = 7 WHERE [DepartmentID] = 3;
UPDATE [Department] SET [HeadStaffID] = 5 WHERE [DepartmentID] = 4;

INSERT INTO [Admin] ([AdminID], [AdminType]) VALUES
    (21, N'University'),
    (22, N'College');

INSERT INTO [UniversityAdmin] ([AdminID]) VALUES
    (21);

INSERT INTO [CollegeAdmin] ([AdminID], [CollegeCode], [IsActive], [AssignedAt]) VALUES
    (22, N'FCAI', 1, N'2023-09-01');

INSERT INTO [Student] ([StudentID], [CollegeCode], [DepartmentID], [AdvisorStaffID], [Level], [EnrollmentDate], [AcademicStatus], [GuardianName], [GuardianOccupation], [GuardianMobile], [City], [HomePhone], [CertificateType], [SchoolName], [GraduationYear], [PreviousScore]) VALUES
    (101, N'FCAI', 2, 2, N'Junior', N'2021-09-19', N'Continuing', N'Khaled Hassan', N'Civil Engineer', N'01022217803', N'Alexandria', N'035550148', N'General Secondary - Mathematics', N'Al Safwa Language School', 2021, 95.6),
    (102, N'FCAI', 2, 2, N'Junior', N'2021-09-25', N'Continuing', N'Younis Maged', NULL, N'01200000102', N'Hurghada', NULL, N'Thanaweya Amma', N'Al Nasr Secondary School', 2021, 96.25),
    (103, N'FCAI', 1, 3, N'Junior', N'2021-09-25', N'Continuing', N'Tarek Mansour', NULL, N'01200000103', N'Hurghada', NULL, N'Thanaweya Amma', N'Hurghada Secondary School', 2021, 91.0),
    (104, N'FCAI', 2, 2, N'Junior', N'2021-09-25', N'Continuing', N'Mohamed Fawzy', NULL, N'01200000104', N'Hurghada', NULL, N'Thanaweya Amma', N'Al Ahram Secondary School', 2021, 89.75),
    (105, N'FCAI', NULL, 3, N'Sophomore', N'2022-09-24', N'Continuing', N'Adel Fouad', NULL, N'01200000105', N'Hurghada', NULL, N'Thanaweya Amma', N'Hurghada Secondary School', 2022, 92.0),
    (106, N'FCAI', NULL, 3, N'Sophomore', N'2022-09-24', N'Continuing', N'Osama Helmy', NULL, N'01200000106', N'Hurghada', NULL, N'Thanaweya Amma', N'Hurghada Language School', 2022, 90.5),
    (107, N'FCAI', NULL, 3, N'Freshman', N'2026-09-26', N'Continuing', N'Ali Mahmoud', NULL, N'01200000107', N'Hurghada', NULL, N'Thanaweya Amma', N'Safaga Secondary School', 2026, 93.0),
    (108, N'FCAI', 2, 2, N'Senior', N'2020-09-26', N'Continuing', N'Samy Morsy', NULL, N'01200000108', N'Hurghada', NULL, N'Thanaweya Amma', N'Al Nasr Secondary School', 2020, 95.0);

-- Teaching assistants (11-14) have no account: they have no portal in the agreed UI.
INSERT INTO [UserAccount] ([LoginID], [PersonID], [Email], [PasswordHash], [Role], [Status], [LastSignInAt], [CreatedAt]) VALUES
    (N'INS-0012', 1, N'khaled.mahmoud@hurghada.edu', N'TEST-ONLY-NOT-A-REAL-HASH', N'Instructor', N'Active', NULL, N'2026-09-01T09:00:00'),
    (N'INS-0048', 2, N'amr.nassar@hurghada.edu', N'TEST-ONLY-NOT-A-REAL-HASH', N'Instructor', N'Active', NULL, N'2026-09-01T09:00:00'),
    (N'INS-0055', 3, N'rania.elsayed@hurghada.edu', N'TEST-ONLY-NOT-A-REAL-HASH', N'Instructor', N'Active', NULL, N'2026-09-01T09:00:00'),
    (N'INS-0060', 4, N'hala.sami@hurghada.edu', N'TEST-ONLY-NOT-A-REAL-HASH', N'Instructor', N'Active', NULL, N'2026-09-01T09:00:00'),
    (N'INS-0052', 5, N'nabil.farouk@hurghada.edu', N'TEST-ONLY-NOT-A-REAL-HASH', N'Instructor', N'Active', NULL, N'2026-09-01T09:00:00'),
    (N'INS-0064', 6, N'laila.mostafa@hurghada.edu', N'TEST-ONLY-NOT-A-REAL-HASH', N'Instructor', N'Active', NULL, N'2026-09-01T09:00:00'),
    (N'INS-0071', 7, N'nader.adel@hurghada.edu', N'TEST-ONLY-NOT-A-REAL-HASH', N'Instructor', N'Active', NULL, N'2026-09-01T09:00:00'),
    (N'ADM-UNI-001', 21, N'hany.abbas@hurghada.edu', N'TEST-ONLY-NOT-A-REAL-HASH', N'UniversityAdmin', N'Active', NULL, N'2026-09-01T09:00:00'),
    (N'ADM-FCAI-012', 22, N'sara.adel@hurghada.edu', N'TEST-ONLY-NOT-A-REAL-HASH', N'CollegeAdmin', N'Active', NULL, N'2026-09-01T09:00:00'),
    (N'ST-2021-0842', 101, N'mariam.hassan@hurghada.edu', N'TEST-ONLY-NOT-A-REAL-HASH', N'Student', N'Active', NULL, N'2026-09-01T09:00:00'),
    (N'ST-2021-0721', 102, N'salma.maged@hurghada.edu', N'TEST-ONLY-NOT-A-REAL-HASH', N'Student', N'Active', NULL, N'2026-09-01T09:00:00'),
    (N'ST-2021-0655', 103, N'ahmed.mansour@hurghada.edu', N'TEST-ONLY-NOT-A-REAL-HASH', N'Student', N'Active', NULL, N'2026-09-01T09:00:00'),
    (N'ST-2021-0913', 104, N'nada.fawzy@hurghada.edu', N'TEST-ONLY-NOT-A-REAL-HASH', N'Student', N'Active', NULL, N'2026-09-01T09:00:00'),
    (N'ST-2022-1027', 105, N'omar.fouad@hurghada.edu', N'TEST-ONLY-NOT-A-REAL-HASH', N'Student', N'Active', NULL, N'2026-09-01T09:00:00'),
    (N'ST-2022-1141', 106, N'malak.helmy@hurghada.edu', N'TEST-ONLY-NOT-A-REAL-HASH', N'Student', N'Active', NULL, N'2026-09-01T09:00:00'),
    (N'ST-2026-0154', 107, N'hussein.mahmoud@hurghada.edu', N'TEST-ONLY-NOT-A-REAL-HASH', N'Student', N'Active', NULL, N'2026-09-01T09:00:00'),
    (N'ST-2020-0452', 108, N'dina.morsy@hurghada.edu', N'TEST-ONLY-NOT-A-REAL-HASH', N'Student', N'Active', NULL, N'2026-09-01T09:00:00');


-- ======================================================================
-- Group 3 - Catalogue and schedule
-- ======================================================================
SET IDENTITY_INSERT [AcademicTerm] ON;
INSERT INTO [AcademicTerm] ([TermID], [AcademicYear], [TermName], [StartDate], [EndDate], [IsCurrent]) VALUES
    (1, N'2025/2026', N'Second', N'2026-02-14', N'2026-06-25', 0),
    (2, N'2026/2027', N'First', N'2026-09-26', N'2027-01-21', 1);
SET IDENTITY_INSERT [AcademicTerm] OFF;

SET IDENTITY_INSERT [Course] ON;
INSERT INTO [Course] ([CourseID], [CollegeCode], [Code], [Name], [Level], [CreditHours], [ActivityType], [Status]) VALUES
    (1, N'FCAI', N'IS 301', N'Database Systems', N'Junior', 3, N'Section', N'Active'),
    (2, N'FCAI', N'CS 315', N'Operating Systems', N'Junior', 3, N'Lab', N'Active'),
    (3, N'FCAI', N'IS 320', N'Systems Analysis & Design', N'Junior', 3, N'Section', N'Active'),
    (4, N'FCAI', N'IS 215', N'File Organization', N'Sophomore', 3, N'Lab', N'Active'),
    (5, N'FCAI', N'IS 410', N'Data Warehousing', N'Senior', 2, N'Section', N'Active'),
    (6, N'FCAI', N'AI 220', N'Applied Machine Learning', N'Junior', 3, N'Lab', N'Active'),
    (7, N'FCAI', N'IS 330', N'Business Intelligence', N'Junior', 3, N'Section', N'Active'),
    (8, N'FCAI', N'CS 340', N'Computer Networks', N'Junior', 3, N'Lab', N'Active'),
    (9, N'FCAI', N'HU 210', N'Academic Writing', N'Junior', 2, N'None', N'Active'),
    (10, N'FCAI', N'CS 101', N'Introduction to Computing', N'Freshman', 3, N'Lab', N'Active'),
    (11, N'FCAI', N'MTH 101', N'Calculus I', N'Freshman', 3, N'None', N'Active'),
    (12, N'FCAI', N'CS 210', N'Data Structures', N'Sophomore', 3, N'Lab', N'Active'),
    (13, N'FCAI', N'MTH 201', N'Discrete Mathematics', N'Sophomore', 3, N'None', N'Active');
SET IDENTITY_INSERT [Course] OFF;

-- Courses offered to departments. Freshman / Sophomore courses have no rows (general courses).
-- AI 220 and CS 340 are shared; HU 210 is offered to all four departments.
INSERT INTO [DepartmentCourse] ([DepartmentID], [CourseID]) VALUES
    (2, 1),
    (1, 2),
    (2, 3),
    (2, 5),
    (4, 6),
    (1, 6),
    (2, 7),
    (1, 8),
    (3, 8),
    (1, 9),
    (2, 9),
    (3, 9),
    (4, 9);

INSERT INTO [CoursePrerequisite] ([CourseID], [PrerequisiteCourseID]) VALUES
    (12, 10),
    (1, 12),
    (2, 12),
    (5, 1),
    (6, 13);

-- Past term (1): published results. Current term (2): results still in Draft.
SET IDENTITY_INSERT [CourseOffering] ON;
INSERT INTO [CourseOffering] ([OfferingID], [CourseID], [TermID], [InstructorStaffID], [LectureDay], [LectureStart], [LectureRoomCode], [ResultStatus], [SubmittedAt], [ReturnReason], [ApprovedByAdminID], [ApprovedAt], [PublishedByAdminID], [PublishedAt]) VALUES
    (1, 1, 2, 2, N'Sun', N'09:00', N'CS-204', N'Draft', NULL, NULL, NULL, NULL, NULL, NULL),
    (2, 2, 2, 2, N'Mon', N'09:00', N'CS-118', N'Draft', NULL, NULL, NULL, NULL, NULL, NULL),
    (3, 3, 2, 2, N'Tue', N'09:00', N'CS-106', N'Draft', NULL, NULL, NULL, NULL, NULL, NULL),
    (4, 4, 2, 2, N'Mon', N'12:00', N'CS-112', N'Draft', NULL, NULL, NULL, NULL, NULL, NULL),
    (5, 5, 2, 2, N'Wed', N'13:00', N'CS-204', N'Draft', NULL, NULL, NULL, NULL, NULL, NULL),
    (6, 6, 2, 5, N'Wed', N'09:00', N'CS-211', N'Draft', NULL, NULL, NULL, NULL, NULL, NULL),
    (7, 7, 2, 6, N'Thu', N'09:00', N'CS-206', N'Draft', NULL, NULL, NULL, NULL, NULL, NULL),
    (8, 8, 2, 7, N'Sat', N'09:00', N'CS-112', N'Draft', NULL, NULL, NULL, NULL, NULL, NULL),
    (9, 9, 2, 4, N'Thu', N'12:00', N'HU-031', N'Draft', NULL, NULL, NULL, NULL, NULL, NULL),
    (10, 10, 2, 3, N'Sat', N'12:00', N'CS-118', N'Draft', NULL, NULL, NULL, NULL, NULL, NULL),
    (11, 11, 2, 3, N'Sun', N'13:00', N'CS-118', N'Draft', NULL, NULL, NULL, NULL, NULL, NULL),
    (12, 12, 2, 3, N'Tue', N'13:00', N'CS-118', N'Draft', NULL, NULL, NULL, NULL, NULL, NULL),
    (13, 13, 2, 4, N'Wed', N'11:00', N'HU-031', N'Draft', NULL, NULL, NULL, NULL, NULL, NULL),
    (14, 12, 1, 3, N'Tue', N'13:00', N'CS-118', N'Published', N'2026-06-10T12:00:00', NULL, 22, N'2026-06-14T10:00:00', 22, N'2026-06-20T10:00:00'),
    (15, 13, 1, 4, N'Wed', N'11:00', N'HU-031', N'Published', N'2026-06-11T12:00:00', NULL, 22, N'2026-06-14T10:30:00', 22, N'2026-06-20T10:00:00');
SET IDENTITY_INSERT [CourseOffering] OFF;

SET IDENTITY_INSERT [ClassGroup] ON;
INSERT INTO [ClassGroup] ([GroupID], [OfferingID], [GroupNumber], [GroupType], [TAStaffID], [Day], [StartTime], [RoomCode], [SeatCapacity]) VALUES
    (1, 1, 1, N'Section', 11, N'Tue', N'13:00', N'CS-220', 40),
    (2, 1, 2, N'Section', 11, N'Thu', N'13:00', N'CS-221', 40),
    (3, 2, 1, N'Lab', 12, N'Tue', N'13:00', N'CS-Lab 2', 30),
    (4, 2, 2, N'Lab', 12, N'Wed', N'15:00', N'CS-Lab 1', 30),
    (5, 3, 1, N'Section', 13, N'Sat', N'13:00', N'CS-220', 40),
    (6, 3, 2, N'Section', 13, N'Mon', N'15:00', N'CS-221', 40),
    (7, 4, 1, N'Lab', 14, N'Wed', N'09:00', N'CS-Lab 3', 30),
    (8, 4, 2, N'Lab', 14, N'Wed', N'11:00', N'CS-Lab 3', 30),
    (9, 5, 1, N'Section', 11, N'Thu', N'10:00', N'CS-220', 40),
    (10, 6, 1, N'Lab', 12, N'Sun', N'13:00', N'CS-Lab 1', 30),
    (11, 7, 1, N'Section', 13, N'Sun', N'13:00', N'CS-221', 40),
    (12, 8, 1, N'Lab', 12, N'Mon', N'13:00', N'CS-Lab 2', 30),
    (13, 10, 1, N'Lab', 14, N'Sun', N'09:00', N'CS-Lab 1', 30),
    (14, 12, 1, N'Lab', 14, N'Thu', N'09:00', N'CS-Lab 2', 30),
    (15, 14, 1, N'Lab', 14, N'Thu', N'09:00', N'CS-Lab 2', 30);
SET IDENTITY_INSERT [ClassGroup] OFF;

INSERT INTO [SchedulePublication] ([CollegeCode], [TermID], [Level], [Status], [PublishedAt]) VALUES
    (N'FCAI', 2, N'Freshman', N'Published', N'2026-09-20T10:00:00'),
    (N'FCAI', 2, N'Sophomore', N'Published', N'2026-09-20T10:00:00'),
    (N'FCAI', 2, N'Junior', N'Published', N'2026-09-20T10:00:00'),
    (N'FCAI', 2, N'Senior', N'UnpublishedChanges', N'2026-09-20T10:00:00');


-- ======================================================================
-- Group 4 - Registration
-- ======================================================================
INSERT INTO [RegistrationPeriod] ([CollegeCode], [TermID], [RegistrationOpens], [RegistrationCloses], [ManualOverride]) VALUES
    (N'FCAI', 1, N'2026-02-01T08:00:00', N'2026-02-26T23:59:00', N'None'),
    (N'FCAI', 2, N'2026-09-12T08:00:00', N'2026-10-08T23:59:00', N'None');

SET IDENTITY_INSERT [RegistrationForm] ON;
INSERT INTO [RegistrationForm] ([FormID], [StudentID], [TermID], [SavedAt], [AdvisorStaffID], [Decision], [AdvisorNote], [DecidedAt]) VALUES
    (1, 101, 2, N'2026-10-01T11:20:00', 2, N'Approved', NULL, N'2026-10-03T10:00:00'),
    (2, 102, 2, N'2026-10-01T12:05:00', 2, N'Approved', NULL, N'2026-10-03T10:15:00'),
    (3, 103, 2, N'2026-10-02T09:40:00', 3, N'AwaitingSignature', NULL, NULL),
    (4, 104, 2, N'2026-10-02T13:10:00', 2, N'ChangesRequested', N'Please confirm your IS 320 section group before I sign.', N'2026-10-04T09:30:00'),
    (5, 105, 2, N'2026-10-01T15:00:00', 3, N'Approved', NULL, N'2026-10-03T11:00:00'),
    (6, 106, 2, N'2026-10-02T16:30:00', 3, N'Approved', NULL, N'2026-10-03T11:10:00'),
    (7, 107, 2, N'2026-10-05T10:00:00', 3, N'AwaitingSignature', NULL, NULL),
    (8, 108, 2, N'2026-10-01T10:00:00', 2, N'Approved', NULL, N'2026-10-02T12:00:00'),
    (9, 101, 1, N'2026-02-10T10:00:00', 2, N'Approved', NULL, N'2026-02-12T10:00:00'),
    (10, 102, 1, N'2026-02-10T11:00:00', 2, N'Approved', NULL, N'2026-02-12T10:30:00');
SET IDENTITY_INSERT [RegistrationForm] OFF;

SET IDENTITY_INSERT [Enrollment] ON;
INSERT INTO [Enrollment] ([EnrollmentID], [StudentID], [OfferingID], [GroupID], [RegisteredAt], [AttendanceMark], [PracticalMark], [MidtermMark], [OralMark], [FinalMark]) VALUES
    (1, 101, 1, 1, N'2026-10-01T11:00:00', 9, 17, 25, NULL, NULL),
    (2, 101, 2, 4, N'2026-10-01T11:00:00', 10, 18, 27, NULL, NULL),
    (3, 101, 3, 5, N'2026-10-01T11:00:00', NULL, NULL, NULL, NULL, NULL),
    (4, 101, 9, NULL, N'2026-10-01T11:00:00', NULL, NULL, NULL, NULL, NULL),
    (5, 101, 6, 10, N'2026-10-01T11:00:00', NULL, NULL, NULL, NULL, NULL),
    (6, 102, 1, 2, N'2026-10-01T11:00:00', 10, 19, 28, NULL, NULL),
    (7, 102, 3, 6, N'2026-10-01T11:00:00', NULL, NULL, NULL, NULL, NULL),
    (8, 102, 7, 11, N'2026-10-01T11:00:00', NULL, NULL, NULL, NULL, NULL),
    (9, 102, 2, 3, N'2026-10-01T11:00:00', 9, 16, 24, NULL, NULL),
    (10, 103, 2, 3, N'2026-10-01T11:00:00', 8, 15, 21, NULL, NULL),
    (11, 103, 8, 12, N'2026-10-01T11:00:00', NULL, NULL, NULL, NULL, NULL),
    (12, 103, 6, 10, N'2026-10-01T11:00:00', NULL, NULL, NULL, NULL, NULL),
    (13, 103, 1, 2, N'2026-10-01T11:00:00', 7, 14, 19, NULL, NULL),
    (14, 104, 1, 1, N'2026-10-01T11:00:00', 6, 12, 15, NULL, NULL),
    (15, 104, 3, 5, N'2026-10-01T11:00:00', NULL, NULL, NULL, NULL, NULL),
    (16, 104, 7, 11, N'2026-10-01T11:00:00', NULL, NULL, NULL, NULL, NULL),
    (17, 104, 9, NULL, N'2026-10-01T11:00:00', NULL, NULL, NULL, NULL, NULL),
    (18, 105, 4, 7, N'2026-10-01T11:00:00', NULL, NULL, NULL, NULL, NULL),
    (19, 105, 12, 14, N'2026-10-01T11:00:00', NULL, NULL, NULL, NULL, NULL),
    (20, 105, 13, NULL, N'2026-10-01T11:00:00', NULL, NULL, NULL, NULL, NULL),
    (21, 106, 4, 7, N'2026-10-01T11:00:00', NULL, NULL, NULL, NULL, NULL),
    (22, 106, 12, 14, N'2026-10-01T11:00:00', NULL, NULL, NULL, NULL, NULL),
    (23, 106, 13, NULL, N'2026-10-01T11:00:00', NULL, NULL, NULL, NULL, NULL),
    (24, 107, 10, 13, N'2026-10-01T11:00:00', NULL, NULL, NULL, NULL, NULL),
    (25, 107, 11, NULL, N'2026-10-01T11:00:00', NULL, NULL, NULL, NULL, NULL),
    (26, 108, 5, 9, N'2026-10-01T11:00:00', NULL, NULL, NULL, NULL, NULL),
    (27, 101, 14, 15, N'2026-02-10T10:00:00', 10, 18, 27, 9, 25),
    (28, 101, 15, NULL, N'2026-02-10T10:00:00', 9, 17, 25, 8, 25),
    (29, 102, 14, 15, N'2026-02-10T10:00:00', 10, 19, 28, 10, 27),
    (30, 102, 15, NULL, N'2026-02-10T10:00:00', 10, 18, 26, 9, 26);
SET IDENTITY_INSERT [Enrollment] OFF;

-- Enrollments 27-30 are the past term (published). Total = sum of the five marks.

SET IDENTITY_INSERT [Notification] ON;
INSERT INTO [Notification] ([NotificationID], [LoginID], [Title], [Body], [IsRead], [CreatedAt]) VALUES
    (1, N'ST-2021-0842', N'Registration approved', N'Your advisor approved your registration form for 2026/2027 First Term.', 1, N'2026-10-03T10:00:00'),
    (2, N'ST-2021-0842', N'Midterm schedule published', N'The midterm exam schedule is now available.', 0, N'2026-10-25T09:00:00'),
    (3, N'ST-2021-0913', N'Changes requested', N'Your advisor requested changes to your registration form.', 0, N'2026-10-04T09:30:00'),
    (4, N'INS-0048', N'Grades pending', N'12 grade entries are not yet submitted.', 0, N'2026-11-20T08:00:00');
SET IDENTITY_INSERT [Notification] OFF;

-- GradeCorrection: one correction after the past-term results were submitted.
SET IDENTITY_INSERT [GradeCorrection] ON;
INSERT INTO [GradeCorrection] ([CorrectionID], [EnrollmentID], [CorrectedByAdminID], [Component], [OldMark], [NewMark], [Reason], [CorrectedAt]) VALUES
    (1, 29, 22, N'Final', 25, 27, N'Exam paper re-marked: question 4 was not counted.', N'2026-06-18T11:00:00');
SET IDENTITY_INSERT [GradeCorrection] OFF;

-- PermissionChangeLog (Group 1 table; placed here because it needs the admins).
-- The permission was switched off and back on, so it ends as in the seed.
SET IDENTITY_INSERT [PermissionChangeLog] ON;
INSERT INTO [PermissionChangeLog] ([ChangeID], [PermissionKey], [ChangedByAdminID], [OldIsEnabled], [NewIsEnabled], [ChangedAt]) VALUES
    (1, N'instructor.exportRoster', 21, 1, 0, N'2026-10-20T10:00:00'),
    (2, N'instructor.exportRoster', 21, 0, 1, N'2026-10-21T09:30:00');
SET IDENTITY_INSERT [PermissionChangeLog] OFF;

UPDATE [Permission] SET [UpdatedByAdminID] = 21, [UpdatedAt] = '2026-10-21T09:30:00' WHERE [PermissionKey] = N'instructor.exportRoster';


-- ======================================================================
-- Group 5 - Teaching and exams
-- ======================================================================
SET IDENTITY_INSERT [ClassSession] ON;
INSERT INTO [ClassSession] ([SessionID], [OfferingID], [GroupID], [SessionNumber], [SessionDate]) VALUES
    (1, 1, NULL, 1, N'2026-10-04'),
    (2, 1, NULL, 2, N'2026-10-11'),
    (3, 1, NULL, 3, N'2026-10-18'),
    (4, 1, 1, 1, N'2026-10-06'),
    (5, 1, 1, 2, N'2026-10-13');
SET IDENTITY_INSERT [ClassSession] OFF;

INSERT INTO [Attendance] ([SessionID], [EnrollmentID], [Status], [RecordedByStaffID], [RecordedAt]) VALUES
    (1, 1, N'Present', 2, N'2026-10-04T12:00:00'),
    (1, 6, N'Present', 2, N'2026-10-04T12:00:00'),
    (1, 13, N'Late', 2, N'2026-10-04T12:00:00'),
    (1, 14, N'Absent', 2, N'2026-10-04T12:00:00'),
    (2, 1, N'Present', 2, N'2026-10-11T12:00:00'),
    (2, 6, N'Present', 2, N'2026-10-11T12:00:00'),
    (2, 13, N'Present', 2, N'2026-10-11T12:00:00'),
    (2, 14, N'Present', 2, N'2026-10-11T12:00:00'),
    (3, 1, N'Present', 2, N'2026-10-18T12:00:00'),
    (3, 6, N'Present', 2, N'2026-10-18T12:00:00'),
    (3, 13, N'Present', 2, N'2026-10-18T12:00:00'),
    (3, 14, N'Absent', 2, N'2026-10-18T12:00:00'),
    (4, 1, N'Present', 2, N'2026-10-06T12:00:00'),
    (4, 14, N'Absent', 2, N'2026-10-06T12:00:00'),
    (5, 1, N'Present', 2, N'2026-10-13T12:00:00'),
    (5, 14, N'Present', 2, N'2026-10-13T12:00:00');

SET IDENTITY_INSERT [Exam] ON;
INSERT INTO [Exam] ([ExamID], [OfferingID], [ExamType], [ExamDate], [StartTime], [EndTime], [RoomCode], [CommitteeName], [HeadStaffID]) VALUES
    (1, 1, N'Midterm', N'2026-11-12', N'09:00', N'11:00', N'Main Hall 2', N'Committee A', 2),
    (2, 2, N'Midterm', N'2026-11-16', N'11:00', N'13:00', N'CS-118', N'Committee B', 2),
    (3, 3, N'Midterm', N'2026-11-19', N'09:00', N'11:00', N'CS-106', N'Committee C', 2),
    (4, 1, N'Final', N'2027-01-09', N'09:00', N'12:00', N'Main Hall 2', N'Committee A', 2),
    (5, 2, N'Final', N'2027-01-12', N'11:00', N'14:00', N'CS-118', N'Committee B', 2);
SET IDENTITY_INSERT [Exam] OFF;

INSERT INTO [ExamSeat] ([ExamID], [EnrollmentID], [SeatNumber]) VALUES
    (1, 1, N'B-24'),
    (1, 6, N'B-25'),
    (1, 13, N'B-26'),
    (1, 14, N'B-27'),
    (2, 2, N'A-01'),
    (2, 9, N'A-02'),
    (2, 10, N'A-03'),
    (3, 3, N'A-12'),
    (3, 7, N'A-13'),
    (3, 15, N'A-14');

INSERT INTO [ExamPublication] ([CollegeCode], [TermID], [ExamType], [Status], [PublishedAt]) VALUES
    (N'FCAI', 2, N'Midterm', N'Published', N'2026-10-25T09:00:00'),
    (N'FCAI', 2, N'Final', N'Draft', NULL);

COMMIT TRANSACTION;
PRINT 'USMS test data inserted.';

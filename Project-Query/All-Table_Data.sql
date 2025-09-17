EXEC PR_User_Insert 
    @UserName = 'john_doe', 
    @Password = 'pass123', 
    @Email = 'john@example.com', 
    @MobileNo = '9876543210';

EXEC PR_User_Insert 
    @UserName = 'alice_smith', 
    @Password = 'alice@456', 
    @Email = 'alice@example.com', 
    @MobileNo = '9876501234';

EXEC PR_User_Insert 
    @UserName = 'bob_martin', 
    @Password = 'bob@pass', 
    @Email = 'bob@example.com', 
    @MobileNo = '9876505678';

EXEC PR_User_Insert 
    @UserName = 'charlie_k', 
    @Password = 'charlie@789', 
    @Email = 'charlie@example.com', 
    @MobileNo = '9876509876';

EXEC PR_User_Insert 
    @UserName = 'diana_r', 
    @Password = 'diana@000', 
    @Email = 'diana@example.com', 
    @MobileNo = '9876512345';

EXEC PR_User_Insert 
    @UserName = 'rahul_verma', 
    @Password = 'rahul@123', 
    @Email = 'rahul.verma@example.com', 
    @MobileNo = '9123456780';

EXEC PR_User_Insert 
    @UserName = 'sneha_patel', 
    @Password = 'sneha@456', 
    @Email = 'sneha.patel@example.com', 
    @MobileNo = '9123456781';

EXEC PR_User_Insert 
    @UserName = 'arjun_mehta', 
    @Password = 'arjun@789', 
    @Email = 'arjun.mehta@example.com', 
    @MobileNo = '9123456782';

EXEC PR_User_Insert 
    @UserName = 'priya_shah', 
    @Password = 'priya@321', 
    @Email = 'priya.shah@example.com', 
    @MobileNo = '9123456783';

EXEC PR_User_Insert 
    @UserName = 'vikas_kumar', 
    @Password = 'vikas@654', 
    @Email = 'vikas.kumar@example.com', 
    @MobileNo = '9123456784';


--Department Data

EXEC PR_Department_Insert 
    @DepartmentName = 'Cardiology',
    @Description = 'Heart and blood vessel related treatments',
    @IsActive = 1,
    @UserID = 1;

EXEC PR_Department_Insert 
    @DepartmentName = 'Neurology',
    @Description = 'Brain and nervous system care',
    @IsActive = 1,
    @UserID = 2;

EXEC PR_Department_Insert 
    @DepartmentName = 'Orthopedics',
    @Description = 'Musculoskeletal system diagnosis and treatment',
    @IsActive = 1,
    @UserID = 3;

EXEC PR_Department_Insert 
    @DepartmentName = 'Pediatrics',
    @Description = 'Child healthcare and treatment',
    @IsActive = 1,
    @UserID = 4;

EXEC PR_Department_Insert 
    @DepartmentName = 'Dermatology',
    @Description = 'Skin, hair, and nail treatments',
    @IsActive = 1,
    @UserID = 5;

EXEC PR_Department_Insert 
    @DepartmentName = 'ENT', 
    @Description = 'Ear, Nose and Throat care',
    @IsActive = 1,
    @UserID = 2;

EXEC PR_Department_Insert 
    @DepartmentName = 'Gynecology', 
    @Description = 'Women’s reproductive health',
    @IsActive = 1,
    @UserID = 3;

EXEC PR_Department_Insert 
    @DepartmentName = 'Oncology', 
    @Description = 'Cancer diagnosis and treatment',
    @IsActive = 1,
    @UserID = 1;

EXEC PR_Department_Insert 
    @DepartmentName = 'Psychiatry', 
    @Description = 'Mental health and behavioral disorders',
    @IsActive = 1,
    @UserID = 1;

EXEC PR_Department_Insert 
    @DepartmentName = 'Urology', 
    @Description = 'Urinary tract and male reproductive system',
    @IsActive = 1,
    @UserID = 4;


--Doctor Data

EXEC PR_Doctor_Insert 
    @Name = 'Dr. Asha Mehta',
    @Phone = '9000010001',
    @Email = 'asha.mehta@hospital.com',
    @Qualification = 'MBBS, MD',
    @Specialization = 'Cardiologist',
    @IsActive = 1,
    @UserID = 1;

EXEC PR_Doctor_Insert 
    @Name = 'Dr. Rajiv Patel',
    @Phone = '9000010002',
    @Email = 'rajiv.patel@hospital.com',
    @Qualification = 'MBBS, MS',
    @Specialization = 'Orthopedic',
    @IsActive = 1,
    @UserID = 2;

EXEC PR_Doctor_Insert 
    @Name = 'Dr. Sneha Shah',
    @Phone = '9000010003',
    @Email = 'sneha.shah@hospital.com',
    @Qualification = 'MBBS, DCH',
    @Specialization = 'Pediatrician',
    @IsActive = 1,
    @UserID = 3;

EXEC PR_Doctor_Insert 
    @Name = 'Dr. Kunal Joshi',
    @Phone = '9000010004',
    @Email = 'kunal.joshi@hospital.com',
    @Qualification = 'MBBS, DGO',
    @Specialization = 'Gynecologist',
    @IsActive = 1,
    @UserID = 4;

EXEC PR_Doctor_Insert 
    @Name = 'Dr. Priya Desai',
    @Phone = '9000010005',
    @Email = 'priya.desai@hospital.com',
    @Qualification = 'MBBS, DVD',
    @Specialization = 'Dermatologist',
    @IsActive = 1,
    @UserID = 5;

EXEC PR_Doctor_Insert 
    @Name = 'Dr. Amit Trivedi',
    @Phone = '9000010006',
    @Email = 'amit.trivedi@hospital.com',
    @Qualification = 'MBBS, DM',
    @Specialization = 'Neurologist',
    @IsActive = 1,
    @UserID = 6;

EXEC PR_Doctor_Insert 
    @Name = 'Dr. Neha Bhatt',
    @Phone = '9000010007',
    @Email = 'neha.bhatt@hospital.com',
    @Qualification = 'MBBS, DPM',
    @Specialization = 'Psychiatrist',
    @IsActive = 1,
    @UserID = 7;

EXEC PR_Doctor_Insert 
    @Name = 'Dr. Manish Sharma',
    @Phone = '9000010008',
    @Email = 'manish.sharma@hospital.com',
    @Qualification = 'MBBS, MCh',
    @Specialization = 'Oncologist',
    @IsActive = 1,
    @UserID = 8;

EXEC PR_Doctor_Insert 
    @Name = 'Dr. Kavita Raval',
    @Phone = '9000010009',
    @Email = 'kavita.raval@hospital.com',
    @Qualification = 'MBBS, MS ENT',
    @Specialization = 'ENT Specialist',
    @IsActive = 1,
    @UserID = 9;

EXEC PR_Doctor_Insert 
    @Name = 'Dr. Rohan Kapadia',
    @Phone = '9000010010',
    @Email = 'rohan.kapadia@hospital.com',
    @Qualification = 'MBBS, MS',
    @Specialization = 'Urologist',
    @IsActive = 1,
    @UserID = 10;


--DoctorDepartment Data

EXEC PR_DoctorDepartment_Insert @DoctorID = 1,  @DepartmentID = 1,  @UserID = 1;
EXEC PR_DoctorDepartment_Insert @DoctorID = 2,  @DepartmentID = 2,  @UserID = 2;
EXEC PR_DoctorDepartment_Insert @DoctorID = 3,  @DepartmentID = 3,  @UserID = 3;
EXEC PR_DoctorDepartment_Insert @DoctorID = 4,  @DepartmentID = 4,  @UserID = 4;
EXEC PR_DoctorDepartment_Insert @DoctorID = 5,  @DepartmentID = 5,  @UserID = 5;
EXEC PR_DoctorDepartment_Insert @DoctorID = 6,  @DepartmentID = 6,  @UserID = 6;
EXEC PR_DoctorDepartment_Insert @DoctorID = 7,  @DepartmentID = 7,  @UserID = 7;
EXEC PR_DoctorDepartment_Insert @DoctorID = 8,  @DepartmentID = 8,  @UserID = 8;
EXEC PR_DoctorDepartment_Insert @DoctorID = 9,  @DepartmentID = 9,  @UserID = 9;
EXEC PR_DoctorDepartment_Insert @DoctorID = 10, @DepartmentID = 10, @UserID = 10;

--Patient Data


EXEC PR_Patient_Insert 
    @Name = 'Anjali Singh', 
    @DateOfBirth = '1990-04-15', 
    @Gender = 'Female', 
    @Email = 'anjali.singh@example.com', 
    @Phone = '9876000001', 
    @Address = '123 MG Road', 
    @City = 'Mumbai', 
    @State = 'Maharashtra', 
    @IsActive = 1, 
    @UserID = 1;

EXEC PR_Patient_Insert 
    @Name = 'Ravi Mehta', 
    @DateOfBirth = '1985-11-02', 
    @Gender = 'Male', 
    @Email = 'ravi.mehta@example.com', 
    @Phone = '9876000002', 
    @Address = '22 Nehru Street', 
    @City = 'Ahmedabad', 
    @State = 'Gujarat', 
    @IsActive = 1, 
    @UserID = 2;

EXEC PR_Patient_Insert 
    @Name = 'Kiran Sharma', 
    @DateOfBirth = '2000-01-20', 
    @Gender = 'Female', 
    @Email = 'kiran.sharma@example.com', 
    @Phone = '9876000003', 
    @Address = '55 Park Lane', 
    @City = 'Delhi', 
    @State = 'Delhi', 
    @IsActive = 1, 
    @UserID = 3;

EXEC PR_Patient_Insert 
    @Name = 'Vikram Chauhan', 
    @DateOfBirth = '1978-06-10', 
    @Gender = 'Male', 
    @Email = 'vikram.chauhan@example.com', 
    @Phone = '9876000004', 
    @Address = '88 Sector 5', 
    @City = 'Chandigarh', 
    @State = 'Punjab', 
    @IsActive = 1, 
    @UserID = 4;

EXEC PR_Patient_Insert 
    @Name = 'Neha Desai', 
    @DateOfBirth = '1995-09-25', 
    @Gender = 'Female', 
    @Email = 'neha.desai@example.com', 
    @Phone = '9876000005', 
    @Address = 'Flat 201, Green Apartments', 
    @City = 'Surat', 
    @State = 'Gujarat', 
    @IsActive = 1, 
    @UserID = 5;

EXEC PR_Patient_Insert 
    @Name = 'Amitabh Nair', 
    @DateOfBirth = '1982-03-12', 
    @Gender = 'Male', 
    @Email = 'amitabh.nair@example.com', 
    @Phone = '9876000006', 
    @Address = 'Plot 12, Link Road', 
    @City = 'Kochi', 
    @State = 'Kerala', 
    @IsActive = 1, 
    @UserID = 6;

EXEC PR_Patient_Insert 
    @Name = 'Swati Joshi', 
    @DateOfBirth = '1998-07-17', 
    @Gender = 'Female', 
    @Email = 'swati.joshi@example.com', 
    @Phone = '9876000007', 
    @Address = '12 Shanti Park', 
    @City = 'Pune', 
    @State = 'Maharashtra', 
    @IsActive = 1, 
    @UserID = 7;

EXEC PR_Patient_Insert 
    @Name = 'Deepak Kumar', 
    @DateOfBirth = '1989-12-05', 
    @Gender = 'Male', 
    @Email = 'deepak.kumar@example.com', 
    @Phone = '9876000008', 
    @Address = '405 Galaxy Complex', 
    @City = 'Patna', 
    @State = 'Bihar', 
    @IsActive = 1, 
    @UserID = 8;

EXEC PR_Patient_Insert 
    @Name = 'Pooja Reddy', 
    @DateOfBirth = '1992-08-30', 
    @Gender = 'Female', 
    @Email = 'pooja.reddy@example.com', 
    @Phone = '9876000009', 
    @Address = '5th Floor, Silver Heights', 
    @City = 'Hyderabad', 
    @State = 'Telangana', 
    @IsActive = 1, 
    @UserID = 9;

EXEC PR_Patient_Insert 
    @Name = 'Nikhil Saxena', 
    @DateOfBirth = '1980-02-14', 
    @Gender = 'Male', 
    @Email = 'nikhil.saxena@example.com', 
    @Phone = '9876000010', 
    @Address = '10 Vivekananda Nagar', 
    @City = 'Bhopal', 
    @State = 'Madhya Pradesh', 
    @IsActive = 1, 
    @UserID = 10;

--Appointment Data

EXEC PR_Appointment_Insert 
    @DoctorID = 1, @PatientID = 1, 
    @AppointmentDate = '2025-07-16 10:00:00', 
    @AppointmentStatus = 'Scheduled', 
    @Description = 'Routine heart checkup', 
    @SpecialRemarks = 'Bring previous reports', 
    @UserID = 1, 
    @TotalConsultedAmount = 500.00;

EXEC PR_Appointment_Insert 
    @DoctorID = 2, @PatientID = 2, 
    @AppointmentDate = '2025-07-16 11:30:00', 
    @AppointmentStatus = 'Scheduled', 
    @Description = 'Knee pain consultation', 
    @SpecialRemarks = 'X-ray recommended', 
    @UserID = 2, 
    @TotalConsultedAmount = 600.00;

EXEC PR_Appointment_Insert 
    @DoctorID = 3, @PatientID = 3, 
    @AppointmentDate = '2025-07-16 09:00:00', 
    @AppointmentStatus = 'Completed', 
    @Description = 'Fever and cold', 
    @SpecialRemarks = 'Prescribed medication', 
    @UserID = 3, 
    @TotalConsultedAmount = 300.00;

EXEC PR_Appointment_Insert 
    @DoctorID = 4, @PatientID = 4, 
    @AppointmentDate = '2025-07-15 16:00:00', 
    @AppointmentStatus = 'Completed', 
    @Description = 'Pregnancy follow-up', 
    @SpecialRemarks = 'Next scan in 2 weeks', 
    @UserID = 4, 
    @TotalConsultedAmount = 800.00;

EXEC PR_Appointment_Insert 
    @DoctorID = 5, @PatientID = 5, 
    @AppointmentDate = '2025-07-14 14:45:00', 
    @AppointmentStatus = 'Cancelled', 
    @Description = 'Skin allergy', 
    @SpecialRemarks = 'Patient didn’t show', 
    @UserID = 5, 
    @TotalConsultedAmount = 0.00;

EXEC PR_Appointment_Insert 
    @DoctorID = 6, @PatientID = 6, 
    @AppointmentDate = '2025-07-17 10:15:00', 
    @AppointmentStatus = 'Scheduled', 
    @Description = 'Headache and dizziness', 
    @SpecialRemarks = 'MRI suggested', 
    @UserID = 6, 
    @TotalConsultedAmount = 700.00;

EXEC PR_Appointment_Insert 
    @DoctorID = 7, @PatientID = 7, 
    @AppointmentDate = '2025-07-18 12:00:00', 
    @AppointmentStatus = 'Scheduled', 
    @Description = 'Anxiety and stress', 
    @SpecialRemarks = 'Counseling session', 
    @UserID = 7, 
    @TotalConsultedAmount = 650.00;

EXEC PR_Appointment_Insert 
    @DoctorID = 8, @PatientID = 8, 
    @AppointmentDate = '2025-07-16 15:00:00', 
    @AppointmentStatus = 'Completed', 
    @Description = 'Tumor consultation', 
    @SpecialRemarks = 'Biopsy scheduled', 
    @UserID = 8, 
    @TotalConsultedAmount = 1200.00;

EXEC PR_Appointment_Insert 
    @DoctorID = 9, @PatientID = 9, 
    @AppointmentDate = '2025-07-13 11:00:00', 
    @AppointmentStatus = 'Completed', 
    @Description = 'Ear pain', 
    @SpecialRemarks = 'Wax removed', 
    @UserID = 9, 
    @TotalConsultedAmount = 400.00;

EXEC PR_Appointment_Insert 
    @DoctorID = 10, @PatientID = 10, 
    @AppointmentDate = '2025-07-16 17:30:00', 
    @AppointmentStatus = 'Scheduled', 
    @Description = 'Kidney stone pain', 
    @SpecialRemarks = 'Ultrasound advised', 
    @UserID = 10, 
    @TotalConsultedAmount = 900.00;

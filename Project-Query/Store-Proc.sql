--USER TABLE ALL SP

--SELECT_ALL SP
CREATE OR ALTER PROCEDURE PR_User_SelectAll
AS
BEGIN
    SELECT UserID,UserName,[Password],Email,MobileNo,IsActive,Created,Modified
    FROM [User]
    ORDER BY UserID;
END;
GO

--SELECT BY PK SP
CREATE OR ALTER PROCEDURE PR_User_SelectByPK
    @UserID INT
AS
BEGIN
    SELECT UserID,UserName,[Password],Email,MobileNo,IsActive,Created,Modified
    FROM [User]
    WHERE UserID = @UserID
    ORDER BY UserID;
END
GO

--DELETE SP
CREATE OR ALTER PROCEDURE PR_User_DeleteByPK
    @UserID INT
AS
BEGIN
    DELETE FROM [User]
    WHERE UserID = @UserID;
END
GO

--INSERT SP
CREATE OR ALTER PROC PR_User_Insert
	@UserName	 NVARCHAR(100),
	@Password	 NVARCHAR(100),
	@Email		 NVARCHAR(100),
	@MobileNo	 NVARCHAR(100),
	@IsActive	 BIT = 1

AS
BEGIN
	INSERT INTO [User]
	(
		UserName,
        [Password],
        Email,
        MobileNo,
        IsActive,
        Created,
        Modified
	)
	VALUES(
		@UserName,
		@Password,
		@Email,
		@MobileNo,
		@IsActive,
		GETDATE(),
		GETDATE()
	)
END;
GO


--UPDATE SP

CREATE OR ALTER PROC PR_User_Update
    @UserID      INT,
	@UserName	 NVARCHAR(100),
	@Password	 NVARCHAR(100),
	@Email		 NVARCHAR(100),
	@MobileNo	 NVARCHAR(100),
	@IsActive	 BIT = 1
AS
BEGIN
	UPDATE [User]
    SET 
        UserName   =  @UserName ,
        [Password] =  @Password ,
        Email      =  @Email	 ,
        MobileNo   =  @MobileNo ,
        IsActive   =  @IsActive ,
        Modified   =  GETDATE() 

    WHERE UserID = @UserID;

END;
GO


--DEPARTMENT TABLE ALL SP

--SELECT_ALL SP
CREATE OR ALTER PROCEDURE PR_Department_SelectAll
AS
BEGIN
    SELECT d.DepartmentID,d.DepartmentName,d.Description,d.IsActive,d.Created,d.Modified,u.UserName 
    FROM Department d
    join [User] u
    on u.UserID = d.UserID
    ORDER BY DepartmentID;
END
GO

--SELECT BY PK
CREATE OR ALTER PROCEDURE PR_Departments_SelectByPK
    @DepartmentID INT
AS
BEGIN
    SELECT d.DepartmentID,d.DepartmentName,d.Description,d.IsActive,d.Created,d.Modified,u.UserID
    FROM Department d
    join [User] u
    on u.UserID = d.UserID
    WHERE DepartmentID = @DepartmentID
    ORDER BY DepartmentID;
END
GO

--DELETE SP
CREATE OR ALTER PROCEDURE PR_Departments_DeleteByPK
    @DepartmentID INT
AS
BEGIN
    DELETE FROM Department
    WHERE DepartmentID = @DepartmentID;
END
GO

--INSERT SP
CREATE OR ALTER PROC PR_Department_Insert
    @DepartmentName NVARCHAR(100),
    @Description    NVARCHAR(250) = NULL,
    @IsActive       BIT = 1,
    @UserID         INT 
AS
BEGIN
	INSERT INTO Department
	(
		DepartmentName,
        Description,
        IsActive,
        Created,
        Modified,
        UserID
    )
	VALUES(
		@DepartmentName,
        @Description,
        @IsActive,
        GETDATE(),
        GETDATE(),
        @UserID
	)
END;
GO

--UPDATE SP
CREATE OR ALTER PROC PR_Department_Update
    @DepartmentID   INT,
    @DepartmentName NVARCHAR(100),
    @Description    NVARCHAR(250) = NULL,
    @IsActive       BIT = 1,
    @UserID         INT 
AS
BEGIN
    UPDATE DEPARTMENT
    SET
		DepartmentName   =  @DepartmentName,
        Description      =  @Description,
        IsActive         =  @IsActive,
        Modified         =  GETDATE(),
        UserID           =  @UserID         

    WHERE DepartmentID = @DepartmentID;
END;
GO

--Doctor TABLE ALL SP

----SELECT BY PK

CREATE OR ALTER PROCEDURE PR_Doctors_SelectByPK
    @DoctorID INT
AS
BEGIN
    SELECT d.DoctorID,d.Name,d.Phone,d.Email,d.Qualification,d.Specialization,d.IsActive,d.Created,d.Modified,d.UserID 
    FROM Doctor d
    join [User] s
    on d.UserID = s.UserID
    WHERE DoctorID = @DoctorID
    ORDER BY DoctorID;
END
GO


--SELECT_ALL SP
CREATE OR ALTER PROCEDURE PR_Doctor_SelectAll
AS
BEGIN
    SELECT d.DoctorID,d.Name,d.Phone,d.Email,d.Qualification,d.Specialization,d.IsActive,d.Created,d.Modified,s.UserName 
    FROM Doctor d
    join [User] s
    on d.UserID = s.UserID
    ORDER BY DoctorID;
END
GO

--DELETE SP
CREATE OR ALTER PROCEDURE PR_Doctors_DeleteByPK
    @DoctorID INT
AS
BEGIN
    DELETE FROM Doctor
    WHERE DoctorID = @DoctorID;
END
GO

--INSERT SP
CREATE OR ALTER PROC PR_Doctor_Insert
	@Name			 nvarchar(100),
	@Phone			 nvarchar(100),
	@Email			 nvarchar(100),
	@Qualification   nvarchar(100),
	@Specialization  nvarchar(100),
	@IsActive		 Bit = 1,
    @UserID         INT 
AS
BEGIN
	INSERT INTO Doctor 
	(	
		Name,
		Phone,
		Email,
		Qualification,
		Specialization,
		IsActive,
		Created,
		Modified,
		UserID
	)
	VALUES
	(
		@Name,
		@Phone,
		@Email,
		@Qualification,
		@Specialization,
		@IsActive,
        GETDATE(),
        GETDATE(),
		@UserID
	)
END;
GO


--UPDATE SP
CREATE OR ALTER PROC PR_Doctor_Update
    @DoctorID        INT,
	@Name			 nvarchar(100),
	@Phone			 nvarchar(100),
	@Email			 nvarchar(100),
	@Qualification   nvarchar(100),
	@Specialization  nvarchar(100),
	@IsActive		 Bit = 1,
    @UserID         INT 
AS
BEGIN
	UPDATE DOCTOR
    SET
		Name             =  @Name,
		Phone            =  @Phone,
		Email            =  @Email,
		Qualification    =  @Qualification,
		Specialization   =  @Specialization,
		IsActive         =  @IsActive,
		Modified         =  GETDATE(),
		UserID           =  @UserID  
    
	WHERE DoctorID = @DoctorID
END;
GO


--DoctorDepartment TABLE ALL SP


--SELECT BY PK
CREATE OR ALTER PROCEDURE PR_DoctorDepartment_SelectByPK
    @DoctorDepartmentID INT
AS
BEGIN
    SELECT DoctorDepartment.DoctorDepartmentID,Doctor.DoctorID,Department.DepartmentID,
           DoctorDepartment.Created,DoctorDepartment.Modified,[User].UserID
    FROM DoctorDepartment
    INNER JOIN Doctor ON DoctorDepartment.DoctorID = Doctor.DoctorID
    INNER JOIN Department ON DoctorDepartment.DepartmentID = Department.DepartmentID
    INNER JOIN [User] ON DoctorDepartment.UserID = [User].UserID
    WHERE DoctorDepartmentID = @DoctorDepartmentID
    ORDER BY DoctorDepartmentID;
END
GO

--SELECT_ALL SP
CREATE OR ALTER PROCEDURE PR_DoctorDepartment_SelectAll
AS
BEGIN
    SELECT DoctorDepartment.DoctorDepartmentID,Doctor.Name,Department.DepartmentName,
           DoctorDepartment.Created,DoctorDepartment.Modified,[User].UserName
    FROM DoctorDepartment
    INNER JOIN Doctor ON DoctorDepartment.DoctorID = Doctor.DoctorID
    INNER JOIN Department ON DoctorDepartment.DepartmentID = Department.DepartmentID
    INNER JOIN [User] ON DoctorDepartment.UserID = [User].UserID
    ORDER BY DoctorDepartmentID;
END
GO

--DELETE SP
CREATE OR ALTER PROCEDURE PR_DoctorDepartment_DeleteByPK
    @DoctorDepartmentID INT
AS
BEGIN
    DELETE FROM DoctorDepartment
    WHERE DoctorDepartmentID = @DoctorDepartmentID;
END
GO

--INSERT SP
CREATE OR ALTER PROC PR_DoctorDepartment_Insert
    @DoctorID      INT,
    @DepartmentID  INT,
    @UserID        INT
AS
BEGIN

    INSERT INTO DoctorDepartment 
    (
        DoctorID,
        DepartmentID,
        Created,
        Modified,
        UserID
    )
    VALUES
    (
        @DoctorID,
        @DepartmentID,
        GETDATE(),
        GETDATE(),
        @UserID
    );
END;
GO

--UPDATE SP
CREATE OR ALTER PROC PR_DoctorDepartment_Update
    @DoctorDepartmentID  INT,
    @DoctorID           INT,
    @DepartmentID       INT,
    @UserID             INT
AS
BEGIN
    
    UPDATE DoctorDepartment
    SET
        DoctorID        =   @DoctorID,
        DepartmentID    =   @DepartmentID,
        Modified        =   GETDATE(),
        UserID          =   @UserID     
    
    WHERE DoctorDepartmentID = @DoctorDepartmentID;
END;
GO


--PATIENT TABLE ALL SP

--SELECT BY PK
CREATE OR ALTER PROCEDURE PR_Patient_SelectByPK
    @PatientID INT
AS
BEGIN
    SELECT 
        Patient.PatientID,
        Patient.Name,
        Patient.DateOfBirth,
        Patient.Gender,
        Patient.Email,
        Patient.Phone,
        Patient.Address,
        Patient.City,
        Patient.State,
        Patient.IsActive,
        Patient.Created,
        Patient.Modified,
        [User].UserID
    FROM Patient
    INNER JOIN [User] ON Patient.UserID = [User].UserID
    ORDER BY PatientID;
END
GO


--SELECT_ALL SP
CREATE OR ALTER PROCEDURE PR_Patient_SelectAll
AS
BEGIN
    SELECT 
        Patient.PatientID,
        Patient.Name,
        Patient.DateOfBirth,
        Patient.Gender,
        Patient.Email,
        Patient.Phone,
        Patient.Address,
        Patient.City,
        Patient.State,
        Patient.IsActive,
        Patient.Created,
        Patient.Modified,
        [User].UserName
    FROM Patient
    INNER JOIN [User] ON Patient.UserID = [User].UserID
    ORDER BY PatientID;
END
GO


--DELETE SP
CREATE OR ALTER PROCEDURE PR_Patient_DeleteByPK
    @PatientID INT
AS
BEGIN
    DELETE FROM Patient
    WHERE PatientID = @PatientID;
END
GO


-- INSERT SP
CREATE OR ALTER PROC PR_Patient_Insert
    @Name         NVARCHAR(100),
    @DateOfBirth  DATETIME,
    @Gender       NVARCHAR(10),
    @Email        NVARCHAR(100),
    @Phone        NVARCHAR(100),
    @Address      NVARCHAR(250),
    @City         NVARCHAR(100),
    @State        NVARCHAR(100),
    @IsActive     BIT = 1,
    @UserID       INT
AS
BEGIN
    INSERT INTO Patient (
        Name,
        DateOfBirth,
        Gender,
        Email,
        Phone,
        Address,
        City,
        State,
        IsActive,
        Created,
        Modified,
        UserID
    )
    VALUES (
        @Name,
        @DateOfBirth,
        @Gender,
        @Email,
        @Phone,
        @Address,
        @City,
        @State,
        @IsActive,
        GETDATE(),
        GETDATE(),
        @UserID
    );
END;
GO


--UPDATE SP
CREATE OR ALTER PROC PR_Patient_Update
    @PatientID    INT,
    @Name         NVARCHAR(100),
    @DateOfBirth  DATETIME,
    @Gender       NVARCHAR(10),
    @Email        NVARCHAR(100),
    @Phone        NVARCHAR(100),
    @Address      NVARCHAR(250),
    @City         NVARCHAR(100),
    @State        NVARCHAR(100),
    @IsActive     BIT = 1,
    @UserID       INT
AS
BEGIN
    UPDATE Patient
    SET
        Name        = @Name,
        DateOfBirth = @DateOfBirth,
        Gender      = @Gender,
        Email       = @Email,
        Phone       = @Phone,
        Address     = @Address,
        City        = @City,
        State       = @State,
        IsActive    = @IsActive,
        Modified    = GETDATE(),
        UserID      = @UserID     
    
    WHERE PatientID = @PatientID;
END;
GO

--APPOINTMENT TABLE ALL SP

--SELECT BY PK
CREATE OR ALTER PROCEDURE PR_Appointment_SelectByPK
    @AppointmentID INT
AS
BEGIN
    SELECT 
        Appointment.AppointmentID,
        Doctor.Name,
        Patient.Name,
        Appointment.AppointmentDate,
        Appointment.AppointmentStatus,
        Appointment.[Description],
        Appointment.SpecialRemarks,
        Appointment.Created,
        Appointment.Modified,
        [User].UserName,
        Appointment.TotalConsultedAmount
    FROM Appointment
    INNER JOIN Doctor ON Appointment.DoctorID = Doctor.DoctorID
    INNER JOIN Patient ON Appointment.PatientID = Patient.PatientID
    INNER JOIN [User] ON Appointment.UserID = [User].UserID
    WHERE AppointmentID = @AppointmentID
    ORDER BY AppointmentID;
END
GO


--SELECT_ALL SP
CREATE OR ALTER PROCEDURE PR_Appointment_SelectAll
AS
BEGIN
    SELECT 
        Appointment.AppointmentID,
        Doctor.Name,
        Patient.PatientName,
        Appointment.AppointmentDate,
        Appointment.AppointmentStatus,
        Appointment.[Description],
        Appointment.SpecialRemarks,
        Appointment.Created,
        Appointment.Modified,
        [User].UserName,
        Appointment.TotalConsultedAmount
    FROM Appointment
    INNER JOIN Doctor ON Appointment.DoctorID = Doctor.DoctorID
    INNER JOIN Patient ON Appointment.PatientID = Patient.PatientID
    INNER JOIN [User] ON Appointment.UserID = [User].UserID
    ORDER BY AppointmentID;
END
GO

--DELETE SP
CREATE OR ALTER PROCEDURE PR_Appointment_DeleteByPK
    @AppointmentID INT
AS
BEGIN
    DELETE FROM Appointment
    WHERE AppointmentID = @AppointmentID;
END
GO

--INSERT SP
CREATE OR ALTER PROC PR_Appointment_Insert
    @DoctorID              INT,
    @PatientID             INT,
    @AppointmentDate       DATETIME,
    @AppointmentStatus     NVARCHAR(20),
    @Description           NVARCHAR(250),
    @SpecialRemarks        NVARCHAR(100),
    @UserID                INT,
    @TotalConsultedAmount  DECIMAL(5,2) = NULL 
AS
BEGIN

    INSERT INTO Appointment (
        DoctorID,
        PatientID,
        AppointmentDate,
        AppointmentStatus,
        Description,
        SpecialRemarks,
        Created,
        Modified,
        UserID,
        TotalConsultedAmount
    )
    VALUES (
        @DoctorID,
        @PatientID,
        @AppointmentDate,
        @AppointmentStatus,
        @Description,
        @SpecialRemarks,
        GETDATE(),
        GETDATE(),
        @UserID,
        @TotalConsultedAmount
    );
END;
GO


--UPDATE SP
CREATE OR ALTER PROC PR_Appointment_Update
    @AppointmentID         INT,
    @DoctorID              INT,
    @PatientID             INT,
    @AppointmentDate       DATETIME,
    @AppointmentStatus     NVARCHAR(20),
    @Description           NVARCHAR(250),
    @SpecialRemarks        NVARCHAR(100),
    @UserID                INT,
    @TotalConsultedAmount  DECIMAL(5,2) = NULL 
AS
BEGIN
    UPDATE Appointment
    SET
        DoctorID             =  @DoctorID,
        PatientID            =  @PatientID,
        AppointmentDate      =  @AppointmentDate,
        AppointmentStatus    =  @AppointmentStatus,
        Description          =  @Description,
        SpecialRemarks       =  @SpecialRemarks,
        Modified             =  GETDATE(),
        UserID               =  @UserID,
        TotalConsultedAmount =  @TotalConsultedAmount
    
    WHERE AppointmentID = @AppointmentID;
END;
GO
 
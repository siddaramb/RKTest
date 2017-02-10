-- =============================================  
-- Author:  siddaram   
-- Create date: 10 Feb 2017
-- Description: To get student details for View Page
-- =============================================  
CREATE PROCEDURE [dbo].[uspGetStudentDetailView]
AS
BEGIN
SELECT ISNULL([RollNo], 0) AS RollNo
		,ISNULL([FirstName], '') AS FirstName
		,ISNULL([MiddleName], '') AS MiddleName
		,ISNULL([LastName], '') AS LastName
		,ISNULL([StandardID], 0) AS StandardID
		,ISNULL([AdmissionDate], '') AS AdmissionDate
		,ISNULL([MobileNO], 0) AS MobileNO
		,ISNULL([FatherName], '') AS FatherName
		,ISNULL([MotherName], '') AS MotherName
		,ISNULL(DateOfBirth, '') AS DateOfBirth
		,ISNULL([Religion], '') AS Religion
		,ISNULL([Caste], '') AS Caste
		,ISNULL([AddressLine], '') AS AddressLine
		,ISNULL([PlaceOfBirth], '') AS PlaceOfBirth
		,ISNULL([Taluk], '') AS Taluk
		,ISNULL([District], '') AS District
		,ISNULL([PinCode], 0) AS PinCode
		,ISNULL([IsKannadaMedium], 0) AS IsKannadaMedium
		,ISNULL([IsEnglishMedium], 0) AS IsEnglishMedium
		,ISNULL([BankName], '') AS BankName
		,ISNULL([AccountNumber], 0) AS AccountNumber
		,ISNULL([IFSC], '') AS IFSC
		,ISNULL([Adhar], 0) AS Adhar
	FROM tblStudent
END


USE [JobFinder]
GO

/****** Object:  StoredProcedure [dbo].[FindApplicant]    ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create Proc [dbo].[FindApplicant] @Id int
As
Begin
    Select *
    From Applicants
    where id = @id;
End;
GO


USE [JobFinder]
GO

/****** Object:  StoredProcedure [dbo].[FindApplicantResume]    ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE Proc [dbo].[FindApplicantResume] @Id int
As
Begin
    Select r.Content,
           r.Extension,
           r.FileName
    From Resume r
    Where ApplicantId = @Id;
End
GO

USE [JobFinder]
GO

/****** Object:  StoredProcedure [dbo].[FindApplicantSkill]    ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create Proc [dbo].[FindApplicantSkill]
    @SkillId int,
    @ApplicantId int
As
Begin
    Select appSkill.SkillId,
           appSkill.ApplicantId
    From ApplicantSkill appSkill
    where appSkill.ApplicantId = @ApplicantId
          and appSkill.SkillId = @SkillId;
End;
GO

USE [JobFinder]
GO

/****** Object:  StoredProcedure [dbo].[FindApplicantsWithJobs]   ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE Proc [dbo].[FindApplicantsWithJobs] @Id int
As
Begin
    select a.Id,
           a.FirstName,
           a.LastName,
           j.Id,
           j.Title,
           j.Description as JobDescription,
           c.Name,
           c.Description as CompanyDescription,
           e.id as EmployerId,
           e.FirstName + ' ' + e.LastName as EmployerName,
           aj.AppliedAt,
           aj.isReviewed
    from Applicants a
        inner join ApplicantJob aj
            on a.Id = aj.ApplicantId
        inner join Jobs j
            on j.Id = aj.ApplicantId
        inner join CompanyJob cj
            on j.Id = cj.JobId
        inner join Companies c
            on c.Id = cj.CompanyId
        inner join Employers e
            on e.CompanyId = c.Id
end;
GO

USE [JobFinder]
GO

/****** Object:  StoredProcedure [dbo].[FindApplication]    ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create Proc [dbo].[FindApplication] @Id int
AS
Begin
    select a.FirstName + ' ' + a.LastName as FullName,
           j.Title,
           j.Description,
           aj.AppliedAt,
           aj.isAccepted,
           aj.isReviewed
    from ApplicantJob aj
        inner join Applicants a
            on aj.ApplicantId = a.Id
        inner join Jobs j
            on j.Id = aj.JobId;

End;
GO

USE [JobFinder]
GO

/****** Object:  StoredProcedure [dbo].[FindCompany]    ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[FindCompany] @Filter NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT *
    FROM dbo.GetAllCompanies
    WHERE NAME COLLATE SQL_Latin1_General_CP1_CI_AS LIKE '%' + ISNULL(@Filter, '') + '%'
          OR Description COLLATE SQL_Latin1_General_CP1_CI_AS LIKE '%' + ISNULL(@Filter, '') + '%'
          OR Country COLLATE SQL_Latin1_General_CP1_CI_AS LIKE '%' + ISNULL(@Filter, '') + '%'
          OR City COLLATE SQL_Latin1_General_CP1_CI_AS LIKE '%' + ISNULL(@Filter, '') + '%'
          OR Address COLLATE SQL_Latin1_General_CP1_CI_AS LIKE '%' + ISNULL(@Filter, '') + '%'
          OR Email COLLATE SQL_Latin1_General_CP1_CI_AS LIKE '%' + ISNULL(@Filter, '') + '%';
END
GO

USE [JobFinder]
GO

/****** Object:  StoredProcedure [dbo].[FindCompanyWithJob]    ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[FindCompanyWithJob] @Filter nvarchar(20)
AS
BEGIN
    SELECT *
    FROM GetAllCompaniesWithJobs
    WHERE Name COLLATE Latin1_General_CI_AI LIKE '%' + @Filter + '%'
          OR Description COLLATE Latin1_General_CI_AI LIKE '%' + @Filter + '%'
          OR Country COLLATE Latin1_General_CI_AI LIKE '%' + @Filter + '%'
          OR City COLLATE Latin1_General_CI_AI LIKE '%' + @Filter + '%'
          OR Email COLLATE Latin1_General_CI_AI LIKE '%' + @Filter + '%'
          OR Title COLLATE Latin1_General_CI_AI LIKE '%' + @Filter + '%'
          OR JobDescription COLLATE Latin1_General_CI_AI LIKE '%' + @Filter + '%';
END
GO

USE [JobFinder]
GO

/****** Object:  StoredProcedure [dbo].[FindJob]    ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create proc [dbo].[FindJob] @Filter nvarchar(20)
As
Begin
    Select *
    from GetAllJobs
    WHERE Title COLLATE SQL_Latin1_General_CP1_CI_AS LIKE '%' + ISNULL(@Filter, '') + '%'
          OR Description COLLATE SQL_Latin1_General_CP1_CI_AS LIKE '%' + ISNULL(@Filter, '') + '%'
          OR CompanyName COLLATE SQL_Latin1_General_CP1_CI_AS LIKE '%' + ISNULL(@Filter, '') + '%'
END
GO

USE [JobFinder]
GO

/****** Object:  StoredProcedure [dbo].[FindJobToDelete]    ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create Proc [dbo].[FindJobToDelete] @Id int
AS
Begin
    Select j.id
    From Jobs j
    where j.id = @Id;
End;
GO

USE [JobFinder]
GO

/****** Object:  StoredProcedure [dbo].[FindJobToUpdate]    ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE Proc [dbo].[FindJobToUpdate] @Id int
AS
Begin
    Select j.Id,
           j.Title,
           j.Description,
           j.EmployerId
    From Jobs j
End;
GO

USE [JobFinder]
GO

/****** Object:  StoredProcedure [dbo].[FindSkill]   ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[FindSkill] @Filter NVARCHAR(MAX)
AS
BEGIN
    SELECT s.Id,
           s.Name,
           s.Description,
           s.Level
    FROM Skills s
    WHERE s.Name COLLATE Latin1_General_CI_AI LIKE '%' + @Filter + '%'
          OR s.Description COLLATE Latin1_General_CI_AI LIKE '%' + @Filter + '%';
END;

GO

USE [JobFinder]
GO

/****** Object:  StoredProcedure [dbo].[FindSkillById]    ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create Proc [dbo].[FindSkillById] @Id int
As
Begin
    Select *
    From Skills
    Where Skills.Id = @Id;
End;
GO

USE [JobFinder]
GO

/****** Object:  StoredProcedure [dbo].[GetApplicantSkill]    ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create Proc [dbo].[GetApplicantSkill] @Id int
As
Begin
    Select s.Id,
           s.Name,
           s.Description,
           s.Level
    From Skills s
        inner join ApplicantSkill AppSk
            on s.Id = AppSk.SkillId
               and ApplicantId = @Id;
End;
GO

USE [JobFinder]
GO

/****** Object:  StoredProcedure [dbo].[GetJobApplicants]    ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetJobApplicants]
    @companyId INT,
    @jobId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT C.Id AS CompanyId,
           C.Name AS CompanyName,
           J.Id AS JobId,
           J.Title,
           A.Id AS ApplicantId,
           A.FirstName,
           A.LastName
    FROM Companies C
        INNER JOIN CompanyJob CJ
            ON C.Id = CJ.CompanyId
        INNER JOIN JOBS J
            ON J.Id = CJ.JobId
        INNER JOIN ApplicantJob AJ
            ON J.Id = AJ.JobId
        INNER JOIN Applicants A
            ON A.Id = AJ.ApplicantId
    WHERE C.Id = @companyId
          AND J.Id = @jobId;
END;
GO

USE [JobFinder]
GO

/****** Object:  StoredProcedure [dbo].[GetExperience]     ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE Proc [dbo].[GetExperience] @ApplicantId int
As
Begin
    Select e.Id,
           e.Title,
           e.Company,
           e.Location,
           e.Description,
           e.StartDate,
           e.EndDate,
           e.IsCurrent
    From dbo.Experience e
    where e.Id = @ApplicantId;
End;
GO

USE [JobFinder]
GO

/****** Object:  StoredProcedure [dbo].[GetPagedJobs]     ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetPagedJobs]
    @PageSize INT,
    @PageNumber INT,
    @TitleFilter NVARCHAR(255) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    WITH OrderedJobs
    AS (SELECT Id,
               Title,
               Description,
               CompanyId,
               CompanyName,
               EmployerId,
               EmployerName,
               ROW_NUMBER() OVER (ORDER BY Id) AS RowNum
        FROM dbo.GetAllJobs
        WHERE (
                  @TitleFilter IS NULL
                  OR Title COLLATE SQL_Latin1_General_CP1_CI_AS LIKE '%' + @TitleFilter + '%'
              )
       )
    SELECT Id,
           Title,
           Description,
           CompanyId,
           CompanyName,
           EmployerId,
           EmployerName
    FROM OrderedJobs
    WHERE RowNum
    BETWEEN (@PageSize * (@PageNumber - 1) + 1) AND (@PageSize * @PageNumber);
END
GO

USE [JobFinder]
GO

/****** Object:  StoredProcedure [dbo].[GetAllSkillWithPaging]     ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[GetAllSkillWithPaging]
    @PageSize INT,
    @PageNumber INT,
    @SortColumn NVARCHAR(100) = 'Id', -- Default sorting column
    @SortOrder NVARCHAR(4) = 'ASC'    -- Default sorting order
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @OrderBy NVARCHAR(200);
    SET @OrderBy = @SortColumn + ' ' + @SortOrder;

    WITH OrderedSkills
    AS (SELECT s.Id,
               s.Name,
               s.Description,
               s.Level,
               ROW_NUMBER() OVER (ORDER BY @OrderBy) AS RowNum
        FROM dbo.Skills s
       )
    SELECT Id,
           Name,
           Description,
           Level
    FROM OrderedSkills
    WHERE RowNum
    BETWEEN (@PageSize * (@PageNumber - 1) + 1) AND (@PageSize * @PageNumber);
END
GO

USE [JobFinder]
GO

/****** Object:  StoredProcedure [dbo].[GetAllAdminsWithPaging]    Script Date: 1/10/2024 2:07:18 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetAllAdminsWithPaging]
    @PageSize INT,
    @PageNumber INT
AS
BEGIN
    SET NOCOUNT ON;

    WITH OrderedAdmins
    AS (SELECT a.id,
               CONCAT(a.firstname, ' ', a.lastname) AS AdminName,
               ROW_NUMBER() OVER (ORDER BY a.id) AS RowNum
        FROM dbo.Admins a
       )
    SELECT id,
           adminname
    FROM OrderedAdmins
    WHERE RowNum
    BETWEEN (@PageSize * (@PageNumber - 1) + 1) AND (@PageSize * @PageNumber);
END
GO


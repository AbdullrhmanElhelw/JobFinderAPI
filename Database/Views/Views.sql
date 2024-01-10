USE [JobFinder]
GO

/****** Object:  View [dbo].[GetAllApplicants]     ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create View [dbo].[GetAllApplicants]
with SchemaBinding
AS
Select a.Id,
       a.FirstName,
       a.LastName
From dbo.Applicants a;
GO


USE [JobFinder]
GO

/****** Object:  View [dbo].[GetAllCompanies]     ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[GetAllCompanies]
WITH SCHEMABINDING
AS
SELECT c.Id AS ID,
       c.Name AS Name,
       c.Description AS Description,
       u.Country AS Country,
       u.City AS City,
       u.Address AS Address,
       u.Email AS Email
FROM dbo.Companies c
    INNER JOIN dbo.AspNetUsers u
        ON u.Id = c.Id;
GO


USE [JobFinder]
GO

/****** Object:  View [dbo].[GetAllCompaniesWithJobs]     ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create View [dbo].[GetAllCompaniesWithJobs]
with SchemaBinding
As
Select c.Id,
       c.Name,
       c.Description,
       u.Country,
       u.City,
       u.Address,
       u.Email,
       j.Id as JobId,
       j.Title,
       j.Description as JobDescription,
       e.FirstName + ' ' + e.LastName as EmployerName
From dbo.AspNetUsers u
    inner join dbo.Companies c
        on c.id = u.Id
    inner join dbo.CompanyJob cj
        on c.Id = cj.CompanyId
    inner join dbo.Jobs j
        on cj.JobId = j.Id
    inner join dbo.Employers e
        on e.CompanyId = c.Id
GO

USE [JobFinder]
GO

/****** Object:  View [dbo].[GetAllJobs]     ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE view [dbo].[GetAllJobs]
with schemabinding
As
Select j.Id,
       j.Title,
       j.Description,
       c.Id as CompanyId,
       c.Name as CompanyName,
       e.Id as EmployerId,
       e.FirstName + ' ' + e.LastName as EmployerName
from dbo.Jobs j
    inner join dbo.CompanyJob cj
        on j.Id = cj.JobId
    inner join dbo.Companies c
        on cj.CompanyId = c.id
    inner join dbo.Employers e
        on c.Id = e.CompanyId
GO

USE [JobFinder]
GO

/****** Object:  View [dbo].[GetAllSkill]     ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE View [dbo].[GetAllSkill]
With SchemaBinding
AS
Select s.Id,
       s.Name,
       s.Description,
       s.Level
From dbo.Skills s

GO

USE [JobFinder]
GO

/****** Object:  View [dbo].[GetAllAdmins]    Script Date: 1/10/2024 2:11:35 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create View [dbo].[GetAllAdmins]
with SchemaBinding
AS
Select a.id,
       a.FirstName + ' ' + a.LastName as 'AdminName'
From dbo.Admins a
GO


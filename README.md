# JobFinder API

This API provides a set of endpoints for managing job-related activities, including administration, applicant, applicant skills, applications, companies, emails, jobs, resumes, skills, and various data transfer objects (DTOs).

## Key Features

### Admin Management:
- Create, login, delete, update, and partially update admin accounts.

### Applicant Management:
- Register, login, add skills, retrieve applicant skills, delete skills, update applicant information, confirm email, create experience, retrieve applicant with jobs, delete experience, and partially update applicant details.


### Application Management:
- Apply for jobs.

### Company Management:
- Create, login, get all companies, filter companies, get all companies with jobs, get job applicants, delete, update, and partially update companies.

### Email Management:
- Confirm email, send reset password email, reset password, update email, and confirm updated email.

### Job Management:
- Get jobs, filter jobs, create, delete, and update jobs.

### Resume Management:
- Create, retrieve, and delete resumes.

### Skill Management:
- Create, create multiple, update, delete skills, and get all skills.

## Endpoints

### Admin Endpoints

| HTTP Method | Endpoint                           | Description                                   |
|-------------|------------------------------------|-----------------------------------------------|
| POST        | /api/Admin/CreateAdmin              | Create a new admin                            |
| POST        | /api/Admin/Login                   | Login as an admin                             |
| POST        | /api/Admin/Logout                  | Logout an admin                              |
| GET         | /api/Admin/GetAdmin                 | Get admin details                            |
| GET         | /api/Admin/GetAllAdmins             | Get all admins                               |
| GET         | /api/Admin/GetAllAdminsWithPaging   | Get all admins with paging                    |
| DELETE      | /api/Admin/DeleteAdmin             | Delete an admin                               |
| PUT         | /api/Admin/UpdateAdmin             | Update admin details                          |
| PATCH       | /api/Admin/PartialUpdateAdmin      | Partially update admin details               |

### Applicant Endpoints

| HTTP Method | Endpoint                           | Description                                   |
|-------------|------------------------------------|-----------------------------------------------|
| POST        | /api/Applicant/Register            | Register a new applicant                      |
| POST        | /api/Applicant/Login               | Login as an applicant                         |
| POST        | /api/Applicant/AddSkill            | Add a skill to an applicant                   |
| POST        | /api/Applicant/CreateExperience    | Create work experience for an applicant      |
| GET         | /api/Applicant/ApplicantSkills/{id}| Retrieve skills of an applicant               |
| GET         | /api/Applicant/ApplicantWithJobs/{id}| Retrieve applicant details with jobs       |
| GET         | /api/Applicant/GetAllApplicants    | Get all applicants                            |
| DELETE      | /api/Applicant/DeleteSkill/{applicantId}/{skillId}| Delete a skill of an applicant       |
| DELETE      | /api/Applicant/Delete/{applicantId}/{experienceId}| Delete work experience of an applicant |
| PUT         | /api/Applicant/UpdateApplicant/{id}| Update applicant details                     |
| PUT         | /api/Applicant/UpdateExperience/{applicantId}/{experienceId}| Update work experience details |
| PATCH       | /api/Applicant/PartialUpdateApplicant| Partially update applicant details          |

### Application Endpoints

| HTTP Method | Endpoint                           | Description                                   |
|-------------|------------------------------------|-----------------------------------------------|
| POST        | /api/Application/ApplyJob          | Apply for a job                               |

### Company Endpoints

| HTTP Method | Endpoint                           | Description                                   |
|-------------|------------------------------------|-----------------------------------------------|
| POST        | /api/Company/register              | Create a new company                          |
| POST        | /api/Company/login                 | Login as a company                            |
| GET         | /api/Company/GetAll                | Get all companies                             |
| GET         | /api/Company/GetAll/{filter}        | Get filtered companies                        |
| GET         | /api/Company/GetAllWithJobs         | Get all companies with jobs                   |
| GET         | /api/Company/GetJobApplicants/{companyId}/{jobId}| Get job applicants for a company   |
| DELETE      | /api/Company/{id}                  | Delete a company                              |
| PUT         | /api/Company/Update/{Id}           | Update company details                       |
| PATCH       | /api/Company/PartialUpdate/{Email} | Partially update company details             |

### Email Endpoints

| HTTP Method | Endpoint                           | Description                                   |
|-------------|------------------------------------|-----------------------------------------------|
| POST        | /api/Email/ConfirmEmail            | Confirm email                                 |
| POST        | /api/Email/SendResetPasswordEmail  | Send reset password email                     |
| POST        | /api/Email/ResetPassword           | Reset password                               |
| PUT         | /api/Email/UpdateEmail             | Update email                                 |
| POST        | /api/Email/ConfirmUpdateEmail      | Confirm updated email                        |

### Employer Endpoints

| HTTP Method | Endpoint                           | Description                                   |
|-------------|------------------------------------|-----------------------------------------------|
| POST        | /api/Employer/Register              | Register a new employer                       |
| POST        | /api/Employer/Login                 | Login as an employer                          |
| GET         | /api/Employer/Get/{id}              | Get employer details                         |
| DELETE      | /api/Employer/Delete/{id}           | Delete an employer                            |

### Job Endpoints

| HTTP Method | Endpoint                           | Description                                   |
|-------------|------------------------------------|-----------------------------------------------|
| GET         | /api/Job                           | Get all jobs                                  |
| GET         | /api/Job/GetAllWithPagination       | Get all jobs with pagination                  |
| GET         | /api/Job/{filter}                   | Filter jobs                                   |
| POST        | /api/Job/Create                    | Create a new job                              |
| DELETE      | /api/Job/Delete/{jobId}            | Delete a job                                  |
| PUT         | /api/Job/Update                    | Update job details                            |
| PATCH       | /api/Job/PartialUpdate/{id}         | Partially update job details                 |

### Resume Endpoints

| HTTP Method | Endpoint                           | Description                                   |
|-------------|------------------------------------|-----------------------------------------------|
| POST        | /api/Resume                        | Create a new resume                           |
| GET         | /api/Resume/{id}                   | Get a resume by ID                            |
| DELETE      | /api/Resume/{applicantId}/{ResumeId}| Delete a resume                               |

### Skill Endpoints

| HTTP Method | Endpoint                           | Description                                   |
|-------------|------------------------------------|-----------------------------------------------|
| GET         | /api/Skill/GetAll                  | Get all skills                                |
| GET         | /api/Skill/{id}                    | Get a skill by ID                             |
| PUT         | /api/Skill/{id}                    | Update a skill                                |
| DELETE      | /api/Skill/{id}                    | Delete a skill                                |
| GET         | /api/Skill/{filter}                | Filter skills                                |
| GET         | /api/Skill/GetAll/{pageSize}/{pageNumber}| Get all skills with pagination            |
| POST        | /api/Skill                         | Create a new skill                            |
| POST        | /api/Skill/multiple                | Create multiple skills                        |
| PATCH       | /api/Skill/partial-update/{id}     | Partially update a skill                     |

## Tools and Concepts

This project utilizes the following tools and concepts:

- **.Net 8:** The project is developed using the .Net 8 framework, providing a robust and feature-rich development environment.

- **EF-Core For Database Command:** Using EF-Core For Commands Only Like ( Create, Update, Delete ) .

- **Dapper For Database Queries:** Using Dapper for Querying as it is a micro ORM and is really fast.

- **JWT (JSON Web Tokens):** JSON Web Tokens are employed for secure and efficient authentication and authorization processes.

- **CQRS With Mediator:** The project adopts the Command Query Responsibility Segregation (CQRS) pattern with Mediator for managing and separating command and query responsibilities, promoting a cleaner and more scalable architecture.

- **UnitOfWork:** Unit of Work pattern is implemented to manage transactions and ensure data consistency across multiple database operations.

- **Repository Pattern:** The repository pattern is utilized for abstracting data access and providing a consistent interface for interacting with the underlying data storage.

- **Outlook SMTP Server:** supports sending emails using the Outlook SMTP server
- **Built Completely in Clean Architecture:** The project is structured following the Clean Architecture principles, promoting separation of concerns, maintainability, and testability.



## Swagger Documentation

- **Job Finder API v1**
  - [OAS3 Documentation](https://app.swaggerhub.com/apis-docs/ELHELW258/job-finder_api/v1#/)
  - Authorize as Admin

## Bump.sh Documentation

- **Job Finder API v1**
  - [Documentation](https://bump.sh/abdullrhmanelhelw/hub/eng-cocu-hub/doc/job-finder-api)
  - Authorize as Admin


using Microsoft.AspNetCore.Http;

namespace Application.DTOs.ResumeDTO;

public record UploadResumeDTO
    (int ApplicantId, IFormFile Resume);
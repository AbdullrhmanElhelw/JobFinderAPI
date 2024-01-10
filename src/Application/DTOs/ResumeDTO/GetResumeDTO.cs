namespace Application.DTOs.ResumeDTO;

public record GetResumeDTO
    (byte[] Content, string Extension, string FileName);
namespace Application.Features.Queries.ResumeQueries.GetResume;

public record GetResumeResponse
    (byte[] Content, string Extension, string FileName);

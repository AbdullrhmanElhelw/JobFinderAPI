using Microsoft.AspNetCore.JsonPatch;

namespace Application.DTOs.ApplicantDTOs;

public record PartialUpdateApplicantDTO
    (string Email, JsonPatchDocument ApplicantPD);
using Application.DTOs.ResumeDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Presentation.Filters;

public class ResumeValidatorAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (context.ActionArguments.ContainsKey("resume"))
        {
            var resumeFile = context.ActionArguments["resume"] as UploadResumeDTO;
            if (resumeFile != null)
            {
                if (!IsResumeValid(resumeFile.Resume))
                {
                    context.ModelState.AddModelError("Resume", "Invalid file type");
                    context.Result = new BadRequestObjectResult(context.ModelState);
                }
            }
        }
    }

    private static bool IsResumeValid(IFormFile resume)
    {
        var allowedExtensions = new[] { ".doc", ".docx", ".pdf" };
        var extension = Path.GetExtension(resume.FileName);
        return allowedExtensions.Contains(extension);
    }
}
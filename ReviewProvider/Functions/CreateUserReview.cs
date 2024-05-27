using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ReviewProvider.Data.Contexts;
using ReviewProvider.Data.Entities;
using ReviewProvider.Factories;
using ReviewProvider.Models;
using ReviewProvider.Services;

namespace ReviewProvider.Functions;

public class CreateUserReview
{
    private readonly ILogger<CreateUserReview> _logger;
    private readonly ICreateUserReviewService _createUserReviewService;

    public CreateUserReview(ILogger<CreateUserReview> logger, ICreateUserReviewService createUserReviewService)
    {
        _logger = logger;
        _createUserReviewService = createUserReviewService;
    }

    [Function("CreateUserReview")]
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequest req)
    {
        try
        {
            var urr = await _createUserReviewService.UnpackUserReviewRequest(req);
            if (urr != null)
            {
                var exists = await _createUserReviewService.UserExists(urr.Email, urr.ProductId);
                if(exists != true)
                {
                    var result = await _createUserReviewService.SaveUserReviewRequest(urr);
                    if (result)
                    {
                        return new OkResult();
                    }
                }
                else
                {
                    return new ConflictResult();
                }
            } 
        }
        catch (Exception ex)
        {
            _logger.LogError($"ERROR : CreateUserReview.Run() :: {ex.Message}");
        }
        return new BadRequestResult();
    }

    
}

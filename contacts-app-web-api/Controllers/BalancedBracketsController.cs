using ContactsApplication.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactsApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BalancedBracketsController : ControllerBase
    {
        private readonly BalancedBracketsService _balancedBracketsService;

        public BalancedBracketsController(BalancedBracketsService balancedBracketsService)
        {
            _balancedBracketsService = balancedBracketsService;
        }

        [HttpGet("check-balanced-brackets")]
        public IActionResult GetAll(string? searchInput = null)
        {
            var isBalanced = _balancedBracketsService.Check(searchInput);
            return Ok(isBalanced);
        }

    }
}

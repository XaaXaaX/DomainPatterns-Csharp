using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Specification.Domain.Entities;

namespace Specification.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StaffController : ControllerBase
    {
        private readonly ILogger<StaffController> _logger;
        private readonly StaffValidator validator = new StaffValidator();
        public StaffController(ILogger<StaffController> logger)=>  _logger = logger;
        

        [HttpPost]
        public bool Add(StaffCommand command)
        {
            Staff staff = command;

            return true;
        }

        [HttpPut]
        public bool AddOrUpdate(StaffCommand command)
        {
            this.validator.Validate(command);
            return true;
        }
    }
}

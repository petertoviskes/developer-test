﻿using Microsoft.AspNetCore.Mvc;
using Taxually.TechnicalTest.Model;
using Taxually.TechnicalTest.RegistrationHandlers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taxually.TechnicalTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VatRegistrationController : ControllerBase
    {
        private readonly IVatRegistrationHandlerFactory registrationHandlerFactory;

        public VatRegistrationController(IVatRegistrationHandlerFactory registrationHandlerFactory)
        {
            this.registrationHandlerFactory = registrationHandlerFactory;
        }

        /// <summary>
        /// Registers a company for a VAT number in a given country
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] VatRegistrationRequest request)
        {
            var registrationHandler = registrationHandlerFactory.CreateHandler(request.Country);
            await registrationHandler.Register(request);

            return Ok();
        }
    }
}

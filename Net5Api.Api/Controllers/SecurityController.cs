using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Net5Api.Api.Responses;
using Net5Api.Core.DTOs;
using Net5Api.Core.Entities;
using Net5Api.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net5Api.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly ISecurityService _securityService;
        private readonly IMapper _mapper;
        public SecurityController(ISecurityService securityService, IMapper mapper)
        {
            _securityService = securityService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post(SecurityDTO securityDTO) {

            var security = _mapper.Map<Security>(securityDTO);

            await _securityService.RegisterUser(security);

            var response = new ApiResponse<SecurityDTO>(securityDTO);

            return Ok(response);
        }
    }
}

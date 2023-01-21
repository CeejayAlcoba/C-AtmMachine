using AtmMachine.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtmMachine.Controllers
{
    [Route("api/action")]
    [ApiController]
    public class ActionController : ControllerBase
    {
        IActionService _actionService;
        public ActionController(IActionService actionService)
        {
            _actionService = actionService;
        }
        [HttpPost]
        [Route("deposit/{userId}/{money}")]
        public IActionResult Deposit([FromRoute] int userId, float money)
        {
            try
            {
                var deposit = _actionService.Deposit(userId, money);
                return Ok(deposit);
            }
            catch
            {
                return BadRequest();
            }
            
        }
        [HttpPost]
        [Route("withdraw/{userId}/{money}")]
        public IActionResult Withdraw([FromRoute] int userId, float money)
        {
            try
            {
                var withdaw = _actionService.Withdraw(userId, money);
                if (withdaw != null)
                    return Ok(withdaw);
                else
                    return BadRequest();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("check-balance/{userId}")]
        public IActionResult CheckBalance([FromRoute] int userId)
        {
            try
            {
                var balance = _actionService.CheckBalance(userId);
                return Ok(balance);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}

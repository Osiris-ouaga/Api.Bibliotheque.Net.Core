﻿using Api.Bibiliotheque.Core.Net.Interfaces;
using Api.Bibiliotheque.Core.Net.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Bibiliotheque.Core.Net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]    
    public class UserController : ControllerBase
    {

        private readonly IUserService _service;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService service, ILogger<UserController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<Models.UserModel>>> Get(CancellationToken cancel)
        {
            _logger.LogWarning("DEBUT DE LONGUE ATTENTE");

            // simule une attente longue de 10 secondes
            //for (int i = 0; i < 10; i++)
            //{
            //    _logger.LogWarning($"JE PASSE POUR LE {i}");
            //    cancel.ThrowIfCancellationRequested();
            //    Thread.Sleep(1000);
            //}

            //await Task.Delay(10000,cancel);//simule une attente longue de 10 secondes
            var result = await _service.GetUsers(cancel);
            _logger.LogWarning("FIN DE LONGUE ATTENTE");
            return Ok(result);
        }

        [HttpGet("{id}")]        
        public async Task<ActionResult<Models.UserModel>> Get(int id)
        {
            var result = await _service.GetUser(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Models.UserModel>> Post(UserModel user)
        {
            var result = await _service.AddUser(user);
            return CreatedAtAction("Post", result);
        }

        [HttpPut]
        public async Task<ActionResult<Models.UserModel>> Put(int id, UserModel user)
        {
            var result = await _service.UpdateUser(id, user);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult<Models.UserModel>> Delete(int id)
        {
            var result = await _service.DeleteUser(id);
            return Ok(result);
        }


    }
}

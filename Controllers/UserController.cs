using dotnetCrud.Models;
using dotnetCrud.Repository;
using dotnetCrud.Services;
using Microsoft.AspNetCore.Mvc;

namespace dotnetCrud.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserRepository repository, IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userService.GetUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetUserById(id);
            return user != null ? Ok(user) : NotFound($"Nenhum usuário encontrado para o id recebido. Id recebido: {id}");
        }

        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            return await _userService.CreateUser(user) ? Ok("Usuário adicionado com sucesso.") : BadRequest("Erro ao adicionar usuário.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, User user)
        {
            return await _userService.UpdateUser(id, user) ? Ok($"Usuário de id {id} atualizado com sucesso.") : BadRequest("Erro ao atualizar usuário.");

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return await _userService.DeleteUser(id) ? Ok($"Usuário de id {id} deletado com sucesso.") : BadRequest("Erro ao deletar usuário.");
        }
    }
}
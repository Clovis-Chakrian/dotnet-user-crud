using dotnetCrud.Models;
using dotnetCrud.Repository;
using Microsoft.AspNetCore.Mvc;

namespace dotnetCrud.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _repository.SearchUsers();
            return users.Any() ? Ok(users) : NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _repository.SearchUser(id);
            return user != null ? Ok(user) : NotFound($"Nenhum usuário encontrado para o id recebido. Id recebido: {id}");
        }

        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            _repository.AddUser(user);
            return await _repository.SaveChangesAsync() ? Ok("Usuário adicionado com sucesso.") : BadRequest("Erro ao adicionar usuário.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, User user)
        {
            var bdUser = await _repository.SearchUser(id);
            if (bdUser == null) return NotFound($"Usuário de {id} não foi encontrado!");

            bdUser.Name = user.Name ?? bdUser.Name;
            bdUser.BirthDate = user.BirthDate != new DateTime() ? user.BirthDate : bdUser.BirthDate;

            _repository.UpdateUser(bdUser);
            return await _repository.SaveChangesAsync() ? Ok($"Usuário de id {id} atualizado com sucesso.") : BadRequest("Erro ao atualizar usuário.");

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var bdUser = await _repository.SearchUser(id);
            if (bdUser == null) return NotFound($"Usuário de {id} não foi encontrado!");

            _repository.DeleteUser(bdUser);
            return await _repository.SaveChangesAsync() ? Ok($"Usuário de id {id} deletado com sucesso.") : BadRequest("Erro ao deletar usuário.");
        }
    }
}
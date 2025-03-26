using eCommerce.API.Repositories;
using eCommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuariosController(IUsuarioRepository repository)
        {
            _usuarioRepository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var listaDeUsuarios = _usuarioRepository.Get();

            return Ok(listaDeUsuarios);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var usuario = _usuarioRepository.Get(id);

            if (usuario == null)
                return NotFound("usuario nao encontrado");

            return Ok(usuario);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Usuario usuario)
        {
            _usuarioRepository.Add(usuario);

            return Ok(usuario);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] Usuario usuario, int id)
        {
            _usuarioRepository.Update(usuario);

            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _usuarioRepository.Delete(id);
            return Ok();
        }



    }
}

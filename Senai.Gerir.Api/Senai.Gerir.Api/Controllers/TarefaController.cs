using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Senai.Gerir.Api.Dominios;
using Senai.Gerir.Api.Interfaces;
using Senai.Gerir.Api.Repositorios;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
namespace Senai.Gerir.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaRepositorio _tarefaRepositorio;

        public TarefaController()
        {
            _tarefaRepositorio = new TarefaRepositorio();
        }

        [Authorize]
        [HttpPost]
        //retorno     nome do endpoint    (parâmetro)
        public IActionResult Cadastrar(Tarefa tarefa)
        {
            try
            {
                _tarefaRepositorio.Cadastrar(tarefa);


                return Ok(tarefa);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [Authorize]
        [HttpPut]
        public IActionResult Editar(Tarefa tarefa)
        {
            try
            {
               

                //Altera a tarefa
                _tarefaRepositorio.Editar(tarefa);
                return Ok(tarefa);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Remover(Guid id)
        {
            try
            {
                _tarefaRepositorio.Remover(id);

                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                //Pegar as informações das claims referente ao usuario
                var claimsUsuario = HttpContext.User.Claims;


                //Pegar o id do usuário na Claim Jti / formato string
                var usuarioid = claimsUsuario.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Jti);

                //Converção para Guid
                Guid UsuarioIdGuid = new Guid(usuarioid.Value);

                //Caso exista retorna Ok e os produtos
                return Ok(_tarefaRepositorio.ListarTodos(UsuarioIdGuid));
            }
            catch (Exception ex)
            {
                //Caso ocorra agum erro retorna BadResquest e a mesnagem de erro
                return BadRequest(ex.Message);
            }
        }

    }
}

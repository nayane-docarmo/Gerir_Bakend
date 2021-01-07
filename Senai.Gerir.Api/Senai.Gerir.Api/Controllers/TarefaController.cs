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
                //Pega o valor do usuario que esta logado 
                var usuarioid = HttpContext.User.Claims.FirstOrDefault(
                                c => c.Type == JwtRegisteredClaimNames.Jti
                    );
                //Atribui o usuario a tarefa
                tarefa.UsuarioId = new System.Guid(usuarioid.Value);

                //Cadastra a tarefa
                _tarefaRepositorio.Cadastrar(tarefa);
                return Ok(tarefa);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [Authorize]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(Guid id)
        {
            try
            {

                //Pega o valor do usuário que esta logado
                var usuarioid = HttpContext.User.Claims.FirstOrDefault(
                                c => c.Type == JwtRegisteredClaimNames.Jti
                            );

                //Busca uma tarefa pelo seu Id
                var tarefa = _tarefaRepositorio.BuscarPorId(id);

                //Verifica se a tarefa existe
                if (tarefa == null)
                    return NotFound();

                //Verifica se a tarefa é do usuário logado
                if (tarefa.UsuarioId != new Guid(usuarioid.Value))
                    return Unauthorized("Usuário não tem permissão");

                return Ok(tarefa);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }


        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Remover(Guid id)
        {
            try
            {

                //Pega o valor do usuário que esta logado
                var usuarioid = HttpContext.User.Claims.FirstOrDefault(
                                c => c.Type == JwtRegisteredClaimNames.Jti
                            );

                //Busca uma tarefa pelo seu Id
                var tarefa = _tarefaRepositorio.BuscarPorId(id);

                //Verifica se a tarefa existe
                if (tarefa == null)
                    return NotFound();

                //Verifica se a tarefa é do usuário logado
                if (tarefa.UsuarioId != new Guid(usuarioid.Value))
                    return Unauthorized("Usuário não tem permissão");

                _tarefaRepositorio.Remover(id);

                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [Authorize]
        [HttpPut]
        public IActionResult Editar(Guid id, Tarefa tarefa)
        {
            try
            {

                //Pega o valor do usuário que esta logado
                var usuarioid = HttpContext.User.Claims.FirstOrDefault(
                                c => c.Type == JwtRegisteredClaimNames.Jti
                            );

                //Busca uma tarefa pelo seu Id
                var tarefaexiste = _tarefaRepositorio.BuscarPorId(id);

                //Verifica se a tarefa existe
                if (tarefaexiste == null)
                    return NotFound();

                //Verifica se a tarefa é do usuário logado
                if (tarefaexiste.UsuarioId != new Guid(usuarioid.Value))
                    return Unauthorized("Usuário não tem permissão");

                //Altera a tarefa
                tarefa.Id = id;
                _tarefaRepositorio.Editar(tarefa);
                return Ok(tarefa);
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
                //passo a passo
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

            //Outro meio mais pratico
            //Pega o valor do usuário que esta logado
            //var usuarioid = HttpContext.User.Claims.FirstOrDefault( c => c.Type == JwtRegisteredClaimNames.Jti  );
            //r tarefas = _tarefaRepositorio.Listar( new System.Guid(usuarioid.Value));
            // return Ok(tarefas);
        }
        [Authorize]
        //api/tarefa/status/idTarefa
        [HttpPut("status/{id}")]
        public IActionResult AlterarStatus(Guid id)
        {
            try
            {
                //Pega o valor do usuário que esta logado
                var usuarioid = HttpContext.User.Claims.FirstOrDefault(
                                c => c.Type == JwtRegisteredClaimNames.Jti
                            );

                //Busca uma tarefa pelo seu Id
                var tarefa = _tarefaRepositorio.BuscarPorId(id);

                //Verifica se a tarefa existe
                if (tarefa == null)
                    return NotFound();

                //Verifica se a tarefa é do usuário logado
                if (tarefa.UsuarioId != new Guid(usuarioid.Value))
                    return Unauthorized("Usuário não tem permissão");

                _tarefaRepositorio.AlterarStatus(id);

                return Ok(tarefa);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Senai.Gerir.Api.Contextos;
using Senai.Gerir.Api.Dominios;
using Senai.Gerir.Api.Interfaces;

namespace Senai.Gerir.Api.Repositorios
{
    //Herdar IUsuarioRepositorio
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        //criar um contexto
        private readonly GerirContext _context;

        public UsuarioRepositorio()

        {
            _context = new GerirContext();
        }

        public Usuario BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Usuario Cadastrar(Usuario usuario)
        {
            //Crio um try catch
            try
            {
                //Cadastrar um usuário
                //pego o context, na tabela de usuários e Add um usuário
                _context.Usuarios.Add(usuario);
                //Salvar o usuário no BD - salva as alterações do contexto
                _context.SaveChanges();
                //retornar um usuario
                return usuario;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Usuario Editar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Usuario Logar(string email, string senha)
        {
            try
            {
                var usuario = _context.Usuarios.FirstOrDefault(c => c.Email == email && c.Senha == senha);
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

            throw new NotImplementedException();
        }

        public void Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
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
            try
            {
                //Buscar o usuario pelo seu Id usando o find
                var usuario = _context.Usuarios.Find(id);

                return usuario;

            }
            catch (Exception ex)
            {

                throw new NotImplementedException();
            }
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
            try
            {
                //Buscar o usuário no banco
                var usuarioexiste = BuscarPorId(usuario.Id);

                //Verificar se o usuário existe
                if (usuarioexiste == null)
                    throw new Exception("Usuário não encontrado");

               //Alterar os valores do usuário
                usuarioexiste.Nome = usuario.Nome;
                usuarioexiste.Email = usuario.Email;

                if (!string.IsNullOrEmpty(usuario.Senha))
                    usuarioexiste.Senha = usuario.Senha;

                _context.Usuarios.Update(usuarioexiste);
                _context.SaveChanges();

                return usuarioexiste;
            }
            catch (Exception ex)
            {

                throw new NotImplementedException();
            }
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
            try
            {
                var usuario = BuscarPorId(id);

                _context.Usuarios.Remove(usuario);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
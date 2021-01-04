using Senai.Gerir.Api.Dominios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gerir.Api.Interfaces
{
    public interface IUsuarioRepositorioe
    {

        /// <summary>
        /// Cadasra um novo usuário
        /// </summary>
        /// <param name="usuario">Contém os dados do usuário</param>
        /// <returns>Retorna o usuário cadastrado</returns>
        Usuario Cadastrar(Usuario usuario);

        /// <summary>
        /// Loga o usuário no sistema
        /// </summary>
        /// <param name="email">Email do usuário</param>
        /// <param name="senha">Senha do usuário</param>
        /// <returns>Retorna o usuário caso encontre</returns>
        Usuario Logar(string email, string senha);

        /// <summary>
        /// Edita um us~uário
        /// </summary>
        /// <param name="usuario">Contém os dados do usuário</param>
        /// <returns></returns>
        Usuario Editar(Usuario usuario);

        /// <summary>
        /// Remove um usuário
        /// </summary>
        /// <param name="Id">Id do usuário</param>
        void Remover(Guid Id);

        /// <summary>
        /// Busca o usuário pelo Id
        /// </summary>
        /// <param name="id">Id do usuário</param>
        /// <returns>Retorna as informações do usuário</returns>
        Usuario BuscarPorId(Guid id);
    }
}

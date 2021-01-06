using Senai.Gerir.Api.Dominios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gerir.Api.Interfaces
{
    public interface ITarefaRepositorio
    {
        /// <summary>
        /// Cadastrar uma atividade
        /// </summary>
        /// <param name="tarefa">Contém os dados da tarefa</param>
        /// <returns>Tarefa cadastrada</returns>
        Tarefa Cadastrar(Tarefa tarefa);
        /// <summary>
        /// LIsta de tarefas do usuário
        /// </summary>
        /// <param name="IdUsuario">Id do Usuário</param>
        /// <returns>Lista de todas tarefas do usuário</returns>
        List<Tarefa> ListarTodos(Guid IdUsuario);
        /// <summary>
        /// Alterar status da tarefa
        /// </summary>
        /// <param name="Id">Id daTarefa</param>
        /// <returns>O satus da tarefa alterada</returns>
        Tarefa AlterarStatus(Guid Id);
        /// <summary>
        /// Remover uma tarefa
        /// </summary>
        /// <param name="Id">Id da Tarefa</param>
        void Remover(Guid Id);
        /// <summary>
        /// Edita a Tarefa
        /// </summary>
        /// <param name="tarefa">Contém os dados da tarefa</param>
        /// <returns>Tarefa Editada</returns>
        Tarefa Editar(Tarefa tarefa);
        /// <summary>
        /// Buscar a tarefa pelo Id
        /// </summary>
        /// <param name="Id">Id da Tarefa</param>
        /// <returns>Retornar as informações da Tarefa</returns>
        Tarefa BuscarPorId(Guid Id);

    }
}

using Senai.Gerir.Api.Contextos;
using Senai.Gerir.Api.Dominios;
using Senai.Gerir.Api.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gerir.Api.Repositorios
{
    //Herdar ITarefasReponsitorio 
    public class TarefaRepositorio : ITarefaRepositorio
    {
        //Criar um contexto
        private readonly GerirContext _context;

        public TarefaRepositorio()
        {
            _context = new GerirContext();
        }

        public Tarefa Cadastrar(Tarefa tarefa)
        {
            //Crio um try catch
            try
            {
                //Cadastrar uma Tarefa
                //pego o context, na tabela de tarefa e Add uma tarefa
                _context.Tarefas.Add(tarefa);
                //Salvar a tarefa no BD - salva as alterações do contexto
                _context.SaveChanges();
                //retornar uma tarefa
                return tarefa;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Tarefa BuscarPorId(Guid id)
        {
            try
            {
                //Buscar a Tarefa pelo seu Id usando o find
                var tarefa = _context.Tarefas.Find(id);

                return tarefa;

            }
            catch (Exception ex)
            {

                throw new NotImplementedException();
            }
        }

        public void Remover(Guid id)
        {
            try
            {
                var tarefa = BuscarPorId(id);

                _context.Tarefas.Remove(tarefa);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Tarefa Editar(Tarefa tarefa)
        {
            try
            {
                //Buscar a tarefa no banco
                var tarefaexiste = BuscarPorId(tarefa.Id);

                //Verificar se a tarefa existe
                if (tarefaexiste == null)
                    throw new Exception("Tarefa não encontrada");

                //Alterar os valores da tarefa
                tarefaexiste.Titulo = tarefa.Titulo;
                tarefaexiste.Descricao = tarefa.Descricao;

                _context.Tarefas.Update(tarefaexiste);
                _context.SaveChanges();

                return tarefaexiste;
            }
            catch (Exception ex)
            {

                throw new NotImplementedException();
            }
        }

        public Tarefa AlterarStatus (Guid Id)
        {
            try
            {
                //Buscar a tarefa no banco
                var tarefaexiste = BuscarPorId(Id);

                //Verificar se a tarefa existe
                if (tarefaexiste == null)
                    throw new Exception("Tarefa não encontrada");

                //Alterar os valores da tarefa

                if (tarefaexiste.Status == false)
                    tarefaexiste.Status = true;
                else
                {
                    tarefaexiste.Status = false;
                }

                //Outra forma de utilizar o bool 
                //por o valor oposto dele mesmo, ou seja, está true automaticamente vira false;vice-versa 
               // tarefaexiste.Status = !tarefaexiste.Status;


                _context.Tarefas.Update(tarefaexiste);
                _context.SaveChanges();

                return tarefaexiste;
            }
            catch (Exception ex)
            {

                throw new NotImplementedException();
            }
        }

        public List<Tarefa> ListarTodos(Guid IdUsuario)
        {
            try
            {
                //Selecionar os itens do banco de dado
                var listaTarefa = _context.Tarefas.Where(c => c.UsuarioId == IdUsuario);

                //Converção para lista 
                return (List<Tarefa>)listaTarefa;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


    }
}

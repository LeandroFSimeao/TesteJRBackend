using apiToDo.Models;
using apiToDo.Repository.Interface;
using System.Collections.Generic;
using System.Linq;

namespace apiToDo.Repository
{
    public class TarefasRepository : ITarefasRepository
    {
        public TarefasRepository()
        {

        }

        private static List<TarefasModel> lstTarefas = new()
        {
            new TarefasModel
            {
                IdTarefa = 1,
                DsTarefa = "Fazer Compras"
            },
            new TarefasModel
            {
                IdTarefa = 2,
                DsTarefa = "Fazer Atividade Faculdade"
            },
            new TarefasModel
            {
                IdTarefa = 3,
                DsTarefa = "Subir Projeto de Teste no GitHub"
            }
        };

        public List<TarefasModel> ObterTarefas()
        {
            return lstTarefas;
        }

        public TarefasModel ObterTarefaPorId(int idTarefa)
        {
            TarefasModel tarefa = lstTarefas.Where(x => x.IdTarefa == idTarefa).FirstOrDefault();
            return tarefa;
        }

        public void InserirTarefa(string tarefa)
        {
            List<int> idTarefas = lstTarefas.Select(x => x.IdTarefa).ToList();
            lstTarefas.Add(new TarefasModel { IdTarefa = idTarefas.Max() + 1, DsTarefa = tarefa });
        }

        public void DeletarTarefa(int id)
        {
            TarefasModel tarefa = lstTarefas.Where(x => x.IdTarefa == id).FirstOrDefault();
            lstTarefas.Remove(tarefa);
        }

        public void AtualizarTarefa(TarefasModel tarefas)
        {
            TarefasModel tarefa = lstTarefas.Where(x => x.IdTarefa == tarefas.IdTarefa).FirstOrDefault();
            tarefa.DsTarefa = tarefas.DsTarefa;
        }
    }
}

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

        //Foi utilizado estrutura lambda no repository para simular uma query usando EntityFramework

        //Refataroção adicionando os dados direto na inicialização da lista de tarefas
        //Aplicação de clean code
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
            //Fazendo um filtro na lista de tarefas pelo idTarefa
            TarefasModel tarefa = lstTarefas.Where(x => x.IdTarefa == idTarefa).FirstOrDefault();
            return tarefa;
        }

        public void InserirTarefa(string tarefa)
        {
            //Obtendo a lista de Id já existente no objeto lstTarefas
            List<int> idTarefas = lstTarefas.Select(x => x.IdTarefa).ToList();
            //Adicionando à tarefas o novo item com base no novo id onde a regra é: maior número já existente + 1
            lstTarefas.Add(new TarefasModel { IdTarefa = idTarefas.Max() + 1, DsTarefa = tarefa });
        }

        public void DeletarTarefa(int id)
        {
            //Percorre a lista procurando a tarefa pelo id
            TarefasModel tarefa = lstTarefas.Where(x => x.IdTarefa == id).FirstOrDefault();
            //Caso encontre o id o mesmo remove o objeto da lista
            lstTarefas.Remove(tarefa);
        }

        public void AtualizarTarefa(TarefasModel tarefas)
        {
            //Percorre a lista de tarefas, caso encontre ele faz a alteração na lista de tarefas
            TarefasModel tarefa = lstTarefas.Where(x => x.IdTarefa == tarefas.IdTarefa).FirstOrDefault();
            tarefa.DsTarefa = tarefas.DsTarefa;
        }
    }
}

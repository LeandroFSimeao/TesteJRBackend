using apiToDo.Models;
using System.Collections.Generic;

namespace apiToDo.Repository.Interface
{
    public interface ITarefasRepository
    {
        public List<TarefasModel> ObterTarefas();
        public void InserirTarefa(string tarefa);
        public void DeletarTarefa(int idTarefa);
        public void AtualizarTarefa(TarefasModel tarefas);
        public TarefasModel ObterTarefaPorId(int idTarefa);

    }
}

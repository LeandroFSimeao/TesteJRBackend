using apiToDo.Models;
using System.Collections.Generic;

namespace apiToDo.Services.Interface
{
    public interface ITarefasService
    {
        public IList<TarefasModel> ObterTarefas();
        public void InserirTarefa(string tarefa);
        public void DeletarTarefa(int idTarefa);
        public void AtualizaTarefa(TarefasModel request);
        public TarefasModel RecuperaTarefaPorId(int idTarefa);

    }
}

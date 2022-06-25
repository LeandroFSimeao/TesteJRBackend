using apiToDo.Models;
using System.Collections.Generic;

namespace apiToDo.Services.Interface
{
    public interface ITarefasService
    {
        //Criação da interface do service para mapeamento da injeção de dependência e definições de scope da classe
        //Utilização do padrão Camel case para paremetros de métodos
        public IList<TarefasModel> ObterTarefas();
        public void InserirTarefa(string tarefa);
        public void DeletarTarefa(int idTarefa);
        public void AtualizaTarefa(TarefasModel request);
        public TarefasModel RecuperaTarefaPorId(int idTarefa);

    }
}

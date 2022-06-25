using apiToDo.Models;
using System.Collections.Generic;

namespace apiToDo.Repository.Interface
{
    public interface ITarefasRepository
    {
        //Criação da interface do repository para mapeamento da injeção de dependência e definições de scope da classe
        //Utilização do padrão Camel case para paremetros de métodos
        public List<TarefasModel> ObterTarefas();
        public void InserirTarefa(string tarefa);
        public void DeletarTarefa(int idTarefa);
        public void AtualizarTarefa(TarefasModel tarefas);
        public TarefasModel ObterTarefaPorId(int idTarefa);

    }
}

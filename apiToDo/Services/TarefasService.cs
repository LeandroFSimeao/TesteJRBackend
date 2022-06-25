using apiToDo.Models;
using apiToDo.Repository.Interface;
using apiToDo.Services.Interface;
using System.Collections.Generic;
using System;

namespace apiToDo.Services
{
    public class TarefasService : ITarefasService
    {
        //Para inicialização de variáveis privadas utiliza-se a nomeclatura "_" para diferenciar das públicas
        private readonly ITarefasRepository _tarefasRepository;

        public TarefasService(ITarefasRepository tarefasRepository)
        {
            _tarefasRepository = tarefasRepository;
        }

        public IList<TarefasModel> ObterTarefas()
        {
            //Obter a lista de tarefas no repositório e retonar
            //Utilização do Ilist para evitar excesso de alocação de mémoria
            IList<TarefasModel> listaTarefas = _tarefasRepository.ObterTarefas();
            return listaTarefas;
        }

        public void InserirTarefa(string tarefa)
        {
            try
            {
                //Chama o método inserir na classe TarefaRepository
                _tarefasRepository.InserirTarefa(tarefa);
            }
            catch
            {
                throw new Exception("Não foi póssível inserir a tarefa");
            }
        }

        public void DeletarTarefa(int idTarefa)
        {
            try
            {
                //Chama o método deletar na classe TarefaRepository
                _tarefasRepository.DeletarTarefa(idTarefa);
            }
            catch (Exception)
            {
                throw new Exception("Não foi póssível deletar a tarefa ou não foi encontrada");
            }
        }

        public void AtualizaTarefa(TarefasModel request)
        {
            try
            {
                //Chama o método Atualizar na classe TarefaRepository
                _tarefasRepository.AtualizarTarefa(request);
            }
            catch
            {
                throw new Exception("Não foi póssível atualizar a tarefa");
            }
        }

        public TarefasModel RecuperaTarefaPorId(int idTarefa)
        {
            //Chama o método Obter na classe TarefaRepository
            TarefasModel tarefa = _tarefasRepository.ObterTarefaPorId(idTarefa);
            //Caso não encontre o Id ele retorna um exception
            if (tarefa == null)
            {
                throw new Exception("Não foi possível obter a tarefa");
            }
            return tarefa;
        }
    }
}

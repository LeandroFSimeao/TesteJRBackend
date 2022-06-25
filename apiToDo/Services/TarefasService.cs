using apiToDo.Models;
using apiToDo.Repository.Interface;
using apiToDo.Services.Interface;
using System.Collections.Generic;
using System;

namespace apiToDo.Services
{
    public class TarefasService : ITarefasService
    {

        private readonly ITarefasRepository _tarefasRepository;

        public TarefasService(ITarefasRepository tarefasRepository)
        {
            _tarefasRepository = tarefasRepository;
        }

        public IList<TarefasModel> ObterTarefas()
        {
            IList<TarefasModel> listaTarefas = _tarefasRepository.ObterTarefas();
            return listaTarefas;
        }

        public void InserirTarefa(string tarefa)
        {
            try
            {
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
                _tarefasRepository.AtualizarTarefa(request);
            }
            catch
            {
                throw new Exception("Não foi póssível atualizar a tarefa");
            }
        }

        public TarefasModel RecuperaTarefaPorId(int idTarefa)
        {
            TarefasModel tarefa = _tarefasRepository.ObterTarefaPorId(idTarefa);
            if (tarefa == null)
            {
                throw new Exception("Não foi possível obter a tarefa");
            }
            return tarefa;
        }
    }
}

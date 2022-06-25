using apiToDo.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace apiToDo.Models
{
    public class Tarefas
    {
        public static List<TarefaDTO> lstTarefas()
        {
            try
            {
                List<TarefaDTO> lstTarefas = new List<TarefaDTO>();

                lstTarefas.Add(new TarefaDTO
                {
                    IdTarefa = 1,
                    DsTarefa = "Fazer Compras"
                });

                lstTarefas.Add(new TarefaDTO
                {
                    IdTarefa = 2,
                    DsTarefa = "Fazer Atividad Faculdade"
                });

                lstTarefas.Add(new TarefaDTO
                {
                    IdTarefa = 3,
                    DsTarefa = "Subir Projeto de Teste no GitHub"
                });

                return lstTarefas;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        public static void InsereTarefa(List<TarefaDTO> lstResponse, TarefaDTO request)
        {
            try
            {
                lstResponse.Add(request);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        // Implementando um método público e estático para excluir uma tarefa da lista, que recebe como parâmetro a lista de tarefas atual e o id da tarefa a ser excúída.
        public static void DeletaTarefa(List<TarefaDTO> lstResponse ,int IdTarefa)
        {
            //iniciando a estrutura de tratamento de erros.
            try
            {
                // Essa linha estava fazendo o mesmo do que a linha seguinte.
                //var Tarefa = lstResponse.FirstOrDefault(x => x.ID_TAREFA == ID_TAREFA);
                // Cria um objeto do tipo tarefa, recebendo um objeto da lista de tarefas que possui o identificador igual ao passado por parâmetro
                TarefaDTO Tarefa2 = lstResponse.FirstOrDefault(x => x.IdTarefa == IdTarefa);
                //Remove o objeto obtido na linha anterior da lista
                if (Tarefa2 == null)
                {
                    // Exibe uma mensagem de erro personalizada para o usuário
                    throw new Exception("Não foi póssível encontrar a tarefa");
                }
                lstResponse.Remove(Tarefa2);
            }
            // Captura o possível erro ocorrido dentro do try, para tratamento
            catch(Exception)
            {
                
                throw new Exception("Não foi póssível deletar a tarefa");
            }
        }

        public static void AtualizaTarefa(List<TarefaDTO> lstResponse, TarefaDTO request)
        {
            try
            {
                TarefaDTO Tarefa = lstResponse.FirstOrDefault(x => x.IdTarefa == request.IdTarefa);
                if (Tarefa == null)
                {
                    throw new Exception("Não foi possível encontrar a tarefa");
                }
                Tarefa.DsTarefa = request.DsTarefa;
            }
            catch
            {
                throw new Exception("Não foi póssível atualizar a tarefa");
            }
        }

        public static TarefaDTO RecuperaTarefaPorId(List<TarefaDTO> lstResponse, int IdTarefa)
        {
            try
            {
                TarefaDTO Tarefa = lstResponse.FirstOrDefault(x => x.IdTarefa == IdTarefa);
                if (Tarefa == null)
                {
                    throw new Exception("Não foi possível encontrar a tarefa");
                }
                return Tarefa;
            }
            catch
            {
                throw new Exception("Não foi póssível encontrar a tarefa");
            }
        }

    }
}

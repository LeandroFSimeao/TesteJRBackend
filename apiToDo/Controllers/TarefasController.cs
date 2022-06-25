using apiToDo.DTO;
using apiToDo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace apiToDo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefasController : ControllerBase
    {
        private static List<TarefaDTO> lstTarefas = Tarefas.lstTarefas();


        [HttpGet]
        public ActionResult RecuperarTarefas()
        {
            try
            {
                return Ok(lstTarefas);
            }

            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro em sua API {ex.Message}"});
            }
        }

        [HttpPost]
        public ActionResult InserirTarefas([FromBody] TarefaDTO Request)
        {
            try
            {
                Tarefas.InserirTarefa(lstTarefas, Request);
                return RecuperarTarefas();

            }

            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro em sua API {ex.Message}" });
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeletarTarefa(int id)
        {
            try
            {
                Tarefas.DeletarTarefa(lstTarefas, id);
                return RecuperarTarefas();
            }

            catch (Exception ex)
            {
                return StatusCode(404, new { msg = $"O Id informado não foi encontrado {ex.Message}" });
            }
        }
    }
}

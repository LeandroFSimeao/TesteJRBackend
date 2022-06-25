using apiToDo.Models;
using apiToDo.Services.Interface;
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
        private readonly ITarefasService _tarefasService;

        public TarefasController(ITarefasService tarefasService)
        {
            _tarefasService = tarefasService;
        }

        [HttpGet]
        public ActionResult RecuperarTarefas()
        {
            IList<TarefasModel> listaTarefas = _tarefasService.ObterTarefas();
            return Ok(listaTarefas);
        }

        [HttpGet("{id}")]
        public ActionResult RecuperarTarefasPorId(int id)
        {
            try
            {
                TarefasModel tarefa = _tarefasService.RecuperaTarefaPorId(id);
                return Ok(tarefa);
            }

            catch (Exception ex)
            {
                return StatusCode(404, new { msg = ex.Message});
            }
        }

        [HttpPost]
        public ActionResult InserirTarefas([FromBody] TarefasModel request)
        {
            try
            {
                _tarefasService.InserirTarefa(request.DsTarefa);
                IList<TarefasModel> listaTarefas = _tarefasService.ObterTarefas();
                return StatusCode(200, new { msg = "Tarefa inserida com sucessp.", tarefas = listaTarefas });
            }

            catch (Exception ex)
            {
                return StatusCode(404, new { msg = ex.Message});
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeletarTarefa(int id)
        {
            try
            {
                _tarefasService.DeletarTarefa(id);
                IList<TarefasModel> listaTarefas = _tarefasService.ObterTarefas();
                return StatusCode(200, new { msg = "Tarefa deletada com sucesso.", tarefas = listaTarefas });
            }

            catch (Exception ex)
            {
                return StatusCode(400, new { msg = ex.Message});
            }
        }
        [HttpPut]
        public ActionResult AtualizarTarefa([FromBody] TarefasModel request)
        {
            try
            {
                _tarefasService.AtualizaTarefa(request);
                IList<TarefasModel> listaTarefas = _tarefasService.ObterTarefas();
                return StatusCode(200, new { msg = "Tarefa atualizada com sucesso.", tarefas = listaTarefas });

            }

            catch (Exception ex)
            {
                return StatusCode(404, new { msg = ex.Message});
            }
        }
    }
}

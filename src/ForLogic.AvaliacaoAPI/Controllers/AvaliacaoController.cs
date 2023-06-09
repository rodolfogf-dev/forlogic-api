﻿using ForLogic.AvaliacaoAPI.Data.ValueObjects;
using ForLogic.AvaliacaoAPI.Model;
using ForLogic.AvaliacaoAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ForLogic.AvaliacaoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvaliacaoController : ControllerBase
    {
        private IAvaliacaoRepository _repository;

        public AvaliacaoController(IAvaliacaoRepository repository)
        {
            _repository = repository ?? throw new
                ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AvaliacaoVO>>> ObterTodos()
        {
            var avaliacoes = await _repository.ObterTodos();
            return Ok(avaliacoes);
        }

        [HttpGet("{mes}/{ano}")]
        //[Authorize]
        public async Task<ActionResult<IEnumerable<AvaliacaoVO>>> ObterAvalicaoPorPeriodo(int mes, int ano)
        {
            var avaliacoes = await _repository.ObterAvalicaoPorPeriodo(mes, ano);
            return Ok(avaliacoes);
        }

        [HttpPost()]
        //[Authorize]
        public async Task<ActionResult<AvaliacaoVO>> CriarAvaliacao(AvaliacaoVO vo)
        {
            if (vo == null) return BadRequest();
            var avaliacao = await _repository.CriarAvalicao(vo);
            return Ok(avaliacao);
        }
    }
}

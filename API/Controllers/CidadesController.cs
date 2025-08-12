using API.Models;
using API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("")]
    [ApiController]
    public class CidadesController : ControllerBase
    {
        [HttpGet("paises/{idPais}/estados/{idEstado}/cidades")]
        public List<Cidade> GetCidades(
            [FromQuery] int fromPopulacao,
            [FromQuery] string? nome = null
            )
        {
            var resultado = CidadesRepository.Cidades;// Obtém a lista de cidades do repositório

            if (!string.IsNullOrEmpty(nome))
            {
                resultado = resultado.Where(cidade => cidade.Nome == nome).ToList();// Filtra as cidades pelo nome
            }

            if (fromPopulacao > 0)
            {
                resultado = resultado.Where(cidade => cidade.Populacao >= fromPopulacao).ToList();// Filtra as cidades pela população
            }
            return resultado;
        }
    }
}

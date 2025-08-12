using API.Models;
using API.Repository;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace API.Controllers
{
    [Route("")]
    [ApiController]
    public class CidadesController : ControllerBase
    {
        [HttpGet("paises/{idPais}/estados/{idEstado}/cidades")]
        public List<Cidade> GetCidades(// Define o método HTTP GET para obter cidades
            [FromQuery] int fromPopulacao,
            [FromRoute, Required] int idPais,
            [FromRoute, Required] int idEstado,
            [FromQuery] string? nome = null
            )
        {
            var resultado = CidadesRepository.Cidades.Where(
                cidade => cidade.IdPais == idPais && cidade.IdEstado == idEstado).ToList();// Filtra as cidades pelo país e estado

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

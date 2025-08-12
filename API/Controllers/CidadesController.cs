using API.Models;
using API.Repository;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace API.Controllers
{
    [Route("paises/{idPais}/estados/{idEstado}/cidades")]// Define a rota para acessar as cidades
    [ApiController]
    public class CidadesController : ControllerBase
    {
        [HttpGet]
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

        [HttpPost]
        public ActionResult PostCidades(
            [FromRoute, Required] int idPais,
            [FromRoute, Required] int idEstado,
            [FromBody] Cidade cidade
            )
        {
            cidade.IdEstado = idEstado;
            cidade.IdPais = idPais;
            CidadesRepository.Cidades.Add(cidade);// Adiciona uma nova cidade à lista de cidades
            CidadesRepository.Save();// Salva as alterações

            string location = $"/paises/{idPais}/estados/{idEstado}/cidades/{cidade.Id}";// Define o local da nova cidade criada

            return Created(location, null);// Retorna o status 201 quando criado
        }
    }
}

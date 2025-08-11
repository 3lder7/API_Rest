using API.Models;
using API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api")]
    [ApiController]
    public class CidadesController : ControllerBase
    {
        [HttpGet("paises/{idPais}/estados/{idEstado}/cidades")]
        public List<Cidade> GetCidades()
        {
            return CidadesRepository.Cidades;
        }
    }
}

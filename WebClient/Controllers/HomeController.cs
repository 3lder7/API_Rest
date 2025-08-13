using Microsoft.AspNetCore.Mvc;
using Models;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebClient.Models;

namespace WebClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(int idCidade, string nome, int estado, int pais, int populacao)// Essa ação é chamada quando o usuário envia o formulário
        {
            Cidade cidade = new Cidade()// Cria uma nova instância da classe Cidade
            {
                Id = idCidade,
                Nome = nome,
                Populacao = populacao
            };

            using (var httpClient = new HttpClient())// Cria uma instância do HttpClient para enviar a requisição
            {
                StringContent conteudo = new StringContent(// Serializa o objeto cidade para JSON
                    JsonSerializer.Serialize(cidade)
                    ,Encoding.UTF8, "application/json");

                try 
                {
                    using (var resposta = await httpClient.PostAsync(
                        $"https://localhost:7015/paises/{pais}/estados/{estado}/cidades", 
                        conteudo))// Envia a requisição POST para o serviço de cidades
                    {
                        if (resposta.StatusCode == System.Net.HttpStatusCode.Created)
                        {
                            ViewBag.Mensagem = "Cidade cadastrada com sucesso.";
                        }
                        else 
                        {
                            ViewBag.Mensagem = "Erro ao cadastrar a cidade.";
                        }
                    }

                }
                catch (Exception) 
                {
              
                }
            }
                return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

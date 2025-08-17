using Microsoft.AspNetCore.Mvc;
using Models;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
<<<<<<< HEAD
=======
using System.Threading.Tasks;
>>>>>>> f0d3f3a291eca739af500dd5c027425e46412a4d
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

<<<<<<< HEAD
        public async Task<IActionResult> Index()
        {
            List<Cidade> Cidades = new List<Cidade>();

            using (var httpClient = new HttpClient())
            {
                try
                {
                    using (var resposta = await httpClient.GetAsync(
                        $"https://localhost:7015/paises/55/estados/11/cidades"))
                    {
                        if (resposta.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var conteudo = resposta.Content.ReadAsStringAsync().Result;

                            if (!String.IsNullOrEmpty(conteudo))
                            {
                                Cidades = JsonSerializer.Deserialize<List<Cidade>>(conteudo, new JsonSerializerOptions
                                {
                                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                                });
                            }

                        }
                        else
                        {
                            ViewBag.ErroBusca = "Ocorreu um erro ao buscar as cidades.";
                        }
                    }

                }
                catch (Exception)
                {
                    ViewBag.ErroBusca = "Ocorreu um erro ao buscar as cidades.";
                }
            }
            return View(Cidades);
=======
        public IActionResult Index()
        {
            return View();
>>>>>>> f0d3f3a291eca739af500dd5c027425e46412a4d
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
<<<<<<< HEAD
                return await Index();
=======
                return View();
>>>>>>> f0d3f3a291eca739af500dd5c027425e46412a4d
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

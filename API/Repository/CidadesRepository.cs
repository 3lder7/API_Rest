using API.Models;
using System.Text.Json;

namespace API.Repository
{
    public class CidadesRepository
    {
        private static List<Cidade> cidades;
        private const string EnderecoJson = "";

        public static List<Cidade> Cidades
        {
            get 
            {
                if (cidades == null)
                {
                    string jsonString = File.ReadAllText(EnderecoJson);

                    if (!string.IsNullOrEmpty(jsonString))
                    {
                        cidades = JsonSerializer.Deserialize<List<Cidade>>(jsonString);
                    }
                    else 
                    {
                        CarregarCidades();
                    }
                    return cidades;
                }
                return cidades;
            }
        }

        private static void CarregarCidades()
        {
            throw new NotImplementedException();
        }
    }
}

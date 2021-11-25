using API1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace API1.Services
{
    public class Livro
    {
        public static  async Task<HttpResponseMessage> requisita(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:3333/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // HTTP GET
            HttpResponseMessage response = await client.GetAsync("livro/" + id);

            return response;
        }

        public async Task<string> ChamaLivroApi(List<Filme> filmes)
        {
            var result = "";
            foreach (var filme in filmes)
            {
                var res = await requisita(filme.IdLivro);

                result = await res.Content.ReadAsStringAsync();
            }

            return result;
        }
    }
}

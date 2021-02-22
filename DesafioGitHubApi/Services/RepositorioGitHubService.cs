using DesafioGitHubApi.Interfaces;
using DesafioGitHubApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace DesafioGitHubApi.Services
{
    public class RepositorioGitHubService : IRepositorioGitHubService
    {

        private readonly RepositorioContexto _repositorioContexto;

        public RepositorioGitHubService(RepositorioContexto repositorioContexto)
        {
            _repositorioContexto = repositorioContexto;
        }

        public async Task<List<RepositorioGitHub>> GetRepositorioGitHubList(String url)
        {
            String resultContent;
            using (HttpClient client = new HttpClient())
            {
                var uri = new Uri(url);

                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.UserAgent.TryParseAdd("request");//Set the User Agent to "request"

                using (HttpResponseMessage response = client.GetAsync(uri).GetAwaiter().GetResult())
                {
                    //response.EnsureSuccessStatusCode();
                    //responseBody = await response.Content.ReadAsByteArrayAsync();
                    
                    // List<RepositorioGitHub> repositorioGitHubList;
                    if (response.StatusCode != HttpStatusCode.OK)
                        return null;
                    else
                        resultContent = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                    return JsonConvert.DeserializeObject<List<RepositorioGitHub>>(resultContent);
                }
            }
          
        }

    }
}

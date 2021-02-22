using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioGitHubApi.Interfaces
{
    public interface IRepositorioGitHubService
    {
        Task<List<RepositorioGitHub>> GetRepositorioGitHubList(String url);
    }
}

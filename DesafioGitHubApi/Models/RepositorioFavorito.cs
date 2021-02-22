using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioGitHubApi.Models
{
    public class RepositorioFavorito
    {
        public Int64 Id { get; set; }
        public String name { get; set; }
        public String full_name { get; set; }
        public String html_url { get; set; }
        public String description { get; set; }
        public String language { get; set; }
        public DateTime updated_at { get; set; }        
        public bool favorito { get; set; }         
    }
}

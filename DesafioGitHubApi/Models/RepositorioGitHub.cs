using DesafioGitHubApi.Interfaces;
using DesafioGitHubApi.Models;
using System;
using System.Collections.Generic;

namespace DesafioGitHubApi
{
    public class RepositorioGitHub
    {
        public RepositorioGitHubOwner owner { get; set; }

        public RepositorioGitHub()
        {
            owner = new RepositorioGitHubOwner();
        }

        public Int64 id { get; set; }
        public String name { get; set; }
        public String full_name { get; set; }
        public String html_url { get; set; }
        public String description { get; set; }
        public String language { get; set; }
        public DateTime updated_at { get; set; }
        public Boolean favorito { get; set; }
        
    }
}

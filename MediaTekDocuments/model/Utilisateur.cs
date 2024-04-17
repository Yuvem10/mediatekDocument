using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTekDocuments.model
{
    public class Utilisateur
    {
        private int id {get;}
        private string identifiant { get;}
        public string password { get;}
        public string nomService { get;}

        public Utilisateur(string identifiant, string password, string nomService)
        {
            this.identifiant = identifiant;
            this.password = password;
            this.nomService = nomService;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTekDocuments.model
{
    public class Abonnement : Commande
    {
        public DateTime dateFinAbonnement { get; }
        public string idRevue { get; }

        public Abonnement(string id, DateTime dateCommande, float montant, DateTime dateFinAbonnement, string idRevue) : base(id, dateCommande, montant)
        {
            this.dateFinAbonnement = dateFinAbonnement;
            this.idRevue = idRevue;
        }
    }
}

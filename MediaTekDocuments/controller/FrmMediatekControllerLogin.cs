using MediaTekDocuments.dal;
using MediaTekDocuments.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTekDocuments.controller
{
    class FrmMediatekControllerLogin
    {
        /// <summary>
        /// Objet d'accès aux données
        /// </summary>
        private readonly Access access;

        private Utilisateur user;

        /// <summary>
        /// Récupération de l'instance unique d'accès aux données
        /// </summary>
        public FrmMediatekControllerLogin()
        {
            access = Access.GetInstance();
        }

        /// <summary>
        /// Check login
        /// </summary>
        public Utilisateur checkLogin(string login, string password)
        {
            return access.checkLogin(login, password);
        }



    }
}

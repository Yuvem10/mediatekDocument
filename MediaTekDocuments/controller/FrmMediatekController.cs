﻿using System.Collections.Generic;
using MediaTekDocuments.model;
using MediaTekDocuments.dal;
using System;

namespace MediaTekDocuments.controller
{
    /// <summary>
    /// Contrôleur lié à FrmMediatek
    /// </summary>
    class FrmMediatekController
    {
        /// <summary>
        /// Objet d'accès aux données
        /// </summary>
        private readonly Access access;

        /// <summary>
        /// Récupération de l'instance unique d'accès aux données
        /// </summary>
        public FrmMediatekController()
        {
            access = Access.GetInstance();
        }

        /// <summary>
        /// getter sur la liste des genres
        /// </summary>
        /// <returns>Liste d'objets Genre</returns>
        public List<Categorie> GetAllGenres()
        {
            return access.GetAllGenres();
        }

        /// <summary>
        /// getter sur la liste des livres
        /// </summary>
        /// <returns>Liste d'objets Livre</returns>
        public List<Livre> GetAllLivres()
        {
            return access.GetAllLivres();
        }

        /// <summary>
        /// getter sur la liste des Dvd
        /// </summary>
        /// <returns>Liste d'objets dvd</returns>
        public List<Dvd> GetAllDvd()
        {
            return access.GetAllDvd();
        }

        /// <summary>
        /// getter sur la liste des revues
        /// </summary>
        /// <returns>Liste d'objets Revue</returns>
        public List<Revue> GetAllRevues()
        {
            return access.GetAllRevues();
        }

        /// <summary>
        /// getter sur les rayons
        /// </summary>
        /// <returns>Liste d'objets Rayon</returns>
        public List<Categorie> GetAllRayons()
        {
            return access.GetAllRayons();
        }

        /// <summary>
        /// getter sur les publics
        /// </summary>
        /// <returns>Liste d'objets Public</returns>
        public List<Categorie> GetAllPublics()
        {
            return access.GetAllPublics();
        }

        /// <summary>
        /// getter sur les statuts
        /// </summary>
        /// <returns>Liste d'objets Suivi</returns>
        public List<Suivi> GetAllStatus()
        {
            return access.GetAllStatus();
        }

        /// <summary>
        /// retrieve a suivi by its id
        /// </summary>
        public Suivi GetStatus(string id)
        {
            return access.GetStatus(id);
        }

        /// <summary>
        /// getter sur les commandes et les documents associés
        /// </summary>
        /// <returns>Liste d'objets CommandeDocument</returns>
        public List<CommandeDocument> GetAllCommandeDocuments()
        {
            return access.GetAllCommandeDocuments();              
        }

        /// <summary>
        /// retrieve order by its id
        /// </summary>
        public Commande retrieveCommandeById(string id)
        {
            return access.retrieveCommandeById(id);
        }

        /// <summary>
        /// retrieve orderDocument by its id
        /// </summary>
        public CommandeDocument retrieveCommandeDocumentById(string id)
        {
            return access.retrieveCommandeDocumentById(id);
        }

        /// <summary>
        /// add command document
        /// </summary>
        public bool AddCommandeDocument(CommandeDocument commandeDocument)
        {
            return access.AddCommandeDocument(commandeDocument);
        }

        /// <summary>
        /// add command 
        /// </summary>
        public bool AddCommande(Commande commande)
        {
            return access.AddCommande(commande);
        }

        /// <summary>
        /// get the number of orders
        /// </summary>
        public bool OrderExist(string name)
        {
            return access.OrderExist(name);
        }

        /// <summary>
        /// retrieve the if of the book by its id 
        /// </summary>
        public Document retrieveDocumentById(string id)
        {
            return access.retrieveDocumentById(id);
        }

        /// <summary>
        /// get order count
        /// </summary>
        public int GetOrderCount()
        {
            return access.GetOrderCount();
        }

        /// <summary>
        /// get commandedocument dvd
        /// </summary>
        public List<CommandeDocument> GetAllCommandeDocumentsDvd()
        {
            return access.GetAllCommandeDocumentsDvd();
        }

        /// <summary>
        /// get commandedocument livre
        /// </summary>
        public List<CommandeDocument> GetAllCommandeDocumentsLivre()
        {
            return access.GetAllCommandeDocumentsLivre();
        }





        /// <summary>
        /// retrieve the id of the current order for adding a new orderdocument
        /// </summary>
        /// <param name="idDocuement">id of the document</param>
        public string GetIdCommande(string idDocuement)
        {
            return access.GetIdCommande(idDocuement);
        }

        /// <summary>
        /// update the status of the order
        /// </summary>
        public bool updateOrderStatus(string idCommande, string idStatus)
        {
            return access.updateOrderStatus(idCommande, idStatus);
        }

        ///<summary>
        /// delete a command document
        ///</summary>
        public bool deleteOrder(string idCommandeDocument)
        {
            return access.deleteOrder(idCommandeDocument);
        }



        /// <summary>
        /// récupère les exemplaires d'une revue
        /// </summary>
        /// <param name="idDocuement">id de la revue concernée</param>
        /// <returns>Liste d'objets Exemplaire</returns>
        public List<Exemplaire> GetExemplairesRevue(string idDocuement)
        {
            return access.GetExemplairesRevue(idDocuement);
        }

        /// <summary>
        /// Crée un exemplaire d'une revue dans la bdd
        /// </summary>
        /// <param name="exemplaire">L'objet Exemplaire concerné</param>
        /// <returns>True si la création a pu se faire</returns>
        public bool CreerExemplaire(Exemplaire exemplaire)
        {
            return access.CreerExemplaire(exemplaire);
        }

        /// <summary>
        /// retrieve abonnement by its id
        /// </summary>
        public Abonnement retrieveAbonnementById(string id)
        {
            return access.retrieveAbonnementById(id);
        }

        /// <summary>
        /// add abonnement
        /// </summary>
        public bool AddAbonnement(Abonnement abonnement)
        {
            return access.AddAbonnement(abonnement);
        }

        /// <summary>
        /// get all abonnements revues
        /// </summary>
        public List<Abonnement> GetAllAbonnements()
        {
            return access.GetAllAbonnements();
        }

   

        /// <summary>
        /// search if the dateparution is in the range of the abonnement
        /// </summary>
        public bool parutionDansAbonnement(string dateCommande, string dateFinAbo, string dateParution)
        {
            return access.parutionDansAbonnement(dateCommande, dateFinAbo, dateParution);
        }

        public DateTime setDateFinAbonnement(string id)
        {
            return access.setDateFinAbonnement(id);
        }

        public bool accessApp(Utilisateur user)
        {
            string test = user.nomService;
            if (user.nomService == "Culture")
            {
                return false;
            }
            return true;
        }

        public string verifService(Utilisateur user)
        {
            return user.nomService;
        }




    }
}

using System;
using System.Collections.Generic;
using MediaTekDocuments.model;
using MediaTekDocuments.manager;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.Configuration;
using System.Linq;
using Serilog;


namespace MediaTekDocuments.dal
{
    /// <summary>
    /// Classe d'accès aux données
    /// </summary>
    public class Access
    {
        private static readonly string connectionName = "MediaTekDocuments.Properties.Settings.mediatek86AuthentificationString";
        /// <summary>
        /// adresse de l'API
        /// </summary>
        private static readonly string uriApi = "https://mediatekdocumentsapi.online/";
        /// <summary>
        /// instance unique de la classe
        /// </summary>
        private static Access instance = null;
        /// <summary>
        /// instance de ApiRest pour envoyer des demandes vers l'api et recevoir la réponse
        /// </summary>
        private readonly ApiRest api = null;
        /// <summary>
        /// méthode HTTP pour select
        /// </summary>
        private const string GET = "GET";
        /// <summary>
        /// méthode HTTP pour insert
        /// </summary>
        private const string POST = "POST";
        /// <summary>
        /// méthode HTTP pour update
        /// </summary>
        public const string PUT = "PUT";
        /// <summary>
        /// methode HTTP pour delete
        /// </summary>
        public const string DELETE = "DELETE";

        /// <summary>
        /// Méthode privée pour créer un singleton
        /// initialise l'accès à l'API
        /// </summary>
        private Access()
        {
            String authenticationString;
            try
            {
                Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Verbose()
                    .WriteTo.Console()
                    .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
                    .CreateLogger();

                authenticationString = GetConnectionStringByName(connectionName);
                api = ApiRest.GetInstance(uriApi, authenticationString);
            }
            catch (Exception e)
            {
                Log.Error("Erreur lors de l'accès à l'API : " + e.Message);
                Console.WriteLine(e.Message);
                Environment.Exit(0);
            }
        }

        static string GetConnectionStringByName(string name)
        {
            string returnValue = null;
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[name];
            if (settings != null)
                returnValue = settings.ConnectionString;
            Log.Information("Connection string : " + returnValue);
            return returnValue;
        }

        /// <summary>
        /// Création et retour de l'instance unique de la classe
        /// </summary>
        /// <returns>instance unique de la classe</returns>
        public static Access GetInstance()
        {
            if(instance == null)
            {
                instance = new Access();
            }
            Log.Information("Accès à la base de données");
            return instance;
        }

        /// <summary>
        /// Retourne tous les genres à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets Genre</returns>
        public List<Categorie> GetAllGenres()
        {
            IEnumerable<Genre> lesGenres = TraitementRecup<Genre>(GET, "genre");
            Log.Information("Récupération des genres");
            return new List<Categorie>(lesGenres);
        }

        /// <summary>
        /// Retourne tous les rayons à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets Rayon</returns>
        public List<Categorie> GetAllRayons()
        {
            IEnumerable<Rayon> lesRayons = TraitementRecup<Rayon>(GET, "rayon");
            Log.Information("Récupération des rayons");
            return new List<Categorie>(lesRayons);
        }

        /// <summary>
        /// Retourne toutes les catégories de public à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets Public</returns>
        public List<Categorie> GetAllPublics()
        {
            IEnumerable<Public> lesPublics = TraitementRecup<Public>(GET, "public");
            Log.Information("Récupération des publics");
            return new List<Categorie>(lesPublics);
        }

        /// <summary>
        /// retrieve all status from the database
        /// </summary>
        /// <returns>list of status</returns>
        public List<Suivi> GetAllStatus()
        {
            IEnumerable<Suivi> lesStatus = TraitementRecup<Suivi>(GET, "suivi");
            Log.Information("Récupération des statuts");
            return new List<Suivi>(lesStatus);
        }

        /// <summary>
        /// retrieve the specific status from the database with the id
        /// </summary>5
        public Suivi GetStatus(string id)
        {
            IEnumerable<Suivi> lesStatus = TraitementRecup<Suivi>(GET, "suivi/" + id);
            Log.Information("Récupération du statut");
            return new List<Suivi>(lesStatus)[0];
        }

       /// <summary>
       /// retrieve all the orders documents from the database
       /// </summary>
       /// <returns>List<returns>
       public List<CommandeDocument> GetAllCommandeDocuments()
       {
            IEnumerable<CommandeDocument> commandeDocuments = TraitementRecup<CommandeDocument>(GET, "commandedocument");
            Log.Information("Récupération des commandes");
            return new List<CommandeDocument>(commandeDocuments);
       }

        ///<summary>
        /// retrieve order by its id
        /// </summary>
        /// <returns>commande</returns>
        public Commande retrieveCommandeById(string id)
        {
            String jsonIdDocument = convertToJson("id", id);
            IEnumerable<Commande> commande = TraitementRecup<Commande>(GET, "commande/" + jsonIdDocument);
            Log.Information("Récupération de la commande");
            return new List<Commande>(commande)[0];
        }

        /// <summary>
        /// retrieve orderdocument by its id
        /// </summary>
        public CommandeDocument retrieveCommandeDocumentById(string id)
        {
            String jsonIdDocument = convertToJson("id", id);
            IEnumerable<CommandeDocument> commandeDocument = TraitementRecup<CommandeDocument>(GET, "commandedocument/" + jsonIdDocument);
            Log.Information("Récupération de la commande document");
 
            return new List<CommandeDocument>(commandeDocument)[0];
        }

        /// <summary>
        /// add a new order document
        /// </summary>
        public bool AddCommandeDocument(CommandeDocument commandeDocument)
        {
            String jsonCommandeDocument = JsonConvert.SerializeObject(commandeDocument, new CustomDateTimeConverter()); 
            try
            {
                Console.WriteLine(jsonCommandeDocument);
                // récupération soit d'une liste vide (requête ok) soit de null (erreur)
                List<CommandeDocument> liste = TraitementRecup<CommandeDocument>(POST, "commandedocument/" + jsonCommandeDocument);
                Log.Information("Ajout de la commande document");
                return (liste != null);
            }
            catch (Exception ex)
            {
                Log.Error("Erreur lors de l'ajout de la commande document : " + ex.Message);
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        /// <summary>
        /// set the name of the order with retrieve the numbers of the order
        /// </summary>
        public string SetNameOrder(bool livre)
        {
            IEnumerable<Commande> commande = TraitementRecup<Commande>(GET, "commande");
            List<Commande> liste = new List<Commande>(commande);

            if (livre)
            {
                List<CommandeDocument> listeCommande = GetAllCommandeDocumentsLivre();

                if (listeCommande.Count == 0)
                {
                    return "CMDL1";
                }

                string id = listeCommande[listeCommande.Count - 1].id;
                string number = id.Substring(4);
                int numberInt = Int32.Parse(number);
                numberInt++;
                string newId = "CMDL" + numberInt;
                Log.Information("Création de la commande document");
                return newId;     
            }
            else
            {
                List<CommandeDocument> listeCommande = GetAllCommandeDocumentsDvd();

                if (listeCommande.Count == 0)
                {
                    return "CMDD1";
                }


                string id = listeCommande[listeCommande.Count - 1].id;
                string number = id.Substring(4);
                int numberInt = Int32.Parse(number);
                numberInt++;
                string newId = "CMDD" + numberInt;
                Log.Information("Création de la commande document");
                return newId;
            }
            
            
        }

        /// <summary>
        /// set name order to a revue order
        /// </summary>
        public string SetNameOrderRevue()
        {
            IEnumerable<Commande> commande = TraitementRecup<Commande>(GET, "commande");
            List<Commande> liste = new List<Commande>(commande);

            List<Abonnement> listeCommande = GetAllAbonnements();

            if (listeCommande.Count == 0)
            {
                return "CMDR1";
            }

            string id = listeCommande[listeCommande.Count - 1].id;
            string number = id.Substring(4);
            int numberInt = Int32.Parse(number);
            numberInt++;
            string newId = "CMDR" + numberInt;
            Log.Information("Création de la commande document");
            return newId;
        }

        /// <summary>
        /// get commandedocument dvd
        /// </summary>
        public List<CommandeDocument> GetAllCommandeDocumentsDvd()
        {
            // retrieve all the order document where the id starts with CMDD
            IEnumerable<CommandeDocument> commandeDocument = TraitementRecup<CommandeDocument>(GET, "commandedocument");
            List<CommandeDocument> listeDvd = new List<CommandeDocument>(commandeDocument);
            List<CommandeDocument> liste = new List<CommandeDocument>();
            foreach (CommandeDocument commande in listeDvd)
            {
                if (commande.id.StartsWith("CMDD"))
                {
                    liste.Add(commande);
                }
            }
            Log.Information("Récupération des commandes document");
            return liste;
        }

        /// <summary>
        /// get commandedocument livre
        /// </summary>
        public List<CommandeDocument> GetAllCommandeDocumentsLivre()
        {
            // retrieve all the order document where the id starts with CMDL
            IEnumerable<CommandeDocument> commandeDocument = TraitementRecup<CommandeDocument>(GET, "commandedocument");
            List<CommandeDocument> listeLivre = new List<CommandeDocument>(commandeDocument);
            List<CommandeDocument> liste = new List<CommandeDocument>();
            foreach (CommandeDocument commande in listeLivre)
            {
                if (commande.id.StartsWith("CMDL"))
                {
                    liste.Add(commande);
                }
            }
            Log.Information("Récupération des commandes document");
            return liste;
        }


        /// <summary>
        /// retrieve livre by its id
        /// </summary>
        public Document retrieveDocumentById(string id)
        {
            String jsonIdDocument = convertToJson("id", id);
            IEnumerable<Document> livre = TraitementRecup<Document>(GET, "document/" + jsonIdDocument);
            Log.Information("Récupération du document");
            return new List<Document>(livre)[0];
        }

        /// <summary>
        /// get order count
        /// </summary>
        public int GetOrderCount()
        {
            IEnumerable<Commande> commande = TraitementRecup<Commande>(GET, "commande");
            List<Commande> liste = new List<Commande>(commande);
            Log.Information("Récupération du nombre de commandes");
            return liste.Count;
        }

        /// <summary>
        /// update the status of the order
        /// </summary>
        public bool updateOrderStatus(string idCommande, string idStatus)
        {
            String jsonIdStatus = convertToJson("statut", idStatus);
            try
            {
                // récupération soit d'une liste vide (requête ok) soit de null (erreur)
                List<Commande> liste = TraitementRecup<Commande>(PUT, "commandedocument/" + idCommande + "/" + jsonIdStatus);
                return (liste != null);
            }
            catch (Exception ex)
            {
                Log.Error("Erreur lors de la mise à jour du statut de la commande : " + ex.Message);
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        ///<summary>
        ///delete a command document
        /// </summary>
        public bool deleteOrder(string idCommande)
        {
            // convert the id to json
            String jsonIdCommande = convertToJson("id", idCommande);
            try
            {
                // récupération soit d'une liste vide (requête ok) soit de null (erreur)
                List<CommandeDocument> liste = TraitementRecup<CommandeDocument>(DELETE, "commande/" + jsonIdCommande);
                return (liste != null);
            }
            catch (Exception ex)
            {
                Log.Error("Erreur lors de la suppression de la commande : " + ex.Message);
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        /// <summary>
        /// retrieve the id of the current order for adding a new orderdocument
        /// </summary>
        public string GetIdCommande(string idDocuement)
        {
            String jsonIdDocument = convertToJson("id", idDocuement);
            try
            {
                // récupération soit d'une liste vide (requête ok) soit de null (erreur)
                IEnumerable<Commande> commande = TraitementRecup<Commande>(GET, "commande/" + jsonIdDocument);
                return new List<Commande>(commande)[0].id;
            }
            catch (Exception ex)
            {
                Log.Error("Erreur lors de la récupération de la commande : " + ex.Message);
                Console.WriteLine(ex.Message);
                return null;
            }
            
        }


        /// <summary>
        /// add commande
        /// </summary>
        public bool AddCommande(Commande commande)
        {
            String jsonCommande = JsonConvert.SerializeObject(commande, new CustomDateTimeConverter());
            try
            {
                Console.WriteLine(jsonCommande);
                // récupération soit d'une liste vide (requête ok) soit de null (erreur)
                List<Commande> liste = TraitementRecup<Commande>(POST, "commande/" + jsonCommande);
                return (liste != null);
            }
            catch (Exception ex)
            {
                Log.Error("Erreur lors de l'ajout de la commande : " + ex.Message);
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        /// <summary>
        /// Retourne toutes les livres à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets Livre</returns>
        public List<Livre> GetAllLivres()
        {
            List<Livre> lesLivres = TraitementRecup<Livre>(GET, "livre");
            Log.Information("Récupération des livres");
            return lesLivres;
        }

        /// <summary>
        /// Retourne toutes les dvd à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets Dvd</returns>
        public List<Dvd> GetAllDvd()
        {
            List<Dvd> lesDvd = TraitementRecup<Dvd>(GET, "dvd");
            Log.Information("Récupération des dvd");
            return lesDvd;
        }

        /// <summary>
        /// Retourne toutes les revues à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets Revue</returns>
        public List<Revue> GetAllRevues()
        {
            List<Revue> lesRevues = TraitementRecup<Revue>(GET, "revue");
            Log.Information("Récupération des revues");
            return lesRevues;
        }

        /// <summary>
        /// Retrieve the list of all the commands from the database
        /// </summary>
        /// <returns>list of documents</returns>
    


        /// <summary>
        /// Retourne les exemplaires d'une revue
        /// </summary>
        /// <param name="idDocument">id de la revue concernée</param>
        /// <returns>Liste d'objets Exemplaire</returns>
        public List<Exemplaire> GetExemplairesRevue(string idDocument)
        {
            String jsonIdDocument = convertToJson("id", idDocument);
            List<Exemplaire> lesExemplaires = TraitementRecup<Exemplaire>(GET, "exemplaire/" + jsonIdDocument);
            Log.Information("Récupération des exemplaires");
            return lesExemplaires;
        }

        /// <summary>
        /// search if the dateparution is in the range of the abonnement
        /// </summary>
        public bool parutionDansAbonnement(string dateCommande, string dateFinAbo, string dateParution)
        {
            DateTime dateCommandeDate = DateTime.Parse(dateCommande);
            DateTime dateFinAboDate = DateTime.Parse(dateFinAbo);
            DateTime dateParutionDate = DateTime.Parse(dateParution);

            if (dateParutionDate >= dateCommandeDate && dateParutionDate <= dateFinAboDate)
            {
                return true;
            }
            Log.Information("Vérification de la parution dans l'abonnement");
            return false;
        }


        ///<summary>
        /// Retrieve abonnement by its id
        /// </summary>
        public Abonnement retrieveAbonnementById(string id)
        {
            String jsonIdDocument = convertToJson("id", id);
            IEnumerable<Abonnement> abonnement = TraitementRecup<Abonnement>(GET, "abonnement/" + jsonIdDocument);
            Log.Information("Récupération de l'abonnement");
            return new List<Abonnement>(abonnement)[0];
        }

        /// <summary>
        /// add abonnement
        /// </summary>
        public bool AddAbonnement(Abonnement abonnement)
        {
            String jsonAbonnement = JsonConvert.SerializeObject(abonnement, new CustomDateTimeConverter());
            try
            {
                Console.WriteLine(jsonAbonnement);
                // récupération soit d'une liste vide (requête ok) soit de null (erreur)
                List<Abonnement> liste = TraitementRecup<Abonnement>(POST, "abonnement/" + jsonAbonnement);
                return (liste != null);
            }
            catch (Exception ex)
            {
                Log.Error("Erreur lors de l'ajout de l'abonnement : " + ex.Message);
                Console.WriteLine(ex.Message);
            }
            return false;
        }   


        /// <summary>
        /// get all abonnement revues 
        /// </summary>
        public List<Abonnement> GetAllAbonnements()
        {
            IEnumerable<Abonnement> abonnement = TraitementRecup<Abonnement>(GET, "abonnement");
            List<Abonnement> listeAbonnement = new List<Abonnement>(abonnement);
            Log.Information("Récupération des abonnements");

            return listeAbonnement;
          
        }

        /// <summary>
        /// search list exemplaire by id of the document
        /// </summary>
        public List<Exemplaire> SearchExemplaire(string idDocument)
        {
            String jsonIdDocument = convertToJson("id", idDocument);
            IEnumerable<Exemplaire> exemplaire = TraitementRecup<Exemplaire>(GET, "exemplaire/" + jsonIdDocument);
            Log.Information("Recherche des exemplaires");
            return new List<Exemplaire>(exemplaire);
        }





        /// <summary>
        /// ecriture d'un exemplaire en base de données
        /// </summary>
        /// <param name="exemplaire">exemplaire à insérer</param>
        /// <returns>true si l'insertion a pu se faire (retour != null)</returns>
        public bool CreerExemplaire(Exemplaire exemplaire)
        {
            String jsonExemplaire = JsonConvert.SerializeObject(exemplaire, new CustomDateTimeConverter());
            try {
                // récupération soit d'une liste vide (requête ok) soit de null (erreur)
                List<Exemplaire> liste = TraitementRecup<Exemplaire>(POST, "exemplaire/" + jsonExemplaire);
                return (liste != null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Log.Information("Création de l'exemplaire");
            return false; 
        }

   
        /// <summary>
        /// Traitement de la récupération du retour de l'api, avec conversion du json en liste pour les select (GET)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="methode">verbe HTTP (GET, POST, PUT, DELETE)</param>
        /// <param name="message">information envoyée</param>
        /// <returns>liste d'objets récupérés (ou liste vide)</returns>
        private List<T> TraitementRecup<T> (String methode, String message)
        {
            List<T> liste = new List<T>();
            try
            {
                JObject retour = api.RecupDistant(methode, message);
                // extraction du code retourné
                String code = (String)retour["code"];
                if (code.Equals("200"))
                {
                    // dans le cas du GET (select), récupération de la liste d'objets
                    if (methode.Equals(GET))
                    {
                        String resultString = JsonConvert.SerializeObject(retour["result"]);
                        // construction de la liste d'objets à partir du retour de l'api
                        liste = JsonConvert.DeserializeObject<List<T>>(resultString, new CustomBooleanJsonConverter());
                    }
                }
                else
                {
                    Log.Error("code erreur = " + code + " message = " + (String)retour["message"]); 
                    Console.WriteLine("code erreur = " + code + " message = " + (String)retour["message"]);
                }
            }catch(Exception e)
            {
                Log.Error("Erreur lors de l'accès à l'API : " + e.Message);
                Console.WriteLine("Erreur lors de l'accès à l'API : "+e.Message);
                Environment.Exit(0);
            }
            Log.Information("Traitement de la récupération");
            return liste;
        }

        /// <summary>
        /// Convertit en json un couple nom/valeur
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="valeur"></param>
        /// <returns>couple au format json</returns>
        private String convertToJson(Object nom, Object valeur)
        {
            Dictionary<Object, Object> dictionary = new Dictionary<Object, Object>();
            dictionary.Add(nom, valeur);
            return JsonConvert.SerializeObject(dictionary);
        }

        /// <summary>
        /// Modification du convertisseur Json pour gérer le format de date
        /// </summary>
        private sealed class CustomDateTimeConverter : IsoDateTimeConverter
        {
            public CustomDateTimeConverter()
            {
                base.DateTimeFormat = "yyyy-MM-dd";
            }
        }

        /// <summary>
        /// Modification du convertisseur Json pour prendre en compte les booléens
        /// classe trouvée sur le site :
        /// https://www.thecodebuzz.com/newtonsoft-jsonreaderexception-could-not-convert-string-to-boolean/
        /// </summary>
        private sealed class CustomBooleanJsonConverter : JsonConverter<bool>
        {
            public override bool ReadJson(JsonReader reader, Type objectType, bool existingValue, bool hasExistingValue, JsonSerializer serializer)
            {
                return Convert.ToBoolean(reader.ValueType == typeof(string) ? Convert.ToByte(reader.Value) : reader.Value);
            }

            public override void WriteJson(JsonWriter writer, bool value, JsonSerializer serializer)
            {
                serializer.Serialize(writer, value);
            }
        }

        public DateTime setDateFinAbonnement(string id)
        {
            List<Exemplaire> exemplaires = GetExemplairesRevue(id);
            DateTime dateFin = new DateTime();

            // for each exemplaire, we check if the date is the latest
            foreach (Exemplaire exemplaire in exemplaires)
            {
                if (exemplaire.DateAchat > dateFin)
                {
                    dateFin = exemplaire.DateAchat;
                }
            }
            Log.Information("Récupération de la date de fin de l'abonnement");
            return dateFin;
        }

        public Utilisateur checkLogin(string login, string password)
        {
            String jsonLogin = convertToJson("identifiant", login);
            IEnumerable<Utilisateur> user = TraitementRecup<Utilisateur>(GET, "utilisateur/" + jsonLogin);
            if (user.Count() == 0)
            {
                return null;
            }
            
            Utilisateur utilisateur = new List<Utilisateur>(user)[0];
            string userPassword = decryptPassword(utilisateur.password);
            if (userPassword.Equals(password))
            {
                return utilisateur;
            }
            Log.Information("Vérification du login");
            return null;
        }

        // two function to encrypt and decrypt the password
        private string hashPassword(string password)
        {
            string encryptedPassword = "";
            foreach (char c in password)
            {
                encryptedPassword += (char)(c + 1);
            }
            Log.Information("Chiffrement du mot de passe");
            return encryptedPassword;
        }

        private string decryptPassword(string password)
        {
            string decryptedPassword = "";
            foreach (char c in password)
            {
                decryptedPassword += (char)(c - 1);
            }
            Log.Information("Déchiffrement du mot de passe");
            return decryptedPassword;
        }

        


    }
}

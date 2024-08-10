using System.Reflection;

namespace MinimalApis
{
    public class Personne
    {
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        /// <summary>
        /// le .NET reconnais cette methode seulement si elle est public, static 
        /// et a un parametre d'entrer type string et parametre de sortie un bool 
        /// et un out type variable class
        /// </summary>
        /// <param variableDeEntrerTypestring="value"></param>
        /// <param variableDeSortieTypeClass="person"></param>
        /// <returns>un bool et un objet type Personne</returns>
        //public static bool TryParse(string value, out Personne? person)
        //{
        //    try
        //    {
        //        ///Split() elle permet de séparer les donnée selon 
        //        ///ce qui est spécifier entre les () et les metre dans un tableau

        //        var data = value.Split(' ');
        //        ///instanciation de la class Personne
        //        person = new Personne()
        //        {
        //            ///afectation des donnée spliter au proprieté de l'objet
        //            Nom = data[0],
        //            Prenom = data[1]
        //        };
        //        return true;

        //    }
        //    catch(Exception)
        //    {
        //        person = null;
        //        return false; 
        //    }
        //}


        /// <summary>
        /// le .NET reconnais cette methode  car elle fait partie de la convention devloppement des API
        /// HttpContext est une class qui vas nous permetre de gere  tout le contexte de la requette 
        /// la création de la varieble contexte vas nous permetre d'accéeder a des request precis 
        /// tel que le Header, le boddy ....
        /// </summary>
        /// <returns>Task personne </returns>


        //public static async ValueTask<Personne?> BindAsync(HttpContext context)
        //{
        //    try
        //    {
        //        ///Streamreader est une class qui permet de ouvrir,lire... des fichier 
        //        using var streamReader = new StreamReader(context.Request.Body);
        //        var body = await streamReader.ReadToEndAsync();

        //        var data = body.Split(' ');
        //        var person = new Personne
        //        {
        //            Nom = data[0],
        //            Prenom = data[1]
        //        };
        //        return person;

        //    }
        //    catch (Exception)
        //    {
        //        return null;

        //    }

        //}
    }
}

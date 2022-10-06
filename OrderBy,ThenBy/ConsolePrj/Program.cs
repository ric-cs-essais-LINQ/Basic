using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using Transverse.Common.DebugTools;

namespace zzzzzTestsRapides
{
    enum Grade
    {
        Low = 1,
        Medium= 2,
        High = 3
    }

    class Personne
    {
        public string Nom { get; set; }

        public DateTime? DateNaiss { get; set; }

        public Grade Grade { get; init; }
    }


    //------------------------------------------------------------------------

    static class Program
    {
        static void Main(string[] args)
        {
            var personnes = new[]
            {
                new Personne() { Nom = "NomZ", DateNaiss = DateTime.Parse("29/02/2012 10:24:00"), Grade = Grade.High},
                new Personne() { Nom = "NomZ", DateNaiss = DateTime.Parse("29/02/2012 10:24:00"), Grade = Grade.Low},
                new Personne() { Nom = "NomZ", DateNaiss = DateTime.Parse("30/08/2014 10:24:00"), Grade = Grade.Medium},
                new Personne() { Nom = "NomZ", DateNaiss = DateTime.Parse("30/08/2014 10:24:00"), Grade = Grade.Low},
                new Personne() { Nom = "NomZ", DateNaiss = DateTime.Parse("31/12/2011 10:24:00"), Grade = Grade.High},
                new Personne() { Nom = "NomZ", DateNaiss = DateTime.Parse("31/12/2011 10:24:00"), Grade = Grade.Medium},
                new Personne() { Nom = "NomZ", DateNaiss = DateTime.Parse("31/12/2011 10:28:00"), Grade = Grade.High},
                new Personne() { Nom = "NomZ", DateNaiss = DateTime.Parse("31/12/2011"), Grade = Grade.High},
                new Personne() { Nom = "NomZ", DateNaiss = DateTime.Parse("28/02/2015"), Grade = Grade.Low},

                new Personne() { Nom = "NomA", DateNaiss = DateTime.Parse("29/02/2012 10:24:00"), Grade = Grade.High},
                new Personne() { Nom = "NomA", DateNaiss = DateTime.Parse("29/02/2012 10:24:00"), Grade = Grade.Low},
                new Personne() { Nom = "NomA", DateNaiss = DateTime.Parse("30/08/2014 10:24:00"), Grade = Grade.Medium},
                new Personne() { Nom = "NomA", DateNaiss = DateTime.Parse("30/08/2014 10:24:00"), Grade = Grade.Low},
                new Personne() { Nom = "NomA", DateNaiss = DateTime.Parse("31/12/2011 10:24:00"), Grade = Grade.High},
                new Personne() { Nom = "NomA", DateNaiss = DateTime.Parse("31/12/2011 10:24:00"), Grade = Grade.Medium},
                new Personne() { Nom = "NomA", DateNaiss = DateTime.Parse("31/12/2011 10:28:00"), Grade = Grade.High},
                new Personne() { Nom = "NomA", DateNaiss = DateTime.Parse("31/12/2011"), Grade = Grade.High},
                new Personne() { Nom = "NomA", DateNaiss = DateTime.Parse("28/02/2015"), Grade = Grade.Low},

            };

            //---------------------------------------------
            Console.WriteLine("\n---- Liste des personnes triée par :  Nom, Grade, DateNaiss(Décroiss.) -  Tri via syntaxe correcte ----\n\n");
            Console.WriteLine(" La syntaxe correcte : personnes.OrderBy(p => p.Nom).ThenBy(p => p.Grade).ThenByDescending(p => p.DateNaiss).ToList()");
            Console.WriteLine("  ATTENTION : pour les dates, ne pas faire  ...By(p => p.DateNaiss.ToString()), sinon tri incorrect");
            Console.WriteLine("              (du fait du ToString() donc)!");
            Console.ReadKey();

            Debug.ShowData(
                personnes.OrderBy(p => p.Nom).ThenBy(p => p.Grade).ThenByDescending(p => p.DateNaiss).ToList()
            );

            //---------------------------------------------
            Console.WriteLine("\n\n\n---- Liste des personnes triée par : Nom, Grade, DateNaiss(Décroiss.) -  Tri via syntaxe rendant le tri FAUX ----\n\n");
            Console.WriteLine("    personnes.OrderBy(p => p.Nom).OrderBy(p => p.Grade).OrderByDescending(p => p.DateNaiss).ToList()");
            Console.WriteLine(" En fait avec ce genre de syntaxe (A BANNIR) : il considère uniqt le dernier tri, à savoir ici : ");
            Console.WriteLine("  OrderByDescending(p => p.DateNaiss)\n\n");
            Console.ReadKey();

            Debug.ShowData(
                personnes.OrderBy(p => p.Nom).OrderBy(p => p.Grade).OrderByDescending(p => p.DateNaiss).ToList()
            );





            //-------------------------------- Tri de strings en mode 'Case insensitive' --------------------------------------------------------------------------------------
            var autresPersonnes = new[]
            {
                new Personne() { Nom = "aaa", Grade = Grade.High},
                new Personne() { Nom = "aaa", Grade = Grade.Low},
                new Personne() { Nom = "AAA", Grade = Grade.High},
                new Personne() { Nom = "AAA", Grade = Grade.Medium},
                new Personne() { Nom = "aaa", Grade = Grade.High},
                new Personne() { Nom = "aaa", Grade = Grade.Low},
            };
            Console.WriteLine("\n\n\n---- Liste d'autres personnes, triée par : Nom(minuscucle donc case insensitive), Grade ----\n\n");
            Console.WriteLine("   personnes2.OrderBy(p => p.Nom.ToLower()).ThenBy(p => p.Grade).ToList()\n\n");
            Console.WriteLine(" On voit que du fait du ToLower(pour le case insensitive donc) sur le Nom, ");
            Console.WriteLine(" il considère 'aaa' et 'AAA' comme tout à fait identiques.");
            Console.WriteLine(" Du coup il ne trie au final dans cet eexemple, que par Grade !");
            Console.ReadKey();


            Debug.ShowData(
                autresPersonnes.OrderBy(p => p.Nom.ToLower()).ThenBy(p => p.Grade).ToList()
            );


            //----------------------------------------------
            Console.WriteLine("\n\nOK");  Console.ReadKey();
        }
    }
}

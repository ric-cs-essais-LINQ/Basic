using System;
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

        public Grade Grade { get; init; }
    }


    //------------------------------------------------------------------------

    static class Program
    {
        static void Main(string[] args)
        {
            var personnes = new[]
            {
                new Personne() { Nom = "NomI", Grade = Grade.Low},
                new Personne() { Nom = "NomA", Grade = Grade.High},
                new Personne() { Nom = "NomF", Grade = Grade.Medium},
                new Personne() { Nom = "NomC", Grade = Grade.Medium},
                new Personne() { Nom = "NomB", Grade = Grade.Low},
                new Personne() { Nom = "NomD", Grade = Grade.Low},
                new Personne() { Nom = "NomG", Grade = Grade.High},
                new Personne() { Nom = "NomH", Grade = Grade.High},
                new Personne() { Nom = "NomE", Grade = Grade.High},

                new Personne() { Nom = "NomR", Grade = Grade.Low},
                new Personne() { Nom = "NomJ", Grade = Grade.High},
                new Personne() { Nom = "NomP", Grade = Grade.High},
                new Personne() { Nom = "NomK", Grade = Grade.Low},
                new Personne() { Nom = "NomQ", Grade = Grade.High},
                new Personne() { Nom = "NomL", Grade = Grade.Medium},
                new Personne() { Nom = "NomM", Grade = Grade.Low},
                new Personne() { Nom = "NomO", Grade = Grade.Medium},
                new Personne() { Nom = "NomN", Grade = Grade.High},

            };

            //---------------------------------------------
            Console.WriteLine("\n---- Liste des personnes regroupées par Grade (une sous-liste de personnes par Grade) ----\n\n");
            Console.ReadKey();

            Debug.ShowData(
                personnes
                    .GroupBy(personne => personne.Grade).ToList() //LA RESULTANTE est un tableau, donc chaque élément est un SOUS-TABLEAU contenant : toutes les Personne ayant le même Grade.
            );


            //---------------------------------------------
            Console.WriteLine("\n---- Liste des personnes regroupées par Grade (une sous-liste de personnes par Grade) - Triée par Grade, NomPersonne ----\n\n");
            Console.ReadKey();

            Debug.ShowData(
                personnes.OrderBy(personne => personne.Grade).ThenBy(personne => personne.Nom)
                    .GroupBy(personne => personne.Grade).ToList()  //LA RESULTANTE est un tableau, donc chaque élément est un SOUS-TABLEAU contenant : toutes les Personne ayant le même Grade.
            );


            //----------------------------------------------
            Console.WriteLine("\n\nOK");  Console.ReadKey();
        }
    }
}

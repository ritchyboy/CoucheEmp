using System;
using System.Collections.Generic;
using System.Linq;

namespace Nothing
{
    public class Employer
    {
        Random rdn = new Random();
        public string Name;
        public string Poste;
        public int IdEmployer;
        public static int index = 0;
        public int nb;
        public Employer()
        {

        }
        public Employer(string Name, string Poste)
        {
            this.nb = index;
            this.Name = Name;
            this.Poste = Poste;
            this.IdEmployer = rdn.Next(0000001, 9999999);
            index++;
        }
        public void AfficherEmployer()
        {
            Console.WriteLine("Index: " + nb);
            Console.WriteLine("Numero d'employer: " + IdEmployer);
            Console.WriteLine("Nom de employer: " + Name);
            Console.WriteLine("Poste de l'employe: " + Poste);
            Console.WriteLine();

        }
        public void MessageColor(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message, color);
            Console.ResetColor();
        }
    }



    class Program
    {
        static void Menu()
        {
            Console.WriteLine("-------------------Menu------------------");
            Console.WriteLine("1.Ajouter un employe");
            Console.WriteLine("2.Retirer un employe");
            Console.WriteLine("3.Afficher les employes");
            Console.WriteLine("4.Vider l'affichage");
            Console.WriteLine();
        }
        static void messageC(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message, color);
            Console.ResetColor();
        }
        static void NullLength(string name, string message)
        {

        }
        static void NullLength(string name, string message1, string message2)
        {
            while (string.IsNullOrEmpty(name) || name.Length <= 1)
            {
                if (string.IsNullOrEmpty(name))
                {
                    messageC(message1, ConsoleColor.Red);
                    name = Console.ReadLine().ToUpper().Trim();
                }
                else if (name.Length <= 1)
                {
                    messageC(message2, ConsoleColor.Yellow);
                    name = Console.ReadLine().ToUpper().Trim();
                }
            }

        }
            static void Main(string[] args)
            {
                var EmploiList = new List<Employer>();
                Menu();
                while (true)
                {
                    try
                    {
                        int choix = int.Parse(Console.ReadLine());
                        if (choix == 1)
                        {
                            Console.WriteLine("Le nom du nouveau : ");
                            string Name = Console.ReadLine().ToUpper().Trim();
                            NullLength(Name, "Il n'y pas de nom", "Le nom est trop petit");
                            Console.WriteLine("Candidat peut etre caissier,commis,gerant,assistant senior,commis senior,assistant gerant");
                            Console.WriteLine("Le poste du nouvelle arrivant : ");
                            string Poste = Console.ReadLine().ToUpper().Trim();
                            if (Poste == "CAISSIER" || Poste == "COMMIS" || Poste == "GERANT" || Poste == "ASSISTANT SENIOR" || Poste == "COMMIS SENIOR" || Poste == "ASSISTANT GERANT")
                            {
                                messageC("Bienvenue a " + Name + "! en tant que " + Poste + "!", ConsoleColor.Green);
                                var NewEmp1 = new Employer(Name, Poste);
                                EmploiList.Add(NewEmp1);
                            }
                            else
                            {
                                while (Poste != "CAISSIER" || Poste != "COMMIS" || Poste != "GERANT" || Poste != "ASSISTANT SENIOR" || Poste != "COMMIS SENIOR" || Poste != "ASSISTANT GERANT" || string.IsNullOrEmpty(Poste))
                                {
                                    messageC("LES POSTES SONT: CAISSIER, COMMIS, GERANT, ASSISANT SENIOR, COMMIS SENIOR ET ASSISTANT GERANT", ConsoleColor.Yellow);
                                    Poste = Console.ReadLine().ToUpper().Trim();
                                    if (Poste == "CAISSIER" || Poste == "COMMIS" || Poste == "GERANT" || Poste == "ASSISTANT SENIOR" || Poste == "COMMIS SENIOR" || Poste == "ASSISTANT GERANT")
                                    {
                                        messageC("Bienvenue a " + Name + "! en tant que " + Poste + "!", ConsoleColor.Green);
                                        var NewEmp1 = new Employer(Name, Poste);
                                        EmploiList.Add(NewEmp1);
                                        break;
                                    }
                                    else if (string.IsNullOrEmpty(Poste))
                                    {
                                        messageC("Il n'y a pas de poste ecris", ConsoleColor.Red);
                                    }
                                }
                            }
                        }
                        else if (choix == 2)
                        {
                            bool getmeout = true;
                            while (getmeout)
                            {
                                try
                                {

                                    Console.WriteLine("Effacer par l'index ou pour annuler mettre -1 ");
                                    int numero = int.Parse(Console.ReadLine());
                                    foreach (var Employer in EmploiList)
                                    {
                                        if (numero == Employer.nb)
                                        {
                                            EmploiList.RemoveAt(Employer.nb);
                                            messageC("Il a ete effacer", ConsoleColor.Green);
                                            getmeout = false;
                                            break;
                                        }
                                        else if (numero == -1)
                                        {
                                            messageC("Action annuler", ConsoleColor.Yellow);
                                            getmeout = false;
                                            break;
                                        }
                                    }
                                }
                                catch
                                {
                                    messageC("Ne ce trouve pas dans l'index", ConsoleColor.Red);
                                }

                            }
                        }


                        else if (choix == 3)
                        {
                            Console.Clear();
                            Console.WriteLine("Le nombre d'employe est de : " + EmploiList.Count());
                            foreach (var Employer in EmploiList)
                            {
                                Employer.AfficherEmployer();

                            }
                        }
                        else if (choix == 4)
                        {
                            Console.Clear();
                        }
                        else if (choix > 4 || choix < 1)
                        {
                            messageC("Cela ne fait pas partie des choix", ConsoleColor.Red);
                        }
                        Menu();
                    }
                    catch
                    {
                        messageC("Entrer un des choix afficher", ConsoleColor.Red);

                    }
                }

            }
        

    }
}


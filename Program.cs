using System;
using System.Collections.Generic;

namespace GIocodellaSigaretta
{
    class Program
    {
        static void Main(string[] args)
        {
            SystemGame Informations = new SystemGame();
            DateTime Clock = new DateTime();
            //dichiarazione delle variabili di game
            int MinPlayersPossible = Informations.minPlayer;
            int MaxPlayersAvailable = Informations.maxPlayer;
            int DeadlinePlayerAvailable = Informations.deadlineNumPlayer;
            Console.WriteLine("--Gioco della sigaretta v1.0 Realizzato da Stefano Troisi--");
            Console.WriteLine("Github@STProgramming repository Giocodellasigaretta");
            Greetings(Informations.Greeting, Clock.Hour);
            Console.WriteLine("In quanti siete a giocare? da " + MinPlayersPossible + " a " + MaxPlayersAvailable);
            NumberOfPlayers Number = new NumberOfPlayers(InsertNumPlayers(MinPlayersPossible, MaxPlayersAvailable, DeadlinePlayerAvailable));
            int NumPlayerSelected = Number.GetNumPlayers();
            howToPlay();
            Player InfoPlayer = new Player(InsertPlayersNames(NumPlayerSelected));
            Console.WriteLine("Ok Iniziamo il gioco:");
            Console.ReadLine();
            Console.Clear();
            Answer Contents = new Answer(ListQuestionsTakingAnswers(Informations.allQuestions, InfoPlayer.GetPlayerNames()));
            Console.WriteLine("Ok abbiamo finito il turno. Siete pronti per leggere la storia creata con tutte le vostre risposte? Dai che vi tagliate");
            Console.ReadLine();
            List<string> PlayersAnswers = Contents.GetAllTheAnswers();
            ReturnAllTheStory(Informations.allQuestions, PlayersAnswers);
        }
        public static void Greetings(string greeting, int hour)
        {
            int morging_start = 5;
            int afternoon_start = 12;
            int evening_start = 18;
            int night_start = 0;
            string goodmorning = "una buona mattinata";
            string goodafternoon = "un buon pomeriggio";
            string goodevening = "una buona serata";
            string goodnight = "una buona nottata";
            string company = " con i tuoi amici.";

            if (morging_start <= hour && hour > afternoon_start)
            {
                Console.WriteLine(greeting + goodmorning + company);
            }
            else if (afternoon_start <= hour && hour > evening_start)
            {
                Console.WriteLine(greeting + goodafternoon + company);
            }
            else if (evening_start <= hour && hour > night_start)
            {
                Console.WriteLine(greeting + goodevening + company);
            }
            else
            {
                Console.WriteLine(greeting + goodnight + company);
            }
        }
        public static int InsertNumPlayers(int min, int max, int limit)
        {
            int numPlayers;
            numPlayers = Convert.ToInt32(Console.ReadLine());
            while(numPlayers < min || numPlayers > max)
            {
                if(numPlayers > limit)
                {
                    Console.WriteLine("E la mado', ma quanti siete? Metteteve la mascherina se no vi prendo a calci");
                }
                Console.WriteLine("Mi spiace ma non si può giocare in " + numPlayers + ". Dovete essere da " + min + " a " + max);
            }
            return numPlayers;
        }
        public static void howToPlay()
        {
            Console.WriteLine("Bene ora che ci siamo tutti...");
            Console.WriteLine("Sapete come si gioca? ");
            string answer = Console.ReadLine();
            switch (answer)
            {
                case "si":
                    Console.WriteLine("Meno male non mi andava di spiegare..");
                    break;

                case "no":
                    Console.WriteLine("Ok.. A turno verrete chiamati e vi verra' posta una domanda. Risponderete la prima cosa che vi viene in mente. Finite le domande provvedero' a riproporvi tutte le vostre risposte strampalate. Una regola FONDAMENTALE non sbirciate.. Apparte che non vale la pena ma vi rovinerete l'effetto sorpresa.");
                    break;

                default:
                    Console.WriteLine("Dovete rispondere si o no. Mo vi attaccate vi chiamero' a turno e non dovete sbirciare quello che scrivete");
                    break;
            }
        }
        public static List<string> InsertPlayersNames(int selectednum)
        {
            List<string> PlayersNames = new List<string>();
            string UserInput;
            Console.WriteLine("OK inserite i vostri nomi");
            for(int i = 1; i <= selectednum; i ++)
            {
                Console.WriteLine("OK tocca al " + i + "* tra di voi");
                UserInput = Console.ReadLine();
                PlayersNames.Add(UserInput);
            }
            return PlayersNames;
        }
        public static List<string> ListQuestionsTakingAnswers(List<string> questions, List<string> names)
        {
            List<string> PlayerAnswers = new List<string>();
            string UserInput;
            int SizeList = questions.Count;
            Random rand = new Random();
            //clico che stampa solo le domande
            for(int i = 0; i < SizeList ; i++)
            {
                int j = rand.Next(i, SizeList);
                Console.WriteLine(questions[j]);
            }
            return PlayerAnswers;
        }
        public static void ReturnAllTheStory(List<string> questions, List<string> answers)
        {
            int SizeList = questions.Count;
            for(int i = 0 ; i < SizeList ; i++)
            {
                Console.WriteLine(questions[i] + "\n" + answers[i]);
            }
        }
    }
    class Answer
    {
        List<string> AllTheAnswers = new List<string>();
        public Answer (List<string> answer)
        {
            foreach(string content in answer)
            {
                AllTheAnswers.Add(content);
            }
        }
        public List<string> GetAllTheAnswers()
        {
            return AllTheAnswers;
        }
    }
    class Player
    {
        List<string> PlayersNames = new List<string>();
        public Player (List<string> PlayersName)
        {
            foreach(string Name in PlayersName)
            {
                PlayersNames.Add(Name);
            }
        }

        public List<string> GetPlayerNames()
        {
            return PlayersNames;
        }
    }
    public class NumberOfPlayers
    {
        private int NumPlayers;
        public NumberOfPlayers(int number)
        {
            NumPlayers = number;
        }
        public int GetNumPlayers()
        {
            return NumPlayers;
        }
    }
    public class SystemGame
    {
        public readonly List<string> allQuestions = new List<string> { "Chi?", "Con Chi?", "Cosa fanno?", "Dove?", "Perchè?", "Ma sopra o sotto?", "Chi ha vinto?", "Chi ha perso?", "Infine?", "Ma perchè proprio sta cosa?", "Chi lo ha fatto a chi?", "Sì, ma perche?", "Chi lo ha fatto con Silvio Berlusconi?", "Come l'ha presa?", "Chi e' stato con Maria De Filippi?" };
        public readonly int minPlayer = 2;
        public readonly int maxPlayer = 12;
        public readonly int deadlineNumPlayer = 20;
        public string Greeting = ("Ciao benvenuto nel gioco della sigaretta impiccione. Niente gioca e passa ");
    }
}

using System;
using System.Collections.Generic;

namespace GIocodellaSigaretta
{
    class Program
    {
        static void Main(string[] args)
        {
            Game Rules = new Game();
            Contents gameContents = new Contents();
            Console.WriteLine("Hello World!");
            Console.WriteLine("In quanti siete a giocare? da " + Rules.minPlayer + " a " + Rules.maxPlayer);
            insertNumPlayers();
            howToPlay();
            insertNamePlayers();
            Console.WriteLine("Ok Iniziamo il gioco:");
            Console.ReadLine();
            Console.Clear();
            listQuestionTakeAnswer();
        }
        public static void insertNumPlayers()
        {
            Game Rules = new Game();
            int numPlayers;
            numPlayers = Convert.ToInt32(Console.ReadLine());
            while(numPlayers < Rules.minPlayer || numPlayers > Rules.maxPlayer)
            {
                if(numPlayers > Rules.deadlineNumPlayer)
                {
                    Console.WriteLine("E la mado', ma quanti siete? Metteteve la mascherina se no vi prendo a calci");
                }
                Console.WriteLine("Mi spiace ma non si può giocare in " + numPlayers + ". Dovete essere da " + Rules.minPlayer + " a " + Rules.maxPlayer);
                numPlayers = Convert.ToInt32(Console.ReadLine());
            }
            Rules.SetnumPlayer(numPlayers);
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
        public static void insertNamePlayers()
        {
            Game Rules = new Game();
            string namePlayer;
            Console.WriteLine("OK inserite i vostri nomi");
            for(int i = 0; i < Rules.GetnumPlayer(); i ++)
            {
                Console.WriteLine("OK tocca al " + i + "* tra di voi");
                namePlayer = Console.ReadLine();
                Rules.SetnamePlayers(namePlayer);
            }
        }
        public static void listQuestionTakeAnswer ()
        {
            Game Rules = new Game();
            Contents gameContent = new Contents();
            Random rand = new Random();
            string answerPlayer;
            for(int i = 0; i < gameContent.allQuestions.Length; i++)
            {
                int j = rand.Next(i, gameContent.allQuestions.Length);
                Console.WriteLine(gameContent.allQuestions[j]);
                Console.WriteLine("risponde " + Rules.GetnamePlayers());
                answerPlayer = Console.ReadLine();
                gameContent.SetallAnswer(answerPlayer);
                Console.Clear();
            }
        }
    }
    class Player
    {
        List<string> PlayersNames = new List<string>();
        List<string> AllTheAnswers = new List<string>();
        public Player (string PlayerName, string Answer)
        {
            PlayersNames.Add(PlayerName);
            AllTheAnswers.Add(Answer);
        }
    }
    public class Contents
    {
        public string[] allQuestions = new string[15] { "Chi?", "Con Chi?", "Cosa fanno?", "Dove?", "Perchè?", "Ma sopra o sotto?", "Chi ha vinto?", "Chi ha perso?", "Infine?", "Ma perchè proprio sta cosa?", "Chi lo ha fatto a chi?", "Sì, ma perche?", "Chi lo ha fatto con Silvio Berlusconi?", "Come l'ha presa?", "Chi e' stato con Maria De Filippi?" };
        private List<string> allAnswers = new List<string>();
        public void SetallAnswer (string Answers)
        {
            allAnswers.Add(Answers);
        }
    }
    public class Game
    {
        public int minPlayer = 2;
        public int maxPlayer = 12;
        public int deadlineNumPlayer = 20;
        private int numPlayer;
        private List<string> namePlayers = new List<string>();
        //creazione metodi per i campi
        //i campi devono poter viaggiare senza alcun intoppo 
        //prevedo, quindi l'uso di 2 metodi per ciascun campo
        //un get e set per questi campi importanti

        //metodi campo numPlayer
        public int GetnumPlayer()
        {
            return numPlayer;
        }

        public void SetnumPlayer(int numPlayers)
        {
            numPlayer = numPlayers;
        }

        //metodi campo namePlayers
        public List<string> GetnamePlayers()
        {
            return namePlayers;
        }

        public void SetnamePlayers(string Names)
        {
            namePlayers.Add(Names);
        }
    }
}

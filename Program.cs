using System;
using System.Collections.Generic;

namespace GIocodellaSigaretta
{
    class Program
    {
        static void Main(string[] args)
        {
            Game Rules = new Game();
            Console.WriteLine("Hello World!");
            Console.WriteLine("In quanti siete a giocare? da " + Rules.minPlayer + " a " + Rules.maxPlayer);
            Rules.numPlayer = insertNumPlayers(Rules.numPlayer);
            howToPlay();
            Rules.namePlayers = insertNamePlayers(Rules.namePlayers);
            Console.WriteLine("Ok Iniziamo il gioco:");
            Console.ReadLine();
            Console.Clear();
            listQuestionTakeAnswer();
        }
        public static int insertNumPlayers(int defaulNumPlayer)
        {
            Game Rules = new Game();
            int numPlayer;
            numPlayer = Convert.ToInt32(Console.ReadLine());
            while(numPlayer < Rules.minPlayer || numPlayer > Rules.maxPlayer)
            {
                if(numPlayer > Rules.deadlineNumPlayer)
                {
                    Console.WriteLine("E la mado', ma quanti siete? Metteteve la mascherina se no vi prendo a calci");
                }
                Console.WriteLine("Mi spiace ma non si può giocare in " + numPlayer + ". Dovete essere da " + Rules.minPlayer + " a " + Rules.maxPlayer);
                numPlayer = Convert.ToInt32(Console.ReadLine());
            }
            return numPlayer;
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
        public static List<string> insertNamePlayers (List<string> defaultNamePlayer)
        {
            Game Rules = new Game();
            string namePlayer;
            for(int i = 0; i < Rules.numPlayer; i ++)
            {
                Console.WriteLine("OK tocca al " + i + "* tra di voi");
                namePlayer = Console.ReadLine();
                Rules.namePlayers.Add(namePlayer);
            }
            return Rules.namePlayers;
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
                Console.WriteLine("risponde " + Rules.namePlayers);
                answerPlayer = Console.ReadLine();
                gameContent.allAnswers.Add(answerPlayer);
                Console.Clear();
            }
        }
    }
    public class Contents
    {
        public string[] allQuestions = new string[15] { "Chi?", "Con Chi?", "Cosa fanno?", "Dove?", "Perchè?", "Ma sopra o sotto?", "Chi ha vinto?", "Chi ha perso?", "Infine?", "Ma perchè proprio sta cosa?", "Chi lo ha fatto a chi?", "Sì, ma perche?", "Chi lo ha fatto con Silvio Berlusconi?", "Come l'ha presa?", "Chi e' stato con Maria De Filippi" };
        public List<string> allAnswers = new List<string>();
    }
    public class Game
    {
        public int minPlayer = 2;
        public int maxPlayer = 12;
        public int deadlineNumPlayer = 20;
        public int numPlayer;
        public List<string> namePlayers = new List<string>();
    }
}

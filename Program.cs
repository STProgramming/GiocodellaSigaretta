using System;

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
            bool response = false;
        }
        public static int insertNumPlayers(int defaulNumPlayer)
        {
            Game Rules = new Game();
            int numPlayer;
            numPlayer = Convert.ToInt32(Console.ReadLine());
            while(numPlayer < Rules.minPlayer || numPlayer > Rules.maxPlayer)
            {
                Console.WriteLine("Mi spiace ma non si può giocare in " + numPlayer + ". Dovete essere da " + Rules.minPlayer + " a " + Rules.maxPlayer);
                numPlayer = Convert.ToInt32(Console.ReadLine());
            }
            return numPlayer;
        }
        public static bool howToPlay()
        {
            Console.WriteLine("Bene ora che ci siamo tutti...");
            Console.WriteLine("Sapete come si gioca? ");
            string answer = Console.ReadLine();
            bool flagAnswer = false;
            while (flagAnswer == false)
            {

            }
        }

    }
    
    public class Question
    {
        public string questionOne = "Chi?";
        public string questionTwo = "Con Chi?";
        public string questionThree = "Cosa fanno?";
        public string questionFour = "Dove?";
        public string questionFive = "Perchè?";
        public string questionSix = "Ma sopra o sotto?";
        public string questionSeven = "Chi ha vinto?";
        public string questionEight = "Chi ha perso?";
        public string questionNine = "Infine?";
        public string questionTen = "Ma perchè proprio sta cosa?";
        public string questionEleven = "Chi lo ha fatto a chi?";
        public string questionTwelve = "Sì, ma perche?";
        public string questionThirteen = "Chi lo ha fatto con Silvio Berlusconi?";
        public string questionFourteen = "Come l'ha presa?";
    }

    public class Game
    {
        public int minPlayer = 2;
        public int maxPlayer = 12;
        public int numPlayer;
        public string[] namePlayers = new string[numPlayer];
    }
}

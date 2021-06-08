using System;
using System.Globalization;
using System.Collections.Generic;

namespace GIocodellaSigaretta
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--Gioco della sigaretta vers 1.0 ora in beta. Realizzato da Stefano Troisi--");
            Console.WriteLine("Github@STProgramming repository Giocodellasigaretta");
            string UsersTryAgain = "si";
            do
            {
                SystemGame Informations = new SystemGame();
                var Clock = Convert.ToInt32(DateTime.Now.ToString("HH"));
                //dichiarazione delle variabili di game
                int MinPlayersPossible = Informations.minPlayer;
                int MaxPlayersAvailable = Informations.maxPlayer;
                int DeadlinePlayerAvailable = Informations.deadlineNumPlayer;
                Greetings(Informations.Greeting, Clock);
                Console.WriteLine("In quanti siete a giocare? da " + MinPlayersPossible + " a " + MaxPlayersAvailable);
                NumberOfPlayers Number = new NumberOfPlayers(InsertNumPlayers(MinPlayersPossible, MaxPlayersAvailable, DeadlinePlayerAvailable));
                howToPlay();
                int SelectedMode = GameModeSelect(Informations.NormalMode, Informations.AdventureMode);
                Player InfoPlayer = new Player(InsertPlayersNames(Number.GetNumPlayers()));
                Console.WriteLine("Ok Iniziamo il gioco:");
                Console.ReadLine();
                Console.Clear();
                List<string> answers = new List<string>();
                List<int> logquest = new List<int>();
                if (SelectedMode == Informations.NormalMode)
                {
                    (answers, logquest) = ListQuestionsTakingAnswers(Informations.allQuestions, InfoPlayer.GetPlayerNames());
                }
                else
                {
                    int QuestionNumber = HowManyQuestions(Informations.TenQuestions, Informations.TwentyQuestions, Informations.ThirtyQuestion, Informations.NormalMode, Informations.AdventureMode);
                    (answers, logquest) = ListRandomQuestionsTakingAnswers(Informations.allQuestions, InfoPlayer.GetPlayerNames(), QuestionNumber);
                }
                Answer Contents = new Answer(answers);
                QuestionsLog Ids = new QuestionsLog(logquest);
                Console.WriteLine("Ok abbiamo finito il turno. Siete pronti per leggere la storia creata con tutte le vostre risposte? Dai che vi tagliate");
                Console.ReadLine();
                ReturnAllTheStory(Informations.allQuestions, Contents.GetAllTheAnswers(), Ids.GetQuestionsLog());
                Console.WriteLine(Informations.CloseGreeting);
                UsersTryAgain = Console.ReadLine();
            }
            while (UsersTryAgain == "si");
            Console.WriteLine("Ciao alla prossima");
        }
        public static void Greetings(string greeting, int hour)
        {
            int morging_start = 5;
            int afternoon_start = 12;
            int evening_start = 18;
            int night_start = 23;
            string goodmorning = "una buona mattinata";
            string goodafternoon = "un buon pomeriggio";
            string goodevening = "una buona serata";
            string goodnight = "una buona nottata";
            string company = " con i tuoi amici.";

            if(morging_start <= hour && afternoon_start > hour)
            {
                Console.WriteLine(greeting + goodmorning + company);
            }
            else if (afternoon_start <= hour && evening_start > hour)
            {
                Console.WriteLine(greeting + goodafternoon + company);
            }
            else if(evening_start <= hour && night_start > hour)
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
            int numPlayers = 0;
            try
            {
                numPlayers = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Inserisci solo numeri");
            }
            while(numPlayers < min || numPlayers > max)
            {
                if(numPlayers > limit)
                {
                    Console.WriteLine("E la mado', ma quanti siete? Metteteve la mascherina se no vi prendo a calci");
                }
                Console.WriteLine("Mi spiace ma non si può giocare in " + numPlayers + ". Dovete essere da " + min + " a " + max);
                numPlayers = Convert.ToInt32(Console.ReadLine());
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
        public static int GameModeSelect(int NormalMode, int AdventureMode)
        {
            int ModeSelected = 0;
            do
            {
                Console.WriteLine("Seleziona la modalità di gioco:\n 1) Per la modalità normale, 2) Per la modalità avventura");
                try
                {
                    ModeSelected = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Inserisci solo numeri");
                }
            }
            while (NormalMode > ModeSelected || ModeSelected > AdventureMode);
            return ModeSelected;
        }
        public static int HowManyQuestions(int tenquestion, int twentyquestions, int thirtyquestions, int NormalMode, int AdventureMode)
        {
            int QuestionSelected = 0;
            do
            {
                Console.WriteLine("Seleziona quante domande vuoi che vi vengano fatte:\n 1) 10 2) 20");
                try
                {
                    QuestionSelected = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Inserisci solo numeri");
                }
            }
            while (NormalMode > QuestionSelected || QuestionSelected > AdventureMode);
            if(QuestionSelected == NormalMode)
            {
                return tenquestion;
            }
            else
            {
                return twentyquestions;
            }
        }
        public static List<string> InsertPlayersNames(int selectednum)
        {
            List<string> PlayersNames = new List<string>();
            string UserInput;
            Console.WriteLine("Ok scrivete i vostri nomi");
            for(int i = 1; i <= selectednum; i ++)
            {
                Console.WriteLine("Tocca al " + i + "*");
                UserInput = Console.ReadLine();
                PlayersNames.Add(UserInput);
            }
            return PlayersNames;
        }
        public static (List<string>, List<int>) ListQuestionsTakingAnswers(List<string> questions, List<string> names)
        {
            List<string> PlayerAnswers = new List<string>();
            List<int> QuestionsExtraction = new List<int>();
            int MajorSize = 6;
            int sizelist = names.Count;
            int x = 0;
            string UserInput;
            Random rand = new Random();
            for (int i = 0; i < MajorSize; i++)
            {
                QuestionsExtraction.Add(i);
                Console.WriteLine(questions[i]);
                if(x == sizelist)
                {
                    x = 0;
                }
                Console.WriteLine("Tocca a " + names[x]);
                x++;
                do
                {
                    UserInput = Console.ReadLine();
                    Console.WriteLine("Stai a fa il timido ? Muoviti a rispondere");
                }
                while (String.IsNullOrEmpty(UserInput));
                Console.Clear();
                PlayerAnswers.Add(UserInput);
            }
            return (PlayerAnswers, QuestionsExtraction);
        }
        public static (List<string>, List<int>) ListRandomQuestionsTakingAnswers(List<string> questions, List<string> names, int QuestionNumber)
        {
            List<string> PlayerAnswers = new List<string>();
            List<int> QuestionsExtraction = new List<int>();
            int MajorSize = QuestionNumber;
            int sizelist = names.Count;
            int FirstInRow = 0;
            int x = 0;
            int j = 0;
            string UserInput;
            Random rand = new Random();
            for(int i = 0; i < MajorSize ; i++)
            {
                if(x == sizelist) 
                {
                    x = 0;
                }
                do
                {
                    j = rand.Next(FirstInRow, MajorSize);
                }
                while (QuestionsExtraction.Contains(j));
                QuestionsExtraction.Add(j);
                Console.WriteLine(questions[j]);
                Console.WriteLine("Tocca a " + names[x]);
                x++;
                UserInput = Console.ReadLine();
                if(String.IsNullOrEmpty(UserInput))
                {
                    Console.WriteLine("Stai a fa il timido ? Muoviti a rispondere");
                    UserInput = Console.ReadLine();
                }
                Console.Clear();
                PlayerAnswers.Add(UserInput);
            }
            return (PlayerAnswers, QuestionsExtraction);
        }
        public static void ReturnAllTheStory(List<string> questions, List<string> answers, List<int> idquestion)
        {
            //TODO creare un convertitore dove mi a salvare in una list tutti i j estratti e poi li vado a richiamare in fase di stampa

            int SizeList = answers.Count;
            for(int i = 0 ; i < SizeList ; i++)
            {
                int shuffle = idquestion[i];
                Console.WriteLine(questions[shuffle]);
                Console.WriteLine(answers[i]);
            }
        }
    }
    class Answer
    {
        List<string> AllTheAnswers = new List<string>();
        public Answer(List<string> PlayersAnswer)
        {
            foreach (string Name in PlayersAnswer)
            {
                AllTheAnswers.Add(Name);
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
    public class QuestionsLog
    {
        List<int> QuestionsId = new List<int>();
        public QuestionsLog (List<int> QuestionsNumber)
        {
            foreach(int Id in QuestionsNumber)
            {
                QuestionsId.Add(Id);
            }
        }

        public List<int> GetQuestionsLog()
        {
            return QuestionsId;
        }
    }
    public class SystemGame
    {
        public readonly List<string> allQuestions = new List<string> { "Chi?", "Con Chi?", "Cosa fanno?", "Dove?", "Quando?" , "Perchè?", "Sopra o sotto?", "Chi ha vinto?", "Chi ha perso?", "In quale setta?", "Chi li minacciava?", "Come lo ha fatto?", "Per quale motivo ha dovuto seppellirlo?", "Chi lo ha fatto con Silvio Berlusconi?", "Come l'ha presa?", "Chi e' stato con Maria De Filippi?", "Perchè proprio Jerry Scotti?", "Perchè era storto?", "Chi pensi che sia stato?", "Cosa pensi ci sia nella tasca di Silvio?", "Chi pensi sia stato ad uccidere l'uomo ragno?", "In quale posizione?" };
        public readonly int minPlayer = 2;
        public readonly int maxPlayer = 6;
        public readonly int deadlineNumPlayer = 20;
        public readonly int TenQuestions = 10;
        public readonly int TwentyQuestions = 20;
        public readonly int ThirtyQuestion = 30;
        public readonly int NormalMode = 1;
        public readonly int AdventureMode = 2;
        public string Greeting = ("Ciao e benvenuti nel gioco della sigaretta impiccione. Niente gioca e passa ");
        public string CloseGreeting = ("\nBeh il gioco è terminato. Vi andrebbe un'altra partita?");
    }
}

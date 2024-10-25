namespace HangmanGP
{
    internal class Program
    {
        static string lettersGuessed = "";
        static string theWord;
        static int life = 7;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            SetupGame();
        }

        private static void SetupGame()
        {
            Console.WriteLine("Welcome to hangman \nPick a word:");
            theWord = Console.ReadLine();
            Console.Clear();
            while (true) StartGame();
        }

        private static void StartGame()
        {
            while (life>0 && !IsWordGuessed())
            {
                ShowWord();
                char ch = GuessLetter();
                lettersGuessed += ch;
                CheckIfLetterIsUsed(ch);
            }
            if (life>0) Console.WriteLine("You guessed the word : " + theWord);
            else Console.WriteLine("You just hanged a man :( \n");
        }

        private static bool IsWordGuessed()
        {
            foreach (char ch in theWord)
                if (!lettersGuessed.Contains(ch)) return false;
            return true;
        }

        static char GuessLetter()
        {
            Console.Write("Guess a letter: ");
            return Console.ReadKey().KeyChar;
        }

       static  bool CheckIfLetterIsUsed(char ch)
        {
            if (theWord.ToLower().Contains(ch))
            {
                Console.WriteLine($"The letter {ch} is in the word");
                return true;
            }
            Console.WriteLine("Oh no. That was WROOOOONG!");
            life--;
            return false;
        }

        static void ShowWord()
        {
            foreach (char ch in theWord.ToLower())
            {
                if (lettersGuessed.ToLower().Contains(ch)) Console.Write(ch);
                else Console.Write("_");
            }
        }
    }
}

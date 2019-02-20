using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrettyPrinting
{
    // This is a onedimensional array pretending to be a twodimensional array.
    class xyArray
    {
        private int[] Array;
        private int x, y;

        public int get(int x, int y)
        {
            return Array[x + (this.x * y)];
        }
        public xyArray(int x, int y)
        {
            Array = new int[x * y];
            this.x = x;
            this.y = y;
        }
    }

    class SubSolution
    {
        int Lelijkheid, LengthOfLastSentence;
        List<int> EnterAfterWords;
        public SubSolution(int Lelijkheid, List<int> EnterAfterWords, int LengthOfLastSentence)
        {
            this.Lelijkheid = Lelijkheid;
            this.LengthOfLastSentence = LengthOfLastSentence;
            this.EnterAfterWords = EnterAfterWords;
        }
    }

    class Program
    {
        static int L, m, NumberOfWords, TotalLelijkheid;
        static string[] text;
        static List<int> EnterAfterWords;
        

        // How many spaces do we have left if we put words x to y in a line?
        static xyArray SpacesLeft = new xyArray(NumberOfWords+1, NumberOfWords+1);

        // This list will contain the optimal solution for words 1...n at index n
        static List<SubSolution> Subsolutions = new List<SubSolution>();

        static void Main(string[] args)
        {
            GetInput();
        }

        static void GetInput()
        {
            Console.SetIn(new StreamReader("Alg2.t1.in"));
            string[] split = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.None);
            L = Int32.Parse(split[0]);
            m = Int32.Parse(split[1]);
            text = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.None);
            NumberOfWords = text.Length;
            EnterAfterWords = new List<int>();
        }

        static void PrettyPrintingDynamic()
        {
            int CurrentLength = 0;
            int nextWordLength;
            string word;
            char LastChar;
            for(int i = 0; i < NumberOfWords; i++)
            {
                word = text[i];
                LastChar = word[word.Length - 1];
                nextWordLength = text[i].Length;

                // The two trivial cases
                if (LastChar == '.' || LastChar == '!')
                {
                    EnterAfterWords.Add(i);
                    CurrentLength = 0;
                    break;
                }
                if(CurrentLength + nextWordLength > L)  // If the word doesn't fit anymore, try it again on the next line
                {
                    i--;
                    EnterAfterWords.Add(i);             // Add a newLine after the previous word
                    TotalLelijkheid += L - CurrentLength;
                    CurrentLength = 0;
                    break;
                }

                // The two branching cases
                

            }
            // top choice:
            // Put enter behind current word?


        }

        static bool WordFits(string word, int sentenceLength)
        {
            return sentenceLength + word.Length <= L;
        }
    }
}

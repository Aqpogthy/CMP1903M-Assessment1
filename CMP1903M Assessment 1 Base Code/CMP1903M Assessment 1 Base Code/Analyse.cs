using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_1_Base_Code
{
    public class Analyse
    {
        Dictionary<char, int> Frequency = new Dictionary<char, int>();
        List<string> LongWords = new List<string>();

        //Handles the analysis of text

        //Method: analyseText
        //Arguments: string
        //Returns: list of integers
        //Calculates and returns an analysis of the text
        public List<int> analyseText(List<string> text)
        {
            List<int> values = new List<int>();
            //Initialise all the values in the list to '0'
            for (int i = 0; i < 5; i++)
            {
                values.Add(0);
            }

            //List of integers to hold the first five measurements:

            //1. Number of sentences
            values[0] += text.Count;

            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
            
            for (int i = 0; i < text.Count; i++)
            {
                if (text[i].Length <= 1)
                {
                    values[0] -= 1; //This checks to see if the sentence is only one character. This solves the problem of having * at the end as well as ellipses and interrobangs
                }
                for (int j = 0; j < text[i].Length; j++)
                {
                    //2. Number of vowels
                    if (vowels.Contains(char.ToLower(text[i][j])))
                    {
                        values[1] += 1; //add 1 to counter if it is a vowel
                    }
                    //3. Number of consonants
                    else if (char.IsLetter(text[i][j])) //have to make sure that they are letters otherwise '.' will be viewed as consonants as well
                    {
                        values[2] += 1; //if not a vowel add one to consonants counter
                    }
                    //4. Number of upper case letters
                    if (text[i][j] >= 'A' && text[i][j] <= 'Z') //Chars are viewed as int as well 
                    {
                        values[3] += 1; //add 1 to counter if it is capatalised
                        FrequentLetters(text[i][j]);
                    }
                    //5. Number of lower case letters
                    else if (char.IsLetter(text[i][j]))
                    {
                        values[4] += 1; //if not capatalised then add counter to lowercase
                        FrequentLetters(text[i][j]);
                    }                    
                }
                string[] words = text[i].Split(' ', ',');
                foreach (string word in words)
                {
                    if (word.Length >= 7)
                    {
                        LongWords.Add(word);
                    }
                }
            }
            File.WriteAllLines(String.Concat(Environment.CurrentDirectory.ToString(), "\\longwords.txt"), LongWords);

            return values;
        }
        //Method: FrequentLetters
        //Arguments: char
        //Returns: list of integers
        //Calculates and returns an analysis of the text
        private void FrequentLetters(char letter) //encapsulation not intended to be accessed by the user
        {
            letter = char.ToUpper(letter);
            if (Frequency.ContainsKey(letter))
            {
                Frequency[letter] += 1;
            }
            else
            {
                Frequency[letter] = 1;
            }
        }
        //Method: GetFrequency
        //Arguments: none
        //Returns: Dictionary of Frequent letters
        public Dictionary<char, int> GetFrequency()
        {
            return Frequency;
        }
        //Method: GetLongWords
        //Arguments: none
        //Returns: list of string
        public List<string> GetLongWords()
        {
            return LongWords;
        }
    }
}

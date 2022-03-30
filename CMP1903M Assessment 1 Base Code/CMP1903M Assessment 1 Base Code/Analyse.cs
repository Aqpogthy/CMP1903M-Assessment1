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
            
            for (int i = 0; i < text.Count; i++)
            {
                if (text[i].Length == 1)
                {
                    values[0] -= 1;
                }
                for (int j = 0; j < text[i].Length; j++)
                {
                    //2. Number of vowels
                    if (text[i][j].ToString().ToLower() == "a" || text[i][j].ToString().ToLower() == "e" || text[i][j].ToString().ToLower() == "i" || text[i][j].ToString().ToLower() == "o" || text[i][j].ToString().ToLower() == "u") //checks if vowel - have to convert to string to lowercase the char otherwise it wouldnt read 'E' as a vowel
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
            }
            
            return values;
        }
        //Method: FrequentLetters
        //Arguments: char
        //Returns: list of integers
        //Calculates and returns an analysis of the text
        public void FrequentLetters(char letter)
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
        
        public Dictionary<char, int> GetFrequency()
        {
            return Frequency;
        }
    }
}

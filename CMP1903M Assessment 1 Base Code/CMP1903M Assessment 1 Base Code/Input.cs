using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_1_Base_Code
{
    public class Input
    {
        //Handles the text input for Assessment 1
        string text = "nothing";
        
        //Method: manualTextInput
        //Arguments: none
        //Returns: string
        //Gets text input from the keyboard
        public string manualTextInput()
        {
            Console.WriteLine("Please enter your sentence to be analysed. You should input one line at a time. (End your last sentence with *)");
            string text = Console.ReadLine();
            return text;
        }

        //Method: fileTextInput
        //Arguments: string (the file path)
        //Returns: string
        //Gets text input from a .txt file
        public string fileTextInput(string fileName)
        {
            while (true)
                try
                {
                    text = File.ReadAllText(fileName);
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Couldn't find the file you are looking for.");
                    fileName = Console.ReadLine();

                }
            return text;
        }

    }
}

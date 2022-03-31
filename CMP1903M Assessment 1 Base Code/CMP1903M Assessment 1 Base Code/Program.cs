//Base code project for CMP1903M Assessment 1
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_1_Base_Code
{
    class Program
    {
        static void Main()
        {
            //Local list of integers to hold the first five measurements of the text
            List<int> parameters = new List<int>();

            //Create 'Input' object
            Input UserInput = new Input();
            //Get either manually entered text, or text from a file
            string option = "";
            while (true)
            {
                Console.WriteLine("1. Do you want to enter the text via the keyboard ?");
                Console.WriteLine("2. Do you want to read in the text from a file? ");
                option = Console.ReadLine(); //Gets the users choice
                if (option == "1" || option == "2")
                {                                 
                    break;
                }
                Console.WriteLine("Please enter 1 or 2");
            }
            
            
            List<string> text = new List<string>();
            if (option == "1") //See if the user chose to enter the sentences manually
            {
                bool Endsentences = false;
                while (Endsentences == false) //Goes until '*' was the last char entered
                {
                    text.Add(UserInput.manualTextInput()); // User enters a single sentence which is added to the list of sentences.
                    if (text[text.Count() - 1][text[text.Count() - 1].Length - 1] == '*') //Sees if the last char that was entered was an '*'
                    {
                        Endsentences = true; //Stops the loop
                    }
                }

            }
            else if (option == "2") //See if the user chose to read from a file
            {
                Console.WriteLine("Enter the file name please.");
                string FileName = Console.ReadLine(); //Get FileName to read from the file
                string line = UserInput.fileTextInput(FileName);
                
                text = line.Split('.', '!', '?').ToList();
                }


            //Create an 'Analyse' object
            Analyse AnalyseText = new Analyse();
            //Pass the text input to the 'analyseText' method and receive a list of integers back
            parameters = AnalyseText.analyseText(text);

            //Report the results of the analysis
            Report sentenceReport = new Report();
            sentenceReport.Outputanalysis(parameters, AnalyseText.GetFrequency());
            //TO ADD: Get the frequency of individual letters?

            Console.ReadLine();

        }
        
        
    
    }
}

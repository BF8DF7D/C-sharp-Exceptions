using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp_Exceptions
{
    class Disease
    {
        private string Name_Disease;
        private string[] Disease_Symptoms;
        private static int number_of_deaths = 0;

        public Disease() 
        {
            Console.WriteLine(" <Ввод информации о заболевании>");
            Console.Write(" Наименование: ");
            Name_Disease = Console.ReadLine();

            Console.WriteLine(" Симптомы.\n Вводите каждый новый симптом с новой строки.\n Для прекращения операции нажмите Enter");

            for(int input_value_number = 0; input_value_number < 50; input_value_number++) {
                Console.Write(" : ");
                Disease_Symptoms[input_value_number] = Console.ReadLine();
                if (Disease_Symptoms[input_value_number] == "")
                    break;
            }
        } 
        public Disease(string name)
        {
            Name_Disease = name; 
            Disease_Symptoms = new string[51];
        }

        public void PrintInfo()
        {
            Console.WriteLine($" Наименование: {GetName()}");
            Console.WriteLine(" Симптомы: ");
            string[] disease_simptoms = GetSymptoms();
            int Output_value_number = 0;
            foreach (string symptom in disease_simptoms)
            {
                if (symptom == "")
                    break;
                Console.WriteLine($" [{++Output_value_number:d2}] {symptom}");
            }
        }
        
        public void ChangeDeaths(int change)
        {
            number_of_deaths = change;
        }
        public static int GetDeaths()
        {
            return number_of_deaths;
        }
        public int GetDiseaseDeaths()
        {
            return number_of_deaths;
        }

        public string GetName() 
        {
            return Name_Disease;
        }
        public string[] GetSymptoms()
        {
            return Disease_Symptoms;
        }
        
        public void SetName(string name)
        {
            Name_Disease = name;
        }

    }
}

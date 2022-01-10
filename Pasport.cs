using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp_Exceptions
{
    class Pasport
    {
        private int series,
            number;
        private string formatPasport;

        public bool SetBool(int[] data_entered)
        {

            int series = data_entered[0],
                number = data_entered[1];

            const int Minimum_value_for_all = 0,
                Maximum_for_series = 9999,
                Maximum_for_number = 999999;

            bool False_Input_Value = (series <= Minimum_value_for_all || series > Maximum_for_series)
                || (number <= Minimum_value_for_all || number > Maximum_for_number);

            return False_Input_Value;
        }

        public Pasport()
        {
            do
            {
                Console.Write(" Паспорт: ");

                Console.Write(" Дата: ");

                //CHECKING FOR THE AMUNT OF DATA ENTERED
                string[] input_values = Console.ReadLine().Split(".");
                const int Quantity_input_value = 2;
                if (input_values.Length != Quantity_input_value)
                {
                    Console.WriteLine("\n <Неверное количество данных>");
                    continue;
                }

                //CHECKING FOR THE DATA TYPE
                int[] pasport = new int[2];
                int input_number = 0;
                bool False_input_value = false;
                foreach (string value in input_values)
                {
                    try
                    {
                        pasport[input_number++] = Convert.ToInt32(value);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("\n <Данные не соотвествуют ожидаемому типу>");
                        False_input_value = true;
                        break;
                    }
                }
                if (False_input_value)
                    continue;

                //CHEACKING FOR THE CORRECT DATA FORMAT
                False_input_value = SetBool(pasport);

                //ASSIGMENT BLOCK
                if (False_input_value)
                    Console.WriteLine("\n <Паспортные данные введены некорректно>");
                else
                {
                    series = pasport[0];
                    number = pasport[1];
                    formatPasport = $"{series:d4} {number:d6}";
                    break;
                }
            } while (true);
        }

        public int GetSeries()
        {
            return series;
        }
        public int GetNumber()
        {
            return number;
        }
        public string GetFormatPasport()
        {
            return formatPasport;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp_Exceptions
{
    class Date
    {
        private int day,
          mounth,
            year;
        private string formatDate;

        internal int Day { 
            get => day;
            set => day = value;
        }
        internal int Mounth { 
            get => mounth; 
            set => mounth = value;
        }
        internal int Year { 
            get => year;
            set => year = value;
        }
        internal string FormatDate
        {
            get => formatDate;
            set => formatDate = value;
        }

        public bool SetBool(int[] data_entered)
        {
            int day = data_entered[0],
                mounth = data_entered[1],
                year = data_entered[2];

            const int Minimum_for_days_and_months = 0,
                Maximum_day = 31,
                Maximum_mounth = 12,
                Minimum_value_for_years = 999,
                Maximum_years = 9999;

            bool False_input_value = (day <= Minimum_for_days_and_months || day > Maximum_day)
                || (mounth <= Minimum_for_days_and_months || mounth > Maximum_mounth)
                || (year <= Minimum_value_for_years || year > Maximum_years);

            return False_input_value;
        }
        public Date()
        {
            do
            {
                Console.Write(" Дата: ");
                
                //CHECKING FOR THE AMUNT OF DATA ENTERED
                string[] input_values = Console.ReadLine().Split(".");
                const int Quantity_input_value = 3;
                if (input_values.Length != Quantity_input_value)
                {
                    Console.WriteLine("\n <Неверное количество данных>");
                    continue;
                }

                //CHECKING FOR THE DATA TYPE
                int[] date = new int[3];
                int input_number = 0;
                bool False_input_value = false;
                foreach (string value in input_values)
                {
                    try
                    {
                        date[input_number++] = Convert.ToInt32(value);
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
                False_input_value = SetBool(date);

                //ASSIGMENT BLOCK
                if (False_input_value)
                    Console.WriteLine("\n <Дата введена некорректно>");
                else
                {
                    day = date[0];
                    mounth = date[1];
                    year = date[2];
                    formatDate = $"{day:d2}.{mounth:d2}.{year}";
                    break;
                }
            } while (true);
        }

        public int[] GetFullInfo()
        {
            int[] info = { day, mounth, year };
            formatDate = $"{day:d2}.{mounth:d2}.{year}";
            return info;
        }
        public int GetDay()
        {
            return day;
        }
        public int GetMounth()
        {
            return mounth;
        }
        public int GetYear()
        {
            return year;
        }
        public string GetFormatDate()
        {
            return formatDate;
        }
    }
}

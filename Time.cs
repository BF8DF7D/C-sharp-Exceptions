using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp_Exceptions
{
    class Time
    {
        private int hour,
            minutes;
        private string formatTime;

        internal int Hour
        {
            get => hour;
            set => hour = value;
        }
        internal int Minutes
        {
            get => minutes;
            set => minutes = value;
        }
        internal string FormatTime
        {
            get => formatTime;
            set => formatTime = value;
        }

        public bool SetBool(int[] data_entered)
        {
            int hour = data_entered[0],
                minutes = data_entered[1];

            const int Minimum_value_for_all = 0,
                Maximum_hour = 23,
                Maximum_minutes = 59;

            bool False_input_value = (hour < Minimum_value_for_all || hour > Maximum_hour)
                || (minutes < Minimum_value_for_all || minutes > Maximum_minutes);
            return False_input_value;
        }

        public Time()
        {
            
            do
            { 
                Console.Write(" Время: ");

                //CHECKING FOR THE AMUNT OF DATA ENTERED
                string[] input_values = Console.ReadLine().Split(".");
                const int Quantity_input_value = 2;
                if (input_values.Length != Quantity_input_value)
                {
                    Console.WriteLine("\n <Неверное количество данных>");
                    continue;
                }

                //CHECKING FOR THE DATA TYPE
                int[] time = new int[2];
                int input_number = 0;
                bool False_input_value = false;
                foreach (string value in input_values)
                {
                    try
                    {
                        time[input_number++] = Convert.ToInt32(value);
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
                False_input_value = SetBool(time);

                //ASSIGMENT BLOCK
                if (False_input_value)
                    Console.WriteLine("\n <Время введено некорректно>");
                else
                {
                    hour = time[0];
                    minutes = time[1];
                    formatTime = $"{hour:d2}:{minutes:d2}";
                    break;
                }

            } while (false);
        }

        public void ChangeTime(int[] changing_values,Date date)
        {
            int input_hours = changing_values[0],
                input_minutes = changing_values[1];

            const int Quantity_minutes_for_hour = 60,
                Quantity_hours_for_days = 24,
                Quantity_days_for_mounths = 31,
                Quantity_mounth_for_year = 12;

            minutes += input_minutes;
            hour += minutes / Quantity_minutes_for_hour;
            hour += input_hours;
            minutes %= Quantity_minutes_for_hour;

            date.Day += hour / Quantity_hours_for_days;
            hour %= Quantity_hours_for_days;
            date.Mounth += date.Day / Quantity_days_for_mounths;
            date.Mounth %= Quantity_days_for_mounths;
            date.Year += date.Mounth / Quantity_mounth_for_year;


            formatTime = $"{hour:d2}:{minutes:d2}";
            date.FormatDate = $"{date.Day:d2}.{date.Mounth:d2}.{date.Year}";
        }

        public int[] GetAllInfo()
        {
            int[] info = { hour, minutes };
            return info;
        }
        public int GetHour()
        {
            return hour;
        }
        public int GetMinutes()
        {
            return minutes;
        }
        public string GetFormatTime()
        {
            return formatTime;
        }
    }
}

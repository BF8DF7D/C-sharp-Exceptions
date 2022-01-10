using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp_Exceptions
{
    class Talon : ICloneable
    {
        private Date Admission_Date;
        private Time Admission_Time;
        private int kabinet;
        private Doctor medic;


        private static bool SetBool(int data_entered)
        {
            const int Minimum_value = 0,
                Maximum_value = 500;
            bool False_input_value = data_entered < Minimum_value || data_entered > Maximum_value;
            return False_input_value;
        }

        public static int InputFormatInt() {
            do
            {
                Console.Write(" Номер кабинета: ");

                //CHECKING FOR THE AMUNT OF DATA ENTERED
                string[] input_values = Console.ReadLine().Split(" ");
                const int Quantity_input_value = 1;
                if (input_values.Length != Quantity_input_value)
                {
                    Console.WriteLine("\n <Неверное количество данных>");
                    continue;

                }

                //CHECKING FOR THE DATA TYPE
                bool False_input_value = false;
                int int_value = 0;
                try
                {
                    int_value = Convert.ToInt32(input_values[0]);
                }
                catch (Exception e)
                {
                    Console.WriteLine("\n <Данные не соотвествуют ожидаемому типу>");
                    False_input_value = true;
                }
                if (False_input_value)
                    continue;

                //ASSIGMENT BLOCK
                False_input_value = SetBool(int_value);
                if (False_input_value)
                    Console.WriteLine("\n <Номер кабинета введен некорректно>");
                else
                    return int_value;

            } while (true);
        }
        public Talon(Date inp_date, Time inp_time, int inp_kab, Doctor inp_med)
        {
            Admission_Date = inp_date;
            Admission_Time = inp_time;
            kabinet = inp_kab;
            medic = inp_med;
        }
        public Talon(Doctor doctor)
        {
            Admission_Date = new Date();
            Admission_Time = new Time();
            kabinet = InputFormatInt();
            medic = doctor;
        }
        public Talon()
        {
            Admission_Date = new Date();
            Admission_Time = new Time();
            kabinet = InputFormatInt();
            medic = new Doctor();

        }

        public void PrintInfo()
        {
            Console.WriteLine($"| {medic.Fio.Full, 45} | {Admission_Date.FormatDate} | {Admission_Time.FormatTime} | {kabinet, 3}|"); 
        }

        public static Talon operator+(Talon talon, string time)
        {
            string[] input_values = time.Split(".");
            const int Quantity_input_value = 2;
            bool False_input_value = input_values.Length != Quantity_input_value;
            if (False_input_value)
                return null;
            Talon value = (Talon)talon.Clone();
            int[] inttime = new int[2];
            int value_number = 0;

            foreach (string string_value in input_values) 
                try
                {
                    inttime[value_number++] = Convert.ToInt32(string_value);
                }
                catch (Exception e)
                {
                    return null;
                }

            value.Admission_Time.ChangeTime(inttime, value.Admission_Date);

            return value;
        }

        public static Talon operator ++(Talon talon)
        {
            return new Talon
            {
                Admission_Time = talon.Admission_Time,
                Admission_Date = talon.Admission_Date,
                kabinet = talon.kabinet + 1,
                medic = talon.medic
            };
        }
        public Date GetDate()
        {
            return Admission_Date;
        }
        public Time GetTime()
        {
            return Admission_Time;
        }
        public int GetKabinet()
        {
            return kabinet;
        }
        public Doctor GetDoctor()
        {
            return medic;
        }

        public object Clone()
        {
            Time Time_for_admission = new()
            {
                Hour = this.Admission_Time.Hour,
                Minutes = this.Admission_Time.Minutes,
                FormatTime = this.Admission_Time.FormatTime
            };
            Date Date_for_admission = new()
            {
                Day = this.Admission_Date.Day,
                Mounth = this.Admission_Date.Mounth,
                Year = this.Admission_Date.Year,
                FormatDate = this.Admission_Date.FormatDate
            };
            return new Talon
            {
                Admission_Date = Date_for_admission,
                Admission_Time = Time_for_admission,
                kabinet = this.kabinet,
                medic = this.medic
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp_Exceptions
{
    class Patient
    {
        private FIO Fio;
        private Date Date_Brith;
        private Pasport pasport;
        private int Medical_Card;

        private Diagnosis[] Diagnosis_History;
        private int Diagnosis_point;

        private bool SetBool(int data_entered)
        {
            const int Minimum_value = 0x0,
                Maximum_value = 0xFFFFFFF;
            bool False_input_value = data_entered < Minimum_value || data_entered > Maximum_value;
            return False_input_value;

        }
        int SetFormatInt()
        {
            do
            {
                Console.Write(" Мед.карта: ");

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
                    Console.WriteLine("\n < Номер мед. карты введён некорректно>");
                else
                    return int_value;
            } while (true);
            
        }
        public Patient()
        {
            Console.WriteLine(" <Ввод информации о пацинте>");

            Fio = new FIO();
            Date_Brith = new Date();
            pasport = new Pasport();
            Medical_Card = SetFormatInt();
            Diagnosis_History = new Diagnosis[50];
        }

        public void PrintInfo()
        {
            Console.WriteLine(" <Персональные данные>");
            Console.WriteLine($" {"ФИО пациента",-26}: {GetFIO().GetFullName()}");
            Console.WriteLine($" {"Серия и номер паспорта",-26}: {GetPasport().GetFormatPasport()}");
            Console.WriteLine($" {"Дата рождения",-26}: {GetDate().GetFormatDate()}");
            Console.WriteLine($" {"Номер медецинской карты",-26}: {GetCard():x7}");
            Console.WriteLine(" <Краткая история болезни>");
            if (Diagnosis_point > 0)
            {
                Console.WriteLine($" Общее число зарегистрированных заболеваний: {Diagnosis_point}");
                Console.WriteLine($" {"Наименование болезни",26} : {"Дата",10} : {"Время",5} :");
                Diagnosis[] diagnosis_history = GetHistory();
                foreach (Diagnosis diagnosis in diagnosis_history)
                {
                    if (diagnosis == null)
                        break;
                    Console.WriteLine($" {diagnosis.GetDisease().GetName(),26} " +
                        $": {diagnosis.GetTalon().GetDate().GetFormatDate(),10} " +
                        $": {diagnosis.GetTalon().GetTime().GetFormatTime(), 5} :");
                }
            }
            else
                Console.WriteLine(" Нет заригестрированных заболеваний ");
        }

        public void GiveDiagnosis(Diagnosis diagnos)
        {
            const int Maximum_values_diagnosis = 50;
            if (Diagnosis_point < Maximum_values_diagnosis)
            {
                Diagnosis_History[Diagnosis_point] = diagnos;
                Diagnosis_point++;
            }
        }

        public bool DiseaseOf(string Name_Disease)
        {
            Diagnosis[] diagnosis_history = GetHistory();
            bool Serched_disease_is_present = false;
            foreach (Diagnosis diagnosis in diagnosis_history)
            {
                if (diagnosis == null)
                    break;
                if (String.Equals(diagnosis.GetDisease().GetName(), Name_Disease))
                {
                    Serched_disease_is_present = true;
                    break;
                }
            }
            return Serched_disease_is_present;
        }

        public void DeleteDiagnosis(int number_diagnosis)
        {
            if (number_diagnosis < Diagnosis_point)
            {
                Diagnosis_History[number_diagnosis] = null;
                for (; number_diagnosis < Diagnosis_point - 1; number_diagnosis++)
                    Diagnosis_History[number_diagnosis] = Diagnosis_History[number_diagnosis + 1];
                Diagnosis_History[number_diagnosis] = null;
                Diagnosis_point--;
            }
        }
        public void DeleteAll()
        {
            Diagnosis_History = new Diagnosis[50];
            Diagnosis_point = 0;

        }

        public FIO GetFIO()
        {
            return Fio;
        }
        public Date GetDate()
        {
            return Date_Brith;
        }
        public Pasport GetPasport()
        {
            return pasport;
        }
        public int GetCard()
        {
            return Medical_Card;
        }
        public Diagnosis[] GetHistory()
        {
            return Diagnosis_History;
        }
    }
}

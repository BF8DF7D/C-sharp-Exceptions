using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp_Exceptions
{
    class Diagnosis
    {
        private Talon talon;
        private Disease disease;

        public Diagnosis(Talon coupon_of_patient, Disease disease_of_patient)
        {
            talon = coupon_of_patient;
            disease = disease_of_patient;
        }
        public Diagnosis()
        {
            talon = null;
            disease = null;
        }

        public void PrintInfo()
        {
            Console.WriteLine($" Доктор: {GetTalon().GetDoctor().GetFIO().GetFullName()}");
            Console.WriteLine($" Дата приёма: {GetTalon().GetDate().GetFormatDate()}");
            Console.WriteLine($" Время приёма: {GetTalon().GetTime().GetFormatTime()}");
            Console.WriteLine($" Номер кабинета: {GetTalon().GetKabinet()}");
            GetDisease().PrintInfo();
        }

        public Talon GetTalon()
        {
            return talon;
        }
        public Disease GetDisease()
        {
            return disease;
        }
    }
}

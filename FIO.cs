using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp_Exceptions
{
    class FIO
    {
        
        private string last_name,
            first_name,
            patronynic,
            full_name;
        public string Last
        {
            get => last_name;
            set => last_name = value;
        }
        public string First {
            get => first_name;
            set => first_name = value;
        }
        public string Patronynic
        {
            get => patronynic;
            set => patronynic = value;
        }
        public string Full
        {
            get
            {
                full_name = $"{last_name} {first_name} {patronynic}";
                return full_name;
            }
        }
        public FIO()
        {
            do
            {
                Console.Write(" ФИО: ");

                full_name = Console.ReadLine();
                string[] name_elements = full_name.Split(" ");
                const int Quantity_input_values = 3;
                if (name_elements.Length != Quantity_input_values)
                {
                    Console.WriteLine("\n <ФИО введено некорректно>");
                    continue;
                }
                else
                {
                    const int last_name = 0,
                        first_name = 1,
                        patronynic = 2;

                    this.last_name = name_elements[last_name];
                    this.first_name = name_elements[first_name];
                    this.patronynic = name_elements[patronynic];
                    break;

                }
            } while (true);
        }

        public string GetLastName()
        {
            return last_name;
        }
        public string GetFisrstName()
        {
            return first_name;
        }
        public string GetPatonynic()
        {
            return patronynic;
        }
        public string GetFullName()
        {
            return full_name;
        }
    };
}


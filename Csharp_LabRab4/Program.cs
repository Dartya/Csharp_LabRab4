using System;

/* 
            ЗАДАНИЕ 1
            Вывести в консоль информацию о сотрудниках в виде таблицы(использовать экранирование символов).
            Колонки: имя сотрудника, название компании(в кавычках), дата устройства на работу(день.месяц.год), сумма продаж(decimal c символом валюты).
            Вывести список из 4 человек: у двух продажи в российских рублях, у двух других -в евро.
            
            ЗАДАНИЕ 2.
            Используя класс StringBuilder сформировать текст, состоящий из 100 строк.Каждая строка длиной от 20 до 100 случайных символов. Записать полученный результат в переменную типа string, вывести результат в консоль.
            */

// ЗАДАНИЕ 1

namespace Csharp_LabRab4
{
    public class Worker {
        string name;                //имя сотрудника
        string company;             //имя компании
        DateTime employment_data;   //дата устройства на работу - определить для каждого объекта через конструктор
        string employment_data_str; //дата устройства на работу в формате строки
        double salesRUB;            //сумма продаж в рублях
        double salesEUR;            //сумма продаж в евро
        char RUB = '₽';             //символ рубля
        char EUR = '€';             //символ евро
        string salesRUBStr;         //формируемая строка суммы продаж в рублях
        string salesEURStr;         //формируемая строка суммы прожаж в евро

        public Worker(string n, string c, int y, int m, int d, double sR, double sE) { //конструктор класса
            name = n;
            company = c;
            employment_data = new DateTime(y, m, d);
            salesRUB = sR;
            salesEUR = sE;
            salesRUBStr = Convert.ToString(salesRUB) + Convert.ToString(RUB);
            salesEURStr = Convert.ToString(salesEUR) + Convert.ToString(EUR);
            employment_data_str = employment_data.ToShortDateString();
        }

        public string getWorkerInfo(int param) {   //параметр вывода строки: 1 - выводит продажи в рублях, все остальное - в рублях
            string result;      //результат формирования строки
            if (param == 1)
                result = name + ", " + company + ", " + employment_data_str + ", " + salesEURStr;
            else
                result = name + ", " + company + ", " + employment_data_str + ", " + salesRUBStr;
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Worker vanya = new Worker("Ваня", "\"Доза\"", 2018, 8, 1, 100000.50, 0);
                Console.WriteLine("Имя    |  Компания  |   Дата устройства   |  Продажи");
                Console.WriteLine(vanya.getWorkerInfo(1));
            }
            catch (Exception e) {
                Console.WriteLine(e.ToString()); 
            }
            finally{
                Console.Write("Press <Enter>");
                Console.ReadLine();
            }
        }
    }
}
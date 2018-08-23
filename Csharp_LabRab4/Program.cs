﻿using System;

/* 
ЗАДАНИЕ 1
Вывести в консоль информацию о сотрудниках в виде таблицы(использовать экранирование символов).
Колонки: имя сотрудника, название компании(в кавычках), дата устройства на работу(день.месяц.год), сумма продаж(decimal c символом валюты).
Вывести список из 4 человек: у двух продажи в российских рублях, у двух других -в евро.
            
ЗАДАНИЕ 2.
Используя класс StringBuilder сформировать текст, состоящий из 100 строк.Каждая строка длиной от 20 до 100 случайных символов. Записать полученный результат в переменную типа string, вывести результат в консоль.
*/

// ЗАДАНИЕ 1

    /*ссылки: 
    составное форматирование: https://docs.microsoft.com/ru-ru/dotnet/standard/base-types/composite-formatting
    decimal: https://docs.microsoft.com/ru-ru/dotnet/csharp/language-reference/keywords/decimal
    еще про форматирование строк: https://msdn.microsoft.com/ru-ru/library/system.string.format(v=vs.110).aspx
    */

namespace Csharp_LabRab4
{
    public class Worker {
        string name;                //имя сотрудника
        string company;             //имя компании
        DateTime employment_data;   //дата устройства на работу - определить для каждого объекта через конструктор
        string employment_data_str; //дата устройства на работу в формате строки
        decimal salesRUB;           //сумма продаж в рублях
        decimal salesEUR;           //сумма продаж в евро
        char RUB = '$';             //символ рубля ₽ некорректно отображается в консоли, поэтому будем отображать доллар #рульживи
        char EUR = '€';             //символ евро
        string salesRUBStr;         //формируемая строка суммы продаж в рублях
        string salesEURStr;         //формируемая строка суммы прожаж в евро

        public Worker(string n, string c, int y, int m, int d, double sR, double sE) { //конструктор класса
            name = n;
            company = c;
            employment_data = new DateTime(y, m, d);
            salesRUB = (decimal)sR;                     //используем явное приведение типов от double к decimal ввиду того, что, если мы будем принимать на вход метода значение decimal, 
            salesEUR = (decimal)sE;                     //при указании значения в параметрах вывода при его вызове в конце значения придется ставить суффикс m для явного обозначения числа как decimal. 
            salesRUBStr = Convert.ToString(salesRUB) + Convert.ToString(RUB);
            salesEURStr = Convert.ToString(salesEUR) + Convert.ToString(EUR);
            employment_data_str = employment_data.ToShortDateString();
        }

        public string getWorkerInfo(int param) {   //параметр вывода строки: 1 - выводит продажи в рублях, все остальное - в рублях
            string result;      //результат формирования строки
            //{0, -10} - индексированныей местозаполнитель, который называется элементом форматирования и соответствует объекту из списка, 
            //где 0 - номер элемента из списка, следующим за строкой фиксированного текста; -10 - отступ на *кол-во сим-в* влево. положительное значение - отступ вправо
            if (param == 1)
                result = String.Format("{0, -10} | {1, -10} | {2, -15} | {3, -15} ", name, company, employment_data_str, salesEURStr);
            else
                result = String.Format("{0, -10} | {1, -10} | {2, -15} | {3, -15} ", name, company, employment_data_str, salesRUBStr);
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Worker vanya = new Worker("Ваня", "\"Рога\"", 2018, 8, 1, 12345.70, 0);
                Worker sonya = new Worker("Соня", "\"Копыта\"", 2017, 02, 01, 54321.65, 0);
                Worker slava = new Worker("Слава", "\"Пятерка\"", 2016, 4, 5, 0, 12345.70);
                Worker klava = new Worker("Клава", "\"Магнит\"", 2015, 05, 03, 0, 54321.65);
                Worker[] aWorker = {vanya, sonya, slava, klava};
                Console.OutputEncoding = System.Text.Encoding.Unicode;  //эту строчку необходимо вставить непосредственно перед консольным выводом, чтобы корректно отобразить символы валют
                //при этом корректно отобразить рубль так и не получилось, поэтому отображаться будет доллар ((( #рубльживи
                Console.WriteLine("{0, -10} | {1, -10} | {2, -15} | {3, -15} ", "Имя", "Компания", "Дата устройства", "Продажи");
                Console.WriteLine("______________________________________________________");
                for (int i = 0; i<2; i++){
                    Console.WriteLine(aWorker[i].getWorkerInfo(0));
                }
                for (int i = 2; i<4; i++){
                    Console.WriteLine(aWorker[i].getWorkerInfo(1));
                }
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
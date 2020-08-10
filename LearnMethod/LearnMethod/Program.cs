using System;
using System.Threading;

namespace LearnMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            bool tvstat;//status данного экземпляра класса
            string tvinfo = "1";//string for status
            Tele myTV = new Tele(); //Создание нового экземпляра
            tvstat = myTV.switchedTV;

            Console.WriteLine("Текущее состояние телевизора");
            GetTVInfo(tvstat, ref tvinfo);
            Console.WriteLine(tvinfo);

            Console.WriteLine("Нажмите Y, если хотите включить телевизор");
            if (Console.ReadKey(true).Key == ConsoleKey.Y)
                myTV.switchedOn();

            Console.WriteLine("Новое состояние телевизора");
            tvstat = myTV.switchedTV;
            GetTVInfo(tvstat, ref tvinfo);
            Console.WriteLine(tvinfo);

            //НУ чтож же, продолжим пилить это никому не нужно приложение дальше?
            Console.WriteLine("Текщий канал 0");
            Console.WriteLine("Нажмите + или - для переключения канала");
            myTV.Switch();

        }


        public static void GetTVInfo(bool tvstat, ref string tvinfo)
        {

            if (tvstat == true)
                tvinfo = "On";
            else tvinfo = "Off";

        }
    }
}

        class Tele
        {
            public bool switchedTV; //Показывает статус ТВ
            public Tele() { switchedTV = false; } // Конструктор

            public void switchedOn() //Turn On
            {
                switchedTV = true;
            }

            public void switchedOff() //Turn Off
            {
                switchedTV = false;
            }


            //Спектр доступных каналов
            int[] chan = { 0, 1, 2, 3, 4 };
            int current;

            //Канал по умолчанию
            public int cur(int a)
            {
                a = chan[2];
                current = a;
                return current;
            }

            //В данном метода производятся основные операции для переключения между каналами
            public void Switch()
            {
            start:
                string a = Convert.ToString(Console.ReadLine());
                try
                {
                    //используйте символы "+" или "-" для переключения каналов по порядку
                    switch (a)
                    {
                        case "+":
                            chan[current] += 1;
                            break;
                        case "-":
                            chan[current] -= 1;
                            break;
                        //блок отвечающий за переключение каналов по номеру
                        default:
                            int i = Convert.ToInt32(a);
                            chan[current] = i;
                            break;
                    }

                    //если номер канала больше 4-х то переводит нас на нулевой канал
                    //если меньше то на 4-ый
                    if (chan[current] > 4)
                    {
                        chan[current] = 0;
                    }
                    if (chan[current] < 0)
                    {
                        chan[current] = 4;
                    }
                    Console.WriteLine("You are on channel #{0}", chan[current]);
                }
                //при вводе некоректонного символа возвращает нас на текущий канал
                catch (FormatException)
                {
                    Console.WriteLine("You are on channel #{0}", chan[current]);
                }
                goto start;
            }
        }


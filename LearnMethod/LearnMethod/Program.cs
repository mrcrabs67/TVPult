using System;

namespace LearnMethod
{
   
    class TV
    {
        public bool switchedTV; //Показывает статус ТВ

        public TV() { switchedTV = false; } // Конструктор

        public void switchedOn() //Turn On
        {
            switchedTV = true;
        }

        public void switchedOff() //Turn Off
        {
            switchedTV = false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            bool tvstat;//status данного экземпляра класса
            string tvinfo = "1";//string for status
            TV myTV = new TV(); //Создание нового экземпляра
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

        }

        public static void GetTVInfo(bool tvstat, ref string tvinfo)
        {

            if (tvstat == true)
                tvinfo = "On";
            else tvinfo = "Off";

        }

        public void Switch()    //В данном методе производятся основные операци.
        {

        }
    }
}

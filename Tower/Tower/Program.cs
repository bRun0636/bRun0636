using System.Net.Mime;
using System.Dynamic;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower
{
    internal class Program
    {

        static void Main(string[] args)
        {
            int num_floor = 1, choice = 0;
            Menu menu = new Menu();
            Console.WriteLine("Добро пожаловать в Башню. Нам придется пройти 5 этажей, чтобы выбраться из нее. Давайте познакомимся! \nКак Вас зовут?");
            Console.WriteLine();
            string name = Console.ReadLine();
            Player player = new Player(name);
            Console.WriteLine($"Приятно познакомиться{name}.\nЯ Эса, Ваш интерактивный помощник, который расскажет, что Вас будет ждать на каждом этаже.\nНу что, попытаемся сбежать? ");
            Console.WriteLine("1.Давай попробуем, вдруг получится) \n2.Нет, слишком сложно. Давай останемся тут, вдруг нас спасут. ");
            while (true)
            {
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                    if (choice == 1 || choice == 2)
                        break;
                }
                catch
                {
                    Console.WriteLine("Введите число.");
                }
            }
            if (choice == 2)
            {
                Environment.Exit(0);
            }
            else
            {

                Console.WriteLine("Держи меч, он поможет в прохождении!");
                player.Sword.description();
                Console.WriteLine("Мой дорогой друг, мы с тобой на первом этаже. Тут нас встречает деревня смурфов.\nОй-ой, злой волшебник Гаргамель. Заклятый враг смурфов. \nПостоянно предпринимает безуспешные попытки захватить смурфиков. Как он тут оказался? \nДавай победим его и спасем смурфов!");
                Console.WriteLine( menu.fight());
                while (true)
                {
                    try
                    {
                        choice = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Введите число.");
                    }
                }
            }
        }
    }
}

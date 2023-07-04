using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Tower
{
    internal class Program
    {


        static void Main(string[] args)
        {
            Player player;
            Enemy enemy;
            Menu menu = new Menu();
            int choise = 0;
            int choise_stat = 0;
            int choise_menu = 0;
            Dictionary<int, string> floor = new Dictionary<int, string>()
            {
                [1] = "Мой дорогой друг, мы с тобой на первом этаже. Тут нас встречает деревня смурфов.\n" +
                "Ой-ой, злой волшебник Гаргамель. Заклятый враг смурфов. Постоянно предпринимает безуспешные попытки захватить смурфиков.\n" +
                "Как он тут оказался? Давай победим его и спасем смурфов!\n",
                [2] = "Смотри, тут пещера, зайдем в нее? Мне кажется, что из нее мы сможем попасть на следующий этаж!\n" + 
                "Нас встречает Леший. Будь аккуратен, он хитер.\n",
                [3] = "Два этажа за спиной. Опускать руки уже не имеет смысла, осталось немного. Тут, смотри, нас встречает\n" +
                "прекрасный цветущий сад. Но что нас тут ждет, я не представляю.\n" +
                "О боже, это же жвачник! Это хищное растение с длинными корнями, будь осторожен и смотри под ноги.\n",
                [4] = "Вау! Мы попали в какой-то древний, отчасти устрашающий зал. Он украшен в стиле 15 века.\n" +
                "Что же может ждать нас за дверью? Пойдем посмотрим?\n" +
                "Ого, смотри! В этом зале вампир. Опасное, кровожадное существо! Берегись и старайся не пораниться,\n" +
                "а то он станет еще злее от запаха крови.\n",
                [5] = "Мы прошли все четыре сложных этажа отважно и смело, осталось совсем чуть-чуть!\n" +
                "Для того, чтобы наконец выйти из этой страшной Башни, нам осталось победить ужасного босса Башни. Но не бойся! В сундуке\n" +
                "мы найдем все необходимое, что поможет нам победить этого босса. Главное, не сдавайся, мой дорогой друг.\n" +
                "Мы появились с тобой в очень-очень древнем болоте, куда не ступала нога человека уже долгие века..\n" +
                "Баба Яга! Она коварна и непредсказуема, будь внимателен. Удачи!\n"
            };
            Console.ReadLine(); //начало пути
            Console.WriteLine("Во время одной из своих экспедиций в древний город Вы наткнулись на таинственную башню, которая стояла на окраине города" +
                "\r\nВдруг Вы подскользнулись и упали, потеряв сознание");
            Console.ReadLine();
            Console.WriteLine("*Вы приходите в себя, перед вашими глазами непонятный огонек*");
            Console.ReadLine();
            Console.WriteLine("Добро пожаловать в Башню.\nНам придется пройти 5 этажей, чтобы выбраться из нее.\nДавайте познакомимся! Как Вас зовут ?");
            string name = Console.ReadLine();
            player = new Player(name);
            Console.WriteLine("Приятно познакомиться. \nЯ Эса, Ваш интерактивный помощник, который расскажет, что Вас будет ждать на каждом этаже.\r\n");
            Console.WriteLine("Ну что, попытаемся выбраться?");
            Console.WriteLine("1) Давай попробуем, вдруг получится)\r\n2) Нет, слишком сложно. Давай останемся тут, вдруг нас спасут. \r\n");

            while (true) //выбор: пройти башню или нет
            {
                try
                {
                    choise = Convert.ToInt32(Console.ReadLine());
                    if (choise == 1 || choise == 2)
                        break;
                }
                catch

                {
                    Console.WriteLine("*Нет такого варианта ответа*");
                }
            }

            if (choise == 2)
            {
                Console.WriteLine("*К сожалению, Вас никто не спас, Вы погибли(((*");
                Console.ReadLine();
                Environment.Exit(0);
            }
            else if (choise == 1)
            {
                Console.WriteLine("Держи меч, он поможет в прохождении!");
                Console.WriteLine("*Вы взяли меч. Повернувшись к двери, Вы открыли ее и начали путь испытаний*");

                int i = 1;
                int qi = i;
                while ((i <= 5 && i > 0) && !player.Death())
                {

                    Console.WriteLine($"*Вы на {i}-м этаже*");
                    Console.WriteLine($"{floor[i]}");
                    enemy = new Enemy(player, i);
                    Console.WriteLine(player.Description());
                    Console.WriteLine($"Здоровье у монстра: {enemy.Hp}");
                    Console.WriteLine(menu.fight());
                    while (!enemy.Death() && !player.Death())
                    {
                        try
                        {
                            choise = Convert.ToInt32(Console.ReadLine());
                            if (choise == 1)
                            {
                                player.Out_damage(enemy);
                                Console.WriteLine($"*Вы нанесли урон врагу {player.Damage}*");
                                player.In_damage(enemy);
                                Console.WriteLine($"*Враг нанёс Вам {enemy.Damage}*");
                            }
                            else if (choise == 2)
                            {
                                if (player.Dodge())
                                {
                                    Console.WriteLine("*Вам удалось уклониться*");
                                }
                                else
                                {
                                    Console.WriteLine("*Уклон не сработал*");
                                    player.In_damage(enemy);
                                    Console.WriteLine($"*Враг нанёс Вам {enemy.Damage}*");
                                    if (player.Death())
                                    {

                                    }
                                }
                            }
                           /* else if (choise == 3)
                            {
                                if (player.Bow != null)
                                {
                                    Console.WriteLine(player.Weap());
                                }
                                else
                                {
                                    Console.WriteLine("*Нет оружия для смены*");
                                }
                            }*/
                        }
                        catch
                        {
                            Console.WriteLine("*Выберите одно действие*");
                        }
                    }
                    if (player.Death())
                    {
                        Console.WriteLine("Увы, мы не смогли пройти эту Башню((( \nБосс оказался сильнее,  чем мы думали. Но мы попытались)");
                        Console.ReadLine();
                        Environment.Exit(0);
                    }
                    if (enemy.Death())
                    {
                        Console.WriteLine($"Поздравляю! Вы победили монстра {i}-го этажа");
                    }
                    choise_menu = 0;
                    player.LvL_up(i);

                    while (i == qi)
                    {
                        Console.WriteLine(menu.main_menu());
                        try
                        {
                            choise_menu = Convert.ToInt32(Console.ReadLine());
                        }
                        catch
                        {
                            Console.WriteLine("*Нет такого варианта ответа*");
                        }
                        if (choise_menu == 1)
                        {
                            i++;
                            qi = i;
                            break;
                        }
                        else if (choise_menu == 2)
                        {
                            Console.WriteLine("*Вы вздремнули и восстановили силы*");
                            player.Sleep();
                        }
                        else if (choise_menu == 3)
                        {
                            try
                            {
                                if (player.Stats > 0)
                                {
                                    Console.WriteLine(menu.stat());
                                    choise_stat = Convert.ToInt32(Console.ReadLine());
                                    if (choise_stat == 1 || choise_stat == 2 || choise_stat == 3 || choise_stat == 4)
                                    {
                                        player.Stats_up(choise_stat);
                                    }
                                }
                                else { Console.WriteLine("*Нет доступных очков характеристики*"); }
                            }
                            catch
                            {
                                Console.WriteLine("*Нет такого варианта ответа*");
                            }
                        }
                        else if (choise_menu == 4)
                        {
                            Console.WriteLine(player.Description());
                        }

                        choise_menu = 0;
                    }
                }
                if (i == 6 && !player.Death())
                {
                    Console.WriteLine("УРААА, МЫ СМОГЛИ ПОБЕДИТЬ ЕЕ! Теперь ты можешь вернуться домой и жить спокойно и счастливо! \nТЫ ОГРОМНЫЙ МОЛОДЕЦ, и тебе не страшны никакие преграды, только вперед! СВОБОДАААААААА \nНадеюсь, мы с тобой не увидимся,в хорошем смысле слова, чтобы вновь не попадаться на такие приключения)");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
            }

        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower
{
    internal class Menu
    {
        public string main_menu()
        {
            return "1)Начать бой\n2)вздремнуть(восстановить здоровье)\n3)Прокачать статы\n4)Посмотретить свои характеристики\n5)Лечь спать";
        }
        public string fight()
        {
            return "1.Ударить\n2.Уклониться\n3.Сменить оружие";
        }
    }
}

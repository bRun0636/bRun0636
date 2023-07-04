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
            return "1) Продолжить испытания\n2) Вздремнуть (восстановить здоровье)\n3) Прокачать статы\n4) Посмотреть характеристику";
        }
        public string fight()
        {
            return "1) Ударить\n2) Уклониться";
        }
        public string stat()
        {
            return "1) Повысить здоровье\n2) Повысить удачу\n3) Повысить шанс уклона\n4)Повысить качество меча";
        }
    }
}

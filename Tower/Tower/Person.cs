using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower
{
        abstract class Person
        {
            protected Random rnd = new Random();
            protected int hp, lvl;
            protected string name;
            protected bool IsDeath;
            public bool Death()
            {    // проверяет мертв ли персонаж
                return IsDeath = hp <= 0;
            }
            public int Hp
            {            // показывает сколько здоровья
                get { return hp; }
                set { hp = value; }
            }
            public int Lvl
            {
                get { return lvl; }
            }
        }
        internal class Player : Person
        {
            Weapon sword;
            Weapon bow;
            int stats, xp, luck;
            int max_hp, max_xp;
            double critical_damage, dodge;
            bool weap;
            string name;
            public Player(string name)
            {
                this.name = name;           //имя персонажа
                IsDeath = false;            //булевая переменная, показывает умер ли игрок
                hp = 100;
                dodge = rnd.Next(10, 30);   //шанс уклона
                xp = 0;                     //опыт
                lvl = 1;                    //уровень
                critical_damage = 1.2;      //коэффицент крит. урона
                luck = rnd.Next(10, 20);    //удача(шанс крит. урона)
                stats = 0;                  //очки повышения характеристек
                max_hp = 100;
                max_xp = 50;
                sword = new Sword(0);       //первоначальное оружие
                weap = true;                //показывает какое оружие меч/лук
            }
            public bool Dodge()
            {
                return dodge > rnd.Next(1, 100);
            }
            public string Description()
            {    //описание персонажа
                if (bow != null)
                {
                    return $"Имя: {name}\nЗдоровье:{hp}\nУровень:{lvl}\nОпыт:{xp}\nСвободные очки прокачки:{stats}\nОружие:\n{sword.Name} {sword.Rare} класса \n{bow.Name} {bow.Rare} класса";
                }
                else
                {
                    return $"Имя: {name}\nЗдоровье:{hp}\nУровень:{lvl}\nОпыт:{xp}\nСвободные очки прокачки:{stats}\nОружие:\n{sword.Name} {sword.Rare} класса";
                }
            }
            public Weapon Sword
            {            //замена меча
                get { return sword; }
                set { sword = value; }
            }
            public Weapon Bow
            {              //замена лука
                get { return bow; }
                set { bow = value; }
            }
            public void LvL_up(int n)
            {      //получение опыта и повышения уровня
                if (n < 5)
                {
                    xp += rnd.Next(10, 40);
                }
                else if (n > 5 && n < 9)
                {
                    xp += rnd.Next(40, 80);
                }
                else if (n == 5)
                {
                    xp += 100;
                }
                else if (n == 9)
                {
                    xp += 250;
                }
                else if (n == 10)
                {
                    xp += 500;
                }
                if (xp >= max_xp)
                {
                    xp -= max_hp;
                    max_hp += 50;
                    stats += 3;
                    lvl += 1;
                }
            }
            public void Stats_up(int n)
            {    //повышения здоровья/выносливости/удачи/ловкости
                switch (n)
                {
                    case 1:
                        max_hp += 30;
                        hp = max_hp;
                        stats--;
                        break;
                    case 2:
                        luck += rnd.Next(5, 10);
                        stats--;
                        break;
                    case 3:
                        dodge += rnd.Next(5, 10);
                        stats--;
                        break;
                }
            }
            public void Out_damage(Enemy e)
            { //урон врагу
                if (weap)
                {
                    if (luck <= rnd.Next(1, 100))
                    {
                        e.Hp -= sword.Damage;
                    }
                    else
                    {
                        e.Hp -= Convert.ToInt32(sword.Damage * critical_damage);
                    }
                }
                else
                {
                    if (luck <= rnd.Next(1, 100))
                    {
                        e.Hp -= bow.Damage;
                    }
                    else
                    {
                        e.Hp -= Convert.ToInt32(bow.Damage * critical_damage);
                    }
                }
            }
            public void In_damage(Enemy e)
            { //получение урона
                hp -= e.Damage;
            }
            public void Sleep() //восстановвление здоровья
            {
                hp = max_hp;
            }
        }
    internal class Enemy : Person 
    { 
        int damage; 
        List<string> enemies = new List<string>() { "Гаргамель", "Леший", "Жвачник", "Вампир", "Баба Яга" };
        public Enemy(Player p, int n) 
        { 
            IsDeath = false; 
            name = enemies[n - 1]; 
            hp = rnd.Next(-30, 30) + p.Hp; if (p.Lvl > 4) 
            { 
                lvl = p.Lvl + rnd.Next(-3, 3); 
            }
            else 
            { 
                lvl = p.Lvl;
            } 
            damage = rnd.Next(5, 15) * lvl; 
        } 
        public int Damage 
        { 
            get 
            { 
                return damage; 
            }
        }
    }

}


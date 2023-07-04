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
        protected int hp, lvl, damage;
        protected string name;
        protected bool IsDeath;
        public bool Death()
        {    // проверяет мертв ли персонаж
            return IsDeath = (hp <= 0);
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
        public int Damage
        {
            get
            {
                return damage;
            }
        }
    }
    internal class Player : Person
    {
        Weapon sword;
        //Weapon bow;
        int stats, xp, luck, n;
        int max_hp, max_xp;
        double critical_damage, dodge;
        //bool weap;
        string name;

        public Player(string name)
        {
            this.name = name;           //имя персонажа
            IsDeath = false;            //булевая переменная, показывает умер ли игрок
            hp = 100;
            dodge = rnd.Next(10, 30);   //шанс уклона
            xp = 0;                     //опыт
            lvl = 1;                    //уровень
            critical_damage = 1.2;      //коэффициент крит. урона
            luck = rnd.Next(10, 20);    //удача (шанс крит. урона)
            stats = 0;                  //очки повышения характеристик
            max_hp = 100;
            max_xp = 50;
            n = 0;
            sword = new Sword(n);       //первоначальное оружие
                                        // weap = true;                //показывает, какое оружие меч/лук взят
        }
        public int Max_hp
        {
            get { return max_hp; }
        }
        public bool Dodge()
        {
            return dodge > rnd.Next(1, 100);
        }
        /*public string Weap()
        {
            if (weap)
            {
                weap = false;
                return "У вас в руках лук";
            }
            else
            {
                weap = true;
                return "У вас в руках меч";
            }
        }*/
        public string Description()
        {    //описание персонажа
            /*if (!weap)
            {
                return $"Имя: {name}\nЗдоровье:{hp}\nУровень:{lvl}\nОпыт:{xp}\nСвободные очки прокачки:{stats}\nОружие:\n{bow.Name} {bow.Rare} класса";
            }
            else
            {
            }*/
            return $"Имя: {name}\nЗдоровье:{hp}\nУровень:{lvl}\nОпыт:{xp}\nСвободные очки прокачки:{stats}\nОружие:\n{sword.Name} {sword.Rare} класса";
        }
        /*public Weapon Sword
        {
            get { return sword; }
            //замена меча
            set { sword = value; }
        }
        public Weapon Bow
        {              //замена лука
            get { return bow; }
            set { bow = value; }
        }*/
        public void LvL_up(int n)
        {      //получение опыта и повышения уровня
            switch (n)
            {
                case 1:
                    xp += rnd.Next(30, 60);
                    break;
                case 2:
                    xp += rnd.Next(70, 100);
                    break;
                case 3:
                    xp += rnd.Next(110, 140);
                    break;
                case 4:
                    xp += rnd.Next(150, 180);
                    break;
                case 5:
                    xp += rnd.Next(200, 250);
                    break;
            }
            if (xp > max_xp)
            {
                xp -= max_xp;
                lvl++;
                stats += 2;
            }
        }
        public int Stats
        {
            get { return stats; }
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
                case 4:
                    if (this.n < 5)
                    {
                        stats--;
                        this.n++;
                        sword = new Sword(this.n);
                    }
                    break;
            }
        }
        public void Out_damage(Enemy e)
        { //урон врагу

            if (luck <= rnd.Next(1, 100))
            {
                damage = sword.Damage;
                e.Hp -= damage;
            }
            else
            {
                damage = Convert.ToInt32(sword.Damage * critical_damage);
                e.Hp -= damage;
            }
            /*if (weap)
            {
            }
            else
            {
                if (luck <= rnd.Next(1, 100))
                {
                    damage = bow.Damage;
                    e.Hp -= damage;
                }
                else
                {
                    damage = Convert.ToInt32(bow.Damage * critical_damage);
                    e.Hp -= damage;
                }
            }*/
        }
        public void In_damage(Enemy e)
        { //получение урона
            hp -= e.Damage;
        }
        public void Sleep() //восстановление здоровья
        {
            hp = max_hp;
        }
    }
    internal class Enemy : Person
    {
        public Enemy(Player p, int n)
        {
            IsDeath = false;
            hp = rnd.Next(-30, 20) + p.Max_hp;
            damage = rnd.Next(5, 10) * n;
        }

    }

}


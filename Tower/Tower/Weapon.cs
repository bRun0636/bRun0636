using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower
{
    abstract class Weapon
    {
        protected Random rnd = new Random();
        protected string range, name, rare;
        protected List<string> rares = new List<string>() { "F", "C", "A", "S", "S++" };
        protected int damage;
        public string Name
        {
            get { return name; }
        }
        public string Rare //редкость
        {
            get { return rare; }
        }
        public string description()
        {    //описание оружия
            return $"Оружие:{name} {rare} класса";
        }
        public int Damage //урон
        {
            get { return damage; }
        }
    }
    /*internal class Bow : Weapon
    {
        public Bow(int n)
        {
            name = "лук";
            range = "Длинная";
            rare = rares[n];
            damage = rnd.Next(8, 11) * (n + 1);
        }
    }*/
    internal class Sword : Weapon
    {
        public Sword(int n)
        {
            name = "меч";
            range = "Короткая";
            rare = rares[n];
            damage = rnd.Next(8, 11) * (n + 1);
        }

    }
}
// internal class Shield:Weapon{
//     public Shield(string name, int n){
//         this.name = name;
//         rare = rares[n];
//         damage = rnd.Next(3, 7) * (n+1);
//     }
//     public void absorption(Enemy e){
//         e.Damage -= damage;
//     }
// }


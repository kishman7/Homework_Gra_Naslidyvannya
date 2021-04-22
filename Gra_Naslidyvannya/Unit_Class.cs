using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gra_Naslidyvannya
{
    public class Unit
    {
        public int Hp { get; set; } // життя
        public int Dmg { get; set; } // пошкодження при атаці
        public int Dodge { get; set; } // шанс ухилятись у %
        public string Name { get; set; } // ім’я учасника
        public string Teams { get; set; } = ""; // назва команди

        public Unit(string tem)
        {
            this.Teams = tem;
        }

        public Unit()
        {
        }

        public void Attack()
        {
            Console.WriteLine("Attack!"); // атакувати
        }
        public void Dodge_Attacks()
        {
            Console.WriteLine("Avoid attacks!"); // ухилятись від атак
        }
        public void Death()
        {
            Console.WriteLine("Death!"); // помирати
        }
        public string ShowUnit()
        {
            return this.Name;
        }
        public void ShowGamer() // стан гравця
        {
            if (this.Hp <= 0)
                Console.WriteLine($"{this.Name} Dead");
            else
                Console.WriteLine($"{this.Name} Life: {this.Hp}");
        }
    }
}

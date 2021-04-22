using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gra_Naslidyvannya
{
    public class Swordsman :  Unit
    {
        public Swordsman(string tem) : base(tem)
        {
            this.Hp = 15;
            this.Dmg = 5;
            this.Dodge = 60;
            this.Name = "Swordsman";
        }
    }
    public class Archer : Unit
    {
        public Archer(string tem) : base(tem)
        {
            this.Hp = 12;
            this.Dmg = 4;
            this.Dodge = 40;
            this.Name = "Archer";
        }
    }
    public class Mage : Unit
    {
        public Mage(string tem) : base(tem)
        {
            this.Hp = 8;
            this.Dmg = 10;
            this.Dodge = 30;
            this.Name = "Mage";
        }
    }
}

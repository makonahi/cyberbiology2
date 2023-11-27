using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace cyberbiology2
{
    public class Seasons
    {
        public int sunPower;
        public string name;
        public Color color;
        public string symbolName;
        public Seasons(int tsunPower,string tname, Color tcolor, string tsymbolName)
        {
            this.sunPower = tsunPower;
            this.name = tname;
            this.color=tcolor;
            this.symbolName = tsymbolName;
        }
    }
}

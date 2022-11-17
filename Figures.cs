using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace convert
{
    public class Figures
    {
        public string Name;
        public int Height;
        public int Width;
        public Figures(string name, int height, int width)
        {
            this.Name = name;
            this.Height = height;
            this.Width = width;
        }
        public Figures()
        {

        }
    }
}

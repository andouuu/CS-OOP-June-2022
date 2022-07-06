using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    internal class Lizard : Reptile
    {
        public Lizard(string name) : base(name)
        {
        }
        public string Name
        {
            get { return base.Name; }
            set { base.Name = value; }
        }
    }
}

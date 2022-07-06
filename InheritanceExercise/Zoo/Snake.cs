using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    internal class Snake : Reptile
    {
        public Snake(string name) : base(name)
        {
        }
        public string Name
        {
            get { return base.Name; }
            set { base.Name = value; }
        }
    }
}

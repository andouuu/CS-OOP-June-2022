using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    internal class Bear : Mammal
    {
        public Bear(string name) : base(name)
        {
        }
        public string Name
        {
            get { return base.Name; }
            set { base.Name = value; }
        }
    }
}

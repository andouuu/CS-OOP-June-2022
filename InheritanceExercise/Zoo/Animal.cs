﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    internal class Animal
    {
        private string name;
        public Animal(string name)
        {
            this.Name = name;
        }
        public string Name { get { return this.name; } set { this.name = value; } }
    }
}

﻿using Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string NamePlural { get; set; }
        public int Size { get; set; }
        public int DropPercentage { get; set; }

        public Item(int id, string name, string namePlural, int size, int dropPercentage)
        {
            ID = id;
            Name = name;
            NamePlural = namePlural;
            Size = size;
            DropPercentage = dropPercentage;
        }
    }
}

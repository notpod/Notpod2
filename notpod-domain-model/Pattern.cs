﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Serialization;

namespace Notpod.Domain
{

    public class Pattern
    {
        private string id;
        
        private string name;

        private string format;
        
        private string compilationformat;
        
        private string description;

        private Pattern()
        {
        }

        public static Pattern Instance(string id, string name, string format)
        {
            Pattern pattern = new Pattern();
            pattern.id = id;
            pattern.name = name;
            pattern.format = format;
            return pattern;
        }

        [XmlElement("id")]
        public string Id
        {
            set { id = value; }
            get { return id; }
        }
        
        [XmlElement("name")]
        public string Name {
            get { return name; }
            set { name = value; }
        }


        [XmlElement("format")]
        public string Format
        {
            set { format = value; }
            get { return format; }
        }

        [XmlElement("compilationformat")]        
        public string Compilationformat {
            get { return compilationformat; }
            set { compilationformat = value; }
        }
        
        [XmlElement("description")]
        public string Description {
            get { return description; }
            set { description = value; }
        }

    }
}

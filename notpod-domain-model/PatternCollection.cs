﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Notpod.Domain
{
    [XmlRoot("patterncollection")]
    public class PatternCollection
    {
        private List<Pattern> patterns = new List<Pattern>();
           
        [XmlElement("patterns")]
        public List<Pattern> Patterns
        {
            set { patterns = value; }
            get { return patterns; }
        }
    }
}

﻿using System;
using System.Collections.Generic;

namespace CollectionViewUpgrade.Models
{
    public class Slide
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Image { get; set; }
        public string Paragraph1 { get; set; }
        public string Paragraph2 { get; set; }
        public SlideType SlideType { get; set; }
        public object Points { get; set; }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraversalYoutube.EntityLayer.Concrete;
public class Guide
{
    public int GuideID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public string TwitterUrl { get; set; }
    public string Description2 { get; set; }
    public string InstagramUrl { get; set; }
    public bool Status { get; set; }
    public List<Destination> Destinations { get; set; }
}

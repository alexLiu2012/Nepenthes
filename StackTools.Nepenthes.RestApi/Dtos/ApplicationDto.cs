﻿using System.Collections.Generic;

namespace StackTools.Nepenthes.RestApi.Dtos
{
    public class ApplicationDto
    {
        //public string Id { get; set; }

        public string Name { get; set; }
        public string Type { get; set; }

        //public string Origin { get; set; }

        public List<string> Locations { get; set; }
    }
}

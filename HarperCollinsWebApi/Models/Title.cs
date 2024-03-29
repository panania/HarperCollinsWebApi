﻿﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HarperCollinsWebApi.Models
{
    public class Title
    {
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string PublicationTitle { get; set; }
        public string Author { get; set; }
        public string PublicationFormat { get; set; }
        [Column(TypeName = "money")]
        public decimal ListPrice { get; set; }
    }
}
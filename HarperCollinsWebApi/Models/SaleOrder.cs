<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarperCollinsWebApi.Models
{
    public class SaleOrder
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int TitleId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Quantity { get; set; }
        public bool IsActive { get; set; }

        public Customer Customer { get; set; }
        public Title Title { get; set; }
    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarperCollinsWebApi.Models
{
    public class SaleOrder
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int TitleId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Quantity { get; set; }
        public bool IsActive { get; set; }

        public Customer Customer { get; set; }
        public Title Title { get; set; }
    }
}
>>>>>>> 170412e4236f2b2d23354ca322baa1af1e3afbce

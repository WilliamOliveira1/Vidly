﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly1.Models
{
    public class MembershipTypes
    {
        public byte Id { get; set; }
        public short SingUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }
    }
}
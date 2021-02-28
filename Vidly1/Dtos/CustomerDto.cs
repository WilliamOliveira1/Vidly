﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly1.Models;

namespace Vidly1.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(255)] // This is how we limit the string length
        public string Name { get; set; }

        public DateTime Birthday { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public byte MenbershipTypeId { get; set; }
    }
}
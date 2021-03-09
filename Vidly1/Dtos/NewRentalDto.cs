using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly1.Dtos
{
    public class NewRentalDto
    {
        /// <summary>
        /// The ID from customer to rental 
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Id's from movies that will be rented
        /// </summary>
        public List<int> MovieIds{ get; set; }
    }
}
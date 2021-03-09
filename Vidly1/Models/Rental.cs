using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly1.Models
{
    public class Rental
    {
        /// <summary>
        ///  Id from new rental
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Date that customer rent the movie
        /// </summary>
        public DateTime DateRented { get; set; }

        /// <summary>
        ///  Date that customer returned the movie
        /// </summary>
        public DateTime? DateReturned { get; set; }

        /// <summary>
        /// Customer information
        /// </summary>
        [Required]
        public Customer Customer { get; set; }

        /// <summary>
        ///  Movies information
        /// </summary>
        [Required]
        public Movie Movie { get; set; }
    }
}
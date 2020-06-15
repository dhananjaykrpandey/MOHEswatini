using MOHEswatini.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace arnikainfotech.Models
{
    public class MSitemap
    {
        
        [Required]
        public ClsUtility.SitemapFrequency? Frequency { get; set; } = ClsUtility.SitemapFrequency.Monthly;
        [Required]
        public string LastModified { get; set; } = DateTime.Now.ToString("yyyy-MM-dd");
        [Required]
        public double? Priority { get; set; }
        [Required]
        public string Url { get; set; }
    }

}

using System;

namespace OS.Web.Models.Statistics
{
    public class ProductViewFreqencyViewModel
    {
        public string IpAddress { get; set; }
        public DateTime LastViewDate { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string UserId { get; set; }
        public int ViewCount { get; set; }
    }
}
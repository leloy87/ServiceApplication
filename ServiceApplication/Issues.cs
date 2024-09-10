using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceApplication
{
    public class Issues
    {
        public int Id { get; set; } // Issue ID for unique identification
        public string Location { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }

        // Use an array to store attachments
        public string[] Attachments { get; set; }

        // Constructor to initialize the issue with attachments
        public Issues(int id, string location, string category, string description, string[] attachments)
        {
            Id = id;
            Location = location;
            Category = category;
            Description = description;
            Attachments = attachments; // Store attachments in an array
        }
    }
}

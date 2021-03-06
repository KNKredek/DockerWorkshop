using System;

namespace Crayons.Web.Models
{
    public class Book : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public Author Author { get; set; }
    }
}
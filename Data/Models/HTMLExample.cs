using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class HTMLExample
    {
        public int Id { get; set; }
        [MaxLength]
        public string HTMLCode { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastEditedDate { get; set; }
        public string PreviousHTMLCode { get; set; }
    }
}

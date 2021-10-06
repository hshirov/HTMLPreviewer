using System;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class RenderHTMLViewModel
    {
        public int Id { get; set; }
        [MaxLength(ErrorMessage = "The size of the code exceeds the limit.")]
        public string HTMLCode { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastEditedDate { get; set; }
        public string PreviousHTMLCode { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Excite.Web.Models
{
    public class IndexViewModel
    {
        [Required]
        public string Text { get; set; }

        [Required]
        public string SubText { get; set; }

        public string Result { get; set; }
    }
}
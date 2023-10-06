﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSIU_WEB.Models
{
    public class ContentCategory
    {
        [Key]
        public int Id { get; set; }

        
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public int Category {get; set; }
        public int ContentId { get; set; }

        [ForeignKey("ContentId")]
        public Content Content { get; set; }
    }
}

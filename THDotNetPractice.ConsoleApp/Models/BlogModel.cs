﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THDotNetPractice.ConsoleApp.Models
{
    [Table("Tbl_Blog")]
    public class BlogModel
    {
        [Key]
        //[Column("BlogId")] //If the db comumn and model field are not same,
        public int BlogId { get; set; }
        public string BlogTitle { get; set; }
        public string BlogAuthor { get; set; }
        public string BlogContent { get; set; }
    }
}

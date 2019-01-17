using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PictureService.Models
{
    public class Picture
    { 
        public int ID { get; set; }
        public string Name { get; set; }
        public byte[] PictureFile { get; set; }
    }
}

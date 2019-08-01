using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class FileRequest
    {
        public string Alt { get; set; }
        public IFormFile File { get; set; }
        public int ProductId { get; set; }
    }
}

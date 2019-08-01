using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Helpers
{
    public class UploadFile
    {
        public static IEnumerable<string> AllowedExtensions => new List<string> { ".jpeg", ".jpg", ".png", ".gif" };
    }
}

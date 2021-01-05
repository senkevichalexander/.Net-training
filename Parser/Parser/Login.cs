using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parser
{
    public class Login
    {
        public string Name { get; set; }
        public List<Window> Windows { get; set; }

        public Login(string name, List<Window> windows)
        {
            Name = name;
            Windows = windows;
        }
        public bool IsValid()
        {
            return Windows.Any(x => x.Title == "main" && x.Top.HasValue && x.Left.HasValue && x.Heigth.HasValue && x.Width.HasValue);
        }

        public void Fix()
        {
            foreach (var item in Windows)
            {
                if (!item.Top.HasValue) item.Top = 0;
                if (!item.Left.HasValue) item.Left = 0;
                if (!item.Width.HasValue) item.Width = 0;
                if (!item.Heigth.HasValue) item.Heigth = 0;
            }
        }
    }
}

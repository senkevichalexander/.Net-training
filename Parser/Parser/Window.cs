using System;
using System.Collections.Generic;
using System.Text;

namespace Parser
{
    public class Window
    {
        public string Title { get; set; }
        public int? Top { get; set; }
        public int? Left { get; set; }
        public int? Width { get; set; }
        public int? Heigth { get; set; }

        public Window(string title, int? top, int? left, int? width, int? heigth)
        {
            Title = title;
            Top = top;
            Left = left;
            Width = width;
            Heigth = heigth;
        }
    }
}

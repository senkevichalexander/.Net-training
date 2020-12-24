using System;
using System.Text.RegularExpressions;

namespace Catalog
{
    public class ISBN
    {
        public string Isbn { get; private set; }

        public ISBN(string isbn)
        {
            var clearIsbn = isbn.Replace("-", "");
            var reg = new Regex("^[0-9]{13}$");

            if (!reg.IsMatch(clearIsbn)) 
            {
                throw new ArgumentException();
            }

            Isbn = isbn;
        }
    }
}

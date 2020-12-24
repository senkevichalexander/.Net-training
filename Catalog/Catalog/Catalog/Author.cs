using System;

namespace Catalog
{
    public class Author
    {        
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public Author(string firstName, string lastName)
        {
            if (firstName.Length > 200 || lastName.Length > 200)
            {
                throw new ArgumentException();
            }

            if(string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            {
                throw new ArgumentException();
            }

            LastName = lastName;
            FirstName = firstName;
        }
    }
}

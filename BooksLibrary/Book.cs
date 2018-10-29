using System;
using System.Reflection;

namespace BooksLibrary
{
    public class Book : IEquatable<Book>, IComparable<Book>, IComparable
    {
        private PropertyInfo[] propertyList;
        public string ISBN { private set; get; }
        public string Author { private set; get; }
        public string Title { private set; get; }
        public string PublishingHouse { private set; get; }
        public string YearOfPublishing { private set; get; }
        public string NumberOfPages { private set; get; }
        public string Price { private set; get; }

        ///<summary>
        ///private constructor, that get information about
        ///properties of the class with a help of Reflection
        /// </summary>
        private Book() 
        {
            propertyList = GetProperties();
        }

        /// <summary>
        /// public constructor: initialize fields
        /// </summary>
        /// <param name="values">source parameters</param>
        public Book(string[] values) : this()
        {
            if (values.Length < propertyList.Length)
                throw new ArgumentException("Not enough input arguments!");

            for (int i = 0; i < propertyList.Length; i++)
            {
                propertyList[i].SetValue(this, values[i]);
            }
        }

        /// <summary>
        /// Method of IComparable 'Book' to compare 
        /// objects with type 'Book'
        /// </summary>
        /// <param name="book">source object for comparison</param>
        /// <returns>result of comparison</returns>
        public int CompareTo(Book book)
        {
            if (Equals(book))
                return 0;

            return Author.CompareTo(book.Author);
        }

        /// <summary>
        /// Method of IComparable for comparison
        /// objects with type 'object'
        /// </summary>
        /// <param name="obj">source object for comparison</param>
        /// <returns>result of comparison</returns>
        int IComparable.CompareTo(object obj)
        {
            if (!(obj is Book))
                throw new InvalidOperationException("CompareTo: Not a Book");

            return CompareTo((Book)obj);
        }

        /// <summary>
        /// Method represent object as a row
        /// </summary>
        /// <returns>row with type 'string'</returns>
        public override string ToString()
        {
            string summary = "";

            for (int i = 0; i < propertyList.Length - 1; i++)
            {
                summary += propertyList[i].Name + ":" + " *" + propertyList[i].GetValue(this) + "* ";
            }

            return summary;
        }

        /// <summary>
        /// Method to compare on equality of interface IEquatable 'Book'
        /// </summary>
        /// <param name="book">object for comparison on equality</param>
        /// <returns>bool result</returns>
        public bool Equals(Book book)
        {
            for (int i = 0; i < propertyList.Length - 1; i++)
            {
                var fisrtArg = this.propertyList[i].GetValue(this);
                var secondArg = book.propertyList[i].GetValue(book);

                if (!fisrtArg.Equals(secondArg))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Method to compare on equality
        /// </summary>
        /// <param name="obj">object for comparison on equality</param>
        /// <returns>result of equality comparison, type bool</returns>
        public override bool Equals(object obj)
        {
            Book book = obj as Book;

            if (book != null)
                return Equals(book);

            return false;
        }

        /// <summary>
        /// Method for calculation unique code
        /// </summary>
        /// <returns>hash</returns>
        public override int GetHashCode()     
        {
            int hash = 0;

            for (int i = 0; i < propertyList.Length - 1; i++)
            {
                hash += propertyList[i].GetValue(this).GetHashCode();
            }

            return base.GetHashCode();
        }

        /// <summary>
        /// Method gets properties parameters
        /// </summary>
        /// <returns>array of properties parameters</returns>
        public static PropertyInfo[] GetProperties()
        {
            return typeof(Book).GetProperties(BindingFlags.Instance | BindingFlags.Public);
        }
    }
}

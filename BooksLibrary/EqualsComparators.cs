using System.Collections.Generic;

namespace BooksLibrary
{
    /// <summary>
    /// Compare for equality objects acccording to field ISBN 
    /// </summary>
    public class ISBNEqualComparer : IEqualityComparer<Book>
    {
        public bool Equals(Book firstArg, Book secondArg)
        {
            return firstArg.ISBN.Equals(secondArg.ISBN);
        }

        public int GetHashCode(Book obj)
        {
            return obj.ISBN.GetHashCode();
        }
    }

    /// <summary>
    /// Compare for equality objects acccording to field Author
    /// </summary>
    public class AuthorEqualComparer : IEqualityComparer<Book>
    {
        public bool Equals(Book firstArg, Book secondArg)
        {
            return firstArg.Author.Equals(secondArg.Author);
        }

        public int GetHashCode(Book obj)
        {
            return obj.Author.GetHashCode();
        }
    }

    /// <summary>
    /// Compare for equality objects acccording to field Title
    /// </summary>
    public class TitleEqualComparer : IEqualityComparer<Book>
    {
        public bool Equals(Book firstArg, Book secondArg)
        {
            return firstArg.Title.Equals(secondArg.Title);
        }

        public int GetHashCode(Book obj)
        {
            return obj.Title.GetHashCode();
        }
    }

    /// <summary>
    /// Compare for equality objects acccording to field PublishingHouse
    /// </summary>
    public class PublishingHouseEqualComparer : IEqualityComparer<Book>
    {
        public bool Equals(Book firstArg, Book secondArg)
        {
            return firstArg.PublishingHouse.Equals(secondArg.PublishingHouse);
        }

        public int GetHashCode(Book obj)
        {
            return obj.PublishingHouse.GetHashCode();
        }
    }

    /// <summary>
    /// Compare for equality objects acccording to field YearOfPublishing
    /// </summary>
    public class YearOfPublishingEqualComparer : IEqualityComparer<Book>
    {
        public bool Equals(Book firstArg, Book secondArg)
        {
            return firstArg.YearOfPublishing.Equals(secondArg.YearOfPublishing);
        }

        public int GetHashCode(Book obj)
        {
            return obj.YearOfPublishing.GetHashCode();
        }
    }

    /// <summary>
    /// Compare for equality objects acccording to field NumberOfPages
    /// </summary>
    public class NumberOfPagesEqualComparer : IEqualityComparer<Book>
    {
        public bool Equals(Book firstArg, Book secondArg)
        {
            return firstArg.NumberOfPages.Equals(secondArg.NumberOfPages);
        }

        public int GetHashCode(Book obj)
        {
            return obj.NumberOfPages.GetHashCode();
        }
    }

    /// <summary>
    /// Compare for equality objects acccording to field Price
    /// </summary>
    public class PriceEqualComparer : IEqualityComparer<Book>
    {
        public bool Equals(Book firstArg, Book secondArg)
        {
            return firstArg.Price.Equals(secondArg.Price);
        }

        public int GetHashCode(Book obj)
        {
            return obj.Price.GetHashCode();
        }
    }
}

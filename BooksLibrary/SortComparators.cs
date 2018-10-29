using System.Collections.Generic;

namespace BooksLibrary
{
    /// <summary>
    /// Compare objects to define their order relations acccording to field ISBN
    /// </summary>
    public class ISBNSortComparer : IComparer<Book>
    {
        public int Compare(Book firstArg, Book secondArg)
        {
            if (firstArg.Equals(secondArg))
                return 0;

            return firstArg.ISBN.CompareTo(secondArg.ISBN);
        }
    }

    /// <summary>
    /// Compare objects to define their order relations acccording to field Author 
    /// </summary>
    public class AuthorSortComparer : IComparer<Book>
    {
        public int Compare(Book firstArg, Book secondArg)
        {
            if (firstArg.Equals(secondArg))
                return 0;

            return firstArg.Author.CompareTo(secondArg.Author);
        }
    }

    /// <summary>
    /// Compare objects to define their order relations acccording to field Title
    /// </summary>
    public class TitleSortComparer : IComparer<Book>
    {
        public int Compare(Book firstArg, Book secondArg)
        {
            if (firstArg.Equals(secondArg))
                return 0;

            return firstArg.Title.CompareTo(secondArg.Title);
        }
    }

    /// <summary>
    /// Compare objects to define their order relations acccording to field PublishingHouse
    /// </summary>
    public class PublishingHouseSortComparer : IComparer<Book>
    {
        public int Compare(Book firstArg, Book secondArg)
        {
            if (firstArg.Equals(secondArg))
                return 0;

            return firstArg.PublishingHouse.CompareTo(secondArg.PublishingHouse);
        }
    }

    /// <summary>
    /// Compare objects to define their order relations acccording to field YearOfPublishing
    /// </summary>
    public class YearOfPublishingSortComparer : IComparer<Book>
    {
        public int Compare(Book firstArg, Book secondArg)
        {
            if (firstArg.Equals(secondArg))
                return 0;

            return firstArg.YearOfPublishing.CompareTo(secondArg.YearOfPublishing);
        }
    }

    /// <summary>
    /// Compare objects to define their order relations acccording to field NumberOfPages
    /// </summary>
    public class NumberOfPagesSortComparer : IComparer<Book>
    {
        public int Compare(Book firstArg, Book secondArg)
        {
            if (firstArg.Equals(secondArg))
                return 0;

            return firstArg.NumberOfPages.CompareTo(secondArg.NumberOfPages);
        }
    }

    /// <summary>
    /// Compare objects to define their order relations acccording to field Price
    /// </summary>
    public class PriceSortComparer : IComparer<Book>
    {
        public int Compare(Book firstArg, Book secondArg)
        {
            if (firstArg.Equals(secondArg))
                return 0;

            return firstArg.Price.CompareTo(secondArg.Price);
        }
    }
}

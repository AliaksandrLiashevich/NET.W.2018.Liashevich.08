using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace BooksLibrary
{
    public class BookListService
    {
        private string path;
        private List<Book> booksList = new List<Book>(); 

        /// <summary>
        /// Constructor with default parameter 
        /// </summary>
        /// <param name="path">Directory with storage file</param>
        public BookListService(string path = "BooksStorageFile")
        {
            this.path = path;
        }

        /// <summary>
        /// Method add object into collection
        /// </summary>
        /// <param name="book">Instance to add to the collection</param>
        public void AddBook(Book book)
        {
            if (CompareBooks(book))
                throw new Exception("This book already exist!");

            booksList.Add(book);
        }

        /// <summary>
        /// Method remove the same object as argument from the collection
        /// </summary>
        /// <param name="book">Instance that we try to remove</param>
        public void RemoveBook(Book book)
        {
            if (!CompareBooks(book))
                throw new Exception("This book doesn't exist!");

            booksList.Remove(book);
        }

        /// <summary>
        /// Method helper for AddBook and RemoveBook.
        /// Compare argument with instances in the collection 
        /// </summary>
        /// <param name="book"></param>
        /// <returns>Bool result</returns>
        private bool CompareBooks(Book book)
        {
            for (int i = 0; i < booksList.Count; i++)
            {
                if (booksList[i].Equals(book))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Allow to perform search in the collection 
        /// according to tag
        /// </summary>
        /// <param name="tag">Key word</param>
        /// <param name="equality">Comparator</param>
        /// <returns>Collection of found objects</returns>
        public List<Book> FindBooksByTag(string tag, IEqualityComparer<Book> equality)
        {
            Book key = Wrapper(tag);
            List<Book> list = new List<Book>();

            for (int i = 0; i < booksList.Count; i++)
            {
                if (equality.Equals(key, booksList[i]))
                {
                    list.Add(booksList[i]);
                }
            }

            return list;
        }

        /// <summary>
        /// Method for sorting instances in the collection
        /// </summary>
        /// <param name="compare">Comparartor</param>
        public void SortBooksByTag(IComparer<Book> compare)
        {
            booksList.Sort(compare);
        }

        /// <summary>
        /// Method creates wrapper-object for tag
        /// </summary>
        /// <param name="tag">Key-word</param>
        /// <returns>Wrapper-object</returns>
        private Book Wrapper(string tag)
        {
            PropertyInfo[] bookProperties = Book.GetProperties();
            string[] values = new string[bookProperties.Length];

            for (int i = 0; i < bookProperties.Length; i++)
            {
                values[i] = tag;
            }

            return new Book(values);
        }

        /// <summary>
        /// Method to load collection from file
        /// </summary>
        public void LoadFile()
        {
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.OpenOrCreate)))
            {
                while (reader.PeekChar() > -1)
                {
                    string[] values = new string[Book.GetProperties().Length];

                    for (int i = 0; i < values.Length; i++)
                    {
                        values[i] = reader.ReadString();
                    }

                    booksList.Add(new Book(values));
                }
            }
        }

        /// <summary>
        /// Method to save collection to file
        /// </summary>
        public void SaveFile()
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                PropertyInfo[] info = Book.GetProperties();

                foreach (Book book in booksList)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        writer.Write((string)info[i].GetValue(book));
                    }
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_ListOfObjects
{
    /// <summary>
    /// 
    ///     ListOfObjects Quick Code
    ///     
    ///     AUTHORS:    John Dunckel
    ///                 Colin Haroutunian
    ///                 Robert Hosler
    ///     
    /// </summary>

    class Program
    {
        /// <summary>
        /// 
        ///     Methods defining the program's process
        ///     
        /// </summary>

        static void Main(string[] args)
        {
            List<Books> bookList = new List<Books>();
            AddObjects(bookList);
            DisplayObjects(bookList);
        }

        static void AddObjects(List<Books> bookList)
        {
            List<Books.Genre> genreList = new List<Books.Genre>();
            bool addMoreBooks = true;
            
            do
            {
                AddObjectsTextHeader("Would you like to provide additional books?");
                Console.WriteLine();
                addMoreBooks = DualConfirmation();
                if (addMoreBooks == true)
                {
                    Books userObject = new Books();

                    userObject.Title = GetBookTitle();
                    userObject.Author = GetBookAuthor();
                    userObject.Pages = GetBookPages();
                    userObject.ReleaseYear = GetBookRelease();
                    userObject.GenreType = GetBookGenre(genreList);
                    bookList.Add(userObject);
                }
            } while (addMoreBooks == true);
        }

        static void DisplayObjects(List<Books> bookList)
        {
            int sumPages = 0;
            foreach (var book in bookList)
            {
                Console.WriteLine($"Author: {book.Author}");
                Console.WriteLine($"Title: {book.Title}");
                Console.WriteLine($"Pages: {book.Pages.ToString()}");
                sumPages += book.Pages;
                Console.WriteLine($"Release Year: {book.ReleaseYear.ToString()}");
                Console.WriteLine($"Genre: {book.GenreType}");
                Console.WriteLine();
            }

            int averagePages = sumPages / bookList.Count();
            Console.WriteLine($"There is an average of '{averagePages} pages'.");
            Console.WriteLine();
            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();
        }

        /// <summary>
        /// 
        ///     Methods to query the book's properties
        ///     
        /// </summary>
        private static Books.Genre GetBookGenre(List<Books.Genre> genreList)
        {
            Books.Genre genre = Books.Genre.HistoricalFiction;
            bool genreAnswer = false;
            do
            {
                Console.Clear();
                DisplayListOfGenres(genreList);
                AddGenreHeader();
                switch (Console.ReadLine())
                {
                    case "1":
                        genre = Books.Genre.HistoricalFiction;
                        genreAnswer = true;
                        break;
                    case "2":
                        genre = Books.Genre.Fantasy;
                        genreAnswer = true;
                        break;
                    case "3":
                        genre = Books.Genre.Biographical;
                        genreAnswer = true;
                        break;
                    case "4":
                        genre = Books.Genre.Classical;
                        genreAnswer = true;
                        break;
                    case "5":
                        genre = Books.Genre.Politics;
                        genreAnswer = true;
                        break;
                    case "6":
                        genre = Books.Genre.Religious;
                        genreAnswer = true;
                        break;
                    case "7":
                        genre = Books.Genre.Horror;
                        genreAnswer = true;
                        break;
                    case "8":
                        genre = Books.Genre.ScienceFiction;
                        genreAnswer = true;
                        break;
                    case "9":
                        genre = Books.Genre.Romance;
                        genreAnswer = true;
                        break;
                    case "10":
                        genre = Books.Genre.Nonfiction;
                        genreAnswer = true;
                        break;
                    case "11":
                        genre = Books.Genre.Historical;
                        genreAnswer = true;
                        break;
                    default:
                        Console.WriteLine("Please re-enter a choice from the menu, using only numbers 1-11.");
                        break;
                }
            } while (genreAnswer == false);
            return genre;
        }

        private static int GetBookRelease()
        {
            int years;
            bool foundYears = false;
            do
            {
                AddObjectsTextHeader("Please add in the release year here: ");
                foundYears = int.TryParse(Console.ReadLine(), out years);
            } while (foundYears == false);
            return years;
        }

        private static string GetBookAuthor()
        {
            bool correctAuthor = false;
            string author;
            do
            {
                AddObjectsTextHeader("Please enter a title: ");
                author = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine($"Is '{author}' the title that you wanted?");
                correctAuthor = DualConfirmation();
            } while (correctAuthor == false);
            return author;
        }

        private static int GetBookPages()
        {
            bool correctPages = false;
            int pages;
            do
            {
                AddObjectsTextHeader("Please enter the number of pages: ");
                correctPages = int.TryParse(Console.ReadLine(), out pages);
            } while (correctPages == false);
            return pages;
        }

        private static string GetBookTitle()
        {
            bool correctTitle = false;
            string title;
            do
            {
                AddObjectsTextHeader("Please enter a title: ");
                title = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine($"Is '{title}' the title that you wanted?");
                correctTitle = DualConfirmation();
            } while (correctTitle == false);
            return title;
        }

        /// <summary>
        /// 
        ///     Methods to display information on the program
        ///     
        /// </summary>
        private static void DisplayListOfGenres(List<Books.Genre> genreType)
        {
            Console.WriteLine("\tGenre Types:");
            Console.WriteLine();
            int i = 0;
            foreach (string genre in Enum.GetNames(typeof(Books.Genre)))
            {
                i++;
                Console.WriteLine($"\t{i}) {genre}");
            }
        }

        private static void AddGenreHeader()
        {
            Console.WriteLine("\tBook List");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Please select the book's genre: ");
        }

        static void AddObjectsTextHeader(string userQuestion)
        {
            Console.Clear();
            Console.WriteLine("\tBook List");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write(userQuestion);
        }

        // Taken from the "Budget Calculator" Capstone project
        static bool DualConfirmation()
        {
            Console.WriteLine("Press ENTER if so. Press ESC if not.");
            ConsoleKeyInfo keyEntry;
            bool userRes = false;
            bool validKey = false;
            do
            {
                keyEntry = Console.ReadKey(intercept: true);
                switch (keyEntry.Key)
                {
                    case ConsoleKey.Enter:
                        userRes = true;
                        validKey = true;
                        break;
                    case ConsoleKey.Escape:
                        userRes = false;
                        validKey = true;
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("ERROR: incorrect '{0}' key entered.", keyEntry.Key);
                        Console.WriteLine("Retry your key submission.");
                        break;
                }
            } while (validKey != true);
            Console.Clear();
            return userRes;
        }
    } 
}
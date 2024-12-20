using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ADO20._12._2024
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            /*Author author = new Author
            {
                firstname = "Ivan",
                lastname = "Ivanov"
            };
            addAuthor(author);
            getAllAuthors();*/

            /*            Author author = GetAuthorByName("Ivan");
                        MessageBox.Show(author.firstname + " " + author.lastname);*/
            //Init();


            MessageBox.Show(GetBookById(1));
        }
        private void addAuthor(Author author)
        {
            using (LibraryEntities db = new LibraryEntities())
            {
                db.Author.Add(author);
                db.SaveChanges();
            }
        }
        private void getAllAuthors()
        {
            using (LibraryEntities db = new LibraryEntities())
            {
                string authorStr = "";
                var authors = db.Author.ToList();
                foreach (var author in authors)
                {
                    authorStr += author.firstname + " " + author.lastname + "\n";
                }
                MessageBox.Show(authorStr);
            }
        }
        private Author GetAuthorByName(string name)
        {
            using (LibraryEntities db = new LibraryEntities())
            {
                /*var author = (from a in db.Author where a.firstname == name select a)
                    .First<Author>();*/

                var author2 = db.Author.Where(a => a.firstname == name).FirstOrDefault<Author>();
                /*if (author2 == null)
                    return author;*/

                return author2;
            }
        }
        private void GetAllAuthorsSortByLastname()
        {
            using (LibraryEntities db = new LibraryEntities())
            {
                var author = db.Author.OrderBy(a => a.lastname).ToList();
            }
        }

        private void addPublisher(Publisher publisher)
        {
            using (LibraryEntities library = new LibraryEntities())
            {
                Publisher publisher1 = library.Publisher
                    .Where(p => p.publisherName == publisher.publisherName).FirstOrDefault();

                if (publisher1 == null)
                {
                    library.Publisher.Add(publisher);
                    library.SaveChanges();
                }
            }
        }

        private void addBook(Book book)
        {
            using (LibraryEntities library = new LibraryEntities())
            {
                Book book1 = library.Book
                    .Where(p => p.title == book.title).FirstOrDefault();

                if (book1 == null)
                {
                    library.Book.Add(book);
                    library.SaveChanges();
                }
            }
        }
        private void Init()
        {
            Author author = new Author
            {
                firstname = "Petr",
                lastname = "Petrov"
            };
            addAuthor(author);
            author = new Author
            {
                firstname = "Sergey",
                lastname = "Sergeev"
            };
            addAuthor(author);
            author = new Author
            {
                firstname = "Elena",
                lastname = "Elenova"
            };
            addAuthor(author);

            Publisher publisher = new Publisher
            {
                publisherName = "Правда севера",
                address = "Поморская 1",
            };
            addPublisher(publisher);
            publisher = new Publisher
            {
                publisherName = "Комсомолец",
                address = "Галушина 32",
            };
            addPublisher(publisher);

            Book book = new Book
            {
                title = "С# для чайников",
                pages = 1000,
                price = 799,
                idPublisher = 1,
                idAuthor = 1
            };
            addBook(book);
            book = new Book
            {
                title = "ADO.NET как победить дипрессию",
                pages = 599,
                price = 1500,
                idPublisher = 2,
                idAuthor = 3
            };
            addBook(book);
            book = new Book
            {
                title = "Entity Framework",
                pages = 4569,
                price = 4987,
                idPublisher = 1,
                idAuthor = 2
            };
            addBook(book);
        }

        private string GetBookById(int id)
        {
            using (LibraryEntities lb = new LibraryEntities())
            {
                Book book =  lb.Book.Where(i => i.id == id).FirstOrDefault();
                return book.title + ", цена: " + book.price +
                    ", издатель: " + book.Publisher.publisherName +
                    ", автор: " + book.Author.firstname + " " + book.Author.lastname;
            }
        }
    }
}

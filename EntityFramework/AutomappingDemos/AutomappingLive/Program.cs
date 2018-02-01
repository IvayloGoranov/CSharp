using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomappingLive
{
    using AutomappingLive.DTO;
    using AutomappingLive.Models;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    class Program
    {
        static void Main()
        {
            ConfigureAutomapper();
            MappingContext context = new MappingContext();
            BookAuthor bookAuthor = new BookAuthor();

            //Book book = new Book()
            //{
            //    Title = "Neshto"
            //};

            //Author author = new Author()
            //{
            //    Name = "Pesho"
            //};

            //Author author2 = new Author()
            //{
            //    Name = "Stamat"
            //};

            //bookAuthor.Book = book;
            //bookAuthor.Author = author;

            //BookAuthor bookAuthor2 = new BookAuthor();
            //bookAuthor2.Book = book;
            //bookAuthor2.Author = author2;
            //context.BookAuthors.Add(bookAuthor);
            //context.BookAuthors.Add(bookAuthor2);
            //context.SaveChanges();
            Book book = context.Books.Find(3);
            BookDto bookDto = Mapper.Map<BookDto>(book);
            foreach (int author in bookDto.Authors)
            {
                Console.WriteLine(author);
            }
        }


        public static void ConfigureAutomapper()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<Book, BookDto>()
                  // .ForMember(dto => dto.Authors,
                  //            configurationExpression =>
                  //            configurationExpression
                  //            .MapFrom(book => book.MappingTable
                  //                     .Select(boko1 => boko1.Author.Id).ToArray()))
                  .Include<OnlineBook, OnlineBookDto>();
                expression.CreateMap<OnlineBook, OnlineBookDto>();
                expression.CreateMap<Author, AuthorDto>();
            });
        }
    }
}

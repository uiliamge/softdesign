using Application.Services.Books;
using Domain;
using Domain.Interfaces;
using Moq;
using Shared.DTOs.Books;

namespace Test
{
    public class BooksServiceTests
    {
        [Fact]
        public async Task AddAsync_ShouldAddBook()
        {
            // Arrange
            var mockRepository = new Mock<IBooksRepository>();
            var service = new BooksService(mockRepository.Object);

            var newBook = new AddBookDTO
            {
                Title = "Test Book",
                Author = "Test Author",
                ReleaseYear = 2023
            };

            var addedBook = new Book { Id = 1, Title = newBook.Title, Author = newBook.Author, ReleaseYear = newBook.ReleaseYear };
            mockRepository.Setup(repo => repo.AddAsync(It.IsAny<Book>())).ReturnsAsync(addedBook);

            // Act
            var result = await service.AddAsync(newBook);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(addedBook.Id, result.Id);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnAllBooks()
        {
            // Arrange
            var mockRepository = new Mock<IBooksRepository>();
            var service = new BooksService(mockRepository.Object);

            var books = new List<Book>
            {
                new Book { Id = 1, Title = "Book 1", Author = "Author 1", ReleaseYear = 1989 },
                new Book { Id = 2, Title = "Book 2", Author = "Author 2", ReleaseYear = 1888 }
            };

            mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(books);

            // Act
            var result = await service.GetAllAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(books.Count, result.Count);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnBookById()
        {
            // Arrange
            var mockRepository = new Mock<IBooksRepository>();
            var service = new BooksService(mockRepository.Object);

            var bookId = 1;
            var book = new Book { Id = bookId, Title = "Book 1", Author = "Author 1", ReleaseYear = 1989 };

            mockRepository.Setup(repo => repo.GetByIdAsync(bookId)).ReturnsAsync(book);

            // Act
            var result = await service.GetByIdAsync(bookId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(book.Id, result.Id);
        }

        [Fact]
        public async Task DeleteAsync_ShouldDeleteBook()
        {
            // Arrange
            var mockRepository = new Mock<IBooksRepository>();
            var service = new BooksService(mockRepository.Object);

            var bookId = 1;
            var bookToDelete = new Book { Id = bookId, Title = "Book 1", Author = "Author 1", ReleaseYear = 1989 };

            mockRepository.Setup(repo => repo.GetByIdAsync(bookId)).ReturnsAsync(bookToDelete);

            // Act
            await service.DeleteAsync(bookId);

            // Assert
            mockRepository.Verify(repo => repo.DeleteAsync(bookToDelete), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_ShouldUpdateBook()
        {
            // Arrange
            var mockRepository = new Mock<IBooksRepository>();
            var service = new BooksService(mockRepository.Object);

            var updatedBook = new BookDTO { Id = 1, Title = "Updated Book Title", Author = "Updated Author", ReleaseYear = 2023 };
            var existingBook = new Book { Id = updatedBook.Id, Title = "Initial Title", Author = "Initial Author", ReleaseYear = 1989 };

            mockRepository.Setup(repo => repo.GetByIdAsync(updatedBook.Id)).ReturnsAsync(existingBook);

            // Act
            await service.UpdateAsync(updatedBook);

            // Assert
            mockRepository.Verify(repo => repo.UpdateAsync(existingBook), Times.Once);
            Assert.Equal(existingBook.Title, updatedBook.Title);
            Assert.Equal(existingBook.Author, updatedBook.Author);
            Assert.Equal(existingBook.ReleaseYear, updatedBook.ReleaseYear);
        }
    }
}
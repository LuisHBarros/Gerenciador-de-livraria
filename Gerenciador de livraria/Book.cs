namespace Gerenciador_de_livraria;

public class Book
{
    private int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public GenreEnum Genre { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }

    public Book(int id, string title, string author, GenreEnum genre, double price, int quantity)
    {
        this.Id = id;
        this.Title= title;
        this.Author = author;
        this.Genre = genre;
        this.Price = price;
        this.Quantity = quantity;
    }
    public enum GenreEnum
    {
        Fiction,
        NonFiction,
        Romance,
        Horror,
        Fantasy,
        ScienceFiction,
        Mystery,
        Thriller,
        Biography,
        History,
        Poetry,
        SelfHelp,
        Health,
        Travel,
        Cookbooks,
        Art,
        Science,
        Math,
        Programming,
        Technology,
        Business,
        Economics,
        Politics,
        Philosophy,
        Religion,
    }
}

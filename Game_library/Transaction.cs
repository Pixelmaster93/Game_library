using System.Runtime.InteropServices.Marshalling;

namespace Game_library;

class Transaction
{
    public Game Game { get; }
    public DateTime Date { get; }
    public decimal Price { get; }
    //public string MethodOfPayment { get; }
    public Store Store { get; }
    public bool IsVirtual { get; }
    public Platform Platform { get; }

    public Transaction(Game game, DateTime date, decimal price, Store store, bool isVirtual, Platform platform)
    {
        Game = game ?? throw new ArgumentNullException(nameof(game));
        Date = date;
        Price = price;
        Store = store ?? throw new ArgumentNullException(nameof(store));
        IsVirtual = isVirtual;
        Platform = platform ?? throw new ArgumentNullException(nameof(platform));
    }
}

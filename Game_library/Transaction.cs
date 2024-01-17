using System.Runtime.InteropServices.Marshalling;

namespace Game_library;

public class Transaction
{
    public DateTime PurchaseDate { get; }
    public bool IsVirtual { get; }
    //public string MethodOfPayment { get; }
    public Store Store { get; }
    public Game Game { get; }
    public Platform Platform { get; }
    public decimal Price { get; }
    public CurrencyType Currency { get; }

    public Transaction(DateTime purchaseData, bool isVirtual, Store store, Game game,  Platform platform, decimal price, CurrencyType currency)
    {
        Game = game ?? throw new ArgumentNullException(nameof(game));
        PurchaseDate = purchaseData;
        Store = store ?? throw new ArgumentNullException(nameof(store));
        IsVirtual = isVirtual;
        Platform = platform ?? throw new ArgumentNullException(nameof(platform));
        Price = price;
        Currency = currency;
    }
}

using Game_library;
using GameLibrary.Import.Txt;

namespace GameLibrary.ImportTest
{
    public class UnitTest1
    {
        
        [Theory]
        [InlineData("C:\\Users\\andyt\\Desktop\\Progetti Corso Train\\Game_library\\GameLibrary.Import.Txt\\Stores.txt")]
        public void TextFileStoreImporters_shuld_work2(string filePath)
        {
            var storeImporter = new TextFileStoreImporter(filePath);

            var result = storeImporter.GetStores3();

            Assert.NotNull(result);
            Assert.IsType<Store[]>(result);
            
            var steamStore = result[0];
            Assert.Equal("Steam", steamStore.Name);
        }



        [Theory]
        [InlineData("C:\\Users\\andyt\\Desktop\\Progetti Corso Train\\Game_library\\GameLibrary.Import.Txt\\Games.txt")]
        public void TextFileGamesImporters_shuld_work(string filePath)
        {

            var gameImporter = new TextFileGameImporter(filePath);

            var result = gameImporter.GetGame();

            Assert.NotNull(result);
            Assert.IsType<Game[]>(result);
        }

        [Theory]
        [InlineData
            (
            "C:\\Users\\andyt\\Desktop\\Progetti Corso Train\\Game_library\\GameLibrary.Import.Txt\\Transactions.txt", 
            "C:\\Users\\andyt\\Desktop\\Progetti Corso Train\\Game_library\\GameLibrary.Import.Txt\\Games.txt",
            "C:\\Users\\andyt\\Desktop\\Progetti Corso Train\\Game_library\\GameLibrary.Import.Txt\\Stores.txt",
            "C:\\Users\\andyt\\Desktop\\Progetti Corso Train\\Game_library\\GameLibrary.Import.Txt\\Platforms.txt"
            
            )]
        public void TextFileTransactionImporters_shuld_work(string fileTransactions, string fileGames, string fileStores, string filePlatforms )
        {
            var gameImporter = new TextFileGameImporter(fileGames);

            var gameResult = gameImporter.GetGame();

            var storeImporter = new TextFileStoreImporter(fileStores);

            var storeResult = storeImporter.GetStores();

            var platformImporter = new TextFilePlatformImporter(filePlatforms);

            var platformResult = platformImporter.GetPlatform();

            var transactionImporter = new TextFileTransactionImporter(fileTransactions, gameResult, storeResult, platformResult);

            var result = transactionImporter.GetTransaction();

            Assert.NotNull(result);
            Assert.IsType<Transaction[]>(result);
        }
    }
}
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
    }
}
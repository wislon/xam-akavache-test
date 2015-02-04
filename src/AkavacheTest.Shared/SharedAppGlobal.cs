using Akavache;
using Akavache.Sqlite3;

namespace AkavacheTest.Shared
{
    public static class SharedAppGlobal
    {
        public static bool Initialised { get; private set; }

        public static IBlobCache NormalCache { get; private set; }

        static SharedAppGlobal()
        {
        }

        public static void Init(string pathToCacheDbFile)
        {
            if (!Initialised)
            {
                BlobCache.ApplicationName = "AkavacheTest";
                BlobCache.EnsureInitialized();

                // correct encryption provider and task scheduler are taken care of by Akavache if those params are left empty
                // EncryptedCache = new SQLiteEncryptedBlobCache(pathToCacheDbFile, encryptionProvider: null, scheduler: null); 

                // correct task scheduler is provided by Akavache if the 'scheduler' parameter is left empty
                NormalCache = new SQLitePersistentBlobCache(pathToCacheDbFile, scheduler: null); 

                Initialised = true;
            }
        }
    }
}

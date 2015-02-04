using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Akavache;

namespace AkavacheTest.Shared
{
    public static class SharedAppGlobal
    {
        static SharedAppGlobal()
        {
            BlobCache.ApplicationName = "AkavacheTest";
            BlobCache.EnsureInitialized();
        }
    }
}

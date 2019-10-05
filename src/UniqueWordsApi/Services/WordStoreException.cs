using System;

namespace UniqueWordsApi.Services
{
    public class WordStoreException : Exception
    {
        public WordStoreException(string msg) : base(msg)
        {

        }
    }
}

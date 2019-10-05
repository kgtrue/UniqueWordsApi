using System;

namespace UniqueWordsApi.WordServices
{
    public class WordStoreException : Exception
    {
        public WordStoreException(string msg) : base(msg)
        {

        }
    }
}

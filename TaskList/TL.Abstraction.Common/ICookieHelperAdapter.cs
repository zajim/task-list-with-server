using System;

namespace TL.Abstraction.Common
{
    public interface ICookieHelperAdapter
    {
        string Get(string key);
        void Set(string key, string value, DateTime expireTime);
        void Remove(string key);
    }
}

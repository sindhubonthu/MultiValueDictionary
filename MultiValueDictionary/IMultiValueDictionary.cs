using System.Collections.Generic;

namespace MultiValueDictionary
{
    internal interface IMultiValueDictionary
    {
        bool Add(string key, string value);
        List<string> GetKeys();
        HashSet<string> GetMembers(string key);
        bool Remove(string key, string value);
        bool RemoveAll(string key);
        bool IsMemberExists(string key, string value);
        List<string> AllMembers();
        bool IsKeyExists(string key);
        void Clear();
        List<KeyValuePair<string, string>> GetItems();
        HashSet<string> Union(string key1, string key2);
        HashSet<string> Intersect(string key1, string key2);
        List<string> AllIntersect();
    }
}

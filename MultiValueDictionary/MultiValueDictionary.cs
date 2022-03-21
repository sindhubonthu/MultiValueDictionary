using System;
using System.Collections.Generic;
using System.Linq;

namespace MultiValueDictionary
{
    public class MultiValueDictionary : IMultiValueDictionary
    {
        // Initializes empty dictionary
        private readonly Dictionary<string, HashSet<string>> _dictionary = new();

        // Adds value to the key, if the value is not already present
        public bool Add(string key, string val)
        {
            ArgumentNullException.ThrowIfNull("key");
            ArgumentNullException.ThrowIfNull("val");

            if (_dictionary.TryGetValue(key, out var values))
            {
                if (values.Contains(val))
                    return false;

                values.Add(val);
                return true;
            }

            _dictionary.Add(key, new HashSet<string> { val });
            return true;
        }

        // Gets all keys in the dictionary
        public List<string> GetKeys()
        {
            return _dictionary.Keys.ToList();
        }

        // Gets all the members for a given key
        public HashSet<string> GetMembers(string key)
        {
            ArgumentNullException.ThrowIfNull("key");

            _dictionary.TryGetValue(key, out var values);
            return values != null ? values : new HashSet<string>();
        }

        /*Removes value for a given key
        Removes key from dictionary if all the values are removed*/
        public bool Remove(string key, string val)
        {
            ArgumentNullException.ThrowIfNull(key);
            ArgumentNullException.ThrowIfNull(val);

            if (!_dictionary[key].Remove(val)) return false;
            if (_dictionary[key].Count == 0)
                _dictionary.Remove(key);
            return true;
        }

        // Removes all members and key
        public bool RemoveAll(string key)
        {
            ArgumentNullException.ThrowIfNull(key);

            return _dictionary.Remove(key);
        }

        // Checks if the given value exists for the key
        public bool IsMemberExists(string key, string val)
        {
            ArgumentNullException.ThrowIfNull(key);
            ArgumentNullException.ThrowIfNull(val);

            _dictionary.TryGetValue(key, out var values);

            return values != null && values.Contains(val);
        }

        // Returns list of all members in the dictionary
        public List<string> AllMembers()
        {
            var membersList = new List<string>();

            foreach (var value in _dictionary.Values.Where(value => value != null))
            {
                membersList.AddRange(value);
            }

            return membersList;
        }

        // Checks if key exists in the dictionary
        public bool IsKeyExists(string key)
        {
            ArgumentNullException.ThrowIfNull(key);

            return _dictionary.ContainsKey(key);
        }

        // Removes all keys and values in the dictionary
        public void Clear()
        {
            _dictionary.Clear();
        }

        // Returns all keys and corresponding members
        public List<KeyValuePair<string, string>> GetItems()
        {
            List<KeyValuePair<string, string>> items = new();

            foreach (var key in _dictionary.Keys)
            {
                _dictionary.TryGetValue(key, out var values);

                foreach(var item in values)
                    items.Add(new KeyValuePair<string, string>(key, item));
            }
            return items;
        }

        // Returns members that exist in either first or second value list.
        public HashSet<string> Union(string key1, string key2)
        {
            ArgumentNullException.ThrowIfNull(key1);
            ArgumentNullException.ThrowIfNull(key2);

            _dictionary.TryGetValue(key1, out var values1);
            _dictionary.TryGetValue(key2, out var values2);

            if (values1 != null && values2 != null)
            {
                values1.UnionWith(values2);
                return values1;
            }

            return new HashSet<string>();
        }

        //Returns members that are common in both key values.
        public HashSet<string> Intersect(string key1, string key2)
        {
            ArgumentNullException.ThrowIfNull(key1);
            ArgumentNullException.ThrowIfNull(key2);

            _dictionary.TryGetValue(key1, out var values1);
            _dictionary.TryGetValue(key2, out var values2);

            if (values1 != null && values2 != null)
            {
                values1.IntersectWith(values2);
                return values1;
            }

            return new HashSet<string>();
        }
    }
}


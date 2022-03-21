# MultiValueDictionary
A Multi value dictionary is a console application that stores keys and members in a dictionary. Each key can have multiple members. It supports the following commands:</br>
ADD - Adds a member to the given key.<br/>
KEYS - Returns all keys in the dictionary.<br/>
MEMBERS - Returns all the members for the given key in the dictionary.<br/>
REMOVE - Removes given member for the given key. If the last member is removed, the key is removed from the dictionary.<br/>
REMOVEALL - Removed all members for the given key and removed the key from the dictionary.<br/>
CLEAR - Removes all keys and members in the dictionary.<br/>
KEYEXISTS - Checks if the given key exixts in the dictionary.<br/>
MEMBEREXISTS - Checks if the given member exists for the given key.<br/>
ALLMEMBERS - Returns all members in the dictionary.<br/>
ITEMS - Returns all keys in the dictionary and the members.<br/>
UNION - Returns all the members for both the given keys.<br/>
INTERSECT - Returns members that are common for both the given keys.<br/>
# System Requirements
Visual Studio 2022<br/>
.NET 6<br/>
# Instructions for Execution
Clone the repository, open the solution in Visual Studio, Set MultiValueDictionary as Start Project and Run.
# Interacting with Command Line
The Multi-Value Dictionary app is a command line application that stores a multivalue dictionary in memory. All keys and members are strings. It should support the following commands. <br/><br/>
KEYS <br/>
Returns all the keys in the dictionary. Order is not guaranteed. <br/>
Valid format : KEYS<br/><br/>
MEMBERS <br/>
Returns the collection of strings for the given key. Return order is not guaranteed. Returns an error if the key does not exists.<br/> Valid format: MEMBERS key<br/><br/>
ADD <br/>
Adds a member to a collection for a given key. Displays an error if the member already exists for the key.  <br/>
Valid format : ADD key value<br/><br/>
REMOVE <br/>
Removes a member from a key. If the last member is removed from the key, the key is removed from the dictionary. If the key or member does not exist, displays an error.   <br/>
Valid format : REMOVE key value<br/><br/>
REMOVEALL <br/>
Removes all members for a key and removes the key from the dictionary. Returns an error if the key does not exist.    <br/>
Valid format : REMOVEALL key <br/><br/>
CLEAR    <br/>
Removes all keys and all members from the dictionary. <br/>
Valid format : CLEAR <br/><br/>
KEYEXISTS    <br/>
Returns whether a key exists or not.  <br/>
Valid format : KEYEXISTS key <br/><br/>
MEMBEREXISTS     <br/>
Returns whether a member exists within a key. Returns false if the key does not exist.  <br/>
Valid format : MEMBEREXISTS key value<br/><br/>
ALLMEMBERS      <br/>
Returns all the members in the dictionary. Returns nothing if there are none. Order is not guaranteed.   <br/>
Valid format : ALLMEMBERS<br/><br/>
ITEMS      <br/>
Returns all keys in the dictionary and all of their members. Returns nothing if there are none. Order is not guaranteed.    <br/>
Valid format : ITEMS<br/><br/>
UNION      <br/>
Returns all the members for both the given keys.  <br/>
Valid format : UNION key1 key2<br/><br/>
INTERSECTION      <br/>
Returns all the common members for both the given keys.  <br/>
Valid format : INTERSECTION key1 key2<br/><br/>

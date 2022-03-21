using MultiValueDictionary;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace UnitTests
{
    [TestFixture]
    public class Tests
    {
        [TestCase("FirstKey", "FirstValue")]
        [TestCase("SecondKey", "SecondValue")]
        public void AddKeyValueGoodOperationTest(string key, string val)
        {
            var addValues = new MultiValueDictionary.MultiValueDictionary();
            var response = addValues.Add(key, val);

            Assert.AreEqual(true, response, "Not expected Result for Add");
        }

        [Test]
        public void GetKeysTest()
        {
            var keys = new MultiValueDictionary.MultiValueDictionary();

            keys.Add("key1", "value1");
            keys.Add("key2", "value2");
            keys.Add("key1", "value2");

            var expectedResult = new List<string> { "key1", "key2" };

            var actualResult = keys.GetKeys();

            Assert.AreEqual(expectedResult, actualResult, "Not expected Result for GetKeys");
        }

        [Test]
        public void GetMembersTest()
        {
            var members = new MultiValueDictionary.MultiValueDictionary();

            members.Add("key1", "value1");
            members.Add("key2", "value2");
            members.Add("key1", "value2");

            var expectedResult = new HashSet<string> { "value1", "value2" };

            var actualResult = members.GetMembers("key1");

            Assert.AreEqual(expectedResult, actualResult, "Not expected Result for GetMembers");
        }

        [Test]
        public void RemoveTest()
        {
            var addValues = new MultiValueDictionary.MultiValueDictionary();

            addValues.Add("key1", "value1");
            addValues.Add("key1", "value2");
            addValues.Add("key2", "value1");

            var actualResult1 = addValues.Remove("key1", "value1");
            Assert.AreEqual(true, actualResult1, "Incorrect result for Remove Test");

            var actualResult2 = addValues.Remove("key1", "value1");
            Assert.AreEqual(false, actualResult2, "Incorrect result for Remove Test");
        }

        [Test]
        public void RemoveAllTest()
        {
            var addValues = new MultiValueDictionary.MultiValueDictionary();

            addValues.Add("key1", "value1");
            addValues.Add("key1", "value2");
            addValues.Add("key2", "value1");

            var actualResult = addValues.RemoveAll("key1");

            Assert.AreEqual(true, actualResult, "Incorrect result for RemoveAll test");
        }

        [Test]
        public void IsMemberExistsTest()
        {
            var addValues = new MultiValueDictionary.MultiValueDictionary();

            addValues.Add("key1", "value1");
            addValues.Add("key1", "value2");
            addValues.Add("key2", "value1");

            var actualResult1 = addValues.IsMemberExists("key1", "value1");
            Assert.AreEqual(true, actualResult1, "Incorrect Result for IsMemberExists test");

            var actualResult2 = addValues.IsMemberExists("key1", "value5");
            Assert.AreEqual(false, actualResult2, "Incorrect Result for IsMemberExists test");
        }

        [Test]
        public void AllMembersTest()
        {
            var addValues = new MultiValueDictionary.MultiValueDictionary();

            addValues.Add("key1", "value1");
            addValues.Add("key1", "value2");
            addValues.Add("key2", "value1");

            var expectedResult = new List<string> { "value1", "value2", "value1" };
            var actualResult = addValues.AllMembers();

            Assert.AreEqual(expectedResult, actualResult, "Incorrect Result for AllMembers");
        }

        [Test]
        public void IsKeyExistsTest()
        {
            var addValues = new MultiValueDictionary.MultiValueDictionary();

            addValues.Add("key1", "value1");
            addValues.Add("key1", "value2");
            addValues.Add("key2", "value1");

            Assert.AreEqual(true, addValues.IsKeyExists("key1"), "Incorrect Result for IsKeyExists");
            Assert.AreEqual(false, addValues.IsKeyExists("key5"), "Incorrect Result for IsKeyExists");
        }

        [Test]
        public void ClearTest()
        {
            var addValues = new MultiValueDictionary.MultiValueDictionary();

            addValues.Add("key1", "value1");
            addValues.Add("key1", "value2");
            addValues.Add("key2", "value1");

            addValues.Clear();

            Assert.AreEqual(0, addValues.GetKeys().Count);
        }

        [Test]
        public void GetItemsTest()
        {
            List<KeyValuePair<string, string>> expectedOutput = new();
            expectedOutput.Add(new KeyValuePair<string, string>("key1", "value1"));
            expectedOutput.Add(new KeyValuePair<string, string>("key1", "value2"));
            expectedOutput.Add(new KeyValuePair<string, string>("key2", "value1"));

            var getItems = new MultiValueDictionary.MultiValueDictionary();

            getItems.Add("key1", "value1");
            getItems.Add("key1", "value2");
            getItems.Add("key2", "value1");

            var actualOutput = getItems.GetItems();
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void UnionTest()
        {
            var members = new MultiValueDictionary.MultiValueDictionary();

            members.Add("key1", "value1");
            members.Add("key2", "value2");
            members.Add("key1", "value2");

            var expectedResult = new HashSet<string> { "value1", "value2" };
            var actualResult = members.Union("key1", "key2");

            Assert.AreEqual(expectedResult, actualResult, "Union result is incorrect");
        }

        [Test]
        public void IntersectionTest()
        {
            var members = new MultiValueDictionary.MultiValueDictionary();

            members.Add("key1", "value1");
            members.Add("key2", "value2");
            members.Add("key1", "value2");

            var expectedResult = new HashSet<string> { "value2" };
            var actualResult = members.Intersect("key1", "key2");

            Assert.AreEqual(expectedResult, actualResult, "Intersection result is incorrect");
        }
    }
}
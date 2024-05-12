using System.Collections.Generic;
using System.Diagnostics.Metrics;
using ClassLibrary;
using Lab_12_ht_2;
namespace TestProject2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodAddContains()
        {
            MyHashTable<MusicalInstrument> hashTable = new MyHashTable<MusicalInstrument>();
            MusicalInstrument muz = new MusicalInstrument("Бибизяна", 10);
            hashTable.AddItem(muz);
            Assert.AreEqual(true, hashTable.Contains(muz));
        }

        [TestMethod]
        public void TestMethodRemoveData()
        {
            MyHashTable<MusicalInstrument> hashTable = new MyHashTable<MusicalInstrument>();
            MusicalInstrument muz = new MusicalInstrument("Бибизяна", 10);
            hashTable.AddItem(muz);
            hashTable.RemoveData(muz);
            Assert.AreEqual("False", hashTable.Contains(muz).ToString());
        }

        [TestMethod]
        public void TestMethodAddData()
        {
            MyHashTable<MusicalInstrument> hashTable = new MyHashTable<MusicalInstrument>();
            MusicalInstrument muz = new MusicalInstrument("Бибизяна", 10);
            hashTable.AddItem(muz);
            Assert.AreEqual("True", hashTable.Contains(muz).ToString());
        }

        [TestMethod]
        public void TestMethodAddItem()
        {
            MyHashTable<MusicalInstrument> hashTable = new MyHashTable<MusicalInstrument>();
            MusicalInstrument muz = new MusicalInstrument("Бибизяна", 10);
            hashTable.AddItem(muz);
            Assert.AreEqual("True", hashTable.Contains(muz).ToString());
        }

        [TestMethod]
        public void TestMethodLength()
        {
            MyHashTable<MusicalInstrument> hashTable = new MyHashTable<MusicalInstrument>(10);
            Assert.IsTrue(hashTable.Capacity == 10 && hashTable.Count == 0);
        }

        [TestMethod]
        public void TestMethodAddItem1()
        {
            MyHashTable<MusicalInstrument> hashTable = new MyHashTable<MusicalInstrument>(10);
            MusicalInstrument muz = new MusicalInstrument();
            for (int i = 0; i < 15; i++)
            {
                muz = new MusicalInstrument();
                muz.RandomInit();
                hashTable.AddItem(muz);
            }
            Assert.IsTrue(hashTable.Contains(muz));
        }

        [TestMethod]
        public void TestMethodFindItem1()
        {
            MyHashTable<MusicalInstrument> hashTable = new MyHashTable<MusicalInstrument>(10);
            MusicalInstrument muz = new MusicalInstrument();
            hashTable.AddItem(muz);
            hashTable.RemoveData(muz);
            Assert.IsTrue(!hashTable.Contains(muz));
        }
    }
}

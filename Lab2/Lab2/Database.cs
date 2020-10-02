using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lab2
{
    // Class to save data
    class Database : IEnumerable<Data>
    {
        // list to save data
        public List<Data> db;
        public int Count => db.Count;

        public Database()
        {
            db = new List<Data>();
        }

        public Data this[int index]
        {
            get => db[index];
        }

        public void Add(Data data)
        {
            db.Add(data);
        }

        public void Insert(int index, Data data)
        {
            db.Insert(index, data);
        }

        public void Remove(Data data)
        {
            db.Remove(data);
        }

        public void RemoveAt(int index)
        {
            db.RemoveAt(index);
        }

        public void Clear()
        {
            db.Clear();
        }

        public void Sort()
        {
            db.Sort(new Data());
        }

        // save db to file
        public void Save(string filename)
        {
            using (var writer = new StreamWriter(filename))
            {
                foreach (var d in db)
                {
                    if(!string.IsNullOrWhiteSpace(d.Identifier))
                        writer.WriteLine($"{d.Identifier},{d.Origin},{d.Destination},{d.Passengers}");
                }
            }
        }
        // call db from file
        public void Load(string filename)
        {
            if (new FileInfo(filename).Exists == false) return;

            using (var reader = new StreamReader(filename))
            {
                var lines = reader.ReadToEnd().Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                foreach (string s in lines)
                {
                    var split = s.Split(',');
                    if (split.Length == 4)
                        db.Add(new Data(split[1], split[2], split[0], int.Parse(split[3])));
                }

                db.Sort();
            }
        }

        public int IndexOf(string identifier)
        {
            for (var i = 0; i < db.Count; i++)
            {
                if (db[i].Identifier == identifier) return i;
            }
            return -1;
        }

        IEnumerator<Data> IEnumerable<Data>.GetEnumerator()
        {
            return ((IEnumerable<Data>)db).GetEnumerator();
        }
        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)db).GetEnumerator();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Lab2
{
    // the class to save information of airplane
    class Data : IComparable, IComparer<Data>
    {
        // Access Modifier)
        // only they can access but can't chage the data
        public string Origin
        {
            get;
            set;
        }
        public string Destination
        {
            get;
            set;
        }
        public string Identifier
        {
            get;
            set;
        }
        public int Passengers
        {
            get;
            set;
        }

        // constructor
        public Data() { }
        public Data (string origin, string destination, string identifier, int passengers)
        {
            Origin = origin;
            Destination = destination;
            Identifier = identifier;
            Passengers = passengers;
        }

        // to compare each airplain object
        public int CompareTo( object obj )
        {
            return Identifier.CompareTo( (obj as Data).Identifier);
        }

        //IComparer<Data> function that can compair each airplain data
        public int Compare( [AllowNull] Data x, [AllowNull] Data y )
        {
            return x.CompareTo( y );
        }
    }
}

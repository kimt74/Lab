using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Lab1
{
    // the class to save information of airplane
    class Data : IComparable, IComparer<Data>
    {
        // Access Modifier)
        // only they can access but can't chage the data
        public string Origin => _origin;
        public string Destination => _destination;
        public string Identifier => _identifier;
        public int Passengers => _passengers;

        string _origin;
        string _destination;
        string _identifier;
        int _passengers;

        // constructor
        public Data() { }
        public Data (string origin, string destination, string identifier, int passengers)
        {
            _origin = origin;
            _destination = destination;
            _identifier = identifier;
            _passengers = passengers;
        }

      

        //fuction that change the value of ogrigin
        public void SetOrigin(string value )
        {
            _origin = value;
        }
        //function that change the destination
        public void SetDestination(string value )
        {
            _destination = value;
        }
        // change of passanger value 
        public void SetPassangers(int value )
        {
            _passengers = value;
        }

        // to compare each airplain object
        public int CompareTo( object obj )
        {
            return _identifier.CompareTo( (obj as Data)._identifier );
        }

        //IComparer<Data> function that can compair each airplain data
        public int Compare( [AllowNull] Data x, [AllowNull] Data y )
        {
            return x.CompareTo( y );
        }
    }
}

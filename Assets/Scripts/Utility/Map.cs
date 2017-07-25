using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map<T1, T2> : List<KeyValuePair<T1,T2>>, IEnumerable 
{
    private Dictionary<T1, T2> _forward = new Dictionary<T1, T2>();
    private Dictionary<T2, T1> _reverse = new Dictionary<T2, T1>();

    public Map()
    {
        this.Forward = new Indexer<T1, T2>(_forward);
        this.Reverse = new Indexer<T2, T1>(_reverse);
    }

    public Map(List<KeyValuePair<T1, T2>> data)
    {
        foreach(KeyValuePair<T1,T2> pair in data)
        {
            _forward.Add(pair.Key, pair.Value);
            _reverse.Add(pair.Value, pair.Key);
        }

        this.Forward = new Indexer<T1, T2>(_forward);
        this.Reverse = new Indexer<T2, T1>(_reverse);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _forward.GetEnumerator();
    }

    public class Indexer<T3, T4>
    {
        private Dictionary<T3, T4> _dictionary;
        public Indexer(Dictionary<T3, T4> dictionary)
        {
            _dictionary = dictionary;
        }
        public T4 this[T3 index]
        {
            get { return _dictionary[index]; }
            set { _dictionary[index] = value; }
        }
    }

    public void Add(T1 t1, T2 t2)
    {
        _forward.Add(t1, t2);
        _reverse.Add(t2, t1);
    }

    public Indexer<T1, T2> Forward { get; private set; }
    public Indexer<T2, T1> Reverse { get; private set; }
}

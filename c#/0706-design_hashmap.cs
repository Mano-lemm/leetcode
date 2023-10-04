using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace leetcode
{
    public class MyHashMap
    {
        private struct Container
        {
            public bool Exists;
            public int Value;
            public int Key;
        }

        static bool isPrime(int n)
        {
            // Corner cases
            if (n <= 1) return false;
            if (n <= 3) return true;

            if (n % 2 == 0 || n % 3 == 0)
                return false;

            for (int i = 5; i * i <= n; i = i + 6)
                if (n % i == 0 ||
                    n % (i + 2) == 0)
                    return false;

            return true;
        }

        private Container[] _values;
        public MyHashMap()
        {
            _values = new Container[11];
        }

        private void Resize()
        {
            int neln = _values.Length * 2 + 1;
            while (!isPrime(neln))
            {
                neln++;
            }

            var old = _values;
            _values = new Container[neln];
            foreach (var cont in old)
            {
                if (cont.Exists)
                {
                    Put(cont.Key, cont.Value);
                }
            }
        }

        public void Put(int key, int value)
        {
            while (_values[key % _values.Length].Exists && _values[key % _values.Length].Key != key)
            {
                Resize();
            }
            _values[key % _values.Length].Exists = true;
            _values[key % _values.Length].Value = value;
            _values[key % _values.Length].Key = key;
        }

        public int Get(int key)
        {
            if (_values[key % _values.Length].Exists && _values[key % _values.Length].Key == key)
            {
                return _values[key % _values.Length].Value;
            }
            return -1;
        }

        public void Remove(int key)
        {
            if (_values[key % _values.Length].Exists && _values[key % _values.Length].Key == key)
            {
                _values[key % _values.Length].Exists = false;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            foreach (var item in _values)
            {
                if(item.Exists)
                {
                    result.Append($"{{{item.Key} : {item.Value}}}");
                }
            }
            return result.ToString();
        }
    }
}

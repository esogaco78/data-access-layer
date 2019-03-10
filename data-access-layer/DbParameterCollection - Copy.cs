using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Exeptions;

namespace DAL
{
    public class DbParameterCollection : IDataParameterCollection
    {
        List<KeyValuePair<string, object>> _list = new List<KeyValuePair<string, object>>();

        public bool Contains(string parameterName)
        {
            return _list.Any(kvp => kvp.Key == parameterName);
        }

        public int IndexOf(string parameterName)
        {
            int i = 0;
            foreach (KeyValuePair<string, object> kvp in _list)
            {
                if (kvp.Key == parameterName)
                {
                    return i;
                }
                i++;
            }
            return -1;
        }

        public void RemoveAt(string parameterName)
        {
            for (int i = 0; i < _list.Count(); i++)
            {
                if (_list[i].Key == parameterName)
                {
                    _list.Remove(_list[i]);
                }
                i++;
            }
        }

        public object this[string parameterName]
        {
            get
            {

                int i = 0;
                foreach (KeyValuePair<string, object> kvp in _list)
                {
                    if (kvp.Key == parameterName)
                    {
                        return i;
                    }
                    i++;
                }
                return -1;


            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int Add(object value)
        {
            int listCount = _list.Count();
            if (_list != null)
            {
                var thisPair = new KeyValuePair<string, object>(listCount.ToString(), value);
                _list.Add(thisPair);
            }
            return listCount - 1;
        }

        public void Clear()
        {
            _list.Clear();
        }

        public bool Contains(object value)
        {
            throw new NotImplementedException();
        }

        public int IndexOf(object value)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, object value)
        {
            throw new NotImplementedException();
        }

        public bool IsFixedSize
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        public void Remove(object value)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public object this[int index]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsSynchronized
        {
            get { throw new NotImplementedException(); }
        }

        public object SyncRoot
        {
            get { _list.SyncRoot; }
        }

        public System.Collections.IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}

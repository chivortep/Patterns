using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SessionReg
{
    public class ValueListHandler:IDisposable
    {
        private List<object> _list;
        List<object>.Enumerator _enumerator;

        public ValueListHandler() { }

        protected void SetList(List<object> list)
        {
            this._list = list;
            if (list != null)
                _enumerator = list.GetEnumerator();
            else
                throw new MissingFieldException("List is empty!");
        }

        public List<object> GetList() { return _list; }

        public int GetSize()
        {
            int size = 0;

            if (_list != null)
            {
                size = _list.Count;
                return size;
            }
            else
                throw new MissingFieldException("List is empty!");
        }

        public void Dispose()
        {
            _enumerator.Dispose();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SessionReg
{
    public class ValueListHandler
    {
        protected List<object> _list;
        List<object>.Enumerator _enumerator;

        public ValueListHandler() { }

        protected void setList(List<object> list)
        {
            this._list = list;
            if (list != null)
                _enumerator = list.GetEnumerator();
            else
                throw new MissingFieldException("List is empty!");
        }

        public ICollection<object> getList() { return _list; }

        public int getSize()
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
    }
}
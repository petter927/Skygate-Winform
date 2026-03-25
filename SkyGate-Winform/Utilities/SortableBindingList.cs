using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyGate_ADONET.Utilities
{
    public class SortableBindingList<T> : BindingList<T>
    {
        private bool _isSorted;
        private ListSortDirection _sortDirection;
        private PropertyDescriptor _sortProperty;

        public SortableBindingList() : base() { }
        public SortableBindingList(IEnumerable<T> list) : base(new List<T>(list)) { }

        protected override bool SupportsSortingCore => true;
        protected override bool IsSortedCore => _isSorted;
        protected override PropertyDescriptor SortPropertyCore => _sortProperty;
        protected override ListSortDirection SortDirectionCore => _sortDirection;

        protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
        {
            var itemsList = Items as List<T>;
            if (itemsList == null)
            {
                _isSorted = false;
                return;
            }

            var comparer = new PropertyComparer<T>(prop, direction);
            itemsList.Sort(comparer);

            _isSorted = true;
            _sortProperty = prop;
            _sortDirection = direction;

            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }

        protected override void RemoveSortCore()
        {
            _isSorted = false;
        }

        private class PropertyComparer<TItem> : IComparer<TItem>
        {
            private readonly PropertyDescriptor _prop;
            private readonly ListSortDirection _direction;

            public PropertyComparer(PropertyDescriptor prop, ListSortDirection direction)
            {
                _prop = prop;
                _direction = direction;
            }

            public int Compare(TItem x, TItem y)
            {
                var a = _prop.GetValue(x) as IComparable;
                var b = _prop.GetValue(y) as IComparable;

                int result;
                if (a == null && b == null) result = 0;
                else if (a == null) result = -1;
                else if (b == null) result = 1;
                else result = a.CompareTo(b);

                return _direction == ListSortDirection.Ascending ? result : -result;
            }
        }
    }
}

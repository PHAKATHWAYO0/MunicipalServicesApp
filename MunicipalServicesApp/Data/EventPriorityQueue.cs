using System;
using System.Collections.Generic;
using MunicipalServicesApp.Models;

namespace MunicipalServicesApp.Data
{
    /// <summary>
    /// A minimal binary-heap priority queue of <see cref="Event"/> objects,
    /// ordered so that the event with the soonest <see cref="Event.Date"/>
    /// is always dequeued first (a "min-heap").
    ///
    /// .NET Framework 4.8 does not include a built-in PriorityQueue&lt;T&gt;
    /// (that type was only added in .NET 6), so this is a small,
    /// self-contained implementation written specifically for this project.
    /// It backs the "Next Upcoming Events" feature on the Local Events
    /// screen: rather than sorting the entire event list every time,
    /// events are enqueued once and the soonest ones are efficiently
    /// popped off the top of the heap in O(log n) time each.
    /// </summary>
    public class EventPriorityQueue
    {
        private readonly List<Event> _heap = new List<Event>();

        public int Count => _heap.Count;

        public void Enqueue(Event item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            _heap.Add(item);
            BubbleUp(_heap.Count - 1);
        }

        /// <summary>Removes and returns the event with the soonest date.</summary>
        public Event Dequeue()
        {
            if (_heap.Count == 0) throw new InvalidOperationException("The priority queue is empty.");

            Event top = _heap[0];
            int lastIndex = _heap.Count - 1;
            _heap[0] = _heap[lastIndex];
            _heap.RemoveAt(lastIndex);

            if (_heap.Count > 0)
            {
                BubbleDown(0);
            }

            return top;
        }

        private void BubbleUp(int index)
        {
            while (index > 0)
            {
                int parent = (index - 1) / 2;
                if (_heap[index].Date >= _heap[parent].Date) break;

                Swap(index, parent);
                index = parent;
            }
        }

        private void BubbleDown(int index)
        {
            int count = _heap.Count;
            while (true)
            {
                int left = index * 2 + 1;
                int right = index * 2 + 2;
                int smallest = index;

                if (left < count && _heap[left].Date < _heap[smallest].Date) smallest = left;
                if (right < count && _heap[right].Date < _heap[smallest].Date) smallest = right;

                if (smallest == index) break;

                Swap(index, smallest);
                index = smallest;
            }
        }

        private void Swap(int i, int j)
        {
            Event temp = _heap[i];
            _heap[i] = _heap[j];
            _heap[j] = temp;
        }
    }
}

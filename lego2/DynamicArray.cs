using System;
using System.Collections.Generic;
using System.Text;

namespace lego2
{
    public class DynamicArray<T>
    {
        private int arrayCapacity;
        public int arraySize { get; set; }
        public T[] data { get; set; }

        public DynamicArray()
        {
            arrayCapacity = 1;
            arraySize = 0;
            data = new T[arrayCapacity];
        }

        public void Add(T givenValue)
        {
            if (arraySize >= arrayCapacity)
            {
                // Create new array
                var newArray = new T[arrayCapacity * 2];

                // Copy elements from short to long array
                for (int i = 0; i < arrayCapacity; i++)
                    newArray[i] = data[i];

                // Update array
                data = newArray;

                // Increase array capacity
                arrayCapacity *= 2;
            }

            // Insert given value
            data[arraySize] = givenValue;
            arraySize++;
        }

        /// <summary>
        /// Get number of elements in array
        /// </summary>
        /// <returns>arraySize</returns>
        public int Count()
        {
            return arraySize;
        }
    }
}

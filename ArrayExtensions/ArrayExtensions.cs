using System;

namespace Grax
{
    public static class ArrayExtensions
    {
        public static void Fill<T>(this T[] destinationArray, params T[] value)
        {
            if (destinationArray == null)
            {
                throw new ArgumentNullException(nameof(destinationArray));
            }

            if (value.Length > destinationArray.Length)
            {
                throw new ArgumentException("Length of value array must not be more than length of destination");
            }

            Array.Copy(value, destinationArray, value.Length);

            var copyLength = value.Length;
            var destinationArrayHalfLength = destinationArray.Length / 2;

            for (; copyLength < destinationArrayHalfLength; copyLength *= 2)
            {
                Array.Copy(destinationArray, 0, destinationArray, copyLength, copyLength);
            }

            Array.Copy(destinationArray, 0, destinationArray, copyLength, destinationArray.Length - copyLength);
        }
    }
}
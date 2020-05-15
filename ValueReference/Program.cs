using System;

namespace ValueReference
{
 public   class Program
    {
        static void Main(string[] args)
        {
            var value = 50;
            UpdateValue(value);
            UpdateValue(ref value);
            Console.WriteLine(value);
        }

        //references the actual location of this variable and updates the value in that reference
        public static void UpdateValue(ref int initialValue)
        {
            initialValue = 100;
        }


        //creates a "copy" of the value for this scope only which is then modified 
        public static void UpdateValue(int initialValue)
        {
            initialValue = 120;
            Console.WriteLine(initialValue);
        }
    }
}

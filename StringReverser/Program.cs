using System;

namespace StringReverser
{
    class Program // Not sure how this code is executed so we'll just make it a console app
    {
        static void Main(string[] args)
        {
            // Running custom tests since I'm unsure of the test framework. Usually these would just be NUnit tests.

            // Normally there would also be tests for the inputs and outputs (Console.WriteLine and Console.ReadLine)
            // but that would require some abstraction and/or mocking framework.
            // We could also add tests for the maximum string size but that would likely just result in an OutOfMemoryException.
            // I'm considering those edge case tests outside of the scope of this example.

            Console.WriteLine("Running tests...");
            ReverseStringReversesStringUsingArrayReverse();
            ReverseStringReversesStringUsingForLoop();
            Console.WriteLine("Tests passed!\n");

            var inputString = string.Empty;

            // Keep prompting the user until we have a valid string
            while (string.IsNullOrWhiteSpace(inputString))
            {
                Console.WriteLine("Enter a string: ");
                inputString = Console.ReadLine();
            }

            Console.WriteLine("Your reversed string: " + ReverseString(inputString));
            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }

        /// <summary>
        /// Reverses a <paramref name="inputString"/> either by using Array.Reverse()
        /// or a for loop.
        /// </summary>
        /// <param name="inputString">String to be reversed.</param>
        /// <param name="useArrayReverse">If true, string will be reversed with Array.Reverse. If false, it will use a for loop.
        /// If null, the user will be prompted.</param>
        /// <returns><paramref name="inputString"/> reversed.</returns>
        public static string ReverseString(string inputString, bool? useArrayReverse = null)
        {
            var charArray = inputString.ToCharArray();
            var reversedString = string.Empty;
            var arrayReverseInput = string.Empty;

            // Continue to prompt until a valid character is entered.
            // The default is "Y" so anything except "n" will continue.
            while (useArrayReverse == null)
            {
                Console.WriteLine("Use Array.Reverse? (Y/n): ");
                arrayReverseInput = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(arrayReverseInput))
                    continue;

                useArrayReverse = arrayReverseInput != "n";
            }

            // Reversing a string is a common interview sample and the desired outcome is usually knowledge of looping.
            // Array.Reverse() is a little cleaner so I'm including both examples.
            if ((bool)useArrayReverse)
            {
                Console.WriteLine("Using Array.Reverse()...");
                Array.Reverse(charArray);
                reversedString = new string(charArray);
            }
            else
            {
                Console.WriteLine("Using for loop...");
                for (int i = charArray.Length - 1; i >= 0; i--)
                    reversedString += charArray[i];
            }

            return reversedString;
        }

        /// <summary>
        /// Tests reversing a string using Array.Reverse.
        /// </summary>
        public static void ReverseStringReversesStringUsingArrayReverse()
        {
            var testString = "abcdefg";
            var result = ReverseString(testString, true);

            Assert("gfedcba", result);
        }

        /// <summary>
        /// Tests reversing a string using a for loop.
        /// </summary>
        public static void ReverseStringReversesStringUsingForLoop()
        {
            var testString = "abcdefg";
            var result = ReverseString(testString, false);

            Assert("gfedcba", result);
        }

        /// <summary>
        /// Custom assertion method. Will throw an exception if the <paramref name="expected"/> is not equal to the <paramref name="actual"/>
        /// </summary>
        /// <param name="expected"></param>
        /// <param name="actual"></param>
        public static void Assert(object expected, object actual)
        {
            if (!expected.Equals(actual))
                throw new Exception($"Expected {expected} but was {actual}."); // This would be AssertionException in NUnit
        }
    }
}
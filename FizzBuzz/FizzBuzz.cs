using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzGame
{
    public class FizzBuzz
    {
        private SortedDictionary<int, string> associations = new SortedDictionary<int, string>();

        /// <summary>
        /// Default contstructor to initialize FuzzBuzz with the default rules including the "pop" variation
        /// </summary>
        public FizzBuzz()
        {  
            associations.Add(3, "Fizz");
            associations.Add(5, "Buzz");
            associations.Add(7, "Pop");
        }

        /// <summary>
        /// Returns the FizzBuzz result based on the customized rule set
        /// </summary>
        /// <param name="number">a game entry that is greater than zero</param>
        /// <returns>a string containing the result after applying the fizzbuzz rules</returns>
        public string GetResult(int number)
        {
            StringBuilder result = new StringBuilder();

            if(number < 1)
            {
                throw new ArgumentOutOfRangeException("The number must be greater than 0");
            }

            foreach(KeyValuePair<int, string> entry in associations)
            {
                if(number % entry.Key == 0)
                {
                    result.Append(entry.Value).Append(" ");
                }
            }

            if(result.Length == 0)
            {
                result.Append(number);
            }

            return result.ToString() ;
        }

        /// <summary>
        /// Allow users to replace existing rules or add additional rules to the game
        /// </summary>
        /// <param name="key">the integer that a number is divisible by in order to add the string value to the output</param>
        /// <param name="value">the string value that is added to the output if a number is divisible by the key</param>
        public void SubstituteRule(int key, string value)
        {
            if(key < 1)
            {
                throw new ArgumentOutOfRangeException("The number must be greater than 0");
            }
            else if (value == null || value == "")
            {
                throw new ArgumentNullException("The fizzbuzz string value must not be null or empty");
            }

            if (associations.ContainsKey(key))
            {
                associations[key] = value;
            }
            else
            {
                associations.Add(key, value);
            }     
        }

        /// <summary>
        /// Allows users to remove an existing rule
        /// </summary>
        /// <param name="key">the integer that a number is divisible by in order to add the string value to the output. This number determines which rule to remove</param>
        public void RemoveRule(int key)
        {
            if (associations.ContainsKey(key))
            {
                associations.Remove(key);
            }
        }
    }
}

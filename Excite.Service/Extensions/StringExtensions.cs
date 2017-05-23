using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Excite.Service.Extensions
{
    public static class StringExtensions
    {
        public static IList<int> IndicesOf(this string input, string match)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            if(match == null)
                throw new ArgumentNullException(nameof(match));

            if (match.Length == 0)
                return new List<int>() {0};

            input = input.ToLower();
            match = match.ToLower();
            var result = new List<int>();

            for (int i = 0; i < input.Length - 1; i++)
            {
                for (int j = i, k = 0; match[k].Equals(input[j]); j++,k++)
                {
                    if (match.Length - k == 1)
                    {
                        result.Add(i + 1);
                        i = j;
                        break;
                    }
                }
            }

            return result;
        }
    }
}

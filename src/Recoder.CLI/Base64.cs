using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recoder.CLI
{
    public class Base64
    {
        public string Decode(string input)
        {
            if ( !input.Contains('.'))
            {
                byte[] data = Convert.FromBase64String(input);
                return Encoding.UTF8.GetString(data);
            }

            var parts = input.Split('.');
            var result = new List<string>();
            foreach (var item in parts)
            {
                result.Add(Decode(item));
                result.Add(Environment.NewLine);
            }

            return string.Concat(result);
        }

        public string Encode(string input)
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            return Convert.ToBase64String(bytes);
        }
    }
}

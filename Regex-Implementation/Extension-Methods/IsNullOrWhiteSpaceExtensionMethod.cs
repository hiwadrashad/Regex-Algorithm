using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regex_Implementation.Extension_Methods
{
    public static class IsNullOrWhiteSpaceExtensionMethod
    {

            public static bool IsNullOrWhiteSpace(this string value)
            {
                if (value != null)
                {
                    for (int i = 0; i < value.Length; i++)
                    {
                        if (!char.IsWhiteSpace(value[i]))
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
        
    }
}

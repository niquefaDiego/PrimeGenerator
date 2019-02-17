using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PrimeGenerator.Pages
{
    public class IndexModel : PageModel
    {
        public string Prime { get; set; }
        public string Message { get; set; }

        [BindProperty(SupportsGet = true)]
        public bool IsPalindrome { get; set; }

        [BindProperty(SupportsGet = true)]
        public bool IsCircular { get; set; }

        [BindProperty(SupportsGet = true)]
        public bool IsRightTruncatable { get; set; }

        public void OnGet()
        {
            var gen = new RandomPrimeGenerator(IsPalindrome, IsCircular, IsRightTruncatable);
            var primeFound = gen.Generate();
            if (primeFound == -1)
            {
                Prime = "Couldn't find a prime for you after 10 millions tries :C";
                Message = "";
            }
            else
            {
                Prime = primeFound.ToString();

                List<string> list = new List<string>();
                if (IsPalindrome) list.Add("palindrome");
                if (IsCircular) list.Add("circular");
                if (IsRightTruncatable) list.Add("right truncable");

                if (list.Count > 0)
                {
                    Message = "This prime is " + list[0];
                    for (int i = 1; i + 1 < list.Count; ++i)
                        Message += ", " + list[i];
                    if (list.Count > 1)
                        Message += " and " + list[list.Count - 1];
                }
                else
                {
                    Message = "This is a normal prime";
                }
            }
        }
    }
}

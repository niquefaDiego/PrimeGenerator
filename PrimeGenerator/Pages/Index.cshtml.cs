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
            if (primeFound == -1) Prime = "Couldn't find a prime for you after 10 millions tries :C";
            else Prime = primeFound.ToString() ;
        }
    }
}

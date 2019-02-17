using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeGenerator.Pages
{
    public class RandomPrimeGenerator
    {
        static int MAX_TRIES = (int)1e7;
        delegate bool Condition(int prime);

        private bool MeetsAllConditions(int n) {
            foreach (var cond in Conditions)
                if (!cond(n))
                    return false;
            return true;
        }

        public int Generate() {
            Random rnd = new Random();
            int ans = 1000  + rnd.Next(1, 1000*1000);
            int tries = 0;
            while (!MeetsAllConditions(ans) ) { 
                ans++;
                if (++tries == MAX_TRIES)
                    return -1;
            }
            return ans;
        }

        private List<Condition> Conditions;
        public RandomPrimeGenerator(bool palindrome, bool circular, bool rTruncatable) {
            Conditions = new List<Condition>{MathMethods.IsPrime};
            if (palindrome)   Conditions.Add(MathMethods.IsPalindrome);
            if (circular)     Conditions.Add(MathMethods.IsCircularPrime);
            if (rTruncatable) Conditions.Add(MathMethods.IsRightTruncatable);
        }
    }
}

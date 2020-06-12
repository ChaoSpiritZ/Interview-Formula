using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewFormula
{
    class Program
    {
        static void Main(string[] args)
        {
            //got rid of the commas, because each part is only one letter anyway...
            Console.WriteLine(SentenceValidator.ValidateSentence("abc@efg@h", "fha")); //true
            Console.WriteLine(SentenceValidator.ValidateSentence("abc@ef@gh", "aegk")); //false
            Console.WriteLine(SentenceValidator.ValidateSentence("ab@cd@ef", "af")); // false
            Console.WriteLine(SentenceValidator.ValidateSentence("aBcdefg@hijk@lmnop", "bkL")); // true, now works lowercases strings!
            Console.WriteLine(SentenceValidator.ValidateSentence("@a@b@c@", "abc")); //need to add a fix to this error but i get the idea
        }
    }
}

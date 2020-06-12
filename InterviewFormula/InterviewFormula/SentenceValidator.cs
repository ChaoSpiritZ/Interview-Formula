using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewFormula
{
    public class SentenceValidator
    {
        //i know the summary is not enough (full) information but it's just practice

        /// <summary>
        /// gets a formula and a sentence from the user, returns true if the sentence's segments match the formula's
        /// letters cannot repeat!
        /// </summary>
        /// <param name="formula">'or' condition is letters sticked together, 'and' condition is @, DON'T PUT @ AT THE START OR AT THE END OF THE FORMULA!</param>
        /// <param name="sentence"></param>
        /// <returns></returns>
        public static bool ValidateSentence(string formula, string sentence)
        {
            //check if letters in formula repeat:
            string andlessFormula = formula.Replace("@", string.Empty).ToLower();
            Dictionary<char, bool> chars = new Dictionary<char, bool>(); //value can be any type, i just need the key
            foreach (var item in andlessFormula)
            {
                if (chars.ContainsKey(item))
                {
                    throw new ArgumentException($"ERROR - the formula [{formula}] contains duplicated letters! [{item}]");
                }

                chars.Add(item, true);
            }

            //build formula:
            List<string> formulaSegments = formula.ToLower().Split('@').ToList();

            Dictionary<string, bool> segments = new Dictionary<string, bool>();

            foreach (var item in formulaSegments)
            {
                segments.Add(item, false);
            }

            //check if the sentence's segments are correct:
            List<char> sentenceSegments = sentence.ToLower().ToCharArray().ToList();
            foreach (var sentenceSegment in sentenceSegments)
            {
                bool exists = false;
                foreach (var segmentPair in segments)
                {
                    if (segmentPair.Key.Contains(sentenceSegment))
                    {
                        if (segmentPair.Value == false)
                        {
                            segments[segmentPair.Key] = true;
                            exists = true;
                            break;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                if (!exists)
                    return false;
            }

            foreach (var item in segments)
            {
                if (item.Value == false)
                    return false;
            }

            return true;
        }
    }
}

using System.Text.RegularExpressions;

namespace ContactsApplication.Services
{
    public class BalancedBracketsService
    {
        public BalancedBracketsService()
        {
        }

        private readonly Dictionary<char, char> _bracketsDictionary = new Dictionary<char, char>()
        {
            {'{', '}' },
            {'(', ')' },
            {'[', ']' }
        };

        public bool Check(string input)
        {
            if (string.IsNullOrEmpty(input)) return false;

            var allowedChars = new List<char>() { '{', '}', '(', ')', '[', ']' };
            var closingBracketsStack = new Stack<char>();

            foreach (var character in input.Trim())
            {
                if (!allowedChars.Contains(character))
                    continue;

                if (_bracketsDictionary.ContainsKey(character))
                {
                    closingBracketsStack.Push(_bracketsDictionary[character]);
                }
                else
                {
                    if (closingBracketsStack.Count == 0) return false;
                    var expectedCharacter = closingBracketsStack.Pop();
                    if (character != expectedCharacter) return false;
                }
            }

            if (closingBracketsStack.Count > 0)
                return false;

            return true;
        }
    }
}


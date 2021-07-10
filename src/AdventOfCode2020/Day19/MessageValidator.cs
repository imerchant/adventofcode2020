using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Day19
{
    public class MessageValidator
    {
        private static readonly Regex ParseRuleRegex = new Regex(@"^(?'id'\d+): (?'content'.+)$", RegexOptions.Compiled);

        public IDictionary<int, string> RulesInput { get; }

        public ISet<string> AcceptableMessages { get; }

        public MessageValidator(string rules)
        {
            AcceptableMessages = new HashSet<string>();

            RulesInput = rules
                .SplitLines()
                .Select(ParseRule)
                .ToDictionary(x => x.Id, x => x.Content);

            var stack = new Stack<string>();
            stack.Push(RulesInput[0]);
            Expand(stack);

            static (int Id, string Content) ParseRule(string rule)
            {
                var match = ParseRuleRegex.Match(rule);
                if (match.Success)
                {
                    var id = int.Parse(match.Groups["id"].Value);
                    var content = match.Groups["content"].Value;

                    return (id, content);
                }

                throw new System.Exception("Could not parse rule");
            }
        }

        private void Expand(Stack<string> stack)
        {
            do
            {
                var rule = stack.Pop();

                
            } while (stack.TryPeek(out _));
        }
    }
}
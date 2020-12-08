using System.Text;

namespace AdventOfCode2020.Day08
{
    public class Instruction
    {
        public int Index { get; }
        public Op Op { get; set; }
        public int Value { get; }

        public Instruction(int index, Op op, int value)
        {
            Index = index;
            Op = op;
            Value = value;
        }

        public override string ToString() =>
            new StringBuilder($"{Op:G}")
                .Append(Value < 0 ? " " : " +")
                .Append(Value)
                .ToString();
    }
}
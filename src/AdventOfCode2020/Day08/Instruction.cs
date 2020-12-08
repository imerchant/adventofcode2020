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

        public override string ToString() => $"{Op:G} {Value:+0;-0}"; // that string format for numbers is really cool
    }
}
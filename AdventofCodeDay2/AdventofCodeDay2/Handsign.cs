using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventofCodeDay2
{
    public class Handsign
    {
        public Handsign(HandSignType type)
        {
            Type = type;
        }
        public Handsign(string signal)
        {
            Type = signal switch
            {
                "A" or "X" => HandSignType.Rock,
                "B" or "Y" => HandSignType.Paper,
                "C" or "Z" => HandSignType.Scissors,
                _ => throw new ArgumentOutOfRangeException(nameof(signal))
            };
        }

        public HandSignType Type { get; }

        public int PointValue => Type switch
        {
            HandSignType.Rock => 1,
            HandSignType.Paper => 2,
            HandSignType.Scissors => 3,
            _ => throw new InvalidOperationException("Invalid hand signal type.")
        };

    }
}

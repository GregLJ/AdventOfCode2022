using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventofCodeDay2
{
    public class OutcomeFinder
    {
        private readonly Dictionary<HandSignType, Dictionary<HandSignType, Outcome>> _outcomes;

        public OutcomeFinder()
        {
            _outcomes = new Dictionary<HandSignType, Dictionary<HandSignType, Outcome>>
            {
                {HandSignType.Rock,
                    new Dictionary<HandSignType, Outcome>
                    {
                        {HandSignType.Rock, Outcome.Tie },
                        {HandSignType.Paper, Outcome.Win },
                        {HandSignType.Scissors, Outcome.Lose }
                    }
                },
                {HandSignType.Paper,
                    new Dictionary<HandSignType, Outcome>
                    {
                        {HandSignType.Rock, Outcome.Lose },
                        {HandSignType.Paper, Outcome.Tie },
                        {HandSignType.Scissors, Outcome.Win }
                    }
                },
                {HandSignType.Scissors,
                    new Dictionary<HandSignType, Outcome>
                    {
                        {HandSignType.Rock, Outcome.Win},
                        {HandSignType.Paper, Outcome.Lose },
                        {HandSignType.Scissors, Outcome.Tie }
                    }
                }
            };
        }

        public Outcome GetOutcome(HandSignType yourSign, HandSignType opponentsSign)
        {
            return _outcomes[opponentsSign][yourSign];
        }

        public HandSignType GetHandSign(HandSignType oppnentSign, Outcome outcome)
        {
            return _outcomes[oppnentSign]
                .First(kvp => kvp.Value == outcome)
                .Key;
        }
    }
}

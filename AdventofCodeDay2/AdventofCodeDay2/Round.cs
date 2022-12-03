using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventofCodeDay2
{
    public class Round
    {
        private readonly OutcomeFinder _outcomeFinder;
        private  Handsign _opponentSign;
        private  Handsign _yourSign;

        public Round(OutcomeFinder outcomeFinder)
        {
            _outcomeFinder = outcomeFinder;
        }
        public void MapToSignals(string opponentSign, string yourSign)
        {
            _opponentSign = new Handsign(opponentSign);
            _yourSign = new Handsign(yourSign);
        }

        public void MapToOutcome(string opponentSign, string yourOutcome)
        {
            _opponentSign = new Handsign(opponentSign);

            var outcome = yourOutcome switch
            {
                "X" => Outcome.Lose,
                "Y" => Outcome.Tie,
                "Z" => Outcome.Win,
                _ => throw new InvalidOperationException()
            };

            _yourSign = new Handsign(_outcomeFinder.GetHandSign(_opponentSign.Type, outcome));
        }

        public int GetOutcome()
        {
            var outcome = _outcomeFinder.GetOutcome(_yourSign.Type, _opponentSign.Type);

            return outcome switch
            {
                Outcome.Lose => _yourSign.PointValue,
                Outcome.Tie => _yourSign.PointValue + 3,
                Outcome.Win => _yourSign.PointValue + 6,

                _ => throw new InvalidOperationException("Invalid Outcome")
            };
        }

        
    }
}

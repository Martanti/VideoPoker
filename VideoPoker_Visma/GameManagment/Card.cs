using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameManagment
{

    /*
     * enums are chosen in order to avoid typos when checking, creatig card symbols and their ranks
     */

    public enum CardSymbol {Clubs, Diamonds, Hearts, Spades }
    public enum CardRank { Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King }

    struct Card
    {
        public CardSymbol cardSymbol;
        public CardRank cardRank;

    }
}

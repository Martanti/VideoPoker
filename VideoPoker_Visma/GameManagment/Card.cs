namespace GameManagment
{

    /*
     * enums are chosen in order to avoid typos when checking, creatig card symbols and their ranks
     */


    public enum CardSymbol {Clubs, Diamonds, Hearts, Spades }
    public enum CardRank {Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace }

    /*
     * Structure is used instead of class in order to avoid accidental data loss when calculating scores
     */
    public struct Card
    {
        public const int amountOfSuits = 4;
        public const int amountOfRanks = 13;

        public CardSymbol cardSymbol;
        public CardRank cardRank;

    }
}

using System.Linq;

namespace GameManagment
{
    public class ScoreCalculator
    {

        /// <summary>
        /// Get score based on held cards
        /// </summary>
        /// <param name="cardDeck">Held cards</param>
        /// <returns>Returns number of points that given hand is worth</returns>
        public int GetScore(Card [] cardDeck)
        {
            if (IsRoyalFlush(cardDeck))
            {
                return 800;
            }

            else if (IsStraightFlush(cardDeck))
            {
                return 50;
            }

            else if (IsFourOfAKind(cardDeck))
            {
                return 25;
            }

            else if (IsFullHouse(cardDeck))
            {
                return 9;
            }

            else if (IsFlush(cardDeck))
            {
                return 6;
            }

            else if (IsStraight(cardDeck))
            {
                return 4;
            }

            else if (IsThreeOfAKind(cardDeck))
            {
                return 3;
            }

            else if (IsTwoPair(cardDeck))
            {
                return 2;
            }

            else if (IsJackOrBetter(cardDeck))
            {
                return 1;
            }

            else return 0;

        }

        /// <summary>
        /// Sorts cards in climbing (lowest first, highest last) order
        /// </summary>
        /// <param name="cards">Held cards</param>
        /// <returns>Returns sorted cards</returns>
        private Card[] OrganizeCardsByRank(Card[] cards)
        { 
            return cards.OrderByDescending((x => (int)x.cardRank)).Reverse().ToArray();
        }

        /// <summary>
        /// Checks if cards are same suit and go from Ten to Ace 
        /// </summary>
        /// <param name="cards">Held cards</param>
        /// <returns>Returns True if held cards are qualified for Royal Flush</returns>
        private bool IsRoyalFlush(Card[] cards)
        {
            /*Possible alternative/TODO could be checkig can held cards form straight and is the lowest card is Ten*/

            bool hasFromJackToAce = cards.All(x =>
                x.cardRank.Equals(CardRank.Ace)
                || x.cardRank.Equals(CardRank.King)
                || x.cardRank.Equals(CardRank.Queen)
                || x.cardRank.Equals(CardRank.Jack)
                || x.cardRank.Equals(CardRank.Ten));

            if (CheckForSameSuite(cards) && hasFromJackToAce)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if cards go one after the other and are the same suit
        /// </summary>
        /// <param name="cards">Held cards</param>
        /// <returns>Returns True if cards qualify for Straight Flush</returns>
        private bool IsStraightFlush(Card[] cards)
        {
            if (IsStraight(cards) && CheckForSameSuite(cards))
            {
                return true;
            }

            else
                return false;

        }

        /// <summary>
        /// Checks if there are four cards of same rank
        /// </summary>
        /// <param name="cards">Held cards</param>
        /// <returns>Returns True if there are four cards with same rank</returns>
        private bool IsFourOfAKind(Card[] cards)
        {
            return CheckForSameRank(4,cards);
        }

        /// <summary>
        /// Checks if there are 3 and 2 sets of same ranked cards
        /// </summary>
        /// <param name="cards">Held cards</param>
        /// <returns>Returns True if cards qualify for Full House</returns>
        private bool IsFullHouse(Card[] cards)
        {

            for (int i = 0; i < Card.amountOfRanks; i++)
            {
                CardRank primaryCheckedRank = (CardRank)i;

                if (cards.Where(x => x.cardRank.Equals(primaryCheckedRank)).Count()==3)
                {
                    for (int j = 0; j < Card.amountOfRanks; j++)
                    {
                        CardRank secondaryCheckedRank = (CardRank)j;

                        if (!secondaryCheckedRank.Equals(primaryCheckedRank) && cards.Where( x => x.cardRank.Equals(secondaryCheckedRank)).Count() == 2)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;

        }

        /// <summary>
        /// Checks if all of the cards in hand are same suit
        /// </summary>
        /// <param name="cards">Held cards</param>
        /// <returns>True if all of the cards have same suit</returns>
        private bool IsFlush(Card[] cards)
        {
            return CheckForSameSuite(cards);
        }

        /// <summary>
        /// Checks if cards go one after the other
        /// </summary>
        /// <param name="cards">Held cards</param>
        /// <returns>Returns True if cards go one after the other</returns>
        private bool IsStraight(Card[] cards)
        {
            cards = OrganizeCardsByRank(cards);

            for (int i = 0; i < cards.Length-1; i++)
            {
                CardRank oneHigherRank = cards[i].cardRank + 1;
                if (!cards[i+1].cardRank.Equals(oneHigherRank))
                {
                    return false;
                }

            }

            return true;
        }

        /// <summary>
        /// Checks if there are three cards with same rank
        /// </summary>
        /// <param name="cards">Held cards</param>
        /// <returns>Returns True if there are 3 cards with same rank</returns>
        private bool IsThreeOfAKind(Card[] cards)
        {
            return CheckForSameRank(3, cards);
        }

        /// <summary>
        /// Checks if there are two pairs of cards in the given hand
        /// </summary>
        /// <param name="cards">Held cards</param>
        /// <returns>Returns True if there are two pairs</returns>
        private bool IsTwoPair(Card[] cards)
        {
            bool isSameKind = CheckForSameRank(
                amountNeeded: 2,
                cards: cards,
                countOfSameKinds: out int countOfPairs
                );

            if (isSameKind)
            {
                if (countOfPairs==2)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Checks if there is a card that is Jack or higher ranking
        /// </summary>
        /// <param name="cards">Held cards</param>
        /// <returns>Returns True if there is a card that is Jack or higher ranking</returns>
        private bool IsJackOrBetter(Card[] cards)
        {
            if (cards.Any(x=> 
            x.cardRank.Equals(CardRank.Jack)
            || x.cardRank.Equals(CardRank.Queen)
            || x.cardRank.Equals(CardRank.King)
            || x.cardRank.Equals(CardRank.Ace)))
            {
                return true;
            }

            else
                return false;
        }

        /// <summary>
        /// Checks if all of the cards have the same suite
        /// </summary>
        /// <param name="cards">Held cards</param>
        /// <returns>Returns true if all of the hands have same suite</returns>
        private bool CheckForSameSuite(Card[] cards)
        {
            for (int i = 0; i < Card.amountOfSuits; i++)
            {
                CardSymbol checkedCardSymbol = (CardSymbol)i;

                if (cards.All(x => x.cardSymbol.Equals(checkedCardSymbol)))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Checks if there are same ranked cards
        /// </summary>
        /// <param name="amountNeeded">Amount of cards that need to have same Ranking</param>
        /// <param name="cards">Held cards</param>
        /// <returns>Returns True if there are enough matched cards</returns>
        private bool CheckForSameRank( int amountNeeded, Card [] cards)
        {
            return CheckForSameRank(amountNeeded, cards, out _);
        }

        /// <summary>
        /// Checks if there are same ranked cards
        /// </summary>
        /// <param name="amountNeeded">Amount of cards that need to have same Ranking</param>
        /// <param name="cards">Held cards</param>
        /// <param name="countOfSameKinds">Amount of different sets of cards that have matched the criteria</param>
        /// <returns></returns>
        private bool CheckForSameRank(int amountNeeded, Card [] cards, out int countOfSameKinds)
        {
            countOfSameKinds = 0;

            for (int i = 0; i < Card.amountOfRanks; i++)
            {
                CardRank checkedCardRank = (CardRank)i;

                Card[] cardsGottenFromHand = cards.Where(x => x.cardRank.Equals(checkedCardRank)).ToArray();

                if (cardsGottenFromHand.Length == amountNeeded)
                {
                    countOfSameKinds++;
                }
            }

            if (countOfSameKinds>0)
                return true;

            else
                return false;
        }

    }
}

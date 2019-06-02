using System;
using System.Collections.Generic;

namespace GameManagment
{
    public class CardManagment
    {
        //this is needed to ensure randomness
        private Random random = new Random();

        private List<Card> availableCards;

        public CardManagment()
        {
            availableCards = new List<Card>();
        }


        /// <summary>
        /// Populates deck with automatically generated cards
        /// </summary>
        public void PopulateDeck()
        {
            for (int i = 0; i < Card.amountOfSuits; i++)
            {
                CardSymbol symbol = (CardSymbol)i;

                for (int j = 0; j < Card.amountOfRanks; j++)
                {
                    CardRank rank = (CardRank)j;

                    availableCards.Add(new Card {
                        cardRank = rank,
                        cardSymbol = symbol
                    });
                }
            }
        }


        /// <summary>
        /// Get a randomly picked card from the deck
        /// </summary>
        /// <returns>Returns a Card type object that is also removed from the deck</returns>
        public Card TakeOutRandomCard()
        {
            int randomCardIndex = random.Next(availableCards.Count);

            Card cardToGiveOut = availableCards[randomCardIndex];

            availableCards.Remove(cardToGiveOut);

            return cardToGiveOut;
        }

    }
}

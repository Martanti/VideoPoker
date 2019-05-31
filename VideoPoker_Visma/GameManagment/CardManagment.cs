using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameManagment
{
    class CardManagment
    {
        private List<Card> availableCards;

        public CardManagment()
        {
            availableCards = new List<Card>();
        }


        public void PopulateDeck()
        {
            for (int i = 0; i < 4; i++)
            {
                CardSymbol symbol = (CardSymbol)i;

                for (int j = 0; j < 13; j++)
                {
                    CardRank rank = (CardRank)j;

                    availableCards.Add(new Card {
                        cardRank = rank,
                        cardSymbol = symbol
                    });
                }
            }
        }


        public Card TakeOutRandomCard()
        {
            Random random = new Random();

            int randomCardIndex =  random.Next(availableCards.Count);

            Card cardToGiveOut = availableCards[randomCardIndex];

            availableCards.Remove(cardToGiveOut);

            return cardToGiveOut;
        }

        public bool CanDraw(int neededAmountToDraw)
        {
            if (neededAmountToDraw<=availableCards.Count)
            {
                return true;
            }

            return false;
        }
    }
}

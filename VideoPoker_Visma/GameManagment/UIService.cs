
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameManagment
{
    class UIService
    {
        //Entering basic loop, that allows start and exit the game
        public void StartGame()
        {
            bool exitTheGame = false;

            while (true)
            {
                Console.WriteLine("What would you like to do?" +
                    "\n1 - Start the game" +
                    "\n2 - Exit the game" +
                    "\n Select your answer and press \"Enter\"");

                string answer = Console.ReadLine().Replace(" ", String.Empty);

                switch (answer)
                {
                    case "1":
                        InnerGameCycle();
                        break;

                    case "2":
                        Console.WriteLine("Roger roger" +
                            "\nClosing the game");
                        exitTheGame = true;
                        break;

                    default:
                        Console.WriteLine("Sorry, but your command was unclear :(" +
                            "\nI'll repeat the question:");
                        break;
                }

                if (exitTheGame) break;
            }
        }


        private void InnerGameCycle()
        {
            CardManagment cardManagment = new CardManagment();
            cardManagment.PopulateDeck();

            int amountOfCardsInHand = 5;

            Card[] cardsInHand = new Card[amountOfCardsInHand];

            for (int i = 0; i < amountOfCardsInHand; i++)
            {
                cardsInHand[i] = cardManagment.TakeOutRandomCard();
            }
            
            while (true)
            {

                Console.WriteLine("Your cards are:");
                for (int i = 0; i < amountOfCardsInHand; i++)
                {
                    Console.WriteLine($"{i+1}) [{cardsInHand[i].cardSymbol} : {cardsInHand[i].cardRank} ]");
                }

                int score = 65;
                Console.WriteLine($"Your current score is {score}");

                Console.WriteLine("Pick you action:" +
                    "\n1)");


            }

        }


    }
}

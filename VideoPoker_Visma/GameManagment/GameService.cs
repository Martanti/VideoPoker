﻿using System;
using System.Linq;

namespace GameManagment
{
    class GameService
    {

        //Entering basic loop, that allows start and exit the game
        public void StartGame()
        {
            bool exitTheGame = false;

            while (true)
            {
                Console.WriteLine("What would you like to do?" +
                    "\n1 - Start the game" +
                    "\n2 - Exit the game");

                int answer = GetAnswer();

                switch (answer)
                {
                    case 1:
                        InnerGameCycle();
                        break;

                    case 2:
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


            bool hasDrawnNewCards = false;
            bool stopGameLoop = false;

            while (true)
            {

                PrintOutCards(cardsInHand);

                ScoreCalculator scoreCalculator = new ScoreCalculator();
                int score = scoreCalculator.GetScore(cardsInHand) ;

                Console.WriteLine($"Your current score is {score}");


                if(!hasDrawnNewCards)
                {
                    Console.WriteLine("Pick you action:" +
                        "\n1) Throw our some cards and get new ones" +
                        "\n2) Submit this as final score");

                    int answer = GetAnswer();

                    switch (answer)
                    {
                        case 1:
                            if (!hasDrawnNewCards)
                            {
                                ThrowingOutCards(ref cardsInHand, ref cardManagment, ref hasDrawnNewCards);
                            }
                            else
                            {
                                Console.WriteLine("Sorry but you have already drawn new cards");
                            }
                            break;

                        case 2:
                            stopGameLoop = true;
                            Finish(cardsInHand);
                            break;

                        default:
                            Console.WriteLine("Selected option was unclear." +
                                "\n I will repeat the question!");
                            break;
                    }
                }
                if (hasDrawnNewCards)
                {
                    Finish(cardsInHand);
                    stopGameLoop = true;
                }
                
                if (stopGameLoop)break;
            }

        }

        private void ThrowingOutCards(ref Card[] heldCards, ref CardManagment cardManagment, ref bool hasPickedCards )
        {
            bool cardsGotten = false;

            while (true)
            {
                Console.WriteLine("Please, enter an amount of cards that you want to throw out" +
                    "\nWrite 0 if you want to get back");
                int answer = GetAnswer();

                if (answer == 0)
                {
                    break;
                }

                else if (answer > heldCards.Length)
                {
                    Console.WriteLine("Sorry, but there are not that many cards");
                }

                else if (answer < 0)
                {
                    Console.WriteLine("Sorry, but selected amount is unavailable");
                }

                else
                {

                    hasPickedCards = true;
                    cardsGotten = true;
                    //if player wants to throw out all of the cards
                    if (answer == heldCards.Length)
                    {
                        for (int i = 0; i < heldCards.Length; i++)
                        {
                            heldCards[i] = cardManagment.TakeOutRandomCard();
                        }
                    }

                    //when player wants to throw out some of the cards
                    else
                    {
                        int[] pickedCardIndexes = new int[answer];
                        PrintOutCards(heldCards);

                        for (int i = 0; i < answer; i++)
                        {
                            Console.WriteLine("Select the number of the card that you want to be thrown out");

                            answer = GetAnswer();


                            if (answer > 0 && answer <= heldCards.Length)
                            {

                                if (pickedCardIndexes.Contains(answer - 1))
                                {
                                    Console.WriteLine("Sorry but you have already entered this number");
                                    i--;
                                }

                                else
                                {
                                    pickedCardIndexes[i] = answer - 1;
                                }
                            }

                            else
                            {
                                Console.WriteLine("There is no such card under this number");
                                i--;
                            }



                        }

                        for (int i = 0; i < pickedCardIndexes.Length; i++)
                        {
                            heldCards[pickedCardIndexes[i]] = cardManagment.TakeOutRandomCard();
                        }

                    }
                }

                if (cardsGotten) break;
            }

            
        }

        private int GetAnswer()
        {
            Console.WriteLine("Please write your answer and press \"Enter\"");
            int result;

            if (Int32.TryParse(Console.ReadLine().Replace(" ", String.Empty), out int returnedInt))
            {
                result = returnedInt;
            }

            else
            {
                result = -1;
            }
            return result ;
        }

        private void Finish(Card [] cards)
        {
            ScoreCalculator scoreCalculator = new ScoreCalculator();
            int score = scoreCalculator.GetScore(cards);
            Console.WriteLine($"Hooray!! Your final score is : {score}!!! Cool!!" +
                $"\nPress any key to get back to main menu");
            Console.ReadKey();
        }

        private void PrintOutCards(Card[] heldCards)
        {
            Console.WriteLine("Your cards are:");
            for (int i = 0; i < heldCards.Length; i++)
            {
                Console.WriteLine($"{i + 1}) [{heldCards[i].cardSymbol} : {heldCards[i].cardRank} ]");
            }
        }



    }
}

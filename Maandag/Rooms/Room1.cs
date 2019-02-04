using System;
using System.Collections.Generic;
using System.Text;

namespace Maandag.Rooms
{
    class Room1 : Room
    {
        string[,] map = new string[10,10];
        int xpos = 5;
        int ypos = 5;
        //dsa
        int mxpos = 3;
        int mypos = 3;
        bool monsterFound = false;

        bool dead = false;
        public void printMap()
        {

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                    Console.Write(" ");


                }
                Console.WriteLine("");
            }
        }

        public bool start()
        {
            initializeMap();
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Green;

            Console.WriteLine("Find the monster in this room by walking around");
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();

            Console.Clear();


            dead = false;
            while (!dead)
            {
                if (monsterFound)
                {
                    //Vecht met het monster en return de resultaat van het gevecht (true gewonnen of false verloren)
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine("You found the monster.");
                    Console.WriteLine(@" ((`\
            ___ \\ '--._
         .'`   `'    o  )
        /    \   '. __.'
       _|    /_  \ \_\_
jgs   {_\______\-'\__\_\");
                    return fightMonster();
                }

                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine("UP = W");
                Console.WriteLine("DOWN = S");
                Console.WriteLine("LEFT = A");
                Console.WriteLine("RIGHT = D");
                Console.WriteLine("YOUR POSTITION = @");
                printMap();
                
                Console.WriteLine("");
                Console.WriteLine("");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "W":
                        map[ypos, xpos] = "X";
                        ypos--;
                        checkNewState();
                        map[ypos, xpos] = "@";
                        break;
                    case "A":
                        map[ypos, xpos] = "X";
                        xpos--;
                        checkNewState();
                        map[ypos, xpos] = "@";
                        break;
                    case "S":
                        map[ypos, xpos] = "X";
                        ypos++;
                        checkNewState();
                        map[ypos, xpos] = "@";

                        break;
                    case "D":
                        map[ypos, xpos] = "X";
                        xpos++;
                        checkNewState();
                        map[ypos, xpos] = "@";
                        break;
                    default:
                        Console.WriteLine("Invalid input, please enter a valid input!");
                        break;
                }
                

                //Console.ReadLine();
            }

            return false;
        }

        private bool fightMonster()
        {
           
            Console.WriteLine("You have to fight him now, choose your weapon");
            bool done = false;
            while (!done)
            {
                Console.BackgroundColor = ConsoleColor.Green;

                Console.WriteLine("(S) for a Sword");
                Console.WriteLine("(B) for a Brick");

                string input = Console.ReadLine();
                switch (input)
                {
              
                    case "S":
                        Console.WriteLine("You lost!!!");
                        Console.WriteLine("Press enter to continue...");
                        Console.ReadLine();
                    
                        return false;
                    case "B":
                        Console.WriteLine("Great, now press enter to use the weapon to fight him");
                        Console.ReadLine();
                        Console.WriteLine("Great choise, you killed the monster!");
                        Console.WriteLine("You completed this room, great work!!! Lets return now to go to the next room!");
                        Console.WriteLine("Press enter to continue...");
                        Console.ReadLine();
                        return true;

                    default:
                        Console.WriteLine("Invalid input, please enter a valid input!");
                        break;
                }
            }

            Console.ReadLine();

            return false;
        }

        private void checkNewState()
        {
            //Ben je op een stekel getrapt
            if(map[ypos,xpos] == "^")
            {
                Console.WriteLine("You fell on a spike and died");
                dead = true;
            }
            if (map[ypos, xpos] == "M")
            {
                //Console.WriteLine("You fell on a spike and died");
                monsterFound = true;
            }

        }

        private void initializeMap()
        {
            for(int i = 0; i < map.GetLength(0); i++)
            {
                for(int j = 0; j<map.GetLength(1); j++)
                {
                    if (i == ypos && j == xpos)
                        map[i, j] = "@";
                    else if (i == mypos && j == mxpos)
                    {
                        map[i, j] = "M";

                    }
                    else
                    {
                        //Random stekels
                        Random rnd = new Random();
                        int random = rnd.Next(1, 10); // creates a number between 1 and 12

                        if (random == 1)
                        {
                            map[i, j] = "^";

                        }
                        else {
                            map[i, j] = "X";
                        }
                    }

                }
            }
        }
    }
}

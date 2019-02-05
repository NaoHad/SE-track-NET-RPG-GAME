using Maandag.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maandag.Rooms
{
    class Room1 : Room
    {
        public Room1(int roomWidth, int roomHeight, bool spikes, Monster monsterInRoom)
        {
            map = new string[roomWidth, roomHeight];

            xpos = 1;
            ypos = 1;
            mxpos = 3;//deze worden random
            mypos = 3;
            monsterFound = false;

            dead = false;
            spikesPresent = spikes;
            monster = monsterInRoom;
            
        }

        string[,] map;
        int xpos;
        int ypos;
        //dsa
        int mxpos;
        int mypos;
        bool monsterFound;
        bool dead;
        bool spikesPresent;
        Monster monster;

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
            Console.WriteLine("This monster is called {0}",monster.name);
            Console.WriteLine(@monster.image);

            Console.WriteLine("You have to fight him now, choose your weapon");
            bool done = false;
            while (!done)
            {
                Console.BackgroundColor = ConsoleColor.Green;

                

                foreach(Weapon weapon in Game.weaponList)
                {
                    Console.WriteLine("({0}) for a {1}",weapon.shortKey,weapon.name);
                    Console.WriteLine(weapon.image);

                }

                string input = Console.ReadLine();

                foreach (Weapon weapon in Game.weaponList) {
                    if (input == weapon.shortKey)
                    {
                        Console.WriteLine("You chose the {0}", weapon.name);
                        Console.WriteLine("Great, now press enter to use the weapon to fight him");
                        Console.ReadLine();
                        if(weapon.name == monster.weakpoint)
                        {
                            Console.WriteLine("Great choise, you killed the monster!");
                            Console.WriteLine("You completed this room, great work!!! Lets return now to go to the next room!");
                            Console.WriteLine("Press enter to continue...");
                            Console.ReadLine();
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("You lost!!!");
                            Console.WriteLine("Press enter to continue...");
                            Console.ReadLine();

                            return false;
                        }
                    }


                }
                Console.WriteLine("Invalid input, please enter a valid input!");

                
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
                        
                        if (random == 1 && spikesPresent)//Als stekels in dit level
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

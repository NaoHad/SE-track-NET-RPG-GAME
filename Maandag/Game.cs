﻿using Maandag.Model;
using Maandag.Rooms;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maandag
{
    //Functie start het spel

    //Functie stop het spel

    static class Game
    {
        public static Player player;
        //public static Room currentRoom;
        public static List<Room1> roomList;

        public static List<Weapon> weaponList;

        private const string E = "exit";
        private const string B = "begin";




        public static void begin()
        {
            //De currentRoom bepaald wat er gebeurt,
            //De start returnt een boolean die bepaald of je gefaald hebt of niet

            Console.WriteLine("We will enter the first room, good luck!!");
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();

            bool done = false;
            bool result = false;
            foreach (Room1 currentRoom in roomList) { 
                result = currentRoom.start();
                if (result)
                {
                    Console.WriteLine("You finished this room, you can continue to the next room");
                }
                else
                {
                    Console.WriteLine("unfortunately, you died and now the game is over!");
                    Game.stop();
                }
            }
            Console.WriteLine("Congratulations! YOU WON THE GAME!!!");
            Console.WriteLine("Press enter to close");
            Console.ReadLine();




        }


        //start(): begint het spel
        //Er zijn bepaalde opties waaruit de user kan kiezen 
        //Ondertussen kan hij ook stop aanroepen
        public static void start()
        {
            Game.initialize();

            Console.WriteLine(@"            )                          *         
              *   )  ( /(        (        (      (  `        
            ` )  /(  )\()) (     )\ )     )\     )\))(   (   
             ( )(_))((_)\  )\   (()/(  ((((_)(  ((_)()\  )\  
            (_(_())  _((_)((_)   /(_))_ )\ _ )\ (_()((_)((_) 
            |_   _| | || || __| (_)) __|(_)_\(_)|  \/  || __|
              | |   | __ || _|    | (_ | / _ \  | |\/| || _| 
              |_|   |_||_||___|    \___|/_/ \_\ |_|  |_||___|");

            Console.WriteLine("Please enter your name");







            string inputName = Console.ReadLine();
            player.name = inputName;   

            bool done = false;
            string input;
            while (!done)
            {
                Console.WriteLine("Please enter what you want to do {0}",player.name);
                Console.WriteLine("Enter (begin) to start the game");
                Console.WriteLine("Enter (stop) to exit the game");
                input = Console.ReadLine();
                switch (input)
                {
                    case B:
                        Game.info();
                        Game.begin();
                        done = true;
                        break;
                    case E:
                        Game.stop();
                        done = true;
                        break;
                    default:
                        Console.WriteLine("Invalide invoer {0}, voer aub een juiste waarde in!",player.name);
                        break;
                }
            }
            
        }

        private static void initialize()
        {
            player = new Player();

            //Create monsters
            Monster monster = new Monster();
            monster.image = @" ((`\
            ___ \\ '--._
         .'`   `'    o  )
        /    \   '. __.'
       _ |    / _  \ \_\_
  jgs   { _\______\-'\__\_\";
            monster.name = "Bunny";
            monster.weakpoint = "Brick";

            Monster m2 = new Monster();
            m2.image = @"                   .     _,
                   |`\__/ /
                   \  . .(
                    | __T|
                   /   |
      _.---======='    |
     //               {}
    `|      ,   ,     {}
     \      /___;    ,'
      ) ,-;`    `\  //
     | / (        ;||
     ||`\\        |||
     ||  \\       |||
jgs  )\   )\      )||";
            m2.name = "Deer";
            m2.weakpoint = "Sword";



            //initialize room list:
            roomList = new List<Room1>();
            roomList.Add(new Room1(10, 5, false,monster));
            roomList.Add(new Room1(10, 5, true,m2));

            //Initialize weaponlist
            weaponList = new List<Weapon>();


            Weapon w1 = new Weapon();
            w1.name = "Brick";
            w1.image = @"  +----------+
 /          /|
+----------+ +
|          |/
+----------+";
            w1.shortKey = "B";
            Weapon w2 = new Weapon();
            w2.name = "Sword";
            w2.image = @"      /| ________________
O|===|* >________________>
      \|";
            w2.shortKey = "S";

            weaponList.Add(w1);
            weaponList.Add(w2);

        }

        private static void info()
        {
            //Hier wordt het spelverloop uitgelegd
            Console.WriteLine(@" o                    
                       _---|         _ _ _ _ _ 
                    o   ---|     o   ]-I-I-I-[ 
   _ _ _ _ _ _  _---|      | _---|    \ ` ' / 
   ]-I-I-I-I-[   ---|      |  ---|    |.   | 
    \ `   '_/       |     / \    |    | /^\| 
     [*]  __|       ^    / ^ \   ^    | |*|| 
     |__   ,|      / \  /    `\ / \   | ===| 
  ___| ___ ,|__   /    /=_=_=_=\   \  |,  _|
  I_I__I_I__I_I  (====(_________)___|_|____|____
  \-\--|-|--/-/  |     I  [ ]__I I_I__|____I_I_| 
   |[]      '|   | []  |`__  . [  \-\--|-|--/-/  
   |.   | |' |___|_____I___|___I___|---------| 
  / \| []   .|_|-|_|-|-|_|-|_|-|_|-| []   [] | 
 <===>  |   .|-=-=-=-=-=-=-=-=-=-=-|   |    / \  
 ] []|`   [] ||.|.|.|.|.|.|.|.|.|.||-      <===> 
 ] []| ` |   |/////////\\\\\\\\\\.||__.  | |[] [ 
 <===>     ' ||||| |   |   | ||||.||  []   <===>
  \T/  | |-- ||||| | O | O | ||||.|| . |'   \T/ 
   |      . _||||| |   |   | ||||.|| |     | |
../|' v . | .|||||/____|____\|||| /|. . | . ./
.|//\............/...........\........../../\\\");
            Console.WriteLine("We need your help to find the hidden treasure in the castle");
            Console.WriteLine("You will visit several rooms of the castle");
            Console.WriteLine("");

            Console.WriteLine("Based on your decisions you will either die or succeed");
            Console.WriteLine("Good luck!!!");



            Console.WriteLine("Press enter to continue");
            Console.ReadLine();

        }

        public static void stop()
        {
            Console.WriteLine("We hope to see you soon!!!");
            Console.WriteLine("Press enter to quit");
            Console.ReadLine();

        }
           
    }
}

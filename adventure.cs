using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace asciiadventure {
  public class Game {
    private Random random = new Random();
    private static Boolean Eq(char c1, char c2){
      return c1.ToString().Equals(c2.ToString(), StringComparison.OrdinalIgnoreCase);
    }

    private static string Menu() {
      return "Get all the treature (T),\nbut be careful, mobs (#) can can attack you!\nDo not be scared, you can kill them if you have a weapon (*).\n\nWASD to move\nIJKL to attack/interact\nEnter command: ";
    }

    private static void PrintScreen(Screen screen, string message, string menu) {
      Console.Clear();
      Console.WriteLine(screen);
      Console.WriteLine($"\n{message}");
      Console.WriteLine($"\n{menu}");
    }
    public void Run() {
      Console.ForegroundColor = ConsoleColor.Green;

      Screen screen = new Screen(25, 25);

      // Horizontal Walls

      // line 1 walls
      for (int i = 0; i < 8; i++){
        new HorizontalWall(1, i, screen);
      }

      for (int i = 11; i < 16; i++){
        new HorizontalWall(1, i, screen);
      }

      for (int i = 19; i < 23; i++){
        new HorizontalWall(1, i, screen);
      }

      // line 2 walls
      for (int i = 12; i < 13; i++){
        new HorizontalWall(2, i, screen);
      }

      for (int i = 14; i < 15; i++){
        new HorizontalWall(2, i, screen);
      }

      // line 3 walls
      for (int i = 2; i < 8; i++){
        new HorizontalWall(3, i, screen);
      }

      // line 6 walls
      for (int i = 5; i < 12; i++){
        new HorizontalWall(6, i, screen);
      }

      // line 8 walls
      for (int i = 5; i < 16; i++){
        new HorizontalWall(8, i, screen);
      }
      
      // line 10 walls
      for (int i = 2; i < 10; i++){
        new HorizontalWall(10, i, screen);
      }

      for (int i = 12; i < 20; i++){
        new HorizontalWall(10, i, screen);
      }
      
      // line 12 walls
      for (int i = 2; i < 10; i++){
        new HorizontalWall(12, i, screen);
      }

      for (int i = 12; i < 19; i++){
        new HorizontalWall(12, i, screen);
      }

      // line 14 walls
      for (int i = 6; i < 20; i++){
        new HorizontalWall(14, i, screen);
      }

      // line 16 walls
      for (int i = 2; i < 16; i++){
        new HorizontalWall(16, i, screen);
      }
      
      // line 21 walls
      for (int i = 5; i < 20; i++){
        new HorizontalWall(21, i, screen);
      }

      // line 23 walls
      for (int i = 2; i < 23; i++){
        new HorizontalWall(23, i, screen);
      }

      // vertical wals

      // vertical walls for 2
      for (int i = 4; i < 10; i++){
        new VerticalWall(i, 2, screen);
      }

      for (int i = 13; i < 16; i++){
        new VerticalWall(i, 2, screen);
      }

      for (int i = 17; i < 23; i++){
        new VerticalWall(i, 2, screen);
      }

      // vertical walls for 5
      for (int i = 7; i < 8; i++){
        new VerticalWall(i, 5, screen);
      }

      for (int i = 17; i < 21; i++){
        new VerticalWall(i, 5, screen);
      }

      // vertical walls for 7
      for (int i = 2; i < 3; i++){
        new VerticalWall(i, 7, screen);
      }

      // vertical walls for 9
      for (int i = 11; i < 12; i++){
        new VerticalWall(i, 9, screen);
      }
 
      // vertical walls for 11
      for (int i = 2; i < 6; i++){
        new VerticalWall(i, 11, screen);
      }

      // vertical walls for 12
      for (int i = 11; i < 12; i++){
        new VerticalWall(i, 12, screen);
      }
      
      // vertical walls for 14
      for (int i = 2; i < 8; i++){
        new VerticalWall(i, 15, screen);
      }
      
      // vertical walls for 19
      for (int i = 2; i < 10; i++){
        new VerticalWall(i, 19, screen);
      }
      for (int i = 15; i < 21; i++){
        new VerticalWall(i, 19, screen);
      }

      // vertical walls for 22
      for (int i = 2; i < 23; i++){
        new VerticalWall(i, 22, screen);
      }
        // end of walls 

      // add a teleport
      Teleport teleport1 = new Teleport(2,5, screen);
      Teleport teleport2 = new Teleport(2,13, screen);

      // add teleport exits
      Teleportexit teleport_exit1 = new Teleportexit(7,7, screen);
      Teleportexit teleport_exit2 = new Teleportexit(2,20, screen);

      // add a player
      Player player = new Player(0, 0, screen, "Zelda");
      
      // add a treasure
      Treasure treasure1 = new Treasure(20, 7, screen);
      Treasure treasure2 = new Treasure(11, 14, screen);
      Treasure treasure3 = new Treasure(11, 7, screen);
      Treasure treasure4 = new Treasure(17, 3, screen);
           
      //add a weapon
      Weapon DESTRUCTION = new Weapon(7, 13, screen);

      // add some mobs
      List<Mob> mobs = new List<Mob>();
      mobs.Add(new Mob(17, 10, screen));
      mobs.Add(new Mob(18, 11, screen));
      mobs.Add(new Mob(19, 12, screen));
      mobs.Add(new Mob(20, 13, screen));
      mobs.Add(new Mob(17, 13, screen));
      mobs.Add(new Mob(18, 12, screen));
      mobs.Add(new Mob(19, 11, screen));
      mobs.Add(new Mob(20, 10, screen));
      mobs.Add(new Mob(11, 19, screen));
      mobs.Add(new Mob(11, 20, screen));
      mobs.Add(new Mob(11, 21, screen));  
             
      
      // initially print the game board
      PrintScreen(screen, "Welcome!", Menu());
      
      Boolean gameOver = false;
      
      while (!gameOver) {
          char input = Console.ReadKey(true).KeyChar;

          String message = "";

          if (Eq(input, 'q')) { // quit the game
            break;
          } else if (Eq(input, 'w')) { // walking
            player.Move(-1, 0);
          } else if (Eq(input, 's')) {
            player.Move(1, 0);
          } else if (Eq(input, 'a')) {
            player.Move(0, -1);
          } else if (Eq(input, 'd')) {
            player.Move(0, 1);

          // interacting with objects
          } else if (Eq(input, 'i')) { 
            message += player.Action(-1, 0) + "\n";
          } else if (Eq(input, 'k')) {
            message += player.Action(1, 0) + "\n";
          } else if (Eq(input, 'j')) {
            message += player.Action(0, -1) + "\n";
          } else if (Eq(input, 'l')) {
            message += player.Action(0, 1) + "\n";
          } else if (Eq(input, 'v')) {
          
            message = "You have nothing\n";
          } else {
            message = $"Unknown command: {input}";
          }
             
          foreach (Mob mob in mobs){
            List<Tuple<int, int>> moves = screen.GetLegalMoves(mob.Row, mob.Col);
            if (moves.Count == 0){
                continue;
            }

            Tuple<int, int> t = moves[random.Next(moves.Count)];
            int deltaRow = t.Item1;
            int deltaCol = t.Item2;
            
            if (screen[mob.Row + deltaRow, mob.Col + deltaCol] is Player) && mob.health > 0 /*had to add this so that mob would stop killing the player after it dies*/){
                mob.Token = "~";
                message += "A MOB GOT YOU! GAME OVER\n";
                gameOver = true;
                mob.Move(deltaRow, deltaCol); //added this so now everything should work
            }
            
            else if (mob.health == 0){
              mob.Token = null; 
              mob.Delete();
            }

            else { 
              mob.Move(deltaRow, deltaCol);
            }
          }

          PrintScreen(screen, message, Menu());
      }
    }

    public static void Main(string[] args){
      Game game = new Game();
      game.Run();
    }
  }
}
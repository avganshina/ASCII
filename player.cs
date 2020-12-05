using System;
using System.Collections.Generic;

namespace asciiadventure {
    class Player : MovingGameObject {
        int treasure_count = 4;
        public Weapon w; //this will be used in action to check whether or not the player picked up a weapon

        public Player(int row, int col, Screen screen, string name) : base(row, col, "@", screen) {
            Name = name;
        }
        public string Name {
            get;
            protected set;
        }
        public override Boolean IsPassable(){
            return true;
        }

        public String Action(int deltaRow, int deltaCol){
            int newRow = Row + deltaRow;
            int newCol = Col + deltaCol;
            if (!Screen.IsInBounds(newRow, newCol)){
                return "nope";
            }
            GameObject other = Screen[newRow, newCol];

            if (other == null){
                return "negative";
            }
            
            if (other is Treasure){
                other.Delete();
                treasure_count--;
                if (treasure_count != 0) 
                  return "Yay, we got the treasure!";
                if (treasure_count == 0)
                  return "You WON! Game over!";
            }

            
            //related to weapon class
            if (other is Weapon){
              this.w = (Weapon)other;
              other.Delete();
              return "You now have a weapon!";
            }

            if((other is Mob) && (this.w != null)){
              Mob m = (Mob)other;
              m.Hit();
             // if (m.health == 0){
                return "You killed the mob! Yay!";
             // }
              return "Attack!";
            }
            
            // related to teleport
            if (other is Teleport && (!Screen.IsInBounds(Row, Col-5))){
                 this.Move(5,4);
                 return "You were teleported!";
            }

            if (other is Teleport && (Screen.IsInBounds(Row, Col-5)) &&(!Screen.IsInBounds(Row, Col-16))){
                 this.Move(0,7);
                 return "You were teleported!";
            }
            return "ouch";
        }
    }
}
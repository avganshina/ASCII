using System;

namespace asciiadventure {
    public class Mob : MovingGameObject {
        public int health = 1; 
        public Mob(int row, int col, Screen screen) : base(row, col, "#", screen) {}
        public void Hit(){
          health--;
          if (health == 0){ 
              this.Delete();
          }    
        }
    }
}
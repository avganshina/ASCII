using System;
using System.Collections.Generic;


namespace asciiadventure {
    public abstract class GameObject {
        
        public int Row {
            get;
            protected set;
        }
        public int Col {
            get;
            protected set;
        }

        public String Token {
            get;
            protected internal set;
        }

        public Screen Screen {
            get;
            protected set;
        }

        public GameObject(int row, int col, String token, Screen screen){
            Row = row;
            Col = col;
            Token = token;
            Screen = screen;
            Screen[row, col] = this;
        }
        public string ToToken() {
            return Token;
        }

        public virtual Boolean IsPassable() {
            return false;
        }

        public override String ToString() {
            return this.ToToken();
        }

        public void Delete() {
            Screen[Row, Col] = null;
        }
    }

    public abstract class MovingGameObject : GameObject {

        public MovingGameObject(int row, int col, String token, Screen screen) : base(row, col, token, screen) {}
        
        public string Move(int deltaRow, int deltaCol) {
            int newRow = deltaRow + Row;
            int newCol = deltaCol + Col;
            if (!Screen.IsInBounds(newRow, newCol)) {
                return "";
            }
            GameObject gameObject = Screen[newRow, newCol];
            if (gameObject != null && !gameObject.IsPassable()) {
                return "TODO: Handle interaction";
            }
            // Now just make the move
            int originalRow = Row;
            int originalCol = Col;
            // now change the location of the object, if the move was legal
            Row = newRow;
            Col = newCol;
            Screen[originalRow, originalCol] = null;
            Screen[Row, Col] = this;
            return "";
        }
    }

    // new features - start

    class Teleport : GameObject {
        public Teleport(int row, int col, Screen screen) : base(row, col, "0", screen) {}
    }

    class Teleportexit : GameObject {
        public Teleportexit(int row, int col, Screen screen) : base(row, col, "X", screen) {}
    }

    // new features - end

    class HorizontalWall : GameObject {
        public HorizontalWall(int row, int col, Screen screen) : base(row, col, "=", screen) {}
    }

    class VerticalWall : GameObject {
        public VerticalWall(int row, int col, Screen screen) : base(row, col, "|", screen) {}
    }

    class Treasure : GameObject {
        public Treasure(int row, int col, Screen screen) : base(row, col, "T", screen) {}
    }

    class Weapon : GameObject {
        public Weapon(int row, int col, Screen screen) : base(row, col, "*", screen) {}
    }
}
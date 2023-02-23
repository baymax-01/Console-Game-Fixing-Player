using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBase
{
    //This is The main Abstract class of entityclass can implement base class
    //and give body of every methods
    public abstract class EntityBase
    {
        private int _gold;
        private int _health;
        private int _maxHealth;
        private string _name;
        private int _level;
        private int _armor;
        private int _enemiesKilled;
        private int _doorKey;
      
        public int DoorKey
        {
            get
            {
                return _doorKey;
            }
            set
            {
                _doorKey = value;
            }
        }
        public int Gold
        {
            get
            {
                return _gold;
            }
            set
            {
                _gold = value;
            }
        }
        public int Level
        {
            get
            {
                return _level;
            }
            set
            {
                _level = value;
            }
        }
        public int Armor
        {
            get
            {
                return _armor;
            }
            set
            {
                _armor = value;
            }
        }
        public int Killed
        {
            get
            {
                return _enemiesKilled;
            }
            set
            {
                _enemiesKilled = value;
            }
        }
        public int Health
        {
            get
            {
                return _health;
            }
            set
            {
                _health = value;
            }
        }

        public int MaxHealth
        {
            get
            {
                return _maxHealth;
            }
            set
            {
                _maxHealth = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        
        public int x { get; private set; }
        public int y { get; private set; }
        private GameScene scene;
        public bool smoothRender = false;
        public Pixel pixel { get; private set; } = new Pixel()
        {
            BackgroundColor = ConsoleColor.Black,
            ForegroundColor = ConsoleColor.Gray
        };
        public bool isDestroyed { get; private set; } = false;
        //Linked use to load maps and traverse the player monster and other objects
        public LinkedList<EntityBase>[,] gridView { get => (LinkedList<EntityBase>[,])scene.grid.Clone(); }
        public EntityType entityType { get => GetEntityByChar(character); }

        public Random random { get => Util.Random; }

        public abstract string name { get; set; }
        public abstract char character { get; set; }

        public virtual void Start(GameScene scene, int x, int y)
        {
            this.scene = scene;
            this.x = x;
            this.y = y;
        }

        public abstract void Update();

        public void Move(int x, int y)
        {
            scene.grid[this.y, this.x].RemoveFirst();
            scene.grid[y, x].AddFirst(this);
            this.x = x;
            this.y = y;
        }
        public abstract void DrawStats();

        //These All MEthods For Destroying Letter
        //when player hits S,G to remove from the Screen

        public void DestroySword()
        {
            isDestroyed = true;
            scene.DestroySword(this);
        }
        public void DestroyKey()
        {
            isDestroyed = true;
            scene.DestroyKey(this);
        }
        public void DestroyTresure()
        {
            isDestroyed = true;
            scene.DestroyTresure(this);
        }
        public void DestroyDoor()
        {
            isDestroyed = true;
            scene.DestroyDoor(this);
        }
        public void DestroyGold()
        {
            isDestroyed = true;
            scene.DestroyGold(this);
        }
        public void DestroyMoster()
        {
            isDestroyed = true;
            scene.DestroyMonster(this);
        }
        //get the curetn object
        public EntityType GetEntityByChar(char c)
        {
            switch (c)
            {
                case Constant.PlayerChar:
                    return EntityType.PLAYER;
                case Constant.Avatar1Char:
                    return EntityType.PLAYER;
                case Constant.Avatar2Char:
                    return EntityType.PLAYER;
                case Constant.Avatar3Char:
                    return EntityType.PLAYER;
                case Constant.GhostChar:
                    return EntityType.GHOST;
                case Constant.WallCharVertical:
                    return EntityType.WALL;
               case Constant.WallCharHorizontal:
                    return EntityType.WALL;
                case Constant.SpaceChar:
                    return EntityType.SPACE;
                case Constant.SwordChar:
                    return EntityType.SWORD;
                case Constant.ExitChar:
                    return EntityType.EXIT;
                case Constant.TreasureChar:
                    return EntityType.TRESURE;
                case Constant.DoorChar:
                    return EntityType.DOOR;
                case Constant.DoorKeyChar:
                    return EntityType.KEY;
                case Constant.GoldChar:
                    return EntityType.GOLD;
                default:
                    return EntityType.NONE;
            }
        }

        public InputStatus GetInputs()
        {
            return scene.input.GetInput();
        }

        public EntityBase GetEntityInDirection(Direction direction, int distance)
        {
            var destX = x;
            var destY = y;
            switch (direction)
            {
                case Direction.LEFT:
                    destX -= distance;
                    break;
                case Direction.RIGHT:
                    destX += distance;
                    break;
                case Direction.UP:
                    destY -= distance;
                    break;
                case Direction.DOWN:
                    destY += distance;
                    break;
            }

            //Out of range
            if (destY < 0 || destX < 0 || destY >= scene.ySize || destY >= scene.xSize)
                return null;

            return gridView[destY, destX].First.Value;
        }

        public void StartTransition(TransitionType type)
        {
            scene.StartTransition(type);
        }
    }
}

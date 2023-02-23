using GameBase.Entity;
using GameBase.Game;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBase
{
    public class GameScene
    {
        public LinkedList<EntityBase>[,] grid;
        public int xSize;
        public int ySize;
        public Renderer renderer;
        public Input input;
        public TransitionType transition = TransitionType.None;

        private int ScoreInMap = 0;
        private int SwordInMap = 0;
        private int MonsterInMap = 0;
        private int KeyInMap = 0;
        private int TreasureInMap = 0;
        public GameScene(int x, int y, Renderer renderer)
        {
            grid = new LinkedList<EntityBase>[y, x];
            xSize = x;
            ySize = y;

            this.renderer = renderer;
            Renderer.Clear();
            input = new Input();
        }

        public void Load(string filePath)
        {
            var text = File.ReadAllText(filePath);
            //Remove \r to fix OS compatibility
            text = text.Replace("\r", "");
            var list = text.Split('\n');
            for (var y = 0; y < ySize; y++)
            {
                var line = list[y];
                for (int x = 0; x < xSize; x++)
                {
                    var character = line[x];
                    var linkedList = new LinkedList<EntityBase>();
                    grid[y, x] = linkedList;

                    linkedList.AddFirst(new Space());

                    if (character == Constant.PlayerChar)
                    {
                        if (shareModel.newgame)
                        {
                            var p = new Player(1,shareModel.name,shareModel.character);
                            p.Start(this, x, y);
                            linkedList.AddFirst(p);
                        }
                        else
                        {
                            var ps = new Player(shareModel.Gold,shareModel.Health,shareModel.name,shareModel.Armor,shareModel.Level, shareModel.character);
                            ps.Start(this, x, y);
                            linkedList.AddFirst(ps);
                        }

                    }
                    else if (character == Constant.GhostChar)
                    {
                        var p = new Monster();
                        p.Start(this, x, y);
                        linkedList.AddFirst(p);
                    }
                    else if (character == Constant.WallCharHorizontal)
                    {
                        var p = new WallHorizonatal();
                        p.Start(this, x, y);
                        linkedList.AddFirst(p);
                    }
                    else if (character == Constant.WallCharVertical)
                    {
                        var p = new WallVertical();
                        p.Start(this, x, y);
                        linkedList.AddFirst(p);
                    }
                    else if (character == Constant.SwordChar)
                    {
                        var p = new Sword();
                        p.Start(this, x, y);
                        linkedList.AddFirst(p);
                    }
                    else if (character == Constant.EntranceChar)
                    {
                        var p = new Entrance();
                        p.Start(this, x, y);
                        linkedList.AddFirst(p);
                    }
                    else if (character == Constant.ExitChar)
                    {
                        var p = new Exit();
                        p.Start(this, x, y);
                        linkedList.AddFirst(p);
                    }
                    else if (character == Constant.TreasureChar)
                    {
                        var p = new Treasure();
                        p.Start(this, x, y);
                        linkedList.AddFirst(p);
                    }
                    else if (character == Constant.DoorKeyChar)
                    {
                        var p = new DoorKey();
                        p.Start(this, x, y);
                        linkedList.AddFirst(p);
                    }
                    else if (character == Constant.DoorChar)
                    {
                        var p = new Door();
                        p.Start(this, x, y);
                        linkedList.AddFirst(p);
                    }
                    else if (character == Constant.GoldChar)
                    {
                        var p = new Gold();
                        p.Start(this, x, y);
                        linkedList.AddFirst(p);
                    }
                }
            }
        }

        public void Tick()
        {
            //We use a queue to first get all jobs to be executed and then execute every single job just once
            //If we execute immediately without a queue, the object position can change within that execution and it's possible that the same object could be executed multiple times during same tick
            var executionQueue = new Queue<EntityBase>();
            for (int y = 0; y < ySize; y++)
            {
                for (int x = 0; x < xSize; x++)
                {
                    var entities = grid[y, x];
                    var item = entities.First;
                    while (item != null)
                    {
                        executionQueue.Enqueue(item.Value);
                        item = item.Next;
                        
                    }
                }
            }

            while (executionQueue.Count > 0 && transition == TransitionType.None)
            {
                var item = executionQueue.Dequeue();
                if (!item.isDestroyed)
                    item.Update();
                item.DrawStats();
            }

            renderer.Render(grid);

          
        }

        
        public void DestroySword(EntityBase e)
        {
            for (int y = 0; y < ySize; y++)
            {
                for (int x = 0; x < xSize; x++)
                {
                    var entities = grid[y, x];
                    var item = entities.First;
                    while (item != null)
                    {
                        if (item.Value == e)
                        {
                            entities.Remove(item);

                            if (item.Value is Sword)
                            {
                                SwordInMap--;
                               // if (SwordInMap == 0)
                                //    StartTransition(TransitionType.Finish);
                            }
                        }
                        item = item.Next;
                    }
                }
            }
        }
        public void DestroyMonster(EntityBase e)
        {
            for (int y = 0; y < ySize; y++)
            {
                for (int x = 0; x < xSize; x++)
                {
                    var entities = grid[y, x];
                    var item = entities.First;
                    while (item != null)
                    {
                        if (item.Value == e)
                        {
                            entities.Remove(item);

                            if (item.Value is Monster)
                            {
                                MonsterInMap--;
                            }
                        }
                        item = item.Next;
                    }
                }
            }
        }
        public void DestroyKey(EntityBase e)
        {
            for (int y = 0; y < ySize; y++)
            {
                for (int x = 0; x < xSize; x++)
                {
                    var entities = grid[y, x];
                    var item = entities.First;
                    while (item != null)
                    {
                        if (item.Value == e)
                        {
                            entities.Remove(item);

                            if (item.Value is DoorKey)
                            {
                                KeyInMap--;
                                // if (SwordInMap == 0)
                                //    StartTransition(TransitionType.Finish);
                            }
                        }
                        item = item.Next;
                    }
                }
            }
        }
        public void DestroyTresure(EntityBase e)
        {
            for (int y = 0; y < ySize; y++)
            {
                for (int x = 0; x < xSize; x++)
                {
                    var entities = grid[y, x];
                    var item = entities.First;
                    while (item != null)
                    {
                        if (item.Value == e)
                        {
                            entities.Remove(item);

                            if (item.Value is Treasure)
                            {
                                TreasureInMap--;
                                // if (SwordInMap == 0)
                                //    StartTransition(TransitionType.Finish);
                            }
                        }
                        item = item.Next;
                    }
                }
            }
        }
        public void DestroyDoor(EntityBase e)
        {
            for (int y = 0; y < ySize; y++)
            {
                for (int x = 0; x < xSize; x++)
                {
                    var entities = grid[y, x];
                    var item = entities.First;
                    while (item != null)
                    {
                        if (item.Value == e)
                        {
                            entities.Remove(item);
                        }
                        item = item.Next;
                    }
                }
            }
        }
        public void DestroyGold(EntityBase e)
        {
            for (int y = 0; y < ySize; y++)
            {
                for (int x = 0; x < xSize; x++)
                {
                    var entities = grid[y, x];
                    var item = entities.First;
                    while (item != null)
                    {
                        if (item.Value == e)
                        {
                            entities.Remove(item);
                        }
                        item = item.Next;
                    }
                }
            }
        }
        public void StartTransition(TransitionType type)
        {
            transition = type;
        }


    }
}

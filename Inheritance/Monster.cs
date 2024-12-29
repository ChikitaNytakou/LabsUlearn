using Digger.Architecture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digger
{
    public class Monster : ICreature
    {
        public CreatureCommand Act(int x, int y)
        {
            CreatureCommand monster = new CreatureCommand();

            if (!Game.IsOver)
                monster = MoveToPlayer(new CreatureCommand(), FindPlayer(), x, y);

            return monster;
        }

        private CreatureCommand MoveToPlayer(CreatureCommand monster, CreatureCommand player, int x, int y)
        {
            if (x > player.DeltaX)
            {
                if (IsNextCellEmpty(x - 1, y))
                    if (x > 0)
                        monster.DeltaX--;
            }
            else if (x < player.DeltaX)
            {
                if (IsNextCellEmpty(x + 1, y))
                    if (x < Game.MapWidth - 1)
                        monster.DeltaX++;
            }

            if (y > player.DeltaY)
            {
                if (IsNextCellEmpty(x, y - 1))
                    if (y > 0)
                        monster.DeltaY--;
            }
            else if (y < player.DeltaY)
            {
                if (IsNextCellEmpty(x, y + 1))
                    if (y < Game.MapHeight - 1)
                        monster.DeltaY++;
            }

            return monster;
        }

        private bool IsNextCellEmpty(int x, int y)
        {
            if (Game.Map[x, y] is Terrain || Game.Map[x, y] is Sack || Game.Map[x, y] is Monster)
                return false;

            return true;
        }

        private CreatureCommand FindPlayer()
        {
            CreatureCommand player = new CreatureCommand();

            bool isFoundPlayer = false;
            for (int i = 0; i < Game.Map.GetLength(0); i++)
            {
                for (int j = 0; j < Game.Map.GetLength(1); j++)
                {
                    if (Game.Map[i, j] is Player)
                    {
                        isFoundPlayer = true;
                        player.DeltaX = i;
                        player.DeltaY = j;
                        return player;
                    }
                }
            }

            if (!isFoundPlayer)
            {
                player.DeltaX = -1;
                player.DeltaY = -1;
            }
            return player;
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            if (conflictedObject is Sack || conflictedObject is Monster)
                return true;
            else
                return false;
        }

        public int GetDrawingPriority()
        {
            return 2;
        }

        public string GetImageFileName()
        {
            return "Monster.png";
        }
    }
}

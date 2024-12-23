using Avalonia.Input;
using Digger.Architecture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digger
{
    public class Player : ICreature
    {
        public CreatureCommand Act(int x, int y)
        {
            var command = new CreatureCommand();

            switch (Game.KeyPressed)
            {
                case Key.Up:
                    if (y > 0)
                        if (Game.Map[x, y - 1] is not Sack)
                            command.DeltaY--;
                    break;
                case Key.Down:
                    if (y < Game.MapHeight - 1)
                        if (Game.Map[x, y + 1] is not Sack) 
                            command.DeltaY++;
                    break;
                case Key.Right:
                    if (x < Game.MapWidth - 1)
                        if (Game.Map[x + 1, y] is not Sack) 
                            command.DeltaX++;
                    break;
                case Key.Left:
                    if (x > 0)
                        if (Game.Map[x - 1, y] is not Sack) 
                            command.DeltaX--;
                    break;
                default:
                    command.DeltaX = 0;
                    command.DeltaY = 0;
                    break;
            }
            return command;
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            if (conflictedObject is Sack || conflictedObject is Monster)
            {
                Game.IsOver = true;
                return true;
            }
            else
                return false;
        }

        public int GetDrawingPriority()
        {
            return 3;
        }

        public string GetImageFileName()
        {
            return "Digger.png";
        }
    }
}

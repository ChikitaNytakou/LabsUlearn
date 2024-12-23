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
                    if (y > 0) command.DeltaY -= 1;
                    break;
                case Key.Down:
                    if (y < Game.MapHeight - 1) command.DeltaY += 1;
                    break;
                case Key.Right:
                    if (x < Game.MapWidth - 1) command.DeltaX += 1;
                    break;
                case Key.Left:
                    if (x > 0) command.DeltaX -= 1;
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
            //string nextObject = conflictedObject.ToString();
            //if (nextObject == "Digger.Terrain") return false;
            //else 
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

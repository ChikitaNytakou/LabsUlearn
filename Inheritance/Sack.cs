using Digger.Architecture;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digger
{
    public class Sack : ICreature
    {
        private int _counter = 0;
        public CreatureCommand Act(int x, int y)
        {
            CreatureCommand command = new CreatureCommand();

            if (IsFallen(x, y, _counter))
            {
                command.DeltaY++;
                _counter++;

            }
            else
            {
                if (_counter > 1)
                    command.TransformTo = new Gold();
                else
                    _counter = 0;
            }

            return command;
        }

        private static bool IsFallen(int x, int y, int counter)
        {
            if (y < Game.MapHeight - 1)
            {
                if (Game.Map[x, y + 1] == null || (Game.Map[x, y + 1] is Player && counter > 0))
                {
                    return true;
                }
            }

            return false;
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            return false;
        }

        public int GetDrawingPriority()
        {
            return 1;
        }

        public string GetImageFileName()
        {
            return "Sack.png";
        }
    }
}

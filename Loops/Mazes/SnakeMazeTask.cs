namespace Mazes;

public static class SnakeMazeTask
{
    public static void MoveOut(Robot robot, int width, int height)
    {
        MoveInHorizontal(robot, width);
        while (!robot.Finished)
        {
            MoveToDownLevel(robot, height);
            MoveInHorizontal(robot, width);
        }
    }

    public static void MoveInHorizontal(Robot robot, int width)
    {
        bool IsLeftSide = robot.X == 1;
        for (int i = 0; i < width - 3; i++) 
        {
            if (IsLeftSide) robot.MoveTo(Direction.Right);
            else robot.MoveTo(Direction.Left);
        }
    }

    public static void MoveToStartHorizontal(Robot robot, int width)
    {
        while (robot.X > 1)
        {
            robot.MoveTo(Direction.Left);
        }
    }

    public static void MoveToDownLevel(Robot robot, int height)
    {
       robot.MoveTo(Direction.Down);
       robot.MoveTo(Direction.Down);
    }
}
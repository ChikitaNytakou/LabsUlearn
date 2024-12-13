namespace Mazes;

public static class EmptyMazeTask
{
    public static void MoveOut(Robot robot, int width, int height)
    {
        while(!robot.Finished)
        {
            MoveToEndHorizontal(robot, width);
            MoveToEndVertical(robot, height);
        }
    }
    public static void MoveToEndHorizontal(Robot robot, int width)
    {
        while (robot.X < width - 2)
        {
            robot.MoveTo(Direction.Right);
        }
    }

    public static void MoveToEndVertical(Robot robot, int height)
    {
        while (robot.Y < height - 2)
        {
            robot.MoveTo(Direction.Down);
        }
    }
}
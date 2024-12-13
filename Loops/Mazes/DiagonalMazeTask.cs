using System;

namespace Mazes;

public static class DiagonalMazeTask
{
    public static void MoveOut(Robot robot, int width, int height)
    {
        int step = FindStep(width, height);
        bool isMazeHorizontalOriented = IsMazeOrientedHorizontally(width, height);
        MoveOneStep(robot, step, isMazeHorizontalOriented);
        while (!robot.Finished)
        {
            MoveToDownLevel(robot, width, height);
            MoveOneStep(robot, step, isMazeHorizontalOriented);
        }
    }

    public static int FindStep(int width, int height)
    {
        if (width > height) return (int)Math.Round((double)width / height);
        else return (int)Math.Round((double)height / width);
    }

    public static bool IsMazeOrientedHorizontally(int width, int height)
    {
        if (width > height) return true;
        else return false;
    }

    public static void MoveOneStep(Robot robot, int step, bool isMazeHorizontalOriented)
    {
        for (int i = 0; i < step; i++)
        {
            if (isMazeHorizontalOriented) robot.MoveTo(Direction.Right);
            else robot.MoveTo(Direction.Down);
        }
    }

    public static void MoveToDownLevel(Robot robot, int width, int height)
    {
        if (width > height) robot.MoveTo(Direction.Down);
        else robot.MoveTo(Direction.Right);
    }
}
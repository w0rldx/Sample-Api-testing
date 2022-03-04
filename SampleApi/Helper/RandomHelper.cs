using System;

namespace WebApplication1.Helper;

public static class RandomHelper
{
    private static Random _random = new Random();
    public static int GetRandomNumber()
    {
        return _random.Next(0, int.MaxValue);
    }
}
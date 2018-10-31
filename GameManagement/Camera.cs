using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public static class Camera 
{
    public static Rectangle position = new Rectangle(0, 0, GameEnvironment.Screen.X, GameEnvironment.Screen.Y);
    public static int levelIndex;
    public static GameObject target;

    public static void Reset()
    {
        position.X = 0;
        position.Y = 0;
    }

    public static void Update()
    {
        if(target!=null && target.Position.X > position.Width / 3)
            position.X = (int)target.Position.X - (position.Width / 3);
    }
}
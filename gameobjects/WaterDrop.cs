using System;
using Microsoft.Xna.Framework;

abstract class WaterDrop : SpriteGameObject
{
    protected float bounce;

    abstract public void MoveDrop();

    public WaterDrop(int layer=0, string id="") : base("Sprites/spr_water", layer, id) 
    {

    }

    public override void Update(GameTime gameTime)
    {
        MoveDrop();

        double t = gameTime.TotalGameTime.TotalSeconds * 3.0f + Position.X;
        bounce = (float)Math.Sin(t) * 0.2f;
        position.Y += bounce;
        Player player = GameWorld.Find("player") as Player;
        if (visible && CollidesWith(player))
        {
            visible = false;
            GameEnvironment.AssetManager.PlaySound("Sounds/snd_watercollected");
        }
    }

}

class WobblyDrop : WaterDrop
{
    int frameCount;
    public override void MoveDrop()
    {
        frameCount++;
        if(frameCount < 10 )
        {
            position.X += 2; 
        }
        else
        {
            position.X -= 2;
        }

        if(frameCount == 18)
        {
            frameCount = 0;
        }
    }
}

class RisingDrop : WaterDrop
{
    public override void MoveDrop()
    {

    }
}


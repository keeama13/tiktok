using Microsoft.Xna.Framework;

partial class Level : GameObjectList
{

    public override void HandleInput(InputHelper inputHelper)
    {
        base.HandleInput(inputHelper);
        if (quitButton.Pressed)
        {
            Reset();
            GameEnvironment.GameStateManager.SwitchTo("levelMenu");
        }      
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        TimerGameObject timer = Find("timer") as TimerGameObject;
        Player player = Find("player") as Player;
        SpriteGameObject backgroundSky = Find("backgroundSky") as SpriteGameObject;
        
        Camera.target = player;

        // check if we died
        if (!player.IsAlive)
        {
            timer.Running = false;
        }
        else
        {    
            Camera.Update();
            if (backgroundSky != null)
                backgroundSky.Position = new Vector2(Camera.position.X, 0);
        }


        // check if we ran out of time
        if (timer.GameOver)
        {
            player.Explode();
        }

        
                       
        // check if we won
        if (Completed && timer.Running)
        {
            player.LevelFinished();
            timer.Running = false;
        }
    }

    public override void Reset()
    {
        base.Reset();
        VisibilityTimer hintTimer = Find("hintTimer") as VisibilityTimer;
        hintTimer.StartVisible();
    }
}

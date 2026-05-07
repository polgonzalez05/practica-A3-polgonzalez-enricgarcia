using SFML.Window;
using SFML.Graphics;
using SFML.System;
using System.Collections.Generic;
using System;

namespace TcGame
{
  public class Player : StaticActor
  {
    public Player()
    {
      Layer = ELayer.Middle;
      Sprite = new Sprite(new Texture("Data/Textures/rui1.png"));
      Center();
      Position = new Vector2f(780.0f, 350.0f);
    }

    public override void Update(float dt)
    {
      base.Update(dt);

      
    }
    
  }
}

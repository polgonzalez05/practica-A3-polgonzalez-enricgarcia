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
      Sprite = newRandomSprite();
      Center();
      Position = new Vector2f(780.0f, 350.0f);
    } 
    
  public override void Update(float dt)
    {
      Follow();
      base.Update(dt);
    }
    private void Follow()
    {
      Speed = 0;
      Forward = (Engine.Get.MousePos - Position).Normal();
      Rotation = (float) Math.Atan2(Forward.Y, Forward.X) * MathUtil.RAD2DEG + 90;
    }

    private Sprite newRandomSprite()
    {
      Random rand = new Random();
      int random = rand.Next(0, 2);
      switch (random)
      {
        case 0:
          return Sprite = new Sprite(new Texture("Data/Textures/rui1.png"));
        case 1:
          return Sprite = new Sprite(new Texture("Data/Textures/rui2.png"));
        case 2:
          return Sprite = new Sprite(new Texture("Data/Textures/rui3.png"));
        default:
          throw new Exception("Valor inesperado");
      }
    }
  }
}

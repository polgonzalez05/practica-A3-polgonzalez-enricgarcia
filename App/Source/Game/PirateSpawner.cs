using SFML.Window;
using SFML.System;
using System;
using SFML.Graphics;

namespace TcGame
{
  public class PirateSpawner : StaticActor
  {
  public float MinTime = 2.0f;
  public float MaxTime = 10.0f;
  public Vector2f MinPosition;
  public Vector2f MaxPosition;
  private float coolDown;

  public void Reset()
  {
    Random r = new Random();
    float d = (float)r.NextDouble();
    coolDown = MaxTime * d + (1.0f - d) * MinTime;
  }

  public override void Update(float dt)
  {
    base.Update(dt);
    coolDown -= dt;
    if (coolDown < 0.0f)
    {
      SpawnPirate();
      Reset();
    }
  }

  public void SpawnPirate()
  {
    Pirate pirate = Engine.Get.Scene.Create<Pirate>();
    MaxPosition = new Vector2f(1583, 818);
    MinPosition = new Vector2f(0, 0);
    Random posX = new Random();
    Random posY = new Random();
    pirate.Position = new Vector2f(posX.Next((int)MinPosition.X, (int)MaxPosition.X), 
      posY.Next((int)MinPosition.Y, (int)MaxPosition.Y));

    if ((pirate.Position.X >= 640 && pirate.Position.X < 940) && (pirate.Position.Y >= 255 && pirate.Position.Y < 555))
    {
      Reset();
    }
  }
  }
}


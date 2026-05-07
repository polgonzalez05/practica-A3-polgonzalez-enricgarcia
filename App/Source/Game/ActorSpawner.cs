using SFML.Window;
using SFML.System;
using System;
using SFML.Graphics;

namespace TcGame
{
  public class ActorSpawner<T> : Actor where T : Actor, new()
  {
    public float MinTime = 2.0f;
    public float MaxTime = 3.0f;
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
        SpawnActor();
        Reset();
      }
    }
    public void SpawnActor()
    {

    }
  }
}


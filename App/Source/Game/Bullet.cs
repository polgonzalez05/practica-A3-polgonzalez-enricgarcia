using SFML.Graphics;
using SFML.Window;
using SFML.System;
using System.Collections.Generic;
using System;

namespace TcGame
{
  public class Bullet : StaticActor
  {
    public bool DamagePlayer = false;
    public float LifeTime = 100.0f;
    public Vector2f Forward = new Vector2f(0.0f, -1.0f);
    public float Speed = 300.0f;
    public float Damage = 10.0f;

    public Bullet()
    {
      Sprite = new Sprite(new Texture("Data/Textures/cannonBall.png"));
    }

    public void SetTexture(Texture texture)
    {
      Sprite = new Sprite(texture);
      Center();
    }

    public override void Update(float dt)
    {
      Position += Forward * Speed * dt;
      LifeTime -= dt;

      if (LifeTime < 0.0f)
      {
        Destroy();
      }

      if (DamagePlayer)
      {
        var players = Engine.Get.Scene.GetAll<Player>();

        foreach (Player player in players)
        {
          if (player.GetGlobalBounds().Intersects(GetGlobalBounds()))
          {
            player.TakeDamage((int)Damage);
            Console.WriteLine("Player hit. Vida: " + player.HitPoints);
            Destroy();
            break;
          }
        }
      }
      else
      {
        var enemies = Engine.Get.Scene.GetAll<Enemy>();

        foreach (Enemy enemy in enemies)
        {
          if (enemy.GetGlobalBounds().Intersects(GetGlobalBounds()))
          {
            enemy.TakeDamage((int)Damage);
            Destroy();
            break;
          }
        }
      }
    }
  }
}


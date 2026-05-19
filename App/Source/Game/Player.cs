using SFML.Window;
using SFML.Graphics;
using SFML.System;
using System;

namespace TcGame
{
  public class Player : StaticActor
  {
    private float coolDown = 0.5f;
    private float currentCoolDown = 0.0f;

    public int HitPoints = 100;

    public Player()
    {
      Layer = ELayer.Middle;
      Sprite = newRandomSprite();
      Center();
      Position = new Vector2f(780.0f, 350.0f);
      
      ChangeCoolDown(0.2f);

    }

    public override void Update(float dt)
    {
      Follow();

      currentCoolDown -= dt;
      if (Mouse.IsButtonPressed(Mouse.Button.Left) && currentCoolDown <= 0.0f)
      {
        Shoot();
        currentCoolDown = coolDown;
      }

      base.Update(dt);
    }

    private void Follow()
    {
      Speed = 0;
      Forward = (Engine.Get.MousePos - Position).Normal();
      Rotation = (float)Math.Atan2(Forward.Y, Forward.X) * MathUtil.RAD2DEG;
    }


    public void ChangeCoolDown(float newCoolDown)
    {
      coolDown = newCoolDown;
    }

    public void Shoot()
    {
      Bullet bullet = Engine.Get.Scene.Create<Bullet>();

      bullet.Position = Position + Forward * 40.0f;
      bullet.Forward = Forward;
      bullet.DamagePlayer = false;
      bullet.Layer = ELayer.Middle;
      bullet.Center();
    }
    public void TakeDamage(int damage)
    {
      HitPoints -= damage;

      if (HitPoints <= 0)
      {
        Destroy();
      }
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

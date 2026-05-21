namespace TcGame
{
  public abstract class Enemy : StaticActor
  {
    public Enemy()
    {
      OnDestroy += Explode;
    }
    public virtual void TakeDamage(int damage)
    {
    }

    private void Explode(Actor actor)
    {
      Explosion e = Engine.Get.Scene.Create<Explosion>();
      e.Position = Position;
    }
  }
}


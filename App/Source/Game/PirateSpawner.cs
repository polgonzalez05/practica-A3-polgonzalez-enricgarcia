using SFML.System;
using System;

namespace TcGame
{
    public class PirateSpawner : StaticActor
    {
        public float MinTime = 2.0f;
        public float MaxTime = 10.0f;

        public Vector2f MinPosition = new Vector2f(0, 0);
        public Vector2f MaxPosition = new Vector2f(1583, 818);
        private readonly Vector2f islandCenter = new Vector2f(790, 405);
        private const float islandRadius = 300f;
        
        private float coolDown;
        private Random random = new Random();

        public PirateSpawner()
        {
            Reset();
        }

        public void Reset()
        {
            float d = (float)random.NextDouble();
            coolDown = MaxTime * d + (1.0f - d) * MinTime;
        }

        public override void Update(float dt)
        {
            base.Update(dt);

            coolDown -= dt;

            if (coolDown <= 0.0f)
            {
                SpawnPirate();
                Reset();
            }
        }

        public void SpawnPirate()
        {
            Pirate pirate = Engine.Get.Scene.Create<Pirate>();

            Vector2f pos;

            do
            {
                pos = new Vector2f(
                    random.Next((int)MinPosition.X, (int)MaxPosition.X),
                    random.Next((int)MinPosition.Y, (int)MaxPosition.Y)
                );
            }
            while (IsInsideIsland(pos));

            pirate.Position = pos;
        }

        private bool IsInsideIsland(Vector2f pos)
        {
            float x = pos.X - islandCenter.X;
            float y = pos.Y - islandCenter.Y;

            return MathF.Sqrt(x * x + y * y) < islandRadius;
        }
    }
}
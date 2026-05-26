using SFML.Window;
using SFML.Graphics;
using SFML.System;
using System;

namespace TcGame
{
    public enum States
    {
        Idle,
        Pursue,
        Withdrawal
    }

    public class Pirate : Enemy
    {
        private States state;
        private float RotSpeed = 2f;
        private float Speed = 5f;
        private float Cooldown = 2.0f;
        private float HitPoints = 15f;
        private float Damage = 1f;
        private bool isPersian;

        public Pirate()
        {
            Sprite = newRandomSprite();
            Center();
        }

        private void Idle()
        {
            Random tiempo = new Random();
            float random = (float)(tiempo.NextDouble() * 1.5 + 0.5);

            Rotation += 300 * random;
        }

        private void Pursue()
        {
            Speed *= 2;
            RotSpeed = 1f;
            Cooldown = 1.0f;
            Damage = 0.8f;
        }

        private void Withdrawal()
        {
            Random tiempo = new Random();
            float random = (float)(tiempo.NextDouble() * 2.0 + 1);
        }

        public override void TakeDamage(int damage)
        {
            HitPoints -= damage;

            if (isPersian)
            {
                state = States.Withdrawal;
            }

            if (HitPoints <= 0)
            {
                Destroy();
            }
        }

        public override FloatRect GetLocalBounds()
        {
            return new FloatRect(
                0,
                0,
                Sprite.Texture.Size.X,
                Sprite.Texture.Size.Y
            );
        }

        private Sprite newRandomSprite()
        {
            Random rand = new Random();
            int random = rand.Next(0, 2);

            switch (random)
            {
                case 0:
                    isPersian = false;
                    return new Sprite(new Texture("Data/Textures/pirata1.png"));

                case 1:
                    isPersian = true;
                    return new Sprite(new Texture("Data/Textures/pirata4.png"));

                default:
                    throw new Exception("Valor inesperado");
            }
        }
    }
}
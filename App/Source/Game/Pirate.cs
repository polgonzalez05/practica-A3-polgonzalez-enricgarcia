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
        private float RotSpeed = 2f; // Velocitat de rotació angular.
        private float Speed = 5f; //  Velocitat de moviment.
        private float Cooldown = 2.0f; // Temps de descans entre dispar i dispar.
        private float HitPoints = 15f; // Punts de vida abans de ser destruïts.
        private float Damage = 1f; // Quantitat de dany que fan les seves bales en impactar
        private bool isPersian;

        public Pirate()
        {
            Sprite = newRandomSprite();
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
        private void Explode(Actor actor)
        {
            Explosion e = Engine.Get.Scene.Create<Explosion>();
            e.Position = Position;
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
            return new FloatRect(Position.X, Position.Y, 14, 460);
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
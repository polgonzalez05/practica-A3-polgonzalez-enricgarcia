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

        private float RotSpeed;
        private float Speed;
        private float Cooldown;
        private float HitPoints;
        private float Damage;

        private bool isPersian;

        private float stateTimer;
        private float shootTimer;
        
        private const float spriteRotationOffset = 90f;
        
        private static Random rand = new Random();

        private readonly Vector2f islandCenter = new Vector2f(790, 405);
        private const float islandRadius = 300f;
        
        private float spawnSpinTimer = 1f;
        private bool finishedSpawnSpin = false;

        private float turnTimer = 0f;
        private float turnInterval = 3f;
        
        private const float minX = 0f;
        private const float maxX = 1583f;
        private const float minY = 0f;
        private const float maxY = 818f;
        
        private int burstBulletsLeft = 0;
        private float burstShotTimer = 0f;
        
        private float burstShotDelay = 0.35f;
        private int bulletsPerBurst = 5;

        
        public Pirate()
        {
            Sprite = NewRandomSprite();
            Center();

            state = States.Idle;
            stateTimer = 0f;
            shootTimer = 0f;

            ApplyStats();
            Rotation = rand.Next(0, 360);
        }

        public override void Update(float dt)
        {
            base.Update(dt);

            if (!finishedSpawnSpin)
            {
                spawnSpinTimer -= dt;
                Rotation += 360f * dt;

                if (spawnSpinTimer <= 0f)
                {
                    finishedSpawnSpin = true;
                }

                return;
            }
            if (isPersian)
                PersianBehaviour(dt);
            else
                EnglishBehaviour(dt);

            MoveForward(dt);
            TryShoot(dt);
        }

        private void EnglishBehaviour(float dt)
        {
            switch (state)
            {
                case States.Idle:
                    Speed = 60f;
                    RotSpeed = 30f;
                    Cooldown = 2.5f;

                    MoveForward(dt);

                    if (stateTimer >= 5f)
                    {
                        ChangeState(States.Pursue);
                    }

                    break;

                case States.Pursue:
                    Speed = 110f;
                    RotSpeed = 60f;
                    Cooldown = 2.0f;

                    MoveForward(dt);
                    TryShoot(dt);
                    
                    if (Distance(Position, islandCenter) < islandRadius)
                    {
                        Rotation += 180f;
                        ChangeState(States.Withdrawal);
                    }

                    break;

                case States.Withdrawal:
                    Speed = 140f;
                    RotSpeed = 80f;
                    Cooldown = 0.8f;

                    MoveForward(dt);
                    TryShoot(dt);
                    
                    if (stateTimer >= 10f)
                    {
                        ChangeState(States.Idle);
                    }

                    break;
            }
        }

        private void PersianBehaviour(float dt)
        {
            Speed = 45f;
            RotSpeed = 20f;
            Cooldown = 3.0f;
            Damage = 0.5f;

            MoveForward(dt);

            if (Distance(Position, islandCenter) < islandRadius)
            {
                Rotation += 180f;
            }

            TryShoot(dt);
            
        }

        private void MoveForward(float dt)
        {
            turnTimer -= dt;

            if (turnTimer <= 0f)
            {
                turnTimer = turnInterval;
                Rotation += rand.Next(-30, 30);
                
            }

            Vector2f dir = GetDirection();
            Vector2f nextPosition = Position + dir * Speed * dt;

            if (Distance(nextPosition, islandCenter) < islandRadius ||
                nextPosition.X < minX || nextPosition.X > maxX ||
                nextPosition.Y < minY || nextPosition.Y > maxY)
            {
                Rotation += rand.Next(120, 240);

                Vector2f dir2 = GetDirection();
                Position += dir2 * Speed * dt;

                return;
            }

            Position = nextPosition;
        }

        private Vector2f GetDirection()
        {
            float radians = (Rotation + 90f) * MathF.PI / 180f;

            return new Vector2f(
                MathF.Cos(radians),
                MathF.Sin(radians)
            );
        }

        private void TryShoot(float dt)
        {
            shootTimer -= dt;

            if (burstBulletsLeft > 0)
            {
                burstShotTimer -= dt;

                if (burstShotTimer <= 0f)
                {
                    ShootForwardBullet();

                    burstBulletsLeft--;
                    burstShotTimer = burstShotDelay;
                }

                return;
            }

            if (shootTimer <= 0f)
            {
                burstBulletsLeft = bulletsPerBurst;
                burstShotTimer = 0f;
                shootTimer = Cooldown;
            }
        }
        private void ShootForwardBullet()
        {
            Vector2f forward = GetDirection();

            Bullet bullet = Engine.Get.Scene.Create<Bullet>();

            bullet.Position = Position + forward * 45f;
            bullet.Forward = forward;
            bullet.Rotation = Rotation;
            bullet.Damage = Damage;
            bullet.DamagePlayer = true;
            bullet.Center();
        }
        
        private void ChangeState(States newState)
        {
            state = newState;
            stateTimer = 0f;
            Rotation += rand.Next(-90, 90);
        }

        private float Distance(Vector2f a, Vector2f b)
        {
            float x = a.X - b.X;
            float y = a.Y - b.Y;

            return MathF.Sqrt(x * x + y * y);
        }

        private void ApplyStats()
        {
            if (isPersian)
            {
                Speed = 45f;
                RotSpeed = 20f;
                Cooldown = 3.0f;
                HitPoints = 10f;
                Damage = 0.5f;
            }
            else
            {
                Speed = 60f;
                RotSpeed = 30f;
                Cooldown = 2.5f;
                HitPoints = 15f;
                Damage = 1f;
            }
        }

        public override void TakeDamage(int damage)
        {
            HitPoints -= damage;

            if (HitPoints <= 0)
            {
                MyGame.Get.AddEnemyDefeated();
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

        private Sprite NewRandomSprite()
        {
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
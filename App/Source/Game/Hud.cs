using SFML.Graphics;
using SFML.System;

namespace TcGame
{
    public class Hud : StaticActor
    {
        private Text text;
        private Font font;

        public Hud()
        {
            font = new Font("Data/Fonts/georgia.ttf");

            text = new Text("", font, 24);
            text.Position = new Vector2f(20, 20);
            text.FillColor = Color.White;
        }

        public override void Update(float dt)
        {
            base.Update(dt);

            Player player = Engine.Get.Scene.GetAll<Player>()[0];

            text.DisplayedString =
                "Vida Rui: " + player.GetHitPoints() +
                "\nEnemigos vencidos: " + MyGame.Get.EnemiesDefeated;
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(text);
        }
    }
}
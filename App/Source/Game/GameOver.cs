using SFML.Graphics;

namespace TcGame;

public class GameOver : StaticActor
{
    public GameOver()
    {
        Layer = ELayer.Front;
        Sprite = new Sprite(new Texture("Data/Textures/gameover.png"));
    }
}
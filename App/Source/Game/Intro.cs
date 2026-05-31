using SFML.Graphics;

namespace TcGame;

public class Intro : StaticActor
{
    public Intro()
    {
        Layer = ELayer.Front;
        Sprite = new Sprite(new Texture("Data/Textures/start.png"));
    }
}
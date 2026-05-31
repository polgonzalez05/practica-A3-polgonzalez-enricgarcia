using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace TcGame
{
  enum GameState
  {
    Intro,
    Playing,
    GameOver
  }
  public class MyGame : Game
  {
    public Hud hud { private set; get; }
    public Background background { get;  private set;}
    private static MyGame Instance;
    private Intro intro;
    private GameOver gameover;
    private Player player;
    private GameState state;
    public static MyGame Get
    {
      get
      {
        if (Instance == null)
        {
          Instance = new MyGame();
        }

        return Instance;
      }
    }
    private MyGame()
    {
    }
    public int EnemiesDefeated { get; private set; }

    public void AddEnemyDefeated()
    {
      EnemiesDefeated++;
    }
    public void Init()
    {
      CanviEstat(GameState.Intro);
    }
       
    public void DeInit()
    {
    }
    public void Update(float dt)
    {
      switch (state)
      {
        case GameState.Intro:
          if (Keyboard.IsKeyPressed(Keyboard.Key.Space))
          {
            CanviEstat(GameState.Playing);
          }
          break;
        case GameState.Playing:
          if (player == null || player.HitPoints <= 0)
          {
            CanviEstat(GameState.GameOver);
          }
          break;
        case GameState.GameOver:
          if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
          {
            Engine.Get.Window.Close();
          }
          break;
      }
    }
    private void DestroyAll<T>() where T : Actor
    {
      var actors = Engine.Get.Scene.GetAll<T>();
      actors.ForEach(x => x.Destroy());
    }

    private void CanviEstat(GameState nouEstat)
    {
      DestroyAll<Actor>();
      state = nouEstat;
      switch (state)
      {
        case GameState.Intro:
          intro = Engine.Get.Scene.Create<Intro>();
          break;
        case GameState.Playing:
          EnemiesDefeated = 0;
          background = Engine.Get.Scene.Create<Background>();
          player = Engine.Get.Scene.Create<Player>();
          Engine.Get.Scene.Create<PirateSpawner>();
          hud = Engine.Get.Scene.Create<Hud>();
          break;
        case GameState.GameOver:
          gameover = Engine.Get.Scene.Create<GameOver>();
          break;
      }
    }
  }
}
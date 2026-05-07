using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace TcGame
{
  public class TileMap : StaticActor
  {
    private Texture tileSet;
    private int[] tiles;
    private int tileW, tileH;
    private int mapW, mapH;
    public VertexArray vertices = new VertexArray(PrimitiveType.Quads, 4);

    public TileMap(){
    }
    public TileMap(string filename, int width, int height, int[] _tiles, int mW, int mH)
    { tileSet = new Texture(filename);
      tileW = width;
      tileH = height;
      tiles = _tiles;
      mapW = mW;
      mapH = mH;
      vertices.Resize(Convert.ToUInt32(mapW * mapH * 4));
      vertices.Clear();

      for (int j = 0; j < mapH; j++)
      {
        for (int i = 0; i < mapW; i++)
        {
          int tileNumber = tiles[i + j * mapW];
          int tu = Convert.ToInt32(tileNumber % (tileSet.Size.X / tileW));
          int tv = Convert.ToInt32(Math.Floor((double)tileNumber / (tileSet.Size.X / tileW)));
          uint index = Convert.ToUInt32((i + j * tileW) * 4);
          Vertex[] quad = new Vertex[4];

          quad[0].Position = new Vector2f(i * tileW, j * tileH);
          quad[1].Position = new Vector2f((i + 1) * tileW, j * tileH);
          quad[2].Position = new Vector2f((i + 1) * tileW, (j + 1) * tileH);
          quad[3].Position = new Vector2f(i * tileW, (j + 1) * tileH);
          quad[0].Color = Color.White;
          quad[1].Color = Color.White;
          quad[2].Color = Color.White;
          quad[3].Color = Color.White;

          quad[0].TexCoords = new Vector2f(tu * tileW, tv * tileH);
          quad[1].TexCoords = new Vector2f((tu + 1) * tileW, tv * tileH);
          quad[2].TexCoords = new Vector2f((tu + 1) * tileW, (tv + 1) * tileH);
          quad[3].TexCoords = new Vector2f(tu * tileW, (tv + 1) * tileH);

          vertices.Append(quad[0]);
          vertices.Append(quad[1]);
          vertices.Append(quad[2]);
          vertices.Append(quad[3]);
        }
      }
    }

    public void Init(string filename, int width, int height, int[]_tiles, int mW, int mH)
    {
      tileSet = new Texture(filename);
      tileW = width;
      tileH = height;
      tiles = _tiles;
      mapW = mW;
      mapH = mH;
      vertices.Resize (Convert.ToUInt32(mapW * mapH * 4));
      vertices.Clear();

      for (int j = 0; j < mapH; j++)
      {
        for (int i = 0; i < mapW; i++)
        {
          int tileNumber = tiles[i + j * mapW];                    
          int tu = Convert.ToInt32( tileNumber % (tileSet.Size.X / tileW));
          int tv = Convert.ToInt32( Math.Floor((double)tileNumber / (tileSet.Size.X / tileW)));
          uint index = Convert.ToUInt32((i + j * tileW) * 4);
          Vertex[] quad = new Vertex[4];

          quad[0].Position = new Vector2f(i * tileW, j * tileH);
          quad[1].Position = new Vector2f((i+1) * tileW, j * tileH);
          quad[2].Position = new Vector2f((i+1) * tileW, (j+1) * tileH);
          quad[3].Position = new Vector2f(i * tileW, (j+1) * tileH);
          quad[0].Color = Color.White;
          quad[1].Color = Color.White;
          quad[2].Color = Color.White;
          quad[3].Color = Color.White;

          quad[0].TexCoords = new Vector2f(tu * tileW, tv * tileH);
          quad[1].TexCoords = new Vector2f((tu+1) * tileW, tv * tileH);
          quad[2].TexCoords = new Vector2f((tu+1) * tileW, (tv+1) * tileH);
          quad[3].TexCoords = new Vector2f(tu * tileW, (tv+1) * tileH);

          vertices.Append(quad[0]);
          vertices.Append(quad[1]);
          vertices.Append(quad[2]);
          vertices.Append(quad[3]);
        }
      }         
    }

    public override void Draw(RenderTarget rt, RenderStates rs){
      rs.Transform = Transform;
      rs.Texture = tileSet;
      rt.Draw(vertices, rs);
    } 
  }
}


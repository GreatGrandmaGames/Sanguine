using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Grandma.Tiles;

namespace Sanguine
{
    public class TemperateMapGenerator : TileMapGenerator
    {
        [SerializeField] protected SanguineTileData grassTile;
        [SerializeField] protected Tree treePrefab;

        public float perlinSeedStep = 0.3f;
        public float seaLevel = 0.25f;

        protected override Tile[,] CreateMapData()
        {
            float horzPerlinSeed = Random.Range(0, 100000f);
            float vertPerlinSeed = Random.Range(0, 100000f);

            Tile[,] map = new Tile[Width, Height];

            for(int i = 0; i < Width; i++)
            {
                for(int j = 0; j < Height; j++)
                {
                    float perlin = Mathf.PerlinNoise(i * perlinSeedStep + horzPerlinSeed, j * perlinSeedStep + vertPerlinSeed);

                    TileData data = null;

                    if(perlin > seaLevel)
                    {
                        data = Instantiate(grassTile);
                    }
                    else
                    {
                        data = Instantiate(waterTile);
                    }

                    data.position = new Vector3Int(i, j, 0);

                    map[i, j] = CreateTile(data);

                    //temp
                    //map[i, j].zPos = -perlin;
                }
            }

            return map;
        }

        protected override void PlaceTerrain()
        {
            Grandma.IterationUtility.ForEach2D(Width, Height, (i, j) =>
            {
                var t = Map[i, j] as SanguineTile;

                if(t.TileID == 1 && i % 3 == 0 && j % 3 == 0)
                {
                    var tree = Instantiate(treePrefab);

                    tree.Place(t);
                }
            });
        }
    }
}
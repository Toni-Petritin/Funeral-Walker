using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapItself : MonoBehaviour
{
    public BiomePreset[] biomes;
    public GameObject tilePrefab;

    [Header("Dimensions")]
    public int width = 50;
    public int height = 50;
    public float scale = 1.0f;
    public Vector2 offset;

    [Header("Height Map")]
    public Wave[] heightWaves;
    public float[,] heightMap;

    [Header("Moisture Map")]
    public Wave[] moistureWaves;
    public float[,] moistureMap;

    [Header("Heat Map")]
    public Wave[] heatWaves;
    public float[,] heatMap;

    void Start()
    {
        GenerateMap();
    }

    void GenerateMap()
    {
        //Height map.
        heightMap = NoiseGenerator.Generate(width, height, scale, heightWaves, offset);

        //Moisture map.
        moistureMap = NoiseGenerator.Generate(width, height, scale, moistureWaves, offset);

        //Heat map.
        heatMap = NoiseGenerator.Generate(width, height, scale, heatWaves, offset);

        for(int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                GameObject tile = Instantiate(tilePrefab, new Vector3(x, y, 0), Quaternion.identity);
                tile.GetComponent<SpriteRenderer>().sprite = GetBiome(heightMap[x, y], moistureMap[x, y], heatMap[x, y]).GetTileSprite();
            }

        }

    }

    //We use this to get a biome that meets the conditions of the noise functions the best.
    BiomePreset GetBiome(float height, float moisture, float heat)
    {
        List<BiomeTempData> biomeTemp = new List<BiomeTempData>();

        //This adds biomes to the list if they meet the minimum conditions of the biome.
        foreach(BiomePreset biome in biomes)
        {
            if(biome.MatchCondition(height, moisture, heat))
            {
                biomeTemp.Add(new BiomeTempData(biome));
            }
        }

        float curVal = 0.0f;
        BiomePreset biomeToReturn = null;
        
        foreach(BiomeTempData biome in biomeTemp)
        {
            if(biomeToReturn == null)
            {
                biomeToReturn = biome.biome;
                curVal = biome.GetDiffValue(height, moisture, heat);
            }
            else
            {
                if(biome.GetDiffValue(height, moisture, heat) < curVal)
                {
                    biomeToReturn = biome.biome;
                    curVal = biome.GetDiffValue(height, moisture, heat);
                }
            }
        }

        if(biomeToReturn == null)
        {
            biomeToReturn = biomes[0];
        }
        return biomeToReturn;
    }

    public class BiomeTempData
    {
        public BiomePreset biome;

        public BiomeTempData(BiomePreset preset)
        {
            biome = preset;
        }

        //What we are returning is the value of each condition combined minus the needed value.
        //This gives the most suited value for the biome. This was used in the example code I used so I went with it,
        //but I'd likely have the height supersede the other values in a more complete game.
        public float GetDiffValue(float height, float moisture, float heat)
        {
            return (height - biome.minHeight) + (moisture - biome.minMoisture) + (heat - biome.minHeat);
        }

    }

}

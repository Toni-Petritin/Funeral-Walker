using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//The whole point of this is to allow easy creation of new biomes.
[CreateAssetMenu(fileName = "Biome Preset", menuName = "New Biome Preset")]
public class BiomePreset : ScriptableObject
{
    public Sprite[] tiles;
    public float minHeight;
    public float minMoisture;
    public float minHeat;
    public int lifeMinus;
    //I don't actually use this bool value, but I added it for possible future use.
    public bool passable = true;

    //This allows several different variations of the same biome sprite to appear randomly.
    public Sprite GetTileSprite()
    {
        return tiles[Random.Range(0, tiles.Length)];
    }

    //This is used to check, if the noise function meets the requirements of the biome.
    public bool MatchCondition(float height, float moisture, float heat)
    {
        return height >= minHeight && moisture >= minMoisture && heat >= minHeat;
    }

    public int LifeReturn()
    {
        return lifeMinus;
    }

}

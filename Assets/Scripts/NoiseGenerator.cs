using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseGenerator : MonoBehaviour
{
    
    public static float[,] Generate (int width, int height, float scale, Wave[] waves, Vector2 offset)
    {
        //Array for noise mapping.
        float[,] noiseMap = new float[width, height];

        //Loop through the array.
        for(int x=0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                float posX = (float)x * scale + offset.x;
                float posY = (float)y * scale + offset.y;

                float normalization = 0.0f;

                //Loop through each wave.
                foreach(Wave wave in waves)
                {
                    //Perlin noise samples with frequency and amplitude.
                    noiseMap[x, y] += wave.amplitude * Mathf.PerlinNoise(posX * wave.frequency + wave.seed, posY * wave.frequency + wave.seed);
                    normalization += wave.amplitude;
                }

                //We push the values back below 1 or "normalize" the values.
                noiseMap[x, y] /= normalization;
            }
        }

        return noiseMap;
    }



}

[System.Serializable]
public class Wave
{
    public float seed;
    public float frequency;
    public float amplitude;
}
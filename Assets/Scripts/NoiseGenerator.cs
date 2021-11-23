using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseGenerator : MonoBehaviour
{
    
    //I don't need the offset for anything, but it doesn't really hurt to have it, so I left it in.
    public static float[,] Generate (int width, int height, Wave[] waves, Vector2 offset)
    {
        //Array and seed for noise mapping.
        //Each wave uses the same seed with different frequences, but it's good enough for our purposes.
        float[,] noiseMap = new float[width, height];
        float seed = Random.Range(0.0f, 1000.0f);

        //Loop through the array.
        for(int x=0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                float posX = (float)x + offset.x;
                float posY = (float)y + offset.y;

                float normalization = 0.0f;

                //Loop through each wave.
                foreach(Wave wave in waves)
                {
                    //Perlin noise samples with frequency and amplitude.
                    noiseMap[x, y] += wave.amplitude * Mathf.PerlinNoise(posX * wave.frequency + seed, posY * wave.frequency + seed);
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
    //These are here to make manipulation of the noise function easier.
    //The seed was originally also determined through here.
    //After I checked it worked, I commented that out.
    //public float seed;
    public float frequency;
    public float amplitude;
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float distance = 1.0f;
    private float xlimit;
    private float ylimit;
    public int life = 200;
    private int posX;
    private int posY;

    //We get the map size here so we don't need to change the movement bounds, if we change it.
    void Start()
    {
        xlimit = GameObject.Find("_Map").GetComponent<MapItself>().width - 1;
        ylimit = GameObject.Find("_Map").GetComponent<MapItself>().height - 1;
    }

    //These are player movements.
    //Each movement will remove life from the player based on the biome they step on, which is called from the "_Map".
    //Why do I round the coordinates?
    //Because I'm not sure how c# handles floats so I make sure we find the closest integer.
    void Update()
    {
        if(life > 0)
        {
            if (Input.GetKeyDown("w") && transform.position.y < ylimit)
            {
                transform.position += new Vector3(0, distance, 0);
                posX = (int)Mathf.Round(transform.position.x);
                posY = (int)Mathf.Round(transform.position.y);
                life -= GameObject.Find("_Map").GetComponent<MapItself>().lifeMap[posX, posY];
            }
            if (Input.GetKeyDown("s") && transform.position.y > 0)
            {
                transform.position += new Vector3(0, -distance, 0);
                posX = (int)Mathf.Round(transform.position.x);
                posY = (int)Mathf.Round(transform.position.y);
                life -= GameObject.Find("_Map").GetComponent<MapItself>().lifeMap[posX, posY];
            }
            if (Input.GetKeyDown("a") && transform.position.x > 0)
            {
                transform.position += new Vector3(-distance, 0, 0);
                posX = (int)Mathf.Round(transform.position.x);
                posY = (int)Mathf.Round(transform.position.y);
                life -= GameObject.Find("_Map").GetComponent<MapItself>().lifeMap[posX, posY];
            }
            if (Input.GetKeyDown("d") && transform.position.x < xlimit)
            {
                transform.position += new Vector3(distance, 0, 0);
                posX = (int)Mathf.Round(transform.position.x);
                posY = (int)Mathf.Round(transform.position.y);
                life -= GameObject.Find("_Map").GetComponent<MapItself>().lifeMap[posX, posY];
            }
        }
        
    }
}

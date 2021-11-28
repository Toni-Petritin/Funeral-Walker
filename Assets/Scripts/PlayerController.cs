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
    public Sprite tombStone;
    private AudioSource playerAudio;
    public AudioClip walkSound;
    public AudioClip deathSound;

    //We get the map size here so we don't need to change the movement bounds, if we change it.
    //Also get the audiosource from main camera.
    void Start()
    {
        xlimit = GameObject.Find("_Map").GetComponent<MapItself>().width - 1;
        ylimit = GameObject.Find("_Map").GetComponent<MapItself>().height - 1;
        playerAudio = GameObject.Find("Main Camera").GetComponent<AudioSource>();
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
                playerAudio.PlayOneShot(walkSound, 1.0f);
            }
            if (Input.GetKeyDown("s") && transform.position.y > 0)
            {
                transform.position += new Vector3(0, -distance, 0);
                posX = (int)Mathf.Round(transform.position.x);
                posY = (int)Mathf.Round(transform.position.y);
                life -= GameObject.Find("_Map").GetComponent<MapItself>().lifeMap[posX, posY];
                playerAudio.PlayOneShot(walkSound, 1.0f);
            }
            if (Input.GetKeyDown("a") && transform.position.x > 0)
            {
                transform.position += new Vector3(-distance, 0, 0);
                posX = (int)Mathf.Round(transform.position.x);
                posY = (int)Mathf.Round(transform.position.y);
                life -= GameObject.Find("_Map").GetComponent<MapItself>().lifeMap[posX, posY];
                playerAudio.PlayOneShot(walkSound, 1.0f);
            }
            if (Input.GetKeyDown("d") && transform.position.x < xlimit)
            {
                transform.position += new Vector3(distance, 0, 0);
                posX = (int)Mathf.Round(transform.position.x);
                posY = (int)Mathf.Round(transform.position.y);
                life -= GameObject.Find("_Map").GetComponent<MapItself>().lifeMap[posX, posY];
                playerAudio.PlayOneShot(walkSound, 1.0f);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                life = 0;
            }
            //This changes the players sprite into a tombstone and plays the death sound.
            //And because it's here, it's only called once... Should be.
            if (life <= 0)
            {
                GetComponent<SpriteRenderer>().sprite = tombStone;
                playerAudio.PlayOneShot(deathSound, 1.0f);
            }

        }
        
    }

    void WalkSound()
    {

    }

}

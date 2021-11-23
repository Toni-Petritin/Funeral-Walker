using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float distance = 1.0f;
    private float xlimit;
    private float ylimit;
    public int life = 200;

    //We get the map size here so we don't need to change the movement bounds, if we change map size.
    void Start()
    {
        xlimit = GameObject.Find("_Map").GetComponent<MapItself>().width - 1;
        ylimit = GameObject.Find("_Map").GetComponent<MapItself>().height - 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(life > 0)
        {
            if (Input.GetKeyDown("w") && transform.position.y < ylimit)
            {
                transform.position += new Vector3(0, distance, 0);
                life -= 1;
            }
            if (Input.GetKeyDown("s") && transform.position.y > 0)
            {
                transform.position += new Vector3(0, -distance, 0);
                life -= 1;
            }
            if (Input.GetKeyDown("a") && transform.position.x > 0)
            {
                transform.position += new Vector3(-distance, 0, 0);
                life -= 1;
            }
            if (Input.GetKeyDown("d") && transform.position.x < xlimit)
            {
                transform.position += new Vector3(distance, 0, 0);
                life -= 1;
            }
        }
        
    }
}

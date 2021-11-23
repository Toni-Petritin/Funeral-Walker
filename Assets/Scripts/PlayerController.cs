using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float distance = 1.0f;
    public float xlimit = 20.0f;
    public float ylimit = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("w") && transform.position.y < ylimit)
        {
            transform.position += new Vector3(distance, 0, 0);
        }
        if(Input.GetKeyDown("s") && transform.position.y > -ylimit)
        {
            transform.position += new Vector3(-distance, 0, 0);
        }
        if(Input.GetKeyDown("a") && transform.position.x < -xlimit)
        {
            transform.position += new Vector3(0, -distance, 0);
        }
        if(Input.GetKeyDown("d") && transform.position.x < xlimit)
        {
            transform.position += new Vector3(0, distance, 0);
        }
    }
}

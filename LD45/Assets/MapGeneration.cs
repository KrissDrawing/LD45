using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour
{

    public Transform player;
    public Transform loopObject;

    private bool order = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x >= transform.position.x && order)
        {
            loopObject.position = new Vector3(transform.position.x + GetComponent<Renderer>().bounds.size.x, transform.position.y, transform.position.z);
            order = !order;
        }
        if (player.transform.position.x >= loopObject.transform.position.x && !order)
        {
            transform.position = new Vector3(loopObject.transform.position.x + GetComponent<Renderer>().bounds.size.x, transform.position.y, transform.position.z);
            order = !order;
        }
    }

    
}

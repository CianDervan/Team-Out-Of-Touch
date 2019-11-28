using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject player;
    public Vector3 playerPosition;
    public Vector3 myPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        myPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        //playerPosition = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        //myPosition = new Vector3(playerPosition.x - 100f, 0, playerPosition.z - 100f);
        myPosition = new Vector3(player.transform.position.x - 100f, 0, 0);
        transform.position = myPosition;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blobMovement : MonoBehaviour
{
    [SerializeField] private PlayerCharacter player;

    public float speed = 2.0f;

    void Start()
    {
        
    }

    void Update()
    {
        /*if (collision)
        {
            if()
        }*/
        Vector2 dir = new Vector2(player.transform.position.x, player.transform.position.y);
        transform.LookAt(dir);
        transform.Translate(0,0,speed*Time.deltaTime);

    }


   /* private void onTriggerEnter(Collider other)
    {
        noWalkZone noWalk = other.GetComponent<noWalkZone>();
        if( noWalk!= null)
        {
            speed = 0;
            transform.Translate(0, 0, speed*Time.deltaTime);
        }
    }*/
}

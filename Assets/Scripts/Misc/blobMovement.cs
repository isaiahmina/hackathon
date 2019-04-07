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
        /*if(inside the '"don't move'" volume)
         * return
         * */
         Vector2 dir = new Vector2(player.transform.position.x, player.transform.position.y);

    }
}

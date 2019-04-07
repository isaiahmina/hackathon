using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPlayer : MonoBehaviour
{
    public float speed = 250.0f;
    

    private Rigidbody2D _body;
    private BoxCollider2D _box;

    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        _box = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _body.rotation = 0;
        float deltaX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float deltaY = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        Vector2 movement = new Vector2(deltaX, deltaY);

        _body.velocity = movement;


        
        Vector3 max = _box.bounds.max;
        Vector3 min = _box.bounds.min;
        Vector3 corner1 = new Vector2(max.x, min.y - .1f);
        Vector3 corner2 = new Vector2(max.x, min.y - .2f);
        Collider2D hit = Physics2D.OverlapArea(corner1, corner2);

        
        MovingPlatform platform = null;
        if (hit != null)
        {
            platform = hit.GetComponent<MovingPlatform>();
        }
        if (platform != null)
        {
            transform.parent = platform.transform;
        }
        else
        {
            transform.parent = null;
        }

        /*
        Vector3 pScale = Vector3.one;
        if (platform != null)
        {
            pScale = platform.transform.localScale;
        }
        if(deltaX!=0)
        {
            transform.localScale = new Vector3(.1f / pScale.x, .1f / pScale.y, .1f);
        }*/
    }
}

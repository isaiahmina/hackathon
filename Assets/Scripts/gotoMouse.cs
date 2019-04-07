using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gotoMouse : MonoBehaviour
{
    public float speed = 1.5f;
    private Vector3 target;

    void Start()
    {
        target = transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0)) { 
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target.z = transform.position.z;
    }
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}

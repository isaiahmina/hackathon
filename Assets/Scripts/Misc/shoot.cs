using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    [SerializeField] private GameObject playerBullet;

    private GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            bullet = Instantiate(playerBullet) as GameObject;
            bullet.transform.position = transform.TransformPoint(0,0, -0.1f);
            bullet.transform.rotation = transform.rotation;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    public float speed = 3.0f;
    public const float baseSpeed = 3.0f;

    public float obstacleRange = 5.0f;
    private bool _alive;
    [SerializeField] private GameObject enemyshot;
    private GameObject _enemyshot;

    public void Start()
    {
        _alive = true;
    }

    public void Awake()
    {
        Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }
    public void OnDestroy()
    {
        Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }
    

    // Update is called once per frame
    void Update()
    {
        if (_alive)
        {
            transform.Translate(0, 0, 0);
        }
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if(Physics.SphereCast(ray, 0.5f, out hit))
        {
            GameObject hitObject = hit.transform.gameObject;
            if (hitObject.GetComponent<PlayerCharacter>()) {
                if (_enemyshot == null)
                {
                    _enemyshot = Instantiate(enemyshot) as GameObject;
                    _enemyshot.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                    _enemyshot.transform.rotation = transform.rotation;
                }
            }
            else if (hit.distance < obstacleRange)
            {
                //float angle = Random.Range(-110, 110);
                //transform.Rotate(0, angle, 0);
            }
        }
        
    }
    private void OnSpeedChanged(float value)
    {
        speed = baseSpeed * value;
    }
    public void SetAlive(bool alive)
    {
        _alive = alive;
    }

}

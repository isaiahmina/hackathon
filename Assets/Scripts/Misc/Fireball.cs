using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{

    [SerializeField] private GameObject Allyshot;
    [SerializeField] private AudioSource soundSource;
    [SerializeField] private AudioClip hitWallSound;
    [SerializeField] private AudioClip hitEnemySound;

    public float speed = 20.0f;
    public float damage = 1;
    private Vector2 final;

    public ReactiveTarget target;
    private Transform PlayerPos;

    private void Start()
    {
        final = new Vector2(0.0f, 0.0f);

        GameObject hitObject = transform.gameObject;
        target = hitObject.GetComponent<ReactiveTarget>();
        PlayerPos = GetComponent<Transform>();
    }

    private void OnGUI()
    {
        Event currentEvent = Event.current;
        Vector2 mousePos = new Vector2();
        Vector2 point = new Vector2();
        mousePos.x = currentEvent.mousePosition.x;
        mousePos.y = Camera.main.pixelHeight - currentEvent.mousePosition.y;
        point = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 0.0f));

        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Shoot());
            final = point;
            if (target != null)
            {
                target.ReactToHit();
                soundSource.PlayOneShot(hitEnemySound);
            }
            else
            {
                soundSource.PlayOneShot(hitWallSound);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Mouse X");
        float inputY = Input.GetAxis("Mouse Y");
        //transform.position = Vector2.MoveTowards(transform.position, final, speed * Time.deltaTime);

    }
    private void OnTriggerEnter(Collider other)
    {
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        
        Destroy(this.gameObject);

    }
    private IEnumerator Shoot()
    {
        GameObject sphere = (GameObject)Instantiate(Allyshot, PlayerPos.position, Quaternion.identity);


        yield return new WaitForSeconds(1f);

        Destroy(sphere);
    }
}

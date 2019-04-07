using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RayShooter : MonoBehaviour
{
    [SerializeField] private GameObject Allyshot;
    [SerializeField] private AudioSource soundSource;
    [SerializeField] private AudioClip hitWallSound;
    [SerializeField] private AudioClip hitEnemySound;
    
    public ReactiveTarget target;
    private Transform PlayerPos;
    

    // Start is called before the first frame update
    void Start()
    {
        GameObject hitObject = transform.gameObject;
        target = hitObject.GetComponent<ReactiveTarget>();
        PlayerPos = GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Mouse X");
        float inputY = Input.GetAxis("Mouse Y");

        if (Input.GetMouseButtonDown(0) /*&& !EventSystem.current.IsPointerOverGameObject()*/)
        {

            Vector2 point = new Vector2(inputX, inputY);
            
            
            Fireball ball = GetComponent<Fireball>();
            transform.Translate(inputX,inputY,0);

            StartCoroutine(Shoot());

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

    private IEnumerator Shoot()
    {
        GameObject sphere = (GameObject)Instantiate (Allyshot, PlayerPos.position, Quaternion.identity);
        

        yield return new WaitForSeconds(1f);

        Destroy(sphere);
    }
}

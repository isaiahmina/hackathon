using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController: MonoBehaviour
{
    [SerializeField] private GameObject EnemyPrefab;
    private GameObject _enemy;


    // Update is called once per frame
    void Update()
    {
        if (_enemy == null)
        {
            _enemy = Instantiate(EnemyPrefab) as GameObject;
            float ranX = Random.Range(-10,10);
            float ranY = Random.Range(-10,10);
            _enemy.transform.position = new Vector3(ranX, ranY, -0.1f);
            float angle = Random.Range(0, 360);
            _enemy.transform.Rotate(0, angle, 0);

        }

    }
}

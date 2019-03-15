using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_manager : MonoBehaviour
{
    public int score;
    public int hp = 7;
    float speed = 2.0f;
    public GameObject[] prefab;
    bool gameStarted;

    // Start is called before the first frame update
    void Start()
    {
        gameStarted = false;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameStarted)
        {
            int seed = Random.Range(0, 10);
            transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);

            if (transform.position.x < -90)
            {
                speed = 2.0f;
            }
            else if (transform.position.x > 90)
            {
                speed = -2.0f;
            }
            else if (seed == 0)
            {
                speed *= -1;
            }
        }
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && gameStarted == false)
        {
            InvokeRepeating("spawn_ball", 1.0f, 1.0f);
            gameStarted = true;
            hp = 5;
            score = 0;
        }

        if (hp == 0)
        {
            gameStarted = false;
            CancelInvoke();
        }
    }

    void spawn_ball()
    {
        int index = Random.Range(0, 4);
        Instantiate(prefab[index], transform.position, Quaternion.identity);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_ball : MonoBehaviour
{
    private float speed = 1.2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "obj_player")
        {
            collision.gameObject.GetComponent<AudioSource>().Play();
            GameObject.Find("obj_manager").GetComponent<scr_manager>().score += 1;
            Destroy(gameObject);
        } else
        {
            collision.gameObject.GetComponent<AudioSource>().Play();
            Destroy(gameObject);
            GameObject.Find("obj_manager").GetComponent<scr_manager>().hp -= 1;
        }
    }

    void FixedUpdate()
    {
        transform.position += Vector3.down * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

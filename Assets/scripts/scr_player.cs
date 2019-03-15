using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_player : MonoBehaviour
{
    [SerializeField]
    private float newz;
    public Sprite[] sprites;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        newz = Mathf.Max(-87.5f, Mathf.Min(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, 87.5f));
        transform.position = new Vector3(newz, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        int int_grade = GameObject.Find("obj_manager").GetComponent<scr_manager>().hp;
        if (int_grade >= 4) { GetComponent<SpriteRenderer>().sprite = sprites[0]; }
        else if (int_grade < 4 && int_grade >= 2) { GetComponent<SpriteRenderer>().sprite = sprites[1]; }
        else { GetComponent<SpriteRenderer>().sprite = sprites[2]; }
    }
}

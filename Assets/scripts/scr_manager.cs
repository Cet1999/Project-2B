using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scr_manager : MonoBehaviour
{
    public int score;
    public int hp = 7;
    float speed = 2.0f;
    public GameObject[] prefab;
    bool gameStarted;
    public AudioSource music;
    public AudioSource sfx1;
    public AudioSource sfx2;

    // Start is called before the first frame update
    void Start()
    {
        gameStarted = false;
        if (PlayerPrefs.HasKey("music"))
        {
            music.volume = PlayerPrefs.GetFloat("music");
        }
        if (PlayerPrefs.HasKey("music_enable"))
        {
            if(PlayerPrefs.GetInt("music_enable") == 1)
            {
                music.enabled = true;
            } else
            {
                music.enabled = false;
            }
        }
        if (PlayerPrefs.HasKey("sfx"))
        {
            sfx1.volume = PlayerPrefs.GetFloat("sfx");
            sfx2.volume = PlayerPrefs.GetFloat("sfx");
        }
        if (PlayerPrefs.HasKey("sfx_enable"))
        {
            if (PlayerPrefs.GetInt("sfx_enable") == 1)
            {
                sfx1.enabled = true;
                sfx2.enabled = true;
            }
            else
            {
                sfx1.enabled = false;
                sfx2.enabled = false;
            }
        }
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
            savescore(score);
            SceneManager.LoadScene("End", LoadSceneMode.Single);
        }
    }

    void spawn_ball()
    {
        int index = Random.Range(0, 4);
        Instantiate(prefab[index], transform.position, Quaternion.identity);
    }

    void savescore(int s)
    {
        string tmp = "*";
        while(PlayerPrefs.GetInt(tmp) > s)
        {
            tmp += "*";
        }
        if (PlayerPrefs.HasKey(tmp))
        {
            Rec(tmp);
            PlayerPrefs.SetInt(tmp, s);
        }
        PlayerPrefs.Save();
    }

    void Rec(string tmp)
    {
        if (tmp.Length == 10)
        {
            return;
        } else
        {
            Rec(tmp + "*");
            PlayerPrefs.SetInt(tmp+"*", PlayerPrefs.GetInt(tmp));
        }
    }
}
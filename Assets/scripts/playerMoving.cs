using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMoving : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool up = false;
        bool down = false;
        bool left = false;
        bool right = false;

        if (Input.GetKey(KeyCode.W))
            up = true;

        if (Input.GetKey(KeyCode.A))
            left = true;

        if (Input.GetKey(KeyCode.S))
            down = true;

        if (Input.GetKey(KeyCode.D))
            right = true;

        this.Move(up, down, left, right);
    }

    private void Move(bool u, bool d, bool l, bool r)
    {
        float v = 0;
        float h = 0;

        if (u)    
            h++;
        if (d)
            h--;

        if (l)
            v--;
        if (r)
            v++;

        this.transform.position = this.transform.position + new Vector3((this.speed * v) * 0.01F, (this.speed * h) * 0.01F, 0);
    }

    void GameOver()
    {
        SceneManager.LoadScene("title");
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        string tag = col.gameObject.tag;
        Debug.Log(tag);
        if (tag == "twitter")
            this.GameOver();
    }
}

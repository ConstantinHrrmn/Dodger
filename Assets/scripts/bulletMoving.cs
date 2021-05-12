using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMoving : MonoBehaviour
{
    private float h;
    private float v;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        this.h = 0;
        this.v = 0;
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(this.speed * this.v * Time.deltaTime, this.speed * this.h * Time.deltaTime, 0);
    }

    public void SetDirection(float a_h, float a_v, Vector3 startPos)
    {
        this.h = a_h;
        this.v = a_v;

        if (this.h > 0)
        {
            startPos.y += 1.5f;
        }

        if (this.h < 0)
        {
            startPos.y -= 1.5f;
        }

        if (this.v > 0)
        {
            startPos.x += 1.5f;
        }

        if (this.v < 0)
        {
            startPos.x -= 1.5f;
        }

        this.transform.position = startPos;

        this.gameObject.GetComponent<SpriteRenderer>().flipX = Input.GetAxisRaw("Horizontal") > 0 ? true : false;
        this.gameObject.GetComponent<SpriteRenderer>().flipY = Input.GetAxisRaw("Vertical") > 0 ? true : false;

        this.gameObject.SetActive(true);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        string tag = col.gameObject.tag;
        if (tag == "side" || tag == "updown")
            this.gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ennemiMoving : MonoBehaviour
{

    public float speed;
    public float maxSpeed;

    private int up = 1;
    private int left = 1;

    private int speedloop = 0;
    private int coutner = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.coutner++;

        if (this.coutner >= this.speedloop )
        {
            if (this.speed <= maxSpeed)
            {
                //this.speed += Time.deltaTime;
                this.speed += 0.1f;
            }

            this.coutner = 0;
        }

        this.Move();
        
    }

    void Move()
    {
        this.transform.position = this.transform.position +  new Vector3(((this.speed * this.left) * 0.01F), ((this.speed * this.up) * 0.01F), 0);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        string tag = col.gameObject.tag;
        if (tag == "side")
            this.left *= -1;

        if (tag == "updown")
            this.up *= -1;
    }

}

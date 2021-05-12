using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMoving : MonoBehaviour
{
    public float speed;
    public GameObject bulletManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v3 = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        this.transform.Translate(this.speed * v3.normalized * Time.deltaTime);

        this.gameObject.GetComponent<SpriteRenderer>().flipX = Input.GetAxisRaw("Horizontal") > 0 ? true : false;
        this.gameObject.GetComponent<SpriteRenderer>().flipY = Input.GetAxisRaw("Vertical") > 0 ? true : false;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("SHOOT");
            bulletManager.GetComponent<BulletManager>().Shoot(this.transform.position);
        }
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

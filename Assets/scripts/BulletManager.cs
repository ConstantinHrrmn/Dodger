using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private List<GameObject> bullets;

    public GameObject BulletModel;
    public int avaibleBullets;

    // Start is called before the first frame update
    void Start()
    {
        this.bullets = new List<GameObject>();
        this.CreateBullets();
    }

    void CreateBullets()
    {
        for (int i = 0; i < this.avaibleBullets; i++)
        {
            this.bullets.Add(Instantiate(BulletModel));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot(Vector3 position)
    {
        foreach (GameObject bullet in this.bullets)
        {
            if (!bullet.activeSelf)
            {
                bullet.gameObject.GetComponent<bulletMoving>().SetDirection(Input.GetAxisRaw("Vertical"), Input.GetAxisRaw("Horizontal"), position);
                return;
            }
        }
    }
}

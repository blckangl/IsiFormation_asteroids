using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 2f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            LevelManager.instance.RemoveEnemy(collision.gameObject,false);
            Instantiate(explosion,collision.contacts[0].point,Quaternion.identity);
            Destroy(gameObject);
        }
    }

}

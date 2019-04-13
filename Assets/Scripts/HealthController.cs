using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public float health = 100f;

    public GameObject explosion;
    public GameObject smallExp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("enemy"))
        {
            health -= 20f;
            LevelManager.instance.UpdateHealthUi(health);
            LevelManager.instance.RemoveEnemy(collision.gameObject, true);
            Instantiate(smallExp);
        }

        if(health <= 0)
        {
            Instantiate(explosion);
            gameObject.SetActive(false);

        }
    }
}

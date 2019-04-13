using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public List<GameObject> Enemies;

    public GameObject player;
    public int coins = 0;

    [Header("UI")]
    public Slider Health;
    public TextMeshProUGUI CoinsUi;
    public GameObject GameOverScreen;

    [Header("audio")]
    public AudioClip Shooting;


    private AudioSource audioSource;

    private void Start()
    {
        if(instance == null)
        {
            instance = this;
            UpdateCoins();
            audioSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }


    public void RemoveEnemy(GameObject enemy,bool hit)
    {
        

       if(Enemies.Count >=0)
        {
            if (!hit)
            {
                coins += 10;
                UpdateCoins();
            }
            Enemies.Remove(enemy);
            Destroy(enemy);
        }

        if(Enemies.Count <= 0)
        {
            GameOver();
        }

    }


    


    public void GameOver()
    {
        GameOverScreen.SetActive(true);

        if (Enemies.Count > 0)
        {
            Enemies.ForEach((x) =>
            {
              
                Destroy(x);
            });
            Enemies = new List<GameObject>();
        }
    }

    public void UpdateHealthUi(float health)
    {
        Health.value = health;
        if(health <= 0)
        {
            GameOver();
        }
    }

    public void UpdateCoins()
    {
        CoinsUi.text = coins.ToString();
    }

    public void PlayShooting()
    {
        audioSource.PlayOneShot(Shooting);
    }
}

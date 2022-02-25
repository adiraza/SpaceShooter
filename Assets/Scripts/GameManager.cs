using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject EnemyPreFab;
    public float minInstantiateValue;
    public float maxInstantiateValue;
    public float EnmyDtime = 10f;

    public GameObject explosion;
    public GameObject MuzzleFlash;

    //public GameObject StartMenu;
    //public GameObject PauseMenu;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        //StartMenu.SetActive(false);
        InvokeRepeating("InstantiateEnemy", 0.5f, 0.8f);
    }

    void InstantiateEnemy()
    {
        Vector2 enemypos = new Vector2(Random.Range(minInstantiateValue, maxInstantiateValue), 5.5f);
        Instantiate(EnemyPreFab, enemypos, Quaternion.identity);
        GameObject enemy = Instantiate(EnemyPreFab, enemypos, Quaternion.Euler(0f, 0f, 0f));
        Destroy(enemy, EnmyDtime);
    }

    void EndGame()
    {
        Debug.Log("GameOver");
    }
}

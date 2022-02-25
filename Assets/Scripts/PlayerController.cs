using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float PlayerSpeed;

    [Header("Missile")]
    public GameObject Missile;
    public Transform missileSpawnPos;
    public float DestroyTime = 5;
    private float Timer = 0;
    public float fireRate = 0.5f;

    public Transform MuzzleFlashPos;

    public GameManager gameManager;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        PlayerShoot();
    }

    void PlayerMovement()
    {
        float Xpos = Input.GetAxis("Horizontal");
        float Ypos = Input.GetAxis("Vertical");

        Vector2 Movement = new Vector2(Xpos, Ypos) * PlayerSpeed * Time.deltaTime;
        transform.Translate(Movement);
    }

    void PlayerShoot()
    {
        Timer += Time.deltaTime;
        if(Input.GetKey(KeyCode.Space))
        {
            if(Timer >= fireRate)
            {
                GameObject gm = Instantiate(Missile, missileSpawnPos.position, Quaternion.identity);
                GameObject muzzle = Instantiate(GameManager.instance.MuzzleFlash, MuzzleFlashPos);
                Destroy(muzzle, DestroyTime);
                Destroy(gm, DestroyTime);
                Timer = 0;
            }
          
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag =="Enemy")
        {
            GameObject gm = Instantiate(GameManager.instance.explosion, transform.position, transform.rotation);
            Destroy(gm, 0.9f);
            Destroy(this.gameObject);
            Debug.Log("GameOver");
            

        }
    }
}

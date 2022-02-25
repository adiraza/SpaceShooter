using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour
{
    public float MissileSpeed = 25f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * MissileSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if(collision.gameObject.tag == "Enemy")
        {
            GameObject gm = Instantiate(GameManager.instance.explosion,transform.position,transform.rotation);
            Destroy(gm, 0.9f);
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
            
        }
    }
}

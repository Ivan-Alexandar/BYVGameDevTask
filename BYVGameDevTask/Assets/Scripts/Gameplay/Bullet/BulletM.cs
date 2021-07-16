using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletM : MonoBehaviour
{

    PlayerController playerController;
    public static int collisionCount = 0;

    public GameObject BulletFFM;
    public GameObject BBCol;
    public GameObject blood;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, transform.position.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        playerController = GameObject.FindGameObjectWithTag("PlayerFunc").GetComponent<PlayerController>();
        if (collision.gameObject.tag == "body1")
        {
            SoundManager.PlaySound("GettingHit");
            Instantiate(blood, collision.transform.position, Quaternion.identity);
            Destroy(gameObject);
            if (collisionCount < 5)
            {
                playerController.hp1[collisionCount].GetComponent<SpriteRenderer>().enabled = false;
                collisionCount++;
            }
            else
            {

            }


        }
        else if (collision.gameObject.tag == "body2")
        {
            SoundManager.PlaySound("GettingHit");
            Instantiate(blood, collision.transform.position, Quaternion.identity);

            Destroy(gameObject);
            if (collisionCount < 5)
            {
                playerController.hp2[collisionCount].GetComponent<SpriteRenderer>().enabled = false;
                collisionCount++;
            }
            else
            {

            }
        }
        else if (collision.gameObject.tag == "Head")
        {
            SoundManager.PlaySound("GettingHit");
            Instantiate(blood, collision.transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(gameObject);
            if (collisionCount < 5)
            {
                for (int i = 0; i < 3; i++)
                {

                    if (collisionCount<5)
                    {

                        playerController.hp1[collisionCount].GetComponent<SpriteRenderer>().enabled = false;
                        collisionCount++;
                    }
                    
                  
                }

            }
            else
            {

            }
        }
        else if (collision.gameObject.tag == "Leg")
        {
            SoundManager.PlaySound("GettingHit");
            Instantiate(blood, collision.transform.position, Quaternion.identity);
            Destroy(gameObject);
            if (collisionCount < 5)
            {
                playerController.hp1[collisionCount].GetComponent<SpriteRenderer>().enabled = false;
                collisionCount++;

            }

        }
        else if (collision.gameObject.tag =="bullet")
        {
            SoundManager.PlaySound("BulletRicochet");
            Instantiate(BBCol, collision.transform.position, Quaternion.identity);
            Instantiate(BulletFFM, gameObject.transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
            
            Destroy(gameObject);
            Destroy(collision.collider);
        }
        else if (collision.gameObject.tag == "Bomb" )
        {
            SoundManager.PlaySound("BulletRicochet");
            Instantiate(BBCol, collision.transform.position, Quaternion.identity);
            Instantiate(BulletFFM, gameObject.transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
            Destroy(gameObject);
 
        }
        else if (collision.gameObject.tag == "HealthBonus")
        {
            Instantiate(BBCol, collision.transform.position, Quaternion.identity);
            Instantiate(BulletFFM, gameObject.transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    PlayerController playerController;
    public static int collisionCount = 0;
    public static int headShotCounter = 0;
    public static int collisionOverload = 0;
    public static int negativeCollison = 0;
    public int fullHPBars = 0;
    public int emptyHPBars = 0;
    HealthBonus healthBonus;
    public GameObject shield;
    public GameObject body;


    static GameObject shield2;

    public GameObject BulletFF;
    public GameObject BBCol;
    public GameObject blood;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(10, transform.position.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collisionCount >= 5)
        {
            collisionOverload = collisionCount;
            collisionCount = collisionOverload - collisionCount;
        }
        if (collisionCount < 0)
        {
            negativeCollison = collisionCount;
            collisionCount = -negativeCollison;
        }
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

        }
        else if (collision.gameObject.tag == "body2")
        {
            SoundManager.PlaySound("GettingHit");
            Instantiate(blood, collision.transform.position, Quaternion.identity);
            Destroy(gameObject);
            if (collisionCount < 5 && headShotCounter < 3)
            {
                playerController.hp2[collisionCount].GetComponent<SpriteRenderer>().enabled = false;
                collisionCount++;
            }
        }
        else if (collision.gameObject.tag == "Head")
        {
            headShotCounter = 0;
            SoundManager.PlaySound("GettingHit");
            Instantiate(blood, collision.transform.position, Quaternion.identity);
            Destroy(gameObject);
            if (collisionCount < 5)
            {
                for (int i = 0; i < 5; i++)
                {

                    if (collisionCount < 5 && headShotCounter < 3)
                    {

                        if (playerController.hp2[i].GetComponent<SpriteRenderer>().enabled == true)
                        {

                            playerController.hp2[i].GetComponent<SpriteRenderer>().enabled = false;
                            headShotCounter++;
                            collisionCount++;

                        }

                    }
                    
                }
            }
        }
        else if (collision.gameObject.tag == "Leg")
        {
            SoundManager.PlaySound("GettingHit");
            Instantiate(blood, collision.transform.position, Quaternion.identity);
            Destroy(gameObject);
            if (collisionCount < 5)
            {

                playerController.hp2[collisionCount].GetComponent<SpriteRenderer>().enabled = false;
                collisionCount++;


            }

        }
        else if (collision.gameObject.tag == "bulletM")
        {
            SoundManager.PlaySound("BulletRicochet");
            Instantiate(BBCol, collision.transform.position, Quaternion.identity);
            Instantiate(BulletFF, gameObject.transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));

            Destroy(gameObject);
            Destroy(collision.collider);
        }
        else if (collision.gameObject.tag == "Bomb")
        {
            SoundManager.PlaySound("BulletRicochet");
            Instantiate(BBCol, collision.transform.position, Quaternion.identity);
            Instantiate(BulletFF, gameObject.transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "HealthBonus")
        {
            healthBonus = collision.collider.GetComponent<HealthBonus>();

            Instantiate(BulletFF, gameObject.transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
            Destroy(gameObject);

            if (healthBonus.bar.transform.localScale.x <= 0.1)
            {

                for (int i = 0; i < 5; i++)
                {
                    if (fullHPBars < 5 && emptyHPBars < 3)
                    {
                        if (playerController.hp1[i].GetComponent<SpriteRenderer>().enabled == false)
                        {

                            playerController.hp1[i].GetComponent<SpriteRenderer>().enabled = true;
                            emptyHPBars++;
                            //print(emptyHPBars);

                        }
                        else if (playerController.hp1[i].GetComponent<SpriteRenderer>().enabled == true)
                        {
                            fullHPBars++;
                            //print(fullHPBars);

                        }
                    }
                }
                collisionCount -= 3;
                headShotCounter = 0;
            }
        }
        if (collision.collider.tag == "ShieldBonus")
        {
 
            Instantiate(BulletFF, gameObject.transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
            Destroy(gameObject);
            body = GameObject.FindGameObjectWithTag("body1");
            //shield2 = Instantiate(shield, body.GetComponent<Rigidbody2D>().transform.position, Quaternion.identity);
            shield2 = Instantiate(shield, body.transform.position, Quaternion.identity);
            shield2.transform.parent = GameObject.FindGameObjectWithTag("player1").transform;
        }
        if (collision.collider.tag =="shield")
        {
            SoundManager.PlaySound("BulletRicochet");
            Instantiate(BBCol, gameObject.transform.position, Quaternion.identity);
            Instantiate(BulletFF, gameObject.transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }
}

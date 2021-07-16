using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    PlayerController playerController;
    public static int collisionCount = 0;
    public static int fullHPBars = 0;
    public static int emptyHPBars = 0;

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
                    if (collisionCount < 5)
                    {
                        playerController.hp2[collisionCount].GetComponent<SpriteRenderer>().enabled = false;
                        collisionCount++;
                    }
                    else
                    {

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

                playerController.hp2[collisionCount].GetComponent<SpriteRenderer>().enabled = false;
                collisionCount++;


            }
            else
            {

            }
        }
        else if (collision.gameObject.tag == "bullet")
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
            HealthBonus healthBonus = collision.collider.GetComponent<HealthBonus>();
            Instantiate(BBCol, collision.transform.position, Quaternion.identity);
            Instantiate(BulletFF, gameObject.transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
            for (emptyHPBars = 0; emptyHPBars < 3; emptyHPBars += 0)
            {
                if (healthBonus.bar.transform.localScale.x <= 0.1)
                {
                    if (fullHPBars < 5)
                    {
                        if (playerController.hp1[fullHPBars].GetComponent<SpriteRenderer>().enabled == false)
                        {

                            playerController.hp1[fullHPBars].GetComponent<SpriteRenderer>().enabled = true;
                            emptyHPBars++;
                            print(emptyHPBars);

                        }
                        else
                        {
                            fullHPBars++;
                            print(fullHPBars);

                        }


                    }
                }


            }
            Destroy(gameObject);
        }
    }
}

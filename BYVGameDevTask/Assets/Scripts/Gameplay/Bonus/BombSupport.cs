using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombSupport : MonoBehaviour
{
    Rigidbody2D rb2d;
    public Text _text;
    public GameObject explosion;
    private Timer timer;
    GameObject PlayerFunctionality;
    PlayerController playerController;
    private int collisionCounter = 0;
    private int body;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 6.75f;
        timer.Run();
        PlayerFunctionality = GameObject.FindWithTag("PlayerFunc");
        playerController = PlayerFunctionality.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

        _text.text = Mathf.Round(timer.SecondsLeft).ToString();
        if (timer.Finished)
        {
            Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //playerController = collision.collider.GetComponentInParent<PlayerController>();
        if (collision.collider.tag != "ground")
        {
            if (collision.collider.tag != "bullet" && collision.collider.tag != "bulletM")
            {


                if (collision.collider.tag == "body1" || collision.collider.tag == "Gun")
                {
                    body = 1;
                    collisionCounter = 0;
                    for (int i = 0; i < 5; i++)
                    {
                        if (collisionCounter < 5)
                        {
                            playerController.hp1[collisionCounter].GetComponent<SpriteRenderer>().enabled = false;
                            collisionCounter++;

                        }

                    }


                }
                else if (collision.collider.tag == "body2" || collision.collider.tag == "Gun2")
                {
                    body = 2;
                    collisionCounter = 0;
                    for (int i = 0; i < 5; i++)
                    {
                        if (collisionCounter < 5)
                        {
                            playerController.hp2[collisionCounter].GetComponent<SpriteRenderer>().enabled = false;
                            collisionCounter++;

                        }

                    }
                }
                Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
                Destroy(gameObject);
            }

            if (collision.collider.GetComponent<Rigidbody2D>() != null)
            {
                rb2d.AddTorque(-rb2d.velocity.x * 50, ForceMode2D.Force);

            }
        }

        print(collision.collider.name);

    }
    private void OnDestroy()
    {
        if (!timer.Finished && body == 1)
        {
            for (int i = 0; i < playerController.bodyPart.Length; i++)
            {
                if (playerController.bodyPart[i].GetComponent<HingeJoint2D>() != null)
                {

                    playerController.bodyPart[i].GetComponent<HingeJoint2D>().breakForce = 0;
                    playerController.bodyPart[i].GetComponent<Rigidbody2D>().freezeRotation = false;
                }
                else if (playerController.bodyPart[i].GetComponent<FixedJoint2D>() != null)
                {
                    playerController.bodyPart[i].GetComponent<FixedJoint2D>().breakForce = 0;
                    playerController.bodyPart[i].GetComponent<Rigidbody2D>().freezeRotation = false;
                }
                playerController.bodyPart[i].GetComponent<Rigidbody2D>().freezeRotation = false;

            }
        }
        else if (!timer.Finished && body == 2)
        {
            for (int i = 0; i < playerController.bodyPart2.Length; i++)
            {
                if (playerController.bodyPart2[i].GetComponent<HingeJoint2D>() != null)
                {

                    playerController.bodyPart2[i].GetComponent<HingeJoint2D>().breakForce = 0;
                    playerController.bodyPart2[i].GetComponent<Rigidbody2D>().freezeRotation = false;
                }
                else if (playerController.bodyPart2[i].GetComponent<FixedJoint2D>() != null)
                {
                    playerController.bodyPart2[i].GetComponent<FixedJoint2D>().breakForce = 0;
                    playerController.bodyPart2[i].GetComponent<Rigidbody2D>().freezeRotation = false;
                }
                playerController.bodyPart2[i].GetComponent<Rigidbody2D>().freezeRotation = false;

            }
        }

  
        SoundManager.PlaySound("Explosion");

    }
}

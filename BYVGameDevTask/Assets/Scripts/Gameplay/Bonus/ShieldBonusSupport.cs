using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShieldBonusSupport : MonoBehaviour
{
    public Text _text;
 
    private Timer timer;
    private void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 6.75f;
        timer.Run();
    }
    private void Update()
    {
        if (timer.Finished)
        {
            Destroy(gameObject);
        }
        _text.text = Mathf.Round(timer.SecondsLeft).ToString();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "bullet" || collision.collider.tag == "bulletM")
        {
            Destroy(gameObject);
           //shield2 = Instantiate(shield, body2.GetComponent<Rigidbody2D>().transform.position, Quaternion.identity);
           // shield2.transform.parent = GameObject.FindGameObjectWithTag("player2").transform;

        }
    }

}

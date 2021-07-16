using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBonus : MonoBehaviour
{
    public Text text;
    public GameObject bar;

    private Timer timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 20;
        timer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = Mathf.Round(timer.SecondsLeft).ToString();
        if (timer.Finished)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "bullet")
        {
            bar.transform.localScale = new Vector3(bar.transform.localScale.x -0.1f, 1,1);
            if (bar.transform.localScale.x <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    
}

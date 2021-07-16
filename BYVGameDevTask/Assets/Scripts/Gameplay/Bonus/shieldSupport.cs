using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldSupport : MonoBehaviour
{
    Timer timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 7.5f;
        timer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.Finished)
        {
            Destroy(gameObject);
        }
        if (gameObject.transform.position.x < 0)
        {

            gameObject.transform.position = new Vector3(gameObject.transform.position.x, GameObject.FindGameObjectWithTag("body1").transform.position.y,
                gameObject.transform.position.z);
        }
        else if (gameObject.transform.position.x > 0)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, GameObject.FindGameObjectWithTag("body2").transform.position.y,
    gameObject.transform.position.z);
        }
    }
}

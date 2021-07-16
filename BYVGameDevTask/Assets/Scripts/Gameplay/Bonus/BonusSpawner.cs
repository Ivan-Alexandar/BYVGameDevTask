using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawner : MonoBehaviour
{
    Timer timer;
    public GameObject bomb, hp, shield;
    // Start is called before the first frame update
    void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = Random.Range(8, 15);
        timer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.Finished)
        {
            switch (Random.Range(1,4))
            {
                case 1: Instantiate(bomb);
                    break;
                case 2: Instantiate(hp);
                    break;
                case 3: Instantiate(shield);
                    break;

            }
            timer.Duration = Random.Range(8, 15);
            timer.Run();
        }
    }
}

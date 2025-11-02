using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Establish all enemy types
    public enum EnemyType
    {
        Chaser,
        Sneaky
    }

    //Get enemy type
    public EnemyType theEnemy;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //Assign movement based on enemy type
        switch (theEnemy)
        {
            case EnemyType.Chaser:
                transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * 3f);
                if (transform.position.y < -6.5f)
                {
                    Destroy(this.gameObject);
                }
                break;
            case EnemyType.Sneaky:
                transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * 4f);
                //Sine wave movement
                transform.Translate(new Vector3(1, 0, 0) * Mathf.Sin(Time.time * 5f + 0f) * 0.025f);
                if (transform.position.y < -6.5f)
                {
                    Destroy(this.gameObject);
                }
                break;
        }
    }
}
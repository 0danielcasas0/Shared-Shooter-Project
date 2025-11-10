using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Establish enemy types
    public enum EnemyType
    {
        Chaser,
        Sneaky
    }

    //Get enemy type
    public EnemyType theEnemy;

    public GameObject explosionPrefab;
    
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //Assign movement patterns based on enemy type
        switch (theEnemy)
        {
            case EnemyType.Chaser:
                break;
            case EnemyType.Sneaky:
                //Sine wave movement
                transform.Translate(new Vector3(1, 0, 0) * Mathf.Sin(Time.time * 2f + 0f) * 0.025f);
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D whatDidIHit)
    {
        if(whatDidIHit.tag == "Player")
        {
            whatDidIHit.GetComponent<PlayerController>().LoseALife();
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        } else if(whatDidIHit.tag == "Weapons")
        {
            Destroy(whatDidIHit.gameObject);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            gameManager.AddScore(5);
            Destroy(this.gameObject);
        }
    }
}

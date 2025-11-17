using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    float currentTime;
    public float countdownTimer;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //Initialize timer
        currentTime = countdownTimer;
    }

    // Update is called once per frame
    void Update()
    {
        //Decrease timer
        currentTime -= Time.deltaTime;

        //Delete coin if time expires
        if (currentTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D whatDidIHit)
    {
        if(whatDidIHit.tag == "Player")
        {
            gameManager.AddScore(1);
            Destroy(this.gameObject);
        }
    }
}

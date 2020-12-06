using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AsteroidDestroy : MonoBehaviour
{
    public GameObject explosion;
    //public GameObject playerExplosion;    

    private SFXManager sfxManager;
    private GameManager gameManager;
    private GameObject player;

    void Awake()
    {
        sfxManager = ( GameObject.Find("SFXManager").GetComponent<SFXManager>() );
        gameManager = ( GameObject.Find("GameManager").GetComponent<GameManager>() );
        player = GameObject.Find("Player");
    }

    void OnTriggerEnter(Collider other)
    {   
        
                     
        if (other.tag == "Player")
        {
            Instantiate(explosion, this.transform.position, this.transform.rotation);
            sfxManager.AsteroidExplosion();
            Destroy(this.gameObject);            
        }
                  

        if (other.tag == "Bullet")
        {
            gameManager.score = gameManager.score += 10;
            Instantiate(explosion, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
            //Debug.Log("killed by bullet");
            sfxManager.AsteroidExplosion();
            Destroy(other.gameObject);
        }

        if (other.tag == "Boundary")
        {
            Destroy(this.gameObject);
        }




    }
}

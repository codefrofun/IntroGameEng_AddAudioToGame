using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDestroy : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;

    private SFXManager sfxManager;

    void Awake()
    {
        sfxManager = (GameObject.Find("SFXManager").GetComponent<SFXManager>() );
    }

    void OnTriggerEnter(Collider other)
    {   
        
                     
        if (other.tag == "Player")
        {
            Instantiate(explosion, this.transform.position, this.transform.rotation);
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            Destroy(this.gameObject);
            sfxManager.PlayerExplosion();
            Destroy(other.gameObject);
        }
                  

        if (other.tag == "Bullet")
        {
            Instantiate(explosion, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
            Debug.Log("killed by bullet");
            sfxManager.AsteroidExplosion();
            Destroy(other.gameObject);
        }

        if (other.tag == "Boundary")
        {
            Destroy(this.gameObject);
        }




    }
}

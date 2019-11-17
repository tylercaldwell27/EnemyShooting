using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolEnemy : MonoBehaviour
{

    [SerializeField]
    GameObject bullet;

    public float fireRate;
    float nextFire;
    float nextReload;
    public float SPtime;
    public float ammo;
    public float clip;
   public PlayerHealth hp;
    public GunShot player;
    public EnemyHealth enemyHp;
    public AudioSource gunSound;
    // Start is called before the first frame update
    void Start()
    {
      //  fireRate = 3f;
        nextFire = Time.time;

    }

    // Update is called once per frame
    void Update()
        
    {
        Debug.Log(SPtime);
        SPtime += Time.time;
        if(SPtime > 25000)
        {
            fireRate = 0.02f;
            SPtime = 0;
            clip = 200;
           // ammo = 200;
        }
        else if(SPtime > 10000 & SPtime < 24999){
            fireRate = 0.05f;
            // ammo = 60;
            clip = 60;
        }

        if(player.hide == false) { 
        if (Time.time > nextFire)
        {
                if (ammo > 0)
                {
                    gunSound.Play();
                    Instantiate(bullet, transform.position, Quaternion.identity);
                    nextFire = Time.time + fireRate;
                    ammo -= 1;
                        Debug.Log(ammo);
                }
                if( ammo <= 0)
                {

                    if(Time.time > nextReload)
                    {
                        ammo = clip;
                        nextReload = Time.time + 7;
                    }
                }
        }
            if (enemyHp.enemyHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
        if(player.hide == true)
        {

        }
    }
    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "Player")
        {
            hp.health = hp.health - 10;
            hp.SetHealthText();
            Debug.Log("you got shot");
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Ai")
        {
          
            Debug.Log("they got shot");
            Destroy(other.gameObject);
        }
    }
}

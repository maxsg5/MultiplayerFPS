using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//what I envision for a Player script is to handle things like checking if the player is dead, 
//having some attributes like PlayerID. Would probably be built off of sometype of scriptable object, 
//we need a way to pass player information along between objects. 
//Say Player1 shoots Player2, when Player2 takes damage Player2 should be aware that Player1 was the one that did the damage so we can keep track of kills etc...


//[RequireComponent(typeof(PlayerHealth))]
[RequireComponent(typeof(Collider))]
public class Player : MonoBehaviour
{
    public int PlayerID; //this is the player's ID, this is used to determine who is the player and who is the enemy.
    public int PlayerScore; //this is the player's score
    public int PlayerKills; //this is the player's kills
    public int PlayerDeaths; //this is the player's deaths
    public int PlayerAssists; //this is the player's assists

    private Collider collider; //the collider of the player
    
    //private PlayerHealth playerHealth; //the player's health
    
    
    // Start is called before the first frame update
    void Awake()
    {
        collider = GetComponent<Collider>();
        //playerHealth = GetComponent<PlayerHealth>();
    }


    //collision detection
    private void OnCollisionEnter(Collision collision)
    {
        //if the player collides with a bullet, the bullet should be destroyed
        if (collision.gameObject.tag == "Bullet")
        {
            //find the player that shot the bullet
            
            //Player shooter = collision.gameObject.GetComponent<Bullet>().shooter;

            //do something

            //destroy the bullet
            Destroy(collision.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage = 1;
    public float Speed = 10f;

    public GameObject effect;
    

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Speed * Time.deltaTime);  
    }
     void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            
            
            Instantiate(effect, transform.position, Quaternion.identity);

            //player takes damage
            other.GetComponent<PlayerControl>().Health -= damage;
            Debug.Log(other.GetComponent<PlayerControl>().Health);
            Destroy(gameObject); //destroys the enemy itself after collision
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
    {
    private Vector2 currentPos;
    private Vector2 targetPos;
    public float Yincr = 4f;
    public float mSpeed = 200f;
    public float maxHeight = 4f;
    public float minHeight = -4f;
    public int Health = 3;
    public GameObject pEffect;
    public Text healthDisplay;
    public GameObject gameOver;
    public GameObject popSound; 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthDisplay.text = "Health: "+ Health.ToString();

        if(Health <= 0)
        {
            gameOver.SetActive(true);
            Destroy(gameObject);
        }

      currentPos = transform.position;

        //move towards a position for smooth movement using transform.position method makes the movement immediate
        transform.position = Vector2.MoveTowards(currentPos, targetPos, mSpeed * Time.deltaTime);
        
        if(Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxHeight)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y + Yincr );
            Instantiate(pEffect, transform.position, Quaternion.identity);
            Instantiate(popSound, transform.position, Quaternion.identity);

        } if(Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minHeight)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y - Yincr );
            Instantiate(pEffect, transform.position, Quaternion.identity);
            Instantiate(popSound, transform.position, Quaternion.identity);

        }
    }
}

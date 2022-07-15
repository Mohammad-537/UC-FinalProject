using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Built : MonoBehaviour
{
    public float bulitSpeed = 7f;
    Rigidbody2D rb;
    public Transform target;
    Vector2 attackDirection;
    //public dragAndShot script;
    int levels;
    
    // Start is called before the first frame update
    void Start()
    {
        
        //Debug.Log(script.Level);
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        //target = GameObject.FindGameObjectsWithTag("Player");
        attackDirection = (target.transform.position - transform.position).normalized * bulitSpeed;
        rb.velocity = new Vector2(attackDirection.x, attackDirection.y);
        //Destroy(gameObject, 5f);
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if(collision2D.gameObject.tag == "Player")
        {
            //SceneManager.LoadScene(levels);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        //script.Level = levels;
    }
}

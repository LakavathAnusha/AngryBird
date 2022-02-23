using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 birdStartPosition;
    public float speed;
    public float maximumDragDistance;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        rb.isKinematic = true;
        birdStartPosition = rb.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
        Vector2 currentPostion = rb.position;
        Vector2 direction = birdStartPosition - currentPostion;
        direction.Normalize();
        rb.isKinematic = false;
        speed = Random.Range(500f, 1000f);
        rb.AddForce(direction * speed);
    }

    private void OnMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);//Mouse/screen Position converted to WorldPoint
        Vector2 desiredPosition = mousePosition;
        if(desiredPosition.x>birdStartPosition.x)
        {
            desiredPosition.x = birdStartPosition.x;
        }
        // transform.position = new Vector3(mousePosition.x,mousePosition.y,transform.position.z);//Assigning mouse Position to bird Position
        float distance = Vector2.Distance(desiredPosition, birdStartPosition);
       if(distance>maximumDragDistance)
        {
            Vector2 direction = desiredPosition - birdStartPosition;
            direction.Normalize();
            desiredPosition = birdStartPosition + (direction * maximumDragDistance);
        }
        rb.position = desiredPosition;


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(ResetAfterDelay());
        
    }
    IEnumerator ResetAfterDelay()
    {
        //Debug.Log("Its a coroutine function");
        yield return new WaitForSeconds(5f);
        Debug.Log("Its a coroutine function");

        rb.position = birdStartPosition;
        rb.isKinematic = true;
        rb.velocity = Vector2.zero;
    }
   
}
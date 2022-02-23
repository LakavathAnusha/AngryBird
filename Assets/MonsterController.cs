using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite monster;
    void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       BirdController bird =  collision.gameObject.GetComponent<BirdController>();
        if(bird!=null || collision.gameObject.tag == "Crate")
        {
            //Destroy(gameObject);
            MonsterDeath();
            
        }
   
    }
   
    private void MonsterDeath()
    {
        //gameObject.SetActive(false);
        GetComponent<SpriteRenderer>().sprite = monster;
    }
    /*Level 1:more Monsters and crates. check for preventing multiple deaths.
     * Level 2:when the collision happens i want to print the score.
     */
    // Update is called once per frame
    void Update()
    {
        
    }
}

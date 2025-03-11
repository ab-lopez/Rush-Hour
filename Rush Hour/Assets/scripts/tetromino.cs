using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class tetronimo : MonoBehaviour
{
    private bool dragging = false;
    public bool placed = false;
    private Vector3 offset;

    public int nomOfCollisions;
    private Vector3 target;
    private float speed = 10.0f;
    private bool invalid = false;
    private bool editing = false;
    private float step;
    

    void Start(){
      Collider2D myCollider = gameObject.GetComponent<Collider2D>();
      target = new Vector3(11, 9, 0);
      step = speed * Time.deltaTime;
    }
    
     void Update() {

    if (dragging) {
      // Move object, taking into account original offset.
      transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
    }
    while(invalid && !dragging){

      target = new Vector3(11, 9, 0); // set og respawn position

      if(transform.position != target){
      transform.position = Vector2.MoveTowards(transform.position, target, step);
      }
      else{
        invalid = false;
      }

    }

    while(editing){ // while tetromino is turning
      
      target = new Vector3(11, -3, 0); // a little higher than where it was to make sure it doesn't fall through

      if(transform.position != target){
      transform.position = Vector2.MoveTowards(transform.position, target, step);
      }
      else{
        editing = false;
      }

    }

  }

  private void OnMouseDown() {
    // If left click and if not yet placed
    if (!placed){
      // Record the difference between the objects centre, and the clicked point on the camera plane.
      offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
      dragging = true;
    }
  }

  private void OnMouseUp() {
    // Stop dragging.
    // needs a collider to check if it's even on the playing field:
    // to be added when/if art gets added
    
    dragging = false;
 
    Debug.Log(gameObject.name + " collisions: " + nomOfCollisions);

     if(nomOfCollisions <= 2 && !invalid){
        placed = true;    
     }
     else{
      invalid = true;
      Debug.Log("BOO");
     }
    
  }

  private void OnMouseOver () {
          // If right click
    if (Input.GetMouseButtonDown(1) && !dragging){
      Debug.Log("right click");

      transform.Rotate(0, 0, 90);
      transform.Translate(0,2,0);

      editing = true;
    }
}

private void OnCollisionEnter2D(Collision2D coll){
     if(!placed){ 
      Debug.Log("trigger is running.");
      
        if(coll.gameObject.tag=="tetromino"){
          Debug.Log("oops! hit: " + coll.gameObject.name);
          nomOfCollisions += 1;
        }

        if(coll.gameObject.tag=="evilWall"){
          Debug.Log("EVIL WALL");
          invalid = true;
        }
        else if(coll.gameObject.tag=="floor"){
          placed = false;
        }
     }

}

 private void OnCollisionExit2D(Collision2D coll)
    {
        if(coll.gameObject.tag=="tetromino"){
          nomOfCollisions -= 1;
        }
       
        if(coll.gameObject.tag=="evilWall"){
          Debug.Log("no more evil wall");
          invalid = false;
        }
    }

}


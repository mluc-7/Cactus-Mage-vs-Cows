using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // speed of the player's movement
    public Rigidbody2D rb; // player's rigidbody
    [HideInInspector] public Vector2 moveDirection; // direction of movement input
    public Camera mainCamera; // main camera reference
    Vector2 mousePosition; // stores the position of the mouse pointer in world space

    void Awake()
    {
        //sanity check for player's rigidbody
        if(rb==null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
        moveDirection = new Vector3();
    }
    
    
    void Update()
    {
        // get input from arrow keys or WASD
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Vertical");

        // get the position of the mouse pointer in world space
        mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        // move the player based on the movement input
        //maybe add dampener
        rb.velocity = moveDirection * moveSpeed;

        // rotate the player sprite to face the mouse pointer 
        Vector2 aimDirection = mousePosition - rb.position;//get the direction vector between the player and the mousePosition
        //we use atan to find the angle (since we know the opposite side and adjacent side lengths from the aimDirection vector)
        //since the result of Atan2 is in radians, we need to convert it to degreees, and finally we need to rotate the player gameObject 90 degrees to face the mousePosition.
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
    }

    void LateUpdate()
    {
        // move the camera to follow the player, it is in Lateupdate so the camera will only update after the player has moved
        mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, mainCamera.transform.position.z);
    }
}

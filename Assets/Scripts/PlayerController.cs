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
    }

    void LateUpdate()
    {
        // move the camera to follow the player, it is in Lateupdate so the camera will only update after the player has moved
        mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, mainCamera.transform.position.z);
    }
}

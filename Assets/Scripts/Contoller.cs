using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class Contoller : MonoBehaviour
{
    public float moveSpeed = 0.5f;
    public float collisionOffset = 0.02f;
    public ContactFilter2D movementFilter;

    Vector2 movementInput;
    Rigidbody2D rb;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {

        // If the mouse pointer is over ui the player cant move
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        // If statements for movement
        if (movementInput != Vector2.zero) {
            bool success = TryMove(movementInput);

            if (!success)
            {
                success = TryMove(new Vector2(movementInput.x, 0));

                if (!success)
                {
                    success = TryMove(new Vector2(0, movementInput.y));
                }
            }

            animator.SetBool("isMoving", success);
        } else
        {
            animator.SetBool("isMoving", false);
        }
    }

    // Method for moving the player
    private bool TryMove(Vector2 direction)
    {
        if (direction != Vector2.zero)
        {

            int count = rb.Cast(
                    direction, //X and Y values
                    movementFilter, //Setting to determine where a collision can occur
                    castCollisions, //List of collisions
                    moveSpeed * Time.fixedDeltaTime + collisionOffset); //The amount to cast equal to the movement plus an offset

            if (count == 0)
            {
                // Statement that move the player
                rb.MovePosition(rb.position + (direction * moveSpeed * Time.fixedDeltaTime));
                return true;
            }
            else
            {
                return false;
            }
        } else
        {
            return false;
        }
    }

    // Method for player animator
    public void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();

        //Idle state
        if (movementInput != Vector2.zero) { 
            animator.SetFloat("XInput", movementInput.x);
            animator.SetFloat("YInput", movementInput.y);
        }

    }
}

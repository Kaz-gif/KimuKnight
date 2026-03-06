using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputAction MoveAction;
    
    public float speed = 0.1f;
    Animator animator;
    void Start()
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    {
        MoveAction.Enable();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {  
        Vector2 move = MoveAction.ReadValue<Vector2>();
        //Feedback for unity console
        Debug.Log(move);
        Vector2 position = (Vector2)transform.position + move * speed;
        transform.position = position;


        // Running animation
        
        if (move.x != 0)
        {
            animator.SetBool("running", true);
        }
        else
        {
            animator.SetBool("running", false);
        }

        // Rotate Character when going backwards

        if (move.x < 0)
        {
            transform.localScale = new Vector2(-5, 5);
        }
        else if (move.x > 0)
        {
            transform.localScale = new Vector2(5, 5);
        }

    }
}

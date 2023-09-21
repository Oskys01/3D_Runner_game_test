using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHandler : MonoBehaviour
{
    private float runSpeed = 1.0f;
    private float sideSpeed = 5.0f;
    public float jumpSpeed = 5f;
    private Vector2 input = Vector2.zero;

    public void OnMove(InputAction.CallbackContext context)
    {
        input = context.ReadValue<Vector2>();
    }

    public void OnJump(){
        GetComponent<Rigidbody>().AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
        GameObject.Find("Remy").GetComponent<Animator>().Play("Jumping");
    }

    
    void Update()
    {
        transform.Translate(new Vector3(input.x * sideSpeed, 0, runSpeed) * Time.deltaTime);
    }
}

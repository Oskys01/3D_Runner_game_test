using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHandler : MonoBehaviour
{
    private float runSpeed = 5.0f;
    private float sideSpeed = 5.0f;
    public float jumpSpeed = 5f;
    private Vector2 input = Vector2.zero;

    private bool canMove = true;

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
        transform.Translate(new Vector3(input.x * sideSpeed, 0, canMove ? runSpeed : 0) * Time.deltaTime);
    }

    public async Task OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.StartsWith("Obs"))
        {
            canMove = false;
            GameObject.Find("Remy").GetComponent<Animator>().Play("FallingDown");
            GetComponent<Rigidbody>().AddForce(Vector3.back, ForceMode.Impulse);
            await Task.Delay(3000);
            canMove = true;
        }
        
    }
}

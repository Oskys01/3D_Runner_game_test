using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHandler : MonoBehaviour
{
    private float runSpeed = 7.5f;
    private float sideSpeed = 5.0f;
    public float jumpSpeed = 5.5f;
    private Vector2 input = Vector2.zero;

    private bool canMove = true;
    private bool canJump = false;
    

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

    public async void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.StartsWith("Obs"))
        {
            sideSpeed = 0f;
            

            canMove = false;
            
            GameObject.Find("Remy").GetComponent<Animator>().Play("FallingDown");
            GetComponent<Rigidbody>().AddForce(Vector3.back * 4, ForceMode.Impulse);
            await Task.Delay(1900);
            sideSpeed = 5.5f;

            await Task.Delay(200);
            canMove = true;
            
        }

        if (collision.gameObject.name.StartsWith("Plane"))
        {
            canJump = true;
        }
            
        
    }
}

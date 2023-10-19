using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerHandler : MonoBehaviour
{
    private float runSpeed = 7.5f;
    private float sideSpeed = 5.0f;
    public float jumpSpeed = 7.5f;
    private Vector2 input = Vector2.zero;

    private bool canMove = true;
    private bool canJump = true;
    private int z = 0;
    private bool isGenerationInProgress = false;

   


    public void OnMove(InputAction.CallbackContext context)
    {

        input = context.ReadValue<Vector2>();
    }

    public void OnJump()
    {
        if (canJump == true)
        {
            canJump = false;
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            GameObject.Find("Remy").GetComponent<Animator>().Play("Jumping");
        }
    }


   async void Update()
    { 


        //INVISIBLE WALLS

        float x =
            transform.position.x < -4.2 && input.x < 0
                ? 0
                : transform.position.x > 4.5 && input.x > 0
                    ? 0
                    : input.x * sideSpeed;

        transform.Translate(new Vector3(x, 0, canMove ? runSpeed : 0) * Time.deltaTime);




        //if (transform.position.x < -4.2)
        //{
        //    if (input.x > 0)
        //    {
        //        transform.Translate(new Vector3(input.x * sideSpeed, 0, canMove ? runSpeed : 0) * Time.deltaTime);

        //    }
        //    else
        //    {
        //        transform.Translate(new Vector3(0, 0, canMove ? runSpeed : 0) * Time.deltaTime);

        //    }

        //}
        //else if (transform.position.x > 4.5)
        //{
        //    //transform.Translate(new Vector3(0, 0, canMove ? runSpeed : 0) * Time.deltaTime);
        //    if (input.x < 0)
        //    {
        //        transform.Translate(new Vector3(input.x * sideSpeed, 0, canMove ? runSpeed : 0) * Time.deltaTime);
        //    }

        //    else
        //    {
        //        //transform.Translate(new Vector3(input.x * sideSpeed, 0, canMove ? runSpeed : 0) * Time.deltaTime);
        //        transform.Translate(new Vector3(0, 0, canMove ? runSpeed : 0) * Time.deltaTime);

        //    }
        //}
        //else
        //{

        //    transform.Translate(new Vector3(input.x * sideSpeed, 0, canMove ? runSpeed : 0) * Time.deltaTime);
        //}



    }

   

    public async void OnCollisionEnter(Collision collision)
    {
        //OBSTACLE COLLISIONS

        if (collision.gameObject.name.StartsWith("Obs"))
        {
            sideSpeed = 0f;


            canMove = false;

            GameObject.Find("Remy").GetComponent<Animator>().Play("FallingDown");
            GetComponent<Rigidbody>().AddForce(Vector3.back * 7, ForceMode.Impulse);
            await Task.Delay(1900);
            sideSpeed = 5.5f;

            await Task.Delay(200);
            canMove = true;

        }

        //COIN PICKUP

       


        if (collision.gameObject.name.StartsWith("Coin"))
        {
            Debug.Log("Colliding with " + collision.gameObject.name.StartsWith("Coin"));
            CoinCollect.coinScore++;
            

            GameObject.Find("CoinSound").GetComponent<AudioSource>().Play();

            Object.Destroy(collision.gameObject);

           var textObject = GameObject.Find("ScoreText");
           var textComponent = textObject.GetComponent<TextMeshProUGUI>();
           textComponent.text = "Score: " + CoinCollect.coinScore.ToString();

            

        }

        canJump = true;


    }
}

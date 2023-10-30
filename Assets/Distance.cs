using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;


public class Distance : MonoBehaviour
{
    public static int distance = 0;
    private bool isDistanceCalculating = false;
    public static bool isDone = false;

    // Update is called once per frame
    async void Update()
    {
       if (PlayerHandler.canMove == true)
        {
            if (isDistanceCalculating == false)
            {
                isDistanceCalculating = true;
                distance++;
                
              


                var textObject = GameObject.Find("distance");
                var textComponent = textObject.GetComponent<TextMeshProUGUI>();
                textComponent.text = "Distance: " + distance.ToString();

                await Task.Delay(1000);
                isDistanceCalculating = false;

                

            }
        }
        

    }

}

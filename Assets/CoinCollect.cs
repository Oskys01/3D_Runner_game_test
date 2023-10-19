using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    public static int coinScore = 0;
    public float rotateSpeed = 10.5f;

    

    void Update()
    {
        transform.Rotate(new Vector3(0, 100, 0) * Time.deltaTime);
        
    }
    
}

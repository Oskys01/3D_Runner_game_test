using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class MapHandler : MonoBehaviour
{
    private int z = 0;
    private bool isGenerationInProgress = false;


    // Update is called once per frame
    async void Update()
    {
        //FURTHER GENERATION

        if (isGenerationInProgress == false)
        {
            await GenerateObject();
        }
    }

    private async Task GenerateObject()
    {
        //OBSTACLE GENERATION

        isGenerationInProgress = true;
        var obs = GameObject.Find("Obs1");
        z += 10;
        Instantiate(obs, new Vector3(0, 0, z), Quaternion.identity);
        await Task.Delay(1000);
        // isGenerationInProgress = false;

        //PLANE GENERATION

        var r = Random.Range(1, 3);
        var env = GameObject.Find("Environment" + r.ToString());
        z += 70;
        Instantiate(env, new Vector3(0, 0, z), Quaternion.identity);
        await Task.Delay(5000);

        isGenerationInProgress = false;
    }

}

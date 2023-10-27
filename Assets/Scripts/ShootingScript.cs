using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ShootingScript : MonoBehaviour
{

    public GameObject arCamera;
    public GameObject smoke;
    public ScoreScript scoreScript;

    public void Shoot(){
        RaycastHit hit;

        if (Physics.Raycast(arCamera.transform.position, arCamera.transform.forward, out hit)) {
            Destroy(hit.transform.gameObject);
            Instantiate(smoke, hit.point, Quaternion.LookRotation(hit.normal));
  if (hit.transform.CompareTag("red"))
        {
            scoreScript.IncreaseScore(1);
            Handheld.Vibrate(); // It's a red balloon, so vibrate the device
        }
        }
    }
}


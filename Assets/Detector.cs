using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    GameManager gameManager;

    void Start()
    {
        gameManager = (GameManager)FindObjectOfType(typeof(GameManager));
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(0, 0.1f, 0) * Mathf.Sin(Time.time);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            gameManager.UpdateScore(1);
        }
    }
}

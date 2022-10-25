using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;
    private Rigidbody rigidBody;
    public float force;

    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            thisAnimation.Play();
            rigidBody.AddForce(new Vector3(0f, force, 0f), ForceMode.Impulse);
        }

        Vector3 velocity;
        velocity = rigidBody.velocity;
        velocity.y = Mathf.Clamp(velocity.y, -12f, 3.5f);
        rigidBody.velocity = velocity;

        if(transform.position.y <= -4.5f)
        {
            SceneManager.LoadScene("GameLose");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene("GameLose");
        }
    }

}

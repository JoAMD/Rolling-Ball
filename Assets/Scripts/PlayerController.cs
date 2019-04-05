using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    
    private Rigidbody rigidbody;
    public float speed;
    private int score = 0;
    public Text scoreBox;
    public Text winText;

    private void Start()
    {
        rigidbody = transform.GetComponent<Rigidbody>();
        setScore();
        winText.text = "";

    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rigidbody.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Destroy(other.gameObject);
        if (other.gameObject.CompareTag("Collectable"))
        {
            other.gameObject.SetActive(false);
            score++;
            setScore();
        }
    }

    private void setScore()
    {
        scoreBox.text = "Score: " + score;
        if (score == 8)
        {
            winText.text = "You win!!!";
        }
    }

}

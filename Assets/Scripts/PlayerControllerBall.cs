using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerControllerBall : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 5f;
    //public float turnSpeed = 5f;
    public bool BallIsOnGround = true;
    private int Score;
    public TextMeshProUGUI ScoreText;
    



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Score = 0;
        SetScoreText ();
    }


    // Update is called once per frame
    void Update()
    {

      float  horizontalInput = Input.GetAxis("Horizontal");
      float  forwardInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed *forwardInput);
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);


        //transform.Rotate(Vector3.up, turnspeed* Time.deltaTime * horizontalInput);
        if (Input.GetButton("Jump") && BallIsOnGround)
        {
            rb.AddForce(new Vector3(0, 7, 0), ForceMode.Impulse);
            BallIsOnGround = false;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name=="Road")
        {
            BallIsOnGround = true;
        }
    }

    public void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.tag == "Coin")
        {
            //Debug.Log("Coins");
            Score = Score + 1;
            SetScoreText();
            //Deactivating gameObject to avoid counting twice
            Col.gameObject.SetActive(false);
            Destroy(Col.gameObject);
        }
    }

    private void SetScoreText()
    {
        ScoreText.text = "Score: " + Score.ToString();
    }

}

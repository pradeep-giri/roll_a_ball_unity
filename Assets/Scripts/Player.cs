using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed = 5;
    private int count = 0;
    private Rigidbody rb;
    public Text scoreText;
    public Text winText;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        DisplayScore();
        winText.text = "";
    }

    void Update()
    {
        if(count == 5)
        {
            winText.text = "You Win !";
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVartical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVartical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUps"))
        {
            other.gameObject.SetActive(false);
            count++;
            DisplayScore();
        }
    }

    void DisplayScore()
    {
        scoreText.text = "Score : " + count.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour {

    public float speed;
    private int count;
    private int numPickups = 8; // Put here the number of pickups you have .
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI winText;
    public Vector2 moveValue ;

    void Start()
    {
        count = 0;
        winText.text = "";
        SetCountText();
    }

    void OnMove ( InputValue value ) {
        moveValue = value.Get<Vector2>() ;
    }

    void FixedUpdate () {
        Vector3 movement = new Vector3 (moveValue.x, 0.0f, moveValue.y);
        GetComponent<Rigidbody>().AddForce(movement * speed * Time.fixedDeltaTime);
    }

    void Update () {}
 
    //void FixedUpdate() {} // NO changes

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "PickUp") {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    private void SetCountText() {
        scoreText.text = "Score: " + count.ToString();
        if (count >= numPickups) {
            winText.text = "You win!";
        }
    }
}
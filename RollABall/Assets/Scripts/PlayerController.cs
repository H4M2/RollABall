using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{

    public float speed;
    private int count;
    private int numPickups = 8; // Put here the number of pickups you have .
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI winText;

    void Start() 
    {
        count = 0;
        winText.text = "";
        SetCountText ();
    }

    void FixedUpdate() {} // NO changes

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == " PickUp ")
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    private void SetCountText()
    {
        scoreText.text = "Score: " + count.ToString();
        if (count >= numPickups)
        {
            winText.text = "You win!";
        }
    }
}
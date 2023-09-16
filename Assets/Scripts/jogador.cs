using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class jogador : MonoBehaviour
{
    private Rigidbody rb;
    public float velocidade;
    private int count;
    public Text countText;
    public Text winText;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";

    }

    void Update()
    {
        float movimentoHorizontal = Input.GetAxis("Horizontal");
        float movimentoVertical = Input.GetAxis("Vertical");
        Vector3 movimento = new Vector3(movimentoHorizontal, 0.0f, movimentoVertical);
        rb.AddForce(movimento * velocidade);

    }

    void OnTriggerEnter(Collider other)
    {
        if  (other.gameObject.tag == "item")
            other.gameObject.SetActive(false); 
        count = count + 1;
        SetCountText();
    }

    void SetCountText()
    {
        countText.text = "Cartas clow: " + count.ToString();
        if (count >= 11)
        {
            winText.text = "VOCÊ COLETOU AS CARTAS!";
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    //[SerializeField] Score score;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] TextMeshProUGUI number;
    public int points;

    void Update()
    {
        number.text = "" + points.ToString();
        points = points + 0;
        if (points == 0)
        {
            text.text = "D-o your best";
        }
        if (points == 100)
        {
            text.text = "C-ome on!";
        }
        if (points == 200)
        {
            text.text = "B-east!";
        }
        if (points == 300)
        {
            text.text = "A-blaze!";
        }
        if (points == 400)
        {
            text.text = "S-lash!";
        }
    }

    private void OnTriggerEnter2D (Collider2D other)
    {

        if (other.gameObject.CompareTag("Enemy"))
        {
            points = points + 100;
            number.text = "" + points.ToString();
        }
    }
}

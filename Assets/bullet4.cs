using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bullet4 : MonoBehaviour
{
    public Text hitungText;
	private int hitung;
    // Start is called before the first frame update
    void Start()
    {
        hitung = 0;
		SetHitungText();
    }


    void OnTriggerEnter(Collider other)
	{
		if (other.tag == "traget") {
		
		hitung = hitung + 100;

		SetHitungText();
		}
	}

    void SetHitungText()
	{
		hitungText.text = "Score: " + hitung.ToString();
	}
}


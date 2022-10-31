using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet2 : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource hitSound;

    private void Awake()
    {
        hitSound = Instantiate(hitSound);
    }
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "target")
        hitSound.Play();
        Destroy(hitSound.gameObject, 2);
    }
}

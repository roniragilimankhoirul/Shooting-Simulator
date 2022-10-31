using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    public AudioSource hitSound;
    void Awake()
    {
       hitSound = Instantiate(hitSound);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag =="target")
            Destroy(collision.gameObject);
        hitSound.Play();
        Destroy(hitSound.gameObject, 2f);
    }
}

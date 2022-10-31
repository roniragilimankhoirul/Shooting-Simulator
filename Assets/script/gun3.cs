using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun3 : MonoBehaviour
{
    // Start is called before the first frame update
    public float shotForce = 1000f;
    public Rigidbody projectile;
    public Transform shotPos;
    public AudioSource shootSound;
    public Animator shotAnim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Rigidbody shot = Instantiate(projectile, shotPos.position, shotPos.rotation) as Rigidbody;
            shotAnim.ResetTrigger("ShotStates");
            shotAnim.SetTrigger("ShotStates");
            shot.AddForce(shotPos.forward * shotForce);
            shootSound.Play();
            Destroy(shot.gameObject, 2f);
        }
    }
}

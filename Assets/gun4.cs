using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun4 : MonoBehaviour
{
    public float shotForce = 1000f;
    public float moveSpeed = 10f;
    public Rigidbody projectile;
    public Transform shotPos;
    private bool isScoped = false;
    public GameObject scopeOverlay;
    public GameObject weaponCamera;
    public Animator LedakAnim;
    public Animator keker;
    public Camera mainCamera;

    public float scopedFOV = 15f;
    public float normalFOV;

    private Vector3 offset;
    [Range(0f, 10f)] public float turnSpeed = 1f;

    public AudioSource shootSound;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetButtonUp("Fire1"))
    {
        Rigidbody shot = Instantiate(projectile, shotPos.position, 
        shotPos.rotation) as Rigidbody;
        LedakAnim.SetTrigger("LoadState");
        shot.AddForce(shotPos.forward * shotForce);
        shootSound.Play();
        Destroy(shot.gameObject, 2f);
    }

    if (Input.GetButtonUp("Fire2"))

    {
        isScoped = !isScoped;
        keker.SetBool("Scoped", isScoped);

        if(isScoped)
            StartCoroutine(OnScoped());
        else
            OnUnscoped();
    }

    }

    void OnUnscoped()
    {
        scopeOverlay.SetActive(false);
        weaponCamera.SetActive(true);

        mainCamera.fieldOfView = normalFOV;
    }

    IEnumerator OnScoped()
    {
        yield return new WaitForSeconds(.15f);
       scopeOverlay.SetActive(true); 
       weaponCamera.SetActive(false);

    normalFOV = mainCamera.fieldOfView;
       mainCamera.fieldOfView = scopedFOV;
    }
}

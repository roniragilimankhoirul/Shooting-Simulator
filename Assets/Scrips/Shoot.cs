using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
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
public int movementSpeed;
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

            MovingRelativeToCamera();
      
        
        float speed = 0.1f;
        Quaternion currentRot = transform.rotation;

        Quaternion cameraRotation = Camera.main.transform.rotation;
        Quaternion targetCameraRotation = new Quaternion(0, cameraRotation.y, cameraRotation.z, cameraRotation.z);
        // transform.rotation = Quaternion.Slerp(currentRot, Camera.main.transform.rotation, speed);
         transform.rotation *= 
        Quaternion.AngleAxis(Input.GetAxis("Mouse X") * 2000 * Time.deltaTime, Vector3.up);


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

       

        void MovingRelativeToCamera(){
        float playerVerInput = Input.GetAxis("Vertical");
        float playerHorInput = Input.GetAxis("Horizontal");

        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;

        Vector3 forwardRelativeVerticalInput = forward * playerVerInput;
        Vector3 rightRelativeVerticalInput = right * playerHorInput;

        Vector3 cameraRelativeMovement = forwardRelativeVerticalInput + rightRelativeVerticalInput;

        transform.Translate(cameraRelativeMovement * movementSpeed * Time.deltaTime, Space.World);
    }
    }
}

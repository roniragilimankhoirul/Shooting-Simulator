using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

    public BoxCollider mainCollider;
    public GameObject musuhRig;
    public Animator animasiMusuh;


    // Start is called before the first frame update
    void Start()
    {
        GetPretelanRagdoll();
        RagdollOff();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "pelor")
        {
            RagdollOn();
        }
    }

    Collider[] ragDollColliders;
    Rigidbody[] ragDollRigidbodies;
    void GetPretelanRagdoll()
    {
        ragDollColliders = musuhRig.GetComponentsInChildren<Collider>();
        ragDollRigidbodies = musuhRig.GetComponentsInChildren<Rigidbody>();
    }

    void RagdollOn()
    {

        animasiMusuh.enabled = false;
        foreach (Collider col in ragDollColliders)
        {
            col.enabled = true;
        }

        foreach (Rigidbody rigid in ragDollRigidbodies)
        {
            rigid.isKinematic = false;
        }
        

        mainCollider.enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
    }

    void RagdollOff()
    {
        foreach (Collider col in ragDollColliders)
        {
            col.enabled = false;
        }

        foreach (Rigidbody rigid in ragDollRigidbodies)
        {
            rigid.isKinematic = true;
        }

        animasiMusuh.enabled = true;
        mainCollider.enabled = true;
        GetComponent<Rigidbody>().isKinematic = false;
    }
}

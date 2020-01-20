using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {
    private Rigidbody rb;
    private Vector3 Jump = new Vector3(0.0f, 2.0f, 0.0f);
    private bool IsGrounded;

    void Start() {
        rb = GetComponentInParent<Rigidbody>();
    }

    void Update() {
        OVRInput.Update();
        Controller();
    }

    void FixedUpdate() {
        OVRInput.FixedUpdate();
    }

    private void OnCollisionStay() {
        IsGrounded = true;
    }

    void Controller() {
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger)) {
            var currentP = GetComponentInParent<OVRPlayerController>().transform.position;
            currentP -= transform.forward * Time.deltaTime * 1.2f;
            GetComponentInParent<OVRPlayerController>().transform.position = currentP;
        }

        if (OVRInput.Get(OVRInput.Button.Up) && IsGrounded) {
            rb.AddForce(Jump * 2.0f, ForceMode.Impulse);
            IsGrounded = false;
        }
    }
}
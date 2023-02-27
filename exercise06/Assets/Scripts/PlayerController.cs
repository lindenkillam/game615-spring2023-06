using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameManager gm;
    public AudioSource playerCollectSound;

    // Start is called before the first frame update
    void Start() {
        playerCollectSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        // The following two lines of code create two variables that contain info
        // about the up, down, left and right buttons. hAxis will be -1 if left
        // is pressed, 1 if right is pressed and 0 if nothing is pressed. Same
        // sort of thing for up and down with vAxis.
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        // This line of code will make it so the gameObject moves forward/backwards
        // based on the vAxis. Because vAxis is 0 when up and down aren't pressed
        // unless those buttons are pressed, the amount we are telling unity to
        // move the gameObject will be zero because multiplying anything by will
        // be 0.
        // Note that the second parameter to the Translate function is Space.World.
        // For now, just go with this approach.
        gameObject.transform.Translate(gameObject.transform.forward * Time.deltaTime * gm.moveSpeed * vAxis, Space.World);

        // Do something similar for how much we will rotate on the y axis with
        // the hAxis. 
        gameObject.transform.Rotate(0, gm.rotateSpeed * Time.deltaTime * hAxis, 0);
    }

    // Unity will tell the function below to run under the following conditions:
    //  1. Two objects with colliders are colliding
    //  2. At least one of the objects' colliders are marked as "Is Trigger"
    //  3. At least one of the objects has a Rigidbody
    private void OnTriggerEnter(Collider other) {
        // 'other' is the name of the collider that just collided with the object
        // that this script ("PlayerController") is attached to. So the if statment
        // below checks to see that that object has the tag "coin". Remember that
        // the tags for GameObjects are assigned in the top left area of the
        // inspector when you select the obect.
        if (other.CompareTag("medkit")) {
            Destroy(other.gameObject);
            playerCollectSound.Play();
            gm.playerScore += 1;
        } else if (other.CompareTag("enemy")) {
            gm.lose = true;
        }
    }
}
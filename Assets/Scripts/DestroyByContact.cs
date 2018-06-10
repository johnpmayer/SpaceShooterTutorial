using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    // called when a collider (other) first touches this collider
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }
        // order in the following two statements doesn't matter, they just
        // "mark" an object to be destroyed at the end of the frame
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}

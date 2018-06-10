using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;

    // called when a collider (other) first touches this collider
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }

        Instantiate(explosion, transform.position, transform.rotation);

        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
        }
        
        // order in the following two statements doesn't matter, they just
        // "mark" an object to be destroyed at the end of the frame
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}

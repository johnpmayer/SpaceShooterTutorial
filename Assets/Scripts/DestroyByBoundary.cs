using UnityEngine;

public class DestroyByBoundary : MonoBehaviour
{
    // called when the other collider stops touching this object
    // in our game, it's when objects leave the object boundary
    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}

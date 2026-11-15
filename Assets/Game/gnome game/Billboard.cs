using UnityEngine;

// Makes the object always orient itself towards the active camera


namespace GnomeGame {
    public class Billboard : MonoBehaviour
    {
        // After everything else has been processed, garauntee this object's rotation
        void LateUpdate() {
            transform.LookAt(Camera.main.transform.position);
        }
    }
}
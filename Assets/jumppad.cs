using UnityEngine;

public class jumppad : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 300, 0));
    }
}

// Input.GetMouseButton(0); // 0 clic gauche
// public GameObject Prefab; demande un prefab pour avoir la référence
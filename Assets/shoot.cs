using UnityEngine;

public class shoot : MonoBehaviour
{

    public GameObject prefab;
    public Vector3 Deltaposition;
    public float velocity;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(prefab);
            bullet.transform.position = transform.position + Deltaposition;
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * velocity);
        }
        
    }      
        
 }
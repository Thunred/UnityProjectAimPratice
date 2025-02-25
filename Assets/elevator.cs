using NUnit.Framework.Constraints;
using UnityEngine;

public class elevator : MonoBehaviour
{
    public GameObject Floor1, Floor2;

    private float _timer;
    private bool IsElevatorON;
    private bool Up;

    
    void Update()
    {
        if (IsElevatorON && Up) 
        {
            _timer += Time.deltaTime;
            transform.position = Vector3.Lerp(Floor1.transform.position, Floor2.transform.position, _timer);
        }

        if (IsElevatorON && !Up)
        {
            _timer += Time.deltaTime;
            transform.position = Vector3.Lerp(Floor2.transform.position, Floor1.transform.position, _timer);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        IsElevatorON = true;
    }
    private void OnTriggerExit(Collider other)
    {
        IsElevatorON = false;
    }
}
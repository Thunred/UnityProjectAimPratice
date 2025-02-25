using UnityEngine;

public class caméramove : MonoBehaviour
{
    public GameObject FirstPersonPos, ThirdPersonPos;

    public bool FirstPersonVisible = false;

    private float _timer;


    void Update()
    {
        _timer += Time.deltaTime;
        if (FirstPersonVisible)
        {
            transform.position = Vector3.Lerp(ThirdPersonPos.transform.position, FirstPersonPos.transform.position, _timer);
        }
        else
        {
            transform.position = Vector3.Lerp(FirstPersonPos.transform.position, ThirdPersonPos.transform.position, _timer);
        }

        if (Input.GetKeyDown(KeyCode.F5))
        {
            FirstPersonVisible = true;
            _timer = 0;
        }
    }
}

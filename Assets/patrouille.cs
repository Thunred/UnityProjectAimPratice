using UnityEngine;

public class patrouille : MonoBehaviour
{
    public Vector3 Startpos;
    public Vector3 Endpos;

    private float _timer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        transform.position = Vector3.Lerp(Startpos, Endpos, _timer); // va a la pos de départ a celle d'arriver la valeur doit etre entre 0 et 1 _timer dans ce cas 
    }
}

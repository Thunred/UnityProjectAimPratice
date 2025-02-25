using UnityEngine;

public class spawner : MonoBehaviour
{
    private float _timer;
    public GameObject enemyspawn; // tableau possible :  public GameObject[] enemyspawn
    public GameObject Player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > 2)
        {
            GameObject spawn = Instantiate(enemyspawn);
            spawn.transform.position = transform.position;
            spawn.GetComponent<enemy>().Player = Player;
            _timer = 0;
        }
    }
}

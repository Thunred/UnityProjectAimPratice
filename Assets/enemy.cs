using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    public int hp;
    public GameObject firedefault;
    public GameObject Player;


    private void Start()
    {
        int maxhp = hp;
        
    }
    void Update()
    {
        GetComponent<NavMeshAgent>().SetDestination(Player.transform.position);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "bullet") 
        {   
            hp--;
            print("hp : "+ hp);
            Destroy(other.gameObject);

            if (hp <= 0)
            {
                GameObject fire = Instantiate(firedefault);
                fire.transform.position = transform.position;
                Destroy(this.gameObject);
            }
        }

    }
}

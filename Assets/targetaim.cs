using UnityEngine;

public class targetaim : MonoBehaviour
{
	private ShootingStand stand;

	void Start()
	{
		stand = Object.FindAnyObjectByType<ShootingStand>();
		if (stand == null)
		{
			Debug.LogError("Aucun ShootingStand trouv� dans la sc�ne !");
		}
	}

	void OnMouseDown()
	{
		if (stand != null)
		{
			stand.TargetHit(gameObject);
		}
	}
}

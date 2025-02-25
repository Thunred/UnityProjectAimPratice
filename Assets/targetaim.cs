using UnityEngine;

public class targetaim : MonoBehaviour
{
	private ShootingStand stand;

	void Start()
	{
		stand = Object.FindAnyObjectByType<ShootingStand>();
		if (stand == null)
		{
			Debug.LogError("Aucun ShootingStand trouvé dans la scène !");
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

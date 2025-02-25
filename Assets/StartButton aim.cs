using UnityEngine;

public class StartButton : MonoBehaviour
{
	public ShootingStand testZone;  // Référence à la zone de test
	public Camera playerCam;

	void Update()
	{
		if (Input.GetMouseButtonDown(0)) // Clic gauche
		{
			Ray ray = playerCam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit))
			{
				if (hit.transform == transform) // Si on clique sur l'objet
				{
					Debug.Log("Tracking boule activer !");
					testZone.StartGame();
				}
			}
		}
	}
}

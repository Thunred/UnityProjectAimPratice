using UnityEngine;
using System.Collections;

public class TestZone : MonoBehaviour
{
	public PlayerController2 playerController;
	public GameObject targetSpherePrefab;  //  Remplace targetSphere par un PREFAB !
	public Camera playerCam;
	public float scoreIncreaseRate = 1f;
	public float trackingDuration = 30f;

	private bool gameActive = false;
	private Collider zoneCollider;
	private GameObject currentTargetSphere;  // Stocke la sphère actuelle

	void Start()
	{
		zoneCollider = GetComponent<Collider>();
	}

	void Update()
	{
		if (gameActive && currentTargetSphere != null)
		{

			{
				
			}
		}
	}

	bool IsCameraInZone()
	{
		return zoneCollider.bounds.Contains(playerCam.transform.position);
	}

	public void StartGame()
	{
		Debug.Log("Tracking start !");
		gameActive = true;
		SpawnTargetSphere();
		StartCoroutine(StopGameAfterTime(trackingDuration));
	}

	IEnumerator StopGameAfterTime(float time)
	{
		yield return new WaitForSeconds(time);
		gameActive = false;

		if (currentTargetSphere != null)
		{
			Destroy(currentTargetSphere);  // Détruit la sphère à la fin du tracking
		}

		Debug.Log("Tracking terminé !");
	}

	void SpawnTargetSphere()
	{
		Bounds bounds = zoneCollider.bounds;

		Vector3 randomPosition = new Vector3(
			Random.Range(bounds.min.x, bounds.max.x),
			bounds.center.y,
			Random.Range(bounds.min.z, bounds.max.z)
		);

		currentTargetSphere = Instantiate(targetSpherePrefab, randomPosition, Quaternion.identity);
	}
}

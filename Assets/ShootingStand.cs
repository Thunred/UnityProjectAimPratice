using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShootingStand : MonoBehaviour
{
	public GameObject targetPrefab; // Prefab de la sphère
	public Transform spawnArea; // Zone de spawn (doit avoir un Collider)
	public int maxTargets = 5; // Nombre max de sphères en même temps
	public float spawnInterval = 1.5f; // Temps entre chaque apparition
	public float gameDuration = 30f; // Durée totale du jeu
	private int score = 0;
	private bool gameActive = false;
	private List<GameObject> activeTargets = new List<GameObject>(); // Liste des cibles actives

	void Start()
	{
		if (spawnArea == null)
		{
			Debug.LogError("SpawnArea n'est pas assigné !");
		}
	}

	public void StartGame()
	{
		Debug.Log("Jeu commencé !");
		gameActive = true;
		score = 0;
		StartCoroutine(SpawnTargets());
		StartCoroutine(StopGameAfterTime(gameDuration));
	}

	IEnumerator SpawnTargets()
	{
		while (gameActive)
		{
			if (activeTargets.Count < maxTargets)
			{
				SpawnTarget();
			}
			yield return new WaitForSeconds(spawnInterval);
		}
	}

	void SpawnTarget()
	{
		if (spawnArea == null) return;

		Bounds bounds = spawnArea.GetComponent<Collider>().bounds;
		Vector3 randomPosition = new Vector3(
			Random.Range(bounds.min.x, bounds.max.x),
			bounds.min.y + 1, // Légèrement au-dessus du sol
			Random.Range(bounds.min.z, bounds.max.z)
		);

		GameObject newTarget = Instantiate(targetPrefab, randomPosition, Quaternion.identity);
		newTarget.tag = "Target";
		activeTargets.Add(newTarget);
	}

	public void TargetHit(GameObject target)
	{
		if (!gameActive) return;

		score += 1;
		Debug.Log("Score du stand: " + score);

		activeTargets.Remove(target);
		Destroy(target);
	}

	IEnumerator StopGameAfterTime(float time)
	{
		yield return new WaitForSeconds(time);
		gameActive = false;
		DestroyAllTargets();
		Debug.Log("Jeu terminé ! Score final: " + score);
	}

	void DestroyAllTargets()
	{
		foreach (GameObject target in activeTargets)
		{
			Destroy(target);
		}
		activeTargets.Clear();
	}
}

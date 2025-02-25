using UnityEngine;

public class tracking : MonoBehaviour
{
	public float moveSpeed = 2f;
	private Vector3 targetPosition;

	void Start()
	{
		SetNewTargetPosition();
	}

	void Update()
	{
		MoveTowardsTarget();
	}

	void MoveTowardsTarget()
	{
		transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
		if (transform.position == targetPosition)
		{
			SetNewTargetPosition();
		}
	}

	void SetNewTargetPosition()
	{
		targetPosition = new Vector3(
			Random.Range(-10f, 10f),
			transform.position.y,
			Random.Range(-10f, 10f)
		);
	}
}

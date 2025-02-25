using UnityEngine;
using UnityEngine.UI;

public class PlayerController2 : MonoBehaviour
{
	public float MoveSpeed;
	public float RotationSpeed;
	public float JumpHeight;
	public Transform cameraTransform; 
	private float rotationX = 0f;

	void Update()
	{
		// Gestion de la rotation horizontale (axe Y pour le personnage)
		float horizontal = Input.GetAxis("Horizontal") * RotationSpeed * Time.deltaTime;
		float vertical = Input.GetAxis("Vertical") * RotationSpeed * Time.deltaTime;

		transform.Translate(horizontal, 0, vertical);

		// Calcul de la nouvelle vitesse en fonction des axes (zqsd et flèches)
		Vector3 CurrentSpeed =
			transform.forward * Input.GetAxis("Vertical") * MoveSpeed +
			transform.right * Input.GetAxis("Horizontal") * MoveSpeed;

		CurrentSpeed.y = GetComponent<Rigidbody>().linearVelocity.y;  // Garder la vitesse verticale intacte

		if (Input.GetKeyDown(KeyCode.Space))
		{
			CurrentSpeed.y += JumpHeight; 
		}

		GetComponent<Rigidbody>().linearVelocity = CurrentSpeed;

		// Rotation de la caméra sur l'axe X (haut/bas de la souris)
		float mouseY = Input.GetAxis("Mouse Y") * RotationSpeed;
		rotationX -= mouseY;
		rotationX = Mathf.Clamp(rotationX, -90f, 90f);  // Limite la rotation pour éviter une inversion de la caméra
		cameraTransform.localRotation = Quaternion.Euler(rotationX, 0, 0);  // Applique la rotation à la caméra

		// Rotation du personnage sur l'axe Y (mouvement horizontal de la souris)
		float mouseX = Input.GetAxis("Mouse X") * RotationSpeed;
		transform.Rotate(0, mouseX, 0);  // Applique la rotation au personnage
	}

	public void Jump()
	{
		GetComponent<Rigidbody>().AddForce(new Vector3(0, 1000, 0));
	}
	public Text scoreText;
	private int score = 0;
	public void AddScore(int value)
	{
		score += value;
		scoreText.text = "Score: " + score;
		Debug.Log("score :"+ scoreText.text);
	}
}

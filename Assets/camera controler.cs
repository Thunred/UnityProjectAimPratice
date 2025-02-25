using UnityEngine;

public class CameraController : MonoBehaviour
{
	public float speed = 5f;
	public float mouseSensitivity = 2f;

	private float xRotation = 0f;
	private Transform playerBody;

	void Start()
	{
		Cursor.lockState = CursorLockMode.Locked; // Cache le curseur
		playerBody = transform; // Utilise la caméra comme "corps"
	}

	void Update()
	{
		// 🎯 Gestion de la souris (rotation)
		float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
		float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

		xRotation -= mouseY;
		xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Empêche de regarder trop haut/bas
		transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
		playerBody.Rotate(Vector3.up * mouseX); // Rotation horizontale

		// 🎮 Déplacement (ZQSD / WASD)
		float moveX = Input.GetAxis("Horizontal"); // Gauche/Droite (A-D)
		float moveZ = Input.GetAxis("Vertical");   // Avant/Arrière (W-S)

		Vector3 move = playerBody.forward * moveZ + playerBody.right * moveX;
		move.y = 0f; // ❗ Empêche le déplacement vertical
		playerBody.position += move * speed * Time.deltaTime;
	}
}

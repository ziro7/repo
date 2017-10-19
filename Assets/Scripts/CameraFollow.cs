using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform cameraMain, player, cameraArm;

	private float mouseX = 90;
	private float mouseY = 0;
	public float mouseSensitivity = 10f;
	public float mouseYPosition = 1f;

	private float moveFB, moveLR;
	public float moveSpeed = 1f;

	[SerializeField] private float zoom = -6;
	public float zoomSpeed = 2;

	public float zoomMin = -2f;
	public float zoomMax = -12f;

	public float rotationSpeed = 5f;



	// Use this for initialization
	void Start()
	{



	}

	// Update is called once per frame
	void Update()
	{

		zoom += Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;

		if (zoom > zoomMin)
			zoom = zoomMin;

		if (zoom < zoomMax)
			zoom = zoomMax;

		cameraMain.transform.localPosition = new Vector3(0, 0, zoom);

		if (Input.GetMouseButton(1))
		{
			mouseX += Input.GetAxis("Mouse X") * mouseSensitivity;
			mouseY -= Input.GetAxis("Mouse Y") * mouseSensitivity;
		}

		mouseY = Mathf.Clamp(mouseY, -40f, 60f);
		cameraMain.LookAt(cameraArm);
		cameraArm.localRotation = Quaternion.Euler(mouseY, mouseX, 0);

		moveFB = Input.GetAxis("Vertical") * moveSpeed;
		moveLR = Input.GetAxis("Horizontal") * moveSpeed;

		Vector3 movement = new Vector3(moveLR, 0, moveFB);
		movement = player.rotation * movement;
		player.GetComponent<CharacterController>().Move(movement * Time.deltaTime);
		cameraArm.position = new Vector3(player.position.x, player.position.y + mouseYPosition, player.position.z);

		if (Input.GetAxis("Vertical") > 0 | Input.GetAxis("Vertical") < 0)
		{

			Quaternion turnAngle = Quaternion.Euler(0, cameraArm.eulerAngles.y, 0);

			player.rotation = Quaternion.Slerp(player.rotation, turnAngle, Time.deltaTime * rotationSpeed);

		}

	}
}
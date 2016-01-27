using UnityEngine;
using System.Collections;

public class FPSMouseLook : MonoBehaviour {

	public float mouseSensitivity = 5f;
	public float xRotation;
	public float yRotation;
	public float currXRotation;
	public float currYRotation;
	public float xRotationV;
	public float yRotationV;
	public float lookSmoothDamp = 0.1f;
	public Transform camTransform;
	public Transform initCamTransform;

	public LeanLeftRight leanLeftRight;

	// Update is called once per frame
	void Update () {

		if(leanLeftRight.allowedToLean)
		{
			xRotation += Input.GetAxis("Mouse X") * mouseSensitivity;
			yRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;

			yRotation = Mathf.Clamp(yRotation, -90, 80);

			currXRotation = Mathf.SmoothDamp(currXRotation, xRotation, ref xRotationV, lookSmoothDamp);
			currYRotation = Mathf.SmoothDamp(currYRotation, yRotation, ref yRotationV, lookSmoothDamp);

			transform.rotation = Quaternion.Euler(0, currXRotation, 0);
			camTransform.rotation = Quaternion.Euler(-currYRotation, currXRotation, 0);
			initCamTransform.rotation = Quaternion.Euler(-currYRotation, currXRotation, 0);
		}
	}
}

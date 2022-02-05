using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    private InputMaster controls; // Inputs NEW INPUT SYSTEM
    public float mouseSensitivityX = 100f; // the sensitivity of the mouse
    public float mouseSensitivityY = 100f; // the sensitivity of the mouse

    public float controllerLookSensitivity = 2000f; // this sensitivity works well for controller analog sticks
    public Transform playerBody;


    float xRotation = 0f;

    void Awake()
    {
        controls = new InputMaster(); // you have to intialize the controls in awake because Unity doesn't allow you to just click and drag via the Inspector. IK it's some BS.
    }

    private void OnEnable()
    {
        controls.Enable(); 
    }
    private void OnDisable()
    {
        controls.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        //hide and lock the cursor to the middle of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //NEW INPUT SYSTEM
        //float mouseX = controls.Player.Look.ReadValue<Vector2>().x * mouseSensitivityX * Time.deltaTime;
        //float mouseY = controls.Player.Look.ReadValue<Vector2>().y * mouseSensitivityY * Time.deltaTime;
        //Debug.Log(controls.Player.Look.ReadValue<Vector2>());
        
        //ANOTHER WAY TO READ MOUSE INPUT TRYING TO MAKE IT SMOOTH LIKE THE OLD INPUT SYSTEM. BUT THIS DOESN'T WORK.
        //float mouseX = controls.Player.MouseX.ReadValue<float>() * mouseSensitivity * Time.deltaTime;
        //float mouseY = controls.Player.MouseY.ReadValue<float>() * mouseSensitivity * Time.deltaTime;
        //Debug.Log(controls.Player.MouseX.ReadValue<float>() + " " + controls.Player.MouseY.ReadValue<float>());
        
        //OLD INPUT SYSTEM
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivityX * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivityY * Time.deltaTime;
        //Debug.Log(Input.GetAxis("Mouse X") + " " + Input.GetAxis("Mouse Y"));

        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f,0f);
        playerBody.Rotate(Vector3.up * mouseX);
        
    }

    
}

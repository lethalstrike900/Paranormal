using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
  public float speed;

    private Rigidbody rb;
	private GameObject player;
	public KeyCode moveForward;
	public KeyCode moveLeft;
	public KeyCode moveRight;
	public KeyCode moveBackward;
	public KeyCode run;
    
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;

		
    }

    void Update ()
    {
	/*
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        rb.AddForce (movement * speed);
		*/
		
		Movement();
		Run();
   
    }


	void Movement()
	{
       /* float translation = Input.GetAxis("Vertical") * speed;
        float straffe = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;
        transform.Translate(straffe, 0, translation);*/
		if (Input.GetKey (moveForward)) {
			gameObject.transform.position += gameObject.transform.forward * speed * Time.deltaTime;
			}
		if (Input.GetKey (moveRight)) {
			gameObject.transform.position += gameObject.transform.right * speed * Time.deltaTime;
			}
		if (Input.GetKey (moveLeft)) {
			gameObject.transform.position -= gameObject.transform.right * speed * Time.deltaTime;
			}
		if (Input.GetKey (moveBackward)) {
			gameObject.transform.position -= gameObject.transform.forward * speed * Time.deltaTime;
			}
	}

	void Run()
	{
		if (Input.GetKeyDown(run))
			{
				speed *= 2;
				
			}
		if (Input.GetKeyUp(run))
					{
						speed /= 2;
					}
	}

}

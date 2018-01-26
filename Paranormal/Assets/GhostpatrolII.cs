using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostpatrolII : MonoBehaviour {

 public Transform[] Wps;
    public float speed;
    public int currentwp;
    public bool patrol = false;
    public Vector3 FaceDir;
    public Vector3 MoveDir;
    public Vector3 Velocity;

  
    public bool chase = false;
    public float pSightDist = 2;
    public float bSightDist = 1;
   
    UnityEngine.AI.NavMeshAgent nav;
	// Use this for initialization
	void Start () {
     
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        Patrol();
        Vision();
        gameObject.transform.position += gameObject.transform.forward * speed * Time.deltaTime;
        Chase();
    }

    void Patrol()
    {
        if (patrol == true)
        {
            speed = 2;

            if (currentwp < Wps.Length)
            {
                
                FaceDir = Wps[currentwp].position;
                MoveDir = FaceDir - transform.position;
                Velocity = GetComponent<Rigidbody>().velocity;
                if (MoveDir.magnitude < 1)
                {
                    currentwp++;
                }
                else
                {
                    Velocity = MoveDir.normalized * speed;
                }

            }
            else
            {
                if (patrol)
                {
                    currentwp = 0;
                }
                else
                {
                    Velocity = Vector3.zero;
                }

            }
           
            GetComponent<Rigidbody>().velocity = Velocity;
            transform.LookAt(FaceDir);
        }
        if (patrol == false)
        {
            //speed = 0;
           // gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

    void Vision()

    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward * pSightDist, Color.red);
        Debug.DrawRay(transform.position, (transform.forward + transform.right).normalized * pSightDist, Color.red);
        Debug.DrawRay(transform.position, (transform.forward - transform.right).normalized * pSightDist, Color.red);
        Debug.DrawRay(transform.position, transform.forward * bSightDist, Color.green);
        Debug.DrawRay(transform.position, (transform.forward + transform.right).normalized * bSightDist, Color.green);
        Debug.DrawRay(transform.position, (transform.forward - transform.right).normalized * bSightDist, Color.green);
        
        if (Physics.Raycast(transform.position, transform.forward, out hit, pSightDist))
        {
            Debug.Log(hit.collider.tag);

            if (hit.collider.gameObject.tag == "Player")
            {
                patrol = false;
                chase = true;
                StartCoroutine(StopChase());

            }

        }

        if (Physics.Raycast(transform.position, (transform.forward + transform.right).normalized, out hit, pSightDist))

        {
            Debug.Log(hit.collider.tag);

            if (hit.collider.gameObject.tag == "Player")

            {
                patrol = false;
                chase = true;
                StartCoroutine(StopChase());
            }

        }

        if (Physics.Raycast(transform.position, (transform.forward - transform.right).normalized, out hit, pSightDist))

        {
            Debug.Log(hit.collider.tag);
            if (hit.collider.gameObject.tag == "Player")
            {
                patrol = false;
                chase = true;
                StartCoroutine(StopChase());
            }
        }
        /*
        if (Physics.Raycast(transform.position, transform.forward, out hit, bSightDist))

        {

            Debug.Log(hit.collider.tag);

            if (hit.collider.gameObject.tag == "Enemy3")

            {

                patrol = true;

            }

        }

        if (Physics.Raycast(transform.position, (transform.forward + transform.right).normalized, out hit, bSightDist))

        {

            Debug.Log(hit.collider.tag);

            if (hit.collider.gameObject.tag == "Enemy3")

            {
                patrol = true;

            }

        }

        if (Physics.Raycast(transform.position, (transform.forward - transform.right).normalized, out hit, bSightDist))

        {

            Debug.Log(hit.collider.tag);

            if (hit.collider.gameObject.tag == "Enemy3")

            {

                patrol = true;


            }

        }
        */
    }

    IEnumerator StopChase()
    {
        
        yield return new WaitForSeconds(5.0f);
        chase = false;
        patrol = true;
    }
    void Chase()
    {
        if (chase == true)
        {
            speed = 3;
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
        }
    }
}

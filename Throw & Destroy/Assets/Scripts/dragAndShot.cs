using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragAndShot : MonoBehaviour
{
    
    Rigidbody2D rb;

    public TrajectoryLine tl;
   [Header("Power")]
    public float power = 10f;
    public Vector2 minPower;
    public Vector2 maxPower;
    [SerializeField]public int Level;

    Camera cam;
    Vector2 force;
    Vector3 startPoint;
    Vector3 endPoint;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        tl = GetComponent<TrajectoryLine>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            startPoint.z = 15;
            Debug.Log(startPoint);
           
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 currentPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            startPoint.z = 15;
            tl.RenderLine(startPoint, currentPoint);
        }
        if (Input.GetMouseButtonUp(0))
        {
            endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            endPoint.z = 15;

            force = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x), Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y));
            rb.AddForce(force * power, ForceMode2D.Impulse);
            tl.EndLine();
        }
    }
}

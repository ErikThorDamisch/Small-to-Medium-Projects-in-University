using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    //public List<Transform> players;

    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;

    [SerializeField] private Vector3 offsetCamera;
    [SerializeField] float minimunOrtohraphicSize = 4f;
    [SerializeField] float maximumOrtohraphicSize = 9f;

    private float boundsDistance;
    private Vector3 velocity;
    Camera camera;

    void Start()
    {
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");
        player3 = GameObject.Find("Player3");
        player4 = GameObject.Find("Player4");
        camera = GetComponent<Camera>();
    }

    //LateUpdate, Updates after all animation on frame is done.
    void LateUpdate()
    {
        Vector3 midPoint = GetMidPoint();

        Vector3 newPosition = midPoint + offsetCamera;

        transform.position = new Vector3(Mathf.Lerp(transform.position.x,newPosition.x,Time.deltaTime), Mathf.Lerp(transform.position.y, newPosition.y, Time.deltaTime), Mathf.Lerp(transform.position.z, newPosition.z, Time.deltaTime));//Vector3.SmoothDamp(transform.position, newPosition, ref velocity, .5f);
        
        Zoom();
    }

    void Zoom()
    {
        float newZoom = Mathf.Lerp(minimunOrtohraphicSize, maximumOrtohraphicSize, boundsDistance / 50f);
        camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, newZoom, Time.deltaTime);
    }

    Vector3 GetMidPoint()
    {

        var bounds = new Bounds(player1.transform.position, Vector3.zero);
            bounds.Encapsulate(player2.transform.position);
        if (PlayerPrefs.GetInt("PlayerNumber") == 4)
        {
            bounds.Encapsulate(player3.transform.position);
            bounds.Encapsulate(player4.transform.position);
        }

        boundsDistance = bounds.size.x;
        return bounds.center;
    }
}

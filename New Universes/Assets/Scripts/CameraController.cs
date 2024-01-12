using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float panSpeed = 20f;
    [SerializeField] private float panBoarderThickness = 10f;
    [SerializeField] private Vector2 panLimit;

    [SerializeField] private float scrollSpeed = 2f;
    [SerializeField] private float scale = 13f;
    [SerializeField] private float minScale = 5f;
    [SerializeField] private float maxScale = 50f;

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBoarderThickness)
        {
            pos.y += panSpeed * Time.deltaTime;
        }
        else if (Input.GetKey("s") || Input.mousePosition.y <= panBoarderThickness)
        {
            pos.y -= panSpeed * Time.deltaTime;
        }

        if (Input.GetKey("a") || Input.mousePosition.x <= panBoarderThickness)
        {
            pos.x -= panSpeed * Time.deltaTime;
        }
        else if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBoarderThickness)
        {
            pos.x += panSpeed * Time.deltaTime;
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        scale += scroll * scrollSpeed * Time.deltaTime;
        scale = Mathf.Clamp(scale, minScale, maxScale);
        Camera.main.orthographicSize = scale;

        pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
        pos.y = Mathf.Clamp(pos.y, -panLimit.y, panLimit.y);

        transform.position = pos;
    }
}

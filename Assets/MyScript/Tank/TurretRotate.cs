using UnityEngine;

public class TurretRotate : MonoBehaviour
{
    Plane plane = new Plane(Vector3.up, 0);
    Vector3 worldPosition;
    // Start is called before the first frame update

    // Update is called once per frame
    public void DoUpdate()
    {
        float distance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out distance))
        {
            worldPosition = ray.GetPoint(distance);
        };
        worldPosition.y = GetComponent<Transform>().position.y;
        GetComponent<Transform>().LookAt(worldPosition);
    }
}

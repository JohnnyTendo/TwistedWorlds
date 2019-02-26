using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject background;
    public Transform target;
    public Vector3 offset;
    public Quaternion rotationOffset;
    Transform cameraTransform;

    void Start()
    {
        cameraTransform = GetComponent<Transform>();
        background.SetActive(true);
    }

    void Update()
    {
        cameraTransform.position = target.position + offset;
        cameraTransform.rotation = rotationOffset;
    }
}

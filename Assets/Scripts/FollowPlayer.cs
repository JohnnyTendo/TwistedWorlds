using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject lightBackground;
    public GameObject darkBackground;
    public Transform target;
    public Vector3 offset;
    public Quaternion rotationOffset;
    Transform cameraTransform;

    void Start()
    {
        cameraTransform = GetComponent<Transform>();
    }

    void Update()
    {
        cameraTransform.position = target.position + offset;
        cameraTransform.rotation = rotationOffset;
        if(GameController.instance.isMirrored)
        {
            lightBackground.SetActive(false);
            darkBackground.SetActive(true);
        }
        if (!GameController.instance.isMirrored)
        {
            lightBackground.SetActive(true);
            darkBackground.SetActive(false);
        }
    }
}

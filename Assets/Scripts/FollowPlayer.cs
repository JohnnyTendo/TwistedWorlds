using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    #region Singleton

    public static FollowPlayer instance;

    void Awake()
    {
        instance = this;
    }
    #endregion
    #region BackgroundSystem
    public GameObject[] backgrounds;
    GameObject activeBackground;
    int backgroundIndex;
    #endregion

    public Transform target;
    public Vector3 offset;
    public Quaternion rotationOffset;
    Transform cameraTransform;

    void Start()
    {
        backgroundIndex = 0;
        backgrounds[0].SetActive(true);
        cameraTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        cameraTransform.position = new Vector3(target.position.x, target.position.y, +10);
    }


    public void CorruptionProgress()
    {
        if (backgroundIndex < backgrounds.Length)
        {
            backgroundIndex++;
            for (int i = 0; i < backgrounds.Length; i++)
            {
                if (i == backgroundIndex)
                {
                    backgrounds[i].SetActive(true);
                }
                else
                {
                    backgrounds[i].SetActive(false);
                }
            }
        }
    }
}

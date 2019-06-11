using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBody : MonoBehaviour
{
    public float recordTime = 5f;
    public GameObject deathFog;
    bool isRewinding = false;
    List<PointInTime> pointsInTime;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pointsInTime = new List<PointInTime>();
    }

    private void FixedUpdate()
    {
        if (isRewinding)
            Rewind();
        else
            Record();
    }

    void Record()
    {
        if (pointsInTime.Count > Mathf.Round(recordTime / Time.fixedDeltaTime))
        {
            pointsInTime.RemoveAt(pointsInTime.Count-1);
        }
        pointsInTime.Insert(0, new PointInTime(transform.position, transform.rotation));
    }

    void Rewind()
    {
        if (pointsInTime.Count > 0)
        {
            PointInTime pointInTime = pointsInTime[0];
            transform.position = pointInTime.position;
            transform.rotation = pointInTime.rotation;
            pointsInTime.RemoveAt(0);
        }
        else
        {
            StopRewind();
        }
    }

    /*void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            StartRewind();
        }
        if (Input.GetKeyUp(KeyCode.Return))
        {
            StopRewind();
        }
    }*/

    public void StartRewind()
    {
        deathFog.SetActive(true);
        isRewinding = true;
        rb.isKinematic = true;
    }

    public void StopRewind()
    {
        deathFog.SetActive(false);
        isRewinding = false;
        rb.isKinematic = false;
    }
}

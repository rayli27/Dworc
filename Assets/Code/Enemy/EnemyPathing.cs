using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    public Transform[] WayPoints;
    public float moveSpeed = 2f;
    public float rotationSpeed = 2f;
    private int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = WayPoints[index].transform.position;
    }

    void Update()
    {
        EnemyMove();    
    }

    void EnemyMove()
    {
        float offset = 90f;
        if(index <= WayPoints.Length-1)
        {
            Vector2 direction = WayPoints[index].transform.position;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 180f;
            Quaternion rotation = Quaternion.AngleAxis(angle + offset, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

            transform.position = Vector2.MoveTowards(transform.position, WayPoints[index].transform.position, moveSpeed * Time.deltaTime);
            if (transform.position == WayPoints[index].transform.position)
            {
                index+= 1;
            }
        }
    }
}

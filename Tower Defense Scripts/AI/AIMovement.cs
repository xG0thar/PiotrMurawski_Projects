using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AIMovement : MonoBehaviour, IMove
{
    [SerializeField]
    private Transform destination;
    [SerializeField]
    private float speed = 0.05f;
    private Rigidbody2D rigidbody2d;
    [SerializeField]
    private Path path;
    public int pathIndex;
    public int livesToLoose = 1;

    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        pathIndex = 0;
    }

    private void Update()
    {
        if(destination != null)
        {
            Move();
        }
        else
        {
            GetDestination();
        }
    }

    public void EndOfPath()
    {
        Debug.Log("End of path");
        BaseReachedEventInfo brei = new BaseReachedEventInfo(livesToLoose);
        EventsManager.FireEvent(Event_Type.base_reached_Event, brei);
    }

    public void GetDestination()
    {
        destination = path.GetNextPathPoint(pathIndex, this);
    }

    public void Move()
    {
        float distance = Vector2.Distance(transform.position, destination.position);
        if(distance <= 0.2f)
        {
            pathIndex++;
            destination = null;
            return;
        }
        Vector2 direction = (destination.position - transform.position).normalized;
        direction *= speed * Time.deltaTime;
        rigidbody2d.AddForce(direction, ForceMode2D.Force);
    }

    public void InjectPath(Path _path)
    {
        path = _path;
    }
}

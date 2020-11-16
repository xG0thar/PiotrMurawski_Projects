using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MagicOrbProjectileMovement : MonoBehaviour, IProjectileMove, IReach, ITargetAquired
{
    [SerializeField]
    private Transform _target;
    private Rigidbody2D rigidbody2d;
    private float speed;

    private void Awake()
    {
        speed = 1f;
        rigidbody2d = GetComponent<Rigidbody2D>();
        //GetComponent<IProjectileSeek>().SubscribeForTarget(this);
    }

    private void Update()
    {
        if (HasTarget())
        {
            if (DistanceToTarget() < 0.5f)
            {
                TargetReached();
            }
            Vector2 direction = (_target.transform.position - transform.position).normalized;
            Move(direction);
            Rotate(direction);
        }
        else
        {
            TargetLost();
        }
    }

    public void Move(Vector2 direction)
    {
        direction *= speed * Time.deltaTime;
        rigidbody2d.AddForce(direction, ForceMode2D.Force); //Zamienic na objectpooler
    }

    public void TargetAquired(Transform target)
    {
        _target = target;
    }

    public void TargetLost()
    {
        Destroy(this.gameObject); //Zamienic na objectpooler
    }

    public void TargetReached()
    {
        _target.GetComponent<AILife>().Damage(60);
        Destroy(this.gameObject);
    }

    public bool HasTarget()
    {
        return (_target != null);
    }

    private void Rotate(Vector2 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public void Move()
    {
        throw new System.NotImplementedException();
    }

    private float DistanceToTarget()
    {
        return Vector2.Distance(transform.position, _target.position);
    }
}

using UnityEngine;

public class ClusterPatrol : MonoBehaviour
{
    [SerializeField] private EnemyDataSo clusterPatrolData;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;

    private Vector2 positionA;
    private Vector2 positionB;
    private Vector2 currentTarget;

    private bool isGoingToB;
    private bool startGoingToB = true;
    private const float ArriveThreshold = 0.1f;


    private void Start()
    {
        positionA = pointA.position;
        positionB = pointB.position;
        isGoingToB = startGoingToB;

        if (isGoingToB)
        {
            currentTarget = positionB;
        }
        else
        {
            currentTarget = positionA;
        }
        spriteRenderer.flipX = (currentTarget.x < rb.position.x);

    }

    private void FixedUpdate()
    {
        Vector2 next = Vector2.MoveTowards(rb.position, currentTarget, clusterPatrolData.MoveSpeed * Time.fixedDeltaTime);

        rb.MovePosition(next);

        if (Vector2.Distance(rb.position, currentTarget) < ArriveThreshold)
        {
            isGoingToB = !isGoingToB;
            if (isGoingToB)
            {
                currentTarget = positionB;
            }
            else
            {
                currentTarget = positionA;

            }
            spriteRenderer.flipX = (currentTarget.x < rb.position.x);

        }
    }

    public void SetStartDirection(bool goToB)
    {
        startGoingToB = goToB;
    }
}

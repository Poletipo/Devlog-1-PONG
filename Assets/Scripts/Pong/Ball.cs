using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour {

    public delegate void BallEvent(int goalIndex);
    public BallEvent OnBallScoring;


    public float initialSpeed = 5f;



    float speed;
    float Launchdirection = -1;
    Vector3 direction;
    bool firstStrike = false;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(ResetBall());
    }

    // Update is called once per frame
    void Update()
    {

        rb.transform.position += direction * speed * Time.deltaTime;

        if (transform.position.magnitude > 15f) {
            StartCoroutine(ResetBall());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collider = collision.collider.gameObject;
        if (collider.layer == LayerMask.NameToLayer("Wall")) {
            //direction = Vector3.Reflect(direction, (Vector3)collision.contacts[0].normal);
            direction = direction - 2.0f * (Vector3)collision.contacts[0].normal * Vector3.Dot(direction, collision.contacts[0].normal);
        }
        else if (collider.layer == LayerMask.NameToLayer("Goal")) {
            OnBallScoring?.Invoke(collider.GetComponent<Goal>().index);
        }
        else {
            if (!firstStrike) {
                speed = initialSpeed * 2f;
                firstStrike = true;
            }

            Vector3 surfaceAngle = (Vector3.left * direction.x).normalized;

            direction = ((transform.position - collider.transform.position).normalized + surfaceAngle).normalized;
        }

    }

    public IEnumerator ResetBall()
    {
        transform.position = Vector3.zero;
        speed = 0;
        firstStrike = false;
        Launchdirection = -Launchdirection;

        yield return new WaitForSeconds(1);

        direction = new Vector3(Launchdirection, Random.Range(-1.0f, 1.0f)).normalized;
        speed = initialSpeed;
    }


}

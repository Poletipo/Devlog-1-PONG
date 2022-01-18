using UnityEngine;

public class Pallets : MonoBehaviour {

    public int playerIndex;
    public float speed = 10f;

    public float accelerationAI = 3f;

    Ball ball;

    float input;
    float yMax;
    Vector3 pos;
    public float maxPercentScreen = 0.9f;

    // Start is called before the first frame update
    void Start()
    {
        Camera cam = Camera.main;
        float yScale = transform.localScale.y;
        yMax = (cam.orthographicSize - (yScale / 2)) * maxPercentScreen;
        pos = transform.position;


        ball = GameObject.FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerIndex < 2) {
            input = Input.GetAxisRaw("Vertical" + playerIndex);
        }
        else {

            float xDistance = Mathf.Abs(ball.transform.position.x - transform.position.x);

            float factor = Mathf.Clamp01(Mathf.InverseLerp(12, 5, xDistance));


            input = Mathf.Clamp(Mathf.Round((ball.transform.position.y - transform.position.y) * factor), -1, 1);
        }

        pos.y = Mathf.Clamp(transform.position.y + input * speed * Time.deltaTime, -yMax, yMax);

        transform.position = pos;

    }
}

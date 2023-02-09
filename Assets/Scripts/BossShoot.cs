using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot : MonoBehaviour
{

    public GameObject Arrow;
    float LaunchForce;
    public Transform shootPoint;
    [SerializeField] float PowerFixator;
    float power = 0;
    Vector2 direction;
    public Transform player;
    private float timeBtwShots;
    public float startTimeBtwShots;


    public GameObject point;
    GameObject[] Points;
    public int NumberofPoints;
    public float SpaceBetweenPoints;
    // Start is called before the first frame update
    void Start()
    {
        timeBtwShots = startTimeBtwShots;
        player = GameObject.FindGameObjectWithTag("Player").transform;

        Points = new GameObject[NumberofPoints];
        for (int i = 0; i < NumberofPoints; i++)
        {
            Points[i] = Instantiate(point, shootPoint.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 bowLocation = transform.position;
        Vector2 playerPos = player.position;

        //Vector2 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float bossShootDir_x = playerPos.x - bowLocation.x;
        float bossShootDir_y = Mathf.Abs(bossShootDir_x)/4;
        direction = new Vector2(bossShootDir_x, bossShootDir_y);
        transform.right = direction;

        Shooting();

        //for (int i = 0; i < NumberofPoints; i++)
        //{
        //    Points[i].transform.position = PointPosition(i * SpaceBetweenPoints);
        //}
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Shoot();
        //    power = 0;

        //}
        if (timeBtwShots <= 0)
        {
            Shoot();
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

    }

    void Shoot()
    {
        GameObject newArrow = Instantiate(Arrow, shootPoint.position, shootPoint.rotation);
        //float chariotSpeedx = Input.GetAxis("Horizontal") * 10;
        //Vector3 chariotSpeed = new Vector3(chariotSpeedx, 0f, 0f);

        //newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * LaunchForce + chariotSpeed;
        newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * LaunchForce;
    }
    void Shooting()
    {

        //if (Input.GetKey(KeyCode.Space) && power < 10)
        //{
        //    power = power + PowerFixator * Time.deltaTime;
        //}
        //if (!Input.GetKey(KeyCode.Space) && power > 0)
        //{
        //    power = power - 3 * PowerFixator * Time.deltaTime;
        //}
        //if (power < 0) { power = 0; }
        //if (power > 10) { power = 10; }

        //LaunchForce = power;
        LaunchForce = 10;
    }

}

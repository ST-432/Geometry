using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class PendulumWave : MonoBehaviour
{

    public GameObject Circle;   //円周上に動く円のオブジェクトのプレファブ
    GameObject[] Circle_arrg = new GameObject[Circle_num];
    public static int Circle_num;
    public int circle_num;
    public static int Max_radius;
    public int max_radius;
    public static int Min_radius;
    public int min_radius;
    public Transform positionCircle;    //全円運動の中心

    private float speed = 20f; // 円運動の速さ

    // Start is called before the first frame update
    void Start()
    {
        Circle_num = circle_num;
        Max_radius = max_radius;
        Min_radius = min_radius;

        System.Array.Resize(ref Circle_arrg, Circle_num);

        int Circle_range = Max_radius - Min_radius;
        float C_r = (Circle_range);
        float Circle_distance = C_r / Circle_num;
        if (Max_radius<=Min_radius)
        {

        }
        if(positionCircle!=null)
        {

        }
        for (int i = 0; i < Circle_num; i++)
        {
            Vector3 position = positionCircle.position;
            GameObject obj;
            obj = Instantiate(Circle);
            position.y = position.y + Min_radius + Circle_distance * i;
            obj.transform.position = position;

            string A;
            A = "Circle" + i.ToString("0");
            obj.name = A;
            Circle_arrg[i] = obj;
            Debug.Log(Circle_arrg[i].name);

        }


    }

    // Update is called once per frame
    void Update()
    {
        Circle_arrg[0].transform.RotateAround(positionCircle.position, Vector3.forward, speed * Time.deltaTime);
        Circle_arrg[4].transform.RotateAround(positionCircle.position, Vector3.forward, speed * Time.deltaTime);
        Circle_arrg[9].transform.RotateAround(positionCircle.position, Vector3.forward, speed * Time.deltaTime);
    }
}

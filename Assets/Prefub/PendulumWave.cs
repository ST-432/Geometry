using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
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

    public GameObject Line;
    GameObject[] Line_arrg = new GameObject[5];

    public float speed; // 円運動の速さ
    public float speed_magnification;

    // Start is called before the first frame update
    void Start()
    {
        if(circle_num>10)
        {
            //画面に入るのが10個まで
            circle_num = 10;
        }
        Circle_num = circle_num;
        Max_radius = max_radius;
        Min_radius = min_radius;

        System.Array.Resize(ref Circle_arrg, Circle_num);
        System.Array.Resize(ref Line_arrg, Circle_num-1);

        int Circle_range = Max_radius - Min_radius;
        float C_r = (Circle_range);
        float Circle_distance = C_r / Circle_num;
        int Circle_color = 255 / Circle_num;
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
            //色の変更処理
            byte byteValue_Red = System.Convert.ToByte(Circle_color * i);
            byte byteValue_Blue = System.Convert.ToByte(255- byteValue_Red);
            obj.GetComponent<SpriteRenderer>().material.color = new Color32(byteValue_Blue, 0, byteValue_Red, 255);

            Circle_arrg[i] = obj;
            Debug.Log(Circle_arrg[i].name);
            if(i<Circle_num-1)
            {
                GameObject obj_line;
                obj_line = Instantiate(Line);
                LineRenderer line = obj_line.GetComponent<LineRenderer>();
                line.positionCount = 2;

                Line_arrg[i] = obj_line;
            }

        }


    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0;i< Circle_arrg.Length;i++)
        {
            Circle_arrg[i].transform.RotateAround(positionCircle.position, Vector3.forward, (i+1)*speed_magnification * speed * Time.deltaTime);
        }
       
        for (int i=0;i< Line_arrg.Length; i++)
        {
            LineRenderer line = Line_arrg[i].GetComponent<LineRenderer>();
            line.SetPosition(0, Circle_arrg[i].transform.position);
            line.SetPosition(1, Circle_arrg[i+1].transform.position);
        }
    }
}

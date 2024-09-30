using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovent : MonoBehaviour
{
    public float mouseSensitivity = 100f;   //鼠标灵敏度

    float xRotation = 0f;   //鼠标在x轴上的旋转
    float yRotation = 0f;   //鼠标在y轴上的旋转

    void Start()
    {
        //隐藏鼠标
        Cursor.lockState = CursorLockMode.Locked;
    }

    // 每帧调用一次更新
    void Update()
    {
        //获取鼠标的移动量
        //Time.deltaTime是每帧之间的时间间隔,这样可以使得移动速度与帧率无关
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //限制鼠标在x轴上的旋转角度
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //鼠标在y轴上的旋转角度
        yRotation += mouseX;

        //旋转摄像机
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Management;

public class System_Input : MonoBehaviour
{
    [SerializeField] public Canvas System_Input_Canvas;
    [SerializeField] public GameObject XR_base_device;
    [SerializeField] public GameObject XR_action_base;
    [SerializeField] public GameObject XR_device_simulator;

    public void Start()
    {
        Time.timeScale = 0;
    }

public void OnClick(int indecs)
{
    // 1. Выключаем "менюшного" игрока и симулятор
    if (XR_device_simulator != null)
        XR_device_simulator.SetActive(false);

    // 2. Выключаем ОБА игрока, чтобы не осталось активных "старых"
    if (XR_base_device != null)
        XR_base_device.SetActive(false);
    if (XR_action_base != null)
        XR_action_base.SetActive(false);

    // 3. Включаем только выбранный
    if (indecs == 1)
    {
        XR_base_device.SetActive(true);
    }
    else if (indecs == 2)
    {
        XR_action_base.SetActive(true);
    }

    // 4. Прячем меню
    System_Input_Canvas.gameObject.SetActive(false);
    Time.timeScale = 1;
}
}
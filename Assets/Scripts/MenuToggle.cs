using UnityEngine;
using UnityEngine.InputSystem;

public class MenuToggle : MonoBehaviour
{
    [Tooltip("Перетащите сюда Canvas с меню")]
    [SerializeField] private GameObject menuCanvas;

    [Tooltip("Перетащите сюда действие 'Menu' из XRI Default Input Actions")]
    [SerializeField] private InputActionReference toggleActionReference;

    private void OnEnable()
    {
        if (toggleActionReference != null && toggleActionReference.action != null)
        {
            // Включаем действие, чтобы оно начало отслеживать нажатия
            toggleActionReference.action.Enable();
            // Подписываемся на событие нажатия
            toggleActionReference.action.performed += OnToggleMenu;
        }
    }

    private void OnDisable()
    {
        if (toggleActionReference != null && toggleActionReference.action != null)
        {
            // Отписываемся от события
            toggleActionReference.action.performed -= OnToggleMenu;
            // Отключаем действие, чтобы оно не тратило ресурсы
            toggleActionReference.action.Disable();
        }
    }

    private void OnToggleMenu(InputAction.CallbackContext context)
    {
        if (menuCanvas != null)
        {
            // Переключаем видимость Canvas
            menuCanvas.SetActive(!menuCanvas.activeSelf);
        }
    }
}
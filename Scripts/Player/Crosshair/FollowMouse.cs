using UnityEngine;
using UnityEngine.InputSystem;

public class FollowMouse : MonoBehaviour
{
    RectTransform uiElement;
    public float moveSpeed = 200f;

    private void Start()
    {
        uiElement = GetComponent<RectTransform>();
    }
    void Update()
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
    uiElement.parent as RectTransform,
    Input.mousePosition,
    null, // Use null for Screen Space - Overlay
    out Vector2 localPoint
);

        uiElement.anchoredPosition = Vector2.MoveTowards(
            uiElement.anchoredPosition,
            localPoint,
            moveSpeed * Time.deltaTime
        );

    }

}

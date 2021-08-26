using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MobileController : MonoBehaviour,IDragHandler,IPointerUpHandler,IPointerDownHandler
{
    private Image joystickBg;
    private Image joystick;
    private Vector2 inputVector;

    private void Start()
    {
        joystickBg = GetComponent<Image>();
        joystick = transform.GetChild(0).GetComponent<Image>();
    }

    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        inputVector = Vector2.zero;
        joystick.rectTransform.anchoredPosition = Vector2.zero;
    }

    public virtual void OnDrag(PointerEventData ped)
    {
        Vector2 pos;
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickBg.rectTransform,ped.position,ped.pressEventCamera, out pos))
        {
            pos.x = (pos.x / joystickBg.rectTransform.sizeDelta.x);
            pos.y = (pos.y / joystickBg.rectTransform.sizeDelta.x);

            inputVector = new Vector2(pos.x * 2, pos.y * 2);
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

            joystick.rectTransform.anchoredPosition = new Vector2(inputVector.x * (joystickBg.rectTransform.sizeDelta.x/2), inputVector.y * (joystickBg.rectTransform.sizeDelta.y / 2));
        }
    }

    public float Horizontal()
    {
        if (inputVector.x != 0) return inputVector.x;
        else return Input.GetAxis("Horizontal");
    }

    public float Vertical()
    {
        if (inputVector.y != 0) return inputVector.y;
        else return Input.GetAxis("Vertical");
    }
}

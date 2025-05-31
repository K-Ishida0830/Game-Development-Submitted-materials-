using UnityEngine;
using UnityEngine.InputSystem;

public class ItemPickup : MonoBehaviour
{
    public static event System.Action OnItemPickedUp;

    [Header("補聴器を拾ったときに無効化するオブジェクト")]
    public GameObject[] objectsToDisable;

    [Header("補聴器を拾ったときに有効化するオブジェクト")]
    public GameObject[] objectsToEnable;

    private bool isPlayerNearby = false;
    private bool isItemPickedUp = false;

    private InputController inputController;

    private void Awake()
    {
        inputController = new InputController();
    }

    private void OnEnable()
    {
        inputController.Enable();
        inputController.Player.Take.performed += HandlePickupInput;
    }

    private void OnDisable()
    {
        inputController.Player.Take.performed -= HandlePickupInput;
        inputController.Disable();
    }

    private void HandlePickupInput(InputAction.CallbackContext context)
    {
        TryPickUpItem();
    }

    public void TryPickUpItem()
    {
        if (isPlayerNearby && !isItemPickedUp)
        {
            Debug.Log($"{gameObject.name} を入手しました！");
            gameObject.SetActive(false);
            isItemPickedUp = true;

            // オブジェクトを無効化
            foreach (var obj in objectsToDisable)
            {
                if (obj != null)
                {
                    obj.SetActive(false);
                }
            }

            // オブジェクトを有効化
            foreach (var obj in objectsToEnable)
            {
                if (obj != null)
                {
                    obj.SetActive(true);
                }
            }

            OnItemPickedUp?.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
        }
    }
}

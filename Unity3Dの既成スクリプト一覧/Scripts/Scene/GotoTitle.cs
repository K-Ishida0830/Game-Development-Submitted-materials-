using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class GotoTitle : MonoBehaviour
{
    public Button retryButton;  // リトライボタン
    public Button exitButton;   // Exitボタン
    private bool isButtonPressed = false;  // ゲームパッドやキーボードが押されたかどうか
    public string titleSceneName = "Title";  // タイトルに遷移するシーン名

    void Start()
    {
        // ボタンのクリックイベントにメソッドを紐付ける
        retryButton.onClick.AddListener(() => LoadScene("Scene01")); // リトライ
        exitButton.onClick.AddListener(() => LoadScene(titleSceneName)); // Exit
    }

    void Update()
    {
        // ゲームパッドのAボタンが押されたか確認
        if (Gamepad.current != null && Gamepad.current.buttonSouth.wasPressedThisFrame)  // Aボタンに対応
        {
            // 現在選択されているボタンがゲームパッドで押されたボタンと一致するか確認
            if (EventSystem.current.currentSelectedGameObject != null)
            {
                Button selectedButton = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
                if (selectedButton != null && selectedButton.interactable)
                {
                    // 選択されているボタンのクリックイベントを呼び出す
                    selectedButton.onClick.Invoke();
                    isButtonPressed = true;  // ボタンが押されたことを記録
                }
            }
        }
        else
        {
            isButtonPressed = false;  // ゲームパッドが離されたらリセット
        }
    }

    // シーンを遷移するメソッド
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}

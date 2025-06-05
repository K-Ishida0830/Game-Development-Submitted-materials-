using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;  // EventSystemを追加

public class GamePlay : MonoBehaviour
{
    public Button startButton;  // ボタンをインスペクターでアタッチする
    public Button retryButton;  // リトライボタンを追加
    private bool isButtonPressed = false;  // ゲームパッドやキーボードが押されたかどうか
    public string startSceneName = "Scene01";  // リトライ時に遷移するシーン名
    public string titleSceneName = "Title";  // タイトルに遷移するシーン名

    void Start()
    {
        // ボタンのクリックイベントにメソッドを紐付ける
        if (startButton != null)
            startButton.onClick.AddListener(() => LoadScene(startSceneName));

        if (retryButton != null)
            retryButton.onClick.AddListener(() => LoadScene(startSceneName)); // リトライボタンも追加
    }

    void Update()
    {
        // ゲームパッドのAボタンが押されたか確認
        if (Gamepad.current != null && Gamepad.current.buttonSouth.wasPressedThisFrame)  // Aボタンに対応
        {
            // 現在選択されているボタンがゲームパッドで押されたボタンと一致するか確認
            if (EventSystem.current != null && EventSystem.current.currentSelectedGameObject != null)
            {
                Button selectedButton = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
                if (selectedButton != null && selectedButton.interactable)
                {
                    selectedButton.onClick.Invoke();  // 選択されているボタンのクリックイベントを呼び出す
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

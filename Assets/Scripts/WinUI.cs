using GogoGaga.TME;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinUI : MonoBehaviour {

    public Image panelBackground;
    public GameObject ui;

    public Button restartButton;
    public Button quitButton;

    private void Start() {
        restartButton.onClick.AddListener(() => {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        });

        quitButton.onClick.AddListener(() => {
            SceneManager.LoadScene(0);
        });

        GetComponent<LeantweenCustomAnimator>().OnUpdate_float.AddListener(Fade);
        GetComponent<LeantweenCustomAnimator>().PlayAnimation();

        ui.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }

    void Fade(float value) {
        panelBackground.color = new Color(panelBackground.color.r, panelBackground.color.g, panelBackground.color.b, value);
    }

}
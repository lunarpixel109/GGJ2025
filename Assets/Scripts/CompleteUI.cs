using GogoGaga.TME;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CompleteUI : MonoBehaviour {

    public Button restartButton;
    public Button quitButton;

    private void Start() {
        restartButton.onClick.AddListener(() => {
            SceneManager.LoadScene(0);
        });

        quitButton.onClick.AddListener(Application.Quit);

        // GetComponent<LeantweenCustomAnimator>().OnUpdate_float.AddListener(Fade);
        // GetComponent<LeantweenCustomAnimator>().OnCompletion.AddListener(() => {
        //     ui.SetActive(true);
        //     Cursor.lockState = CursorLockMode.None;
        // });
        // GetComponent<LeantweenCustomAnimator>().PlayAnimation();
    }

    // void Fade(float value) {
    //     panelBackground.color = new Color(panelBackground.color.r, panelBackground.color.g, panelBackground.color.b, value);
    // }

}
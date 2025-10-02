using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class TutorialSystem : MonoBehaviour
{
    [SerializeField] TMP_Text TutorialTextBox;
    [SerializeField] GameObject TutorialPanel;
    [SerializeField] TutorialSO[] TutorialTexts;

    //Revisar en el caso de añadir más tutoriales.
    private bool TutorialDone = false;

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.anyKey.isPressed && !TutorialDone)
        {
            StartCoroutine(StartTutorial());
            TutorialDone = true;
        }
    }

    IEnumerator StartTutorial()
    {
        this.TutorialPanel.gameObject.SetActive(true);

        foreach (var item in TutorialTexts)
        {
            this.TutorialTextBox.text = item.Text;
            yield return new WaitForSeconds(5);
        }

        this.TutorialPanel.gameObject.SetActive(false);

    }
}

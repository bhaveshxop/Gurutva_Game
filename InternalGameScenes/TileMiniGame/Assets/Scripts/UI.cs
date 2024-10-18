using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private Text _scoreLabel;
    [SerializeField] private Text _pairsLabel;
    [SerializeField] private Text _winLabel;

    public string ScoreLabel { set => _scoreLabel.text = value; }
    public string PairsLabel { set => _pairsLabel.text = value; }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SetWinScreenState(bool state)
    {
        _winLabel.gameObject.SetActive(state);
    }
}

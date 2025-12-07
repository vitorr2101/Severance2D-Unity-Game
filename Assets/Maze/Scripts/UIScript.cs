using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{

    [SerializeField] private TMP_Text _textScore;

    [SerializeField] private GameObject _gameOverPanel;

    [SerializeField] private GameObject _gameWinPanel;

    [SerializeField] private TMP_Text _textGameOver;

    [SerializeField] private GameObject _player;

    void Awake(){
        _textScore.text = "0";
        _gameOverPanel.SetActive(false);
    }

    void OnEnable(){
        Gatherable.OnGathered += HandleGathered;
        EnemyAI.OnPlayerAttacked += HandlePlayerAttacked;
    }

    void OnDisable(){
        Gatherable.OnGathered -= HandleGathered;
        EnemyAI.OnPlayerAttacked -= HandlePlayerAttacked;

    }

    void HandlePlayerAttacked(){
            _gameOverPanel.SetActive(true);
            _player.SetActive(false);
    }

    void HandleGathered(int gathered){
        _textScore.text = gathered.ToString();

        int totalGatherableLeft = FindObjectsByType<Gatherable>(FindObjectsInactive.Exclude,FindObjectsSortMode.None).Length;
        if(totalGatherableLeft == 0){
            _textGameOver.text = "Você conseguiu fugir da Lumon!";
            _gameWinPanel.SetActive(true);
            _player.SetActive(false);
        }
    }

    public void RestartScene(){
        SceneManager.LoadScene(0);
    }
}

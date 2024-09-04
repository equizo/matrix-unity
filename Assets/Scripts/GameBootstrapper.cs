using services;
using ui;
using UnityEngine;

public class GameBootstrapper : MonoBehaviour
{
  #region Editor references

  [SerializeField] private Ui _ui;

  #endregion

  private Game _game;

  private void Start()
  {
    HideCursor();
    var services = InitServices();
    StartGame(services);
  }

  private static void HideCursor() =>
    Cursor.visible = false;

  private static Services InitServices() =>
    new();

  private void StartGame(Services services) =>
    _game = new Game(services, _ui);

  private void Update() =>
    _game.Update(Time.deltaTime);
}
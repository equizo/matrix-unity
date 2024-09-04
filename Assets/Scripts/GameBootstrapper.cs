using DefaultNamespace.configuration;
using services;
using system;
using ui;
using UnityEngine;

public class GameBootstrapper : MonoBehaviour
{
  #region Editor references

  [SerializeField] private Ui _ui;

  #endregion

  private const string Alphabet = "ﾊﾐﾋｰｳｼﾅﾓﾆｻﾜﾂｵﾘｱﾎﾃﾏｹﾒｴｶｷﾑﾕﾗｾﾈｽﾀﾇﾍ0123456789<>.=*+-";
  private Game _game;

  private void Start()
  {
    HideCursor();
    StaticDataHandler.Init(new FileContentProvider());
    StartGame(InitServices());
  }

  private static void HideCursor() =>
    Cursor.visible = false;

  private static Services InitServices() =>
    new(Alphabet);

  private void StartGame(Services services) =>
    _game = new Game(services, _ui);

  private void Update() =>
    _game?.Update(Time.deltaTime);
}
using System.Collections.Generic;
using DefaultNamespace;
using services;
using ui;
using waterfall;

public class Game
{
  private readonly Timer _addCascadeTimer;
  private readonly Timer _renderingTimer;
  private readonly CascadesRenderer _cascadesRenderer;
  private readonly List<int> _columns = new();
  private readonly Waterfall _waterfall;

  public Game(IServices services, Ui ui)
  {
    var uiText = ui.Text;

    var mapSize = new Map().GetSize(ui.HolderSize, uiText.fontSize);
    int height = mapSize.Item2;
    int width = mapSize.Item1;

    CreateColumns(width);
    UnityEngine.Debug.Log($"mapSize: {mapSize}");
    services.CascadeFactory.Init(mapSize, _columns);
    _addCascadeTimer = new Timer(Config.AddCascadeInterval);
    _renderingTimer = new Timer(Config.RenderingInterval);
    _waterfall = new Waterfall(services.CascadeFactory, _columns, height);
    _cascadesRenderer = new CascadesRenderer(_waterfall.Cascades, uiText, mapSize);
    _addCascadeTimer.OnTick += OnAddCascadeTimerTick;
    _renderingTimer.OnTick += OnRenderingTick;
  }

  private void OnRenderingTick() =>
    Render();

  private void CreateColumns(int width)
  {
    for (int i = 0; i < width; i++) {
      _columns.Add(i);
    }
  }

  ~Game()
  {
    _addCascadeTimer.OnTick -= OnAddCascadeTimerTick;
    _renderingTimer.OnTick -= OnRenderingTick;
  }

  public void Update(float deltaTime)
  {
    _waterfall.Update(deltaTime);
    _addCascadeTimer.Update(deltaTime);
    _renderingTimer.Update(deltaTime);
  }

  private void OnAddCascadeTimerTick() =>
    AddCascade();

  private void AddCascade() =>
    _waterfall.AddCascade();

  private void Render() =>
    _cascadesRenderer.Update();
}
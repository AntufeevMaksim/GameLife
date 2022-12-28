
class Cell{
  
  bool _is_alive;
  int _x;
  int _y;

  int _amount_neighbors;
  public Cell(bool is_alive){
    _is_alive = is_alive;
  }

  public int X { get => _x; set => _x = value; }
  public int Y { get => _y; set => _y = value; }
  public int Amount_neighbors { get => _amount_neighbors; set => _amount_neighbors = value; }

  public bool IsAlive(){
    return _is_alive;
  }

  public void SetStatus(bool alive){
    _is_alive = alive;
  }
}
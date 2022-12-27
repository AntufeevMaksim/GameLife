
class Cell{
  
  bool _is_alive;
  int _x;
  int _y;

  public Cell(bool is_alive){
    _is_alive = is_alive;
  }

  public int X { get => _x; set => _x = value; }
  public int Y { get => _y; set => _y = value; }

  public bool IsAlive(){
    return _is_alive;
  }
}
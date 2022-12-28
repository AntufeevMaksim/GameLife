
class Game
{
  Graphics graphics = new Graphics();
  List<List<Cell>> _field = new List<List<Cell>>();
  int _heighth = 40;
  int _width = 40;
  public void Run(){
    Console.WriteLine();
    GenerateField();
    while (true){
      graphics.Draw(_field);
      Move();

      if(Console.KeyAvailable == true){
        if(Console.ReadKey().Key == ConsoleKey.Escape){
          Console.SetCursorPosition(0, _heighth+2);
          break;
        }
      }
      System.Threading.Thread.Sleep(1000);    
    }
  }

  void GenerateField(){

    List<Cell> alive_cells = InputParse();

    for(int y = 0; y < _heighth; y++){
      _field.Add(new List<Cell>());
      for(int x = 0; x < _width; x++){
        if(IsAlive(alive_cells, x, y)){
          _field[y].Add(new Cell(true));
        }
        else{
          _field[y].Add(new Cell(false));
        }
      }
    }
  }

  List<Cell> InputParse(){
    string input = Console.ReadLine();
    List<Cell> cells = new List<Cell>();

    string[] pairs = input.Split(" ");

    foreach(string pair in pairs){
      string[] coords = pair.Split(",");
      Cell cell = new Cell(true);
      cell.X = Int32.Parse(coords[0])-1;
      cell.Y = Int32.Parse(coords[1])-1;
      cells.Add(cell);
    }
    return cells;
  }

  bool IsAlive(List<Cell> alive_cells, int x, int y){
    foreach(Cell cell in alive_cells){
      if(cell.X == x && cell.Y == y){
        return true;
      }
    }
    return false;
  }


  void AddNeighbors(int x, int y){
    x -= 1; y -=1;
    AddNeighbor(x, y);

    x += 1;
    AddNeighbor(x, y);

    x += 1;
    AddNeighbor(x, y);

    y +=1;
    AddNeighbor(x, y);

    y +=1;
    AddNeighbor(x, y);

    x -= 1;
    AddNeighbor(x, y);

    x -= 1;
    AddNeighbor(x, y);

    y -=1;
    AddNeighbor(x, y);

    
  }

  void AddNeighbor(int x, int y){
    if((x>=0 && x < _width) && (y>=0 && y < _heighth)){
      _field[y][x].Amount_neighbors += 1;
    }
  }

  void CountNeighbors(){
    for(int y = 0; y < _heighth; y++){
      for(int x = 0; x < _width; x++){
        if(_field[y][x].IsAlive()){
          AddNeighbors(x, y);
        }
      }
    }
    
  }

  void Move()
  {
    CountNeighbors();

    for(int y = 0; y < _heighth; y++){
      for(int x = 0; x < _width; x++){
      if(_field[y][x].IsAlive() == false && _field[y][x].Amount_neighbors == 3){
        _field[y][x].SetStatus(true);
      }
      else if(_field[y][x].IsAlive() == true && (_field[y][x].Amount_neighbors < 2 || _field[y][x].Amount_neighbors > 3)){
        _field[y][x].SetStatus(false);
      }
      _field[y][x].Amount_neighbors = 0;
    }
    }


  }
}

class Game
{
  Graphics graphics = new Graphics();
  List<List<Cell>> _field = new List<List<Cell>>();
  int _heighth = 10;
  int _width = 10;
  public void Run(){
    Console.WriteLine();
    GenerateField();
    while (true){
      graphics.Draw(_field);
      Move();
      System.Threading.Thread.Sleep(1000);    
    }
  }

  void GenerateField(){ //generate demo field

    List<Cell> alive_cells = InputParse();

    for(int x = 0; x < 10; x++){
      _field.Add(new List<Cell>());
      for(int y = 0; y < 10; y++){
        if(IsAlive(alive_cells, x, y)){
          _field[x].Add(new Cell(true));
        }
        else{
          _field[x].Add(new Cell(false));
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
    if((x>0 && x < _width) && (y>0 && y < _heighth)){
      _field[x][y].Amount_neighbors += 1;
    }
  }

  void CountNeighbors(){
    for(int x = 0; x < _field.Count(); x++){
      for(int y = 0; y < _field[0].Count(); y++){
        if(_field[x][y].IsAlive()){
          AddNeighbors(x, y);
        }
      }
    }
    
  }

  void Move()
  {
    CountNeighbors();

    for(int x = 0; x < _field.Count(); x++){
      for(int y = 0; y < _field[0].Count(); y++){
      if(_field[x][y].IsAlive() == false && _field[x][y].Amount_neighbors == 3){
        _field[x][y].SetStatus(true);
      }
      else if(_field[x][y].IsAlive() == true && (_field[x][y].Amount_neighbors < 2 || _field[x][y].Amount_neighbors > 3)){
        _field[x][y].SetStatus(false);
      }
      _field[x][y].Amount_neighbors = 0;
    }
    }


  }
}
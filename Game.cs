
class Game
{
  static Graphics graphics = new Graphics();
  static List<List<Cell>> _field = new List<List<Cell>>();
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

    List<Cell> alive_cells = GetAliveCells();

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

  List<Cell> GetAliveCells(){
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

  void Move(){
    List<Cell> alive_cells = GetAliveCells();
//    List<Cell> 
  }
}
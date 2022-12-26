
class Graphics{

  public void Draw(List<List<Cell>> field){
//    int heighth = field.Count();
//    int width = field[0].Count();

    foreach(var i1 in field){
      foreach(Cell cell in i1){
        if(cell.IsAlive()){
          Console.Write("🔴");
        }
        else{
          Console.Write("⚪");
        }
      }
      Console.WriteLine(); //next line
    }
    Console.SetCursorPosition(0, 0);
  }
}
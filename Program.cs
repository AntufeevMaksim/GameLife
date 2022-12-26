// See https://aka.ms/new-console-template for more information
internal class Program{

  static Graphics graphics = new Graphics();
  static List<List<Cell>> field = new List<List<Cell>>();
  static void Main(string[] args){
      GenerateField();
      graphics.Draw(field);
//      graphics.Draw(field);
    }

  static void GenerateField(){ //generate demo field

    for(int i1 = 0; i1 < 10; i1++){
      field.Add(new List<Cell>());
      for(int i2 = 0; i2 < 10; i2++){
        field[i1].Add(new Cell(false));
      }
    }
  }

}
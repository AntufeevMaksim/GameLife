// See https://aka.ms/new-console-template for more information
internal class Program{

  static Graphics graphics = new Graphics();
  static List<List<Cell>> _field = new List<List<Cell>>();
  static void Main(string[] args){
      new Game().Run();
    }
}
namespace GenericsExamples.Models;

public class Box<T> {
    public string Name { get; set; }
    public T Item { get; set; }
    public List<T> ItemList { get; set; }

    public Box(string givenName, T givenItem, List<T> givenItemList) {
        this.Name = givenName;
        this.Item = givenItem;
        this.ItemList = givenItemList;
    }

    public override string ToString() {
        string output = $"{this.Name} Item: {this.Item}\n{this.Name} ItemList:\n";
        
        foreach(T elem in this.ItemList) {
            output += $"{elem}\n";
        }

        return output;
    }

}
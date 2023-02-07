public class CaseModel {

    bool IsOccupied { get; set; }
    int Position { get; set; }
    string Color { get; set; }

    public CaseModel(int position, bool isOccupied, string color) {
        Position = position;
        IsOccupied = isOccupied;
        Color = color;
    }

}
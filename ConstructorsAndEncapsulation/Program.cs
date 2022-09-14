
string[] coursesArr = {
    "Kurs om C#", "Git och GitHub", "Databser"};
HtmlGenerator Website = new HtmlGenerator(h1: "Hej klassen", h2: "Viktigt meddelande", coursesArr);
StyleGenerator style = new StyleGenerator(h1: "Hej klassen", h2: "Viktigt meddelande", _color: "red", coursesArr);
style.PrintPage();

class HtmlGenerator
{
    public string docStart = "<!DOCTYPE html>\n" +
      "<html>\n" + "<body>\n";
    public string h1 = "<h1></h1>\n";
    public string h2 = "<h2></h2>\n";
    public string main = "<main>\n" + "</main>\n";
    public string paragraph = "<p></p>\n";
    public string docEnd = "</body>\n" + "</html>";

    public HtmlGenerator(string h1, string h2, string[] coursesArr)
    {
        string InsertParagraphContent(string[] coursesArr)
        {
            string paragraphContent = "";
            foreach (var item in coursesArr)
            {
                paragraphContent += paragraph.Insert(paragraph.IndexOf("</"), item);
            }
            return paragraphContent;
        }
        main = main.Insert(main.IndexOf("</"), InsertParagraphContent(coursesArr));
        this.h1 = this.h1.Insert(this.h1.IndexOf("</"), h1);
        this.h2 = this.h2.Insert(this.h2.IndexOf("</"), h2);
    }
    public virtual void PrintPage()
    {
        Console.Write(docStart + h1 + h2 + main + docEnd);
    }
}
class StyleGenerator : HtmlGenerator
{
    private string head = "<head>\n</head>\n";
    private string style = "<style></style>\n";
    public StyleGenerator(string h1, string h2, string _color, string[] coursesArr) : base(h1, h2, coursesArr)
    {

        head = docStart.Insert(docStart.IndexOf("<html>"), head);
        style = head.Insert(head.IndexOf("</"), style);
        style = style.Insert(style.IndexOf("</"), _color);
    }
    public override void PrintPage()
    {
        Console.Write(style + h1 + h2 + main + docEnd);
    }
}



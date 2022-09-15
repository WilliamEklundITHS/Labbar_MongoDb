
string[] coursesArr = {
    "Kurs om C#", "Git och GitHub", "Databser"};
HtmlGenerator Website = new HtmlGenerator(h1: "Hej klassen", h2: "Viktigt meddelande", coursesArr);
Website.PrintPage();

StyleGenerator StyleWebsite = new StyleGenerator(h1: "Hej klassen", h2: "Viktigt meddelande", primaryColor: "red", coursesArr);
StyleWebsite.PrintPage();

interface IHtmlSkeleton
{
    void PrintPage();
}
class HtmlGenerator : IHtmlSkeleton
{

    protected string docStart = "<!DOCTYPE html>\n" +
"<html>\n" + "<body>\n";
    protected string h1 = "<h1></h1>\n";
    protected string h2 = "<h2></h2>\n";
    protected string main = "<main>\n" + "</main>\n";
    protected string paragraph = "<p></p>\n";
    protected string docEnd = "</body>\n" + "</html>";

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

class StyleGenerator : HtmlGenerator, IHtmlSkeleton
{
    protected string head = "<head>\n</head>\n";
    protected string style = "<style></style>\n";

    public StyleGenerator(string h1, string h2, string primaryColor, string[] coursesArr) : base(h1, h2, coursesArr)
    {
        head = docStart.Insert(docStart.IndexOf("<html>"), head);
        style = head.Insert(head.IndexOf("</"), style);
        style = style.Insert(style.IndexOf("</"), $"color: {primaryColor};");
    }
    override public void PrintPage()
    {
        Console.Write("\n\n" + style + h1 + h2 + main + docEnd);
    }
}


string[] coursesArr = {
    "Kurs om C#", "Git och GitHub", "Databser", "Konstruktorer och Enkapsulation"};
HtmlGenerator Website = new HtmlGenerator(h1Title: "Hej Klassen", h2Message: "Ditt meddelande", h3Class: "NE22", coursesArr);
Website.PrintFullPage();
class HtmlGenerator
{
    private string docStart = "<!DOCTYPE html>\n" +
"<html>\n" + "<body>\n";
    private string h1 = "<h1></h1>\n";
    private string h3 = "<h3>Klass: </h3>\n";
    private string h2 = "<h2></h2>\n";
    private string main = "<main>\n" + "</main>\n";
    private string paragraph = "<p></p>\n";
    private string docEnd = "</body>\n" + "</html>";
    public string DocStart
    {
        get { return docStart; }
        set
        {
            docStart = "<!DOCTYPE html>\n" +
               "<html>\n" + "<body>\n";
        }
    }
    public string H1
    {
        get { return h1; }
        set { h1 = "<h1></h1>\n"; }
    }
    public string H2
    {
        get { return h2; }
        set { h2 = "<h2></h2>\n"; }
    }
    public string H3
    {
        get { return h3; }
        set { h3 = "<h3>Klass: </h3>\n"; }
    }
    public string Main
    {
        get { return main; }
        set { main = "<main>\n" + "</main>\n"; }
    }
    public string Paragraph
    {
        get { return paragraph; }
        set { paragraph = "<p></p>\n"; }
    }
    public string DocEnd
    {
        get { return docEnd; }
        set { docEnd = "</body>\n" + "</html>"; }
    }

    public HtmlGenerator(string h1Title, string h2Message, string h3Class, string[] coursesArr)
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
        h1 = h1.Insert(h1.IndexOf("</"), h1Title);
        h2 = h2.Insert(h2.IndexOf("</"), h2Message);
        h3 = h3.Insert(h3.IndexOf("</"), h3Class);
    }

    public void PrintFullPage()
    {
        Console.WriteLine(DocStart + H1 + H3 + H2 + Main + DocEnd);
    }
}

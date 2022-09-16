
string[] coursesArr = {
    "Kurs om C#", "Git och GitHub", "Databser"};

string[] messageArr = { "Viktigt meddelande", "Information mm" };

HtmlGenerator Website = new HtmlGenerator(title: "Hej klassen", messageArr, coursesArr);
Website.PrintPage();

StyleGenerator StyleWebsite = new StyleGenerator(title: "Hej klassen", messageArr, color: "red", coursesArr);
StyleWebsite.PrintPage();

interface IHtmlGenerrator
{
    void PrintPage();
}

class HtmlGenerator : IHtmlGenerrator
{
    protected virtual string DocStart
    { get; set; }
    protected string H1
    { get; set; }
    protected string H2
    { get; set; }
    protected string Main
    { get; set; }
    protected string Paragraph
    { get; set; }
    protected string DocEnd
    { get; set; }

    public HtmlGenerator(string title, string[] messageArr, string[] coursesArr)
    {
        DocStart = "<!DOCTYPE html>\n" +
      "<html>\n" + "<body>\n";
        H1 = "<h1></h1>\n";
        H2 = "<h2></h2>\n";
        Main = "<main>\n" + "</main>\n";
        Paragraph = "<p></p>\n";
        DocEnd = "</body>\n" + "</html>";

        string InsertParagraphContent(string[] coursesArr)
        {
            string paragraphContent = "";

            foreach (var item in coursesArr)
            {
                paragraphContent += Paragraph.Insert(Paragraph.IndexOf("</"), item);
            }
            return paragraphContent;
        }
        string InsertMessagesContent(string[] _messageArr)
        {

            string messagesContent = "";
            foreach (var item in _messageArr)
            {
                messagesContent += H2.Insert(H2.IndexOf("</"), item);
            }
            return messagesContent;
        }
        Main = Main.Insert(Main.IndexOf("</"), InsertParagraphContent(coursesArr));
        H1 = H1.Insert(H1.IndexOf("</"), title);
        H2 = InsertMessagesContent(messageArr);
    }
    public virtual void PrintPage()
    {
        Console.Write("---HtmlGenerator---\n\n" + DocStart + H1 + H2 + Main + DocEnd);
    }
}
class StyleGenerator : HtmlGenerator, IHtmlGenerrator
{
    public StyleGenerator(string title, string[] messageArr, string color, string[] coursesArr) : base(title, messageArr, coursesArr)
    {
        DocStart = "<!DOCTYPE html>\n<html>\n<head>\n<style></style>\n</head>\n";
        DocStart = DocStart.Insert(DocStart.IndexOf("</style>"), color);
    }
    public override void PrintPage()
    {
        Console.Write("\n\n---StyleGenerator---\n\n" + DocStart + H1 + H2 + Main + DocEnd);
    }
}















/*class Animal  // Base class (parent) 
{
    public virtual void animalSound()
    {
        Console.WriteLine("The animal makes a sound");
    }
}

class Pig : Animal  // Derived class (child) 
{
    public override void animalSound()
    {
        Console.WriteLine("The pig says: wee wee");
    }
}

class Dog : Animal  // Derived class (child) 
{
    public override void animalSound()
    {
        Console.WriteLine("The dog says: bow wow");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Animal myAnimal = new Animal();  // Create a Animal object
        Animal myPig = new Pig();  // Create a Pig object
        Animal myDog = new Dog();  // Create a Dog object

        myAnimal.animalSound();
        myPig.animalSound();
        myDog.animalSound();
    }
}*/
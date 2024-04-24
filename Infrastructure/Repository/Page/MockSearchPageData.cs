using Infrastructure.Models.Data.Shared.Card;
using Infrastructure.Models.Data.Shared.Image;

namespace Infrastructure.Repository.Page
{
    public class MockSearchPageData
    {
        

        public MockSearchPageData()
        {
            Image image0 = new Image("LMWlogo.png", null,0,false,false,"SearchPageCardImage0");
            Card card0 = new Card(image0, "Part 1 of My Portfolio Completed", "This portfolio will be the home of all side projects and learning pieces done outside of work including Programming, Games, 2D and 3D Assets.", "0", 0, false, false,4, "SearchPageCard0");
            Image image1 = new Image("LMWlogo.png", null, 1, false, false, "SearchPageCardImage1");
            Card card1 = new Card(image1, "Lewis Matthew Whittard Software Development Logo", "This Logo was created using a mix of Blender and GIMP.", "1", 1, false, false,3, "Card1");
            Image image2 = new Image("LMWlogo.png", null, 2, false, false, "SearchPageCardImage2");
            Card card2 = new Card(image2, "My Portfolio – Website Development", "My portfolio website Made with MVC.Net Core (C#,CSHTML,Bootstrap), Libre Office Calc, ClosedXML and Canva.", "2", 2, false, false,2, "SearchPageCard2");
            Image image3 = new Image("TestIconSquare.png", null, 3, false, false, "SearchPageCardImage3");
            Card card3 = new Card(image3, "UI Test Automation Portfolio Piece", "UI Test Automation portfolio piece, I used the following tools: C#, Selenium, NUnit, Libre Office Impress and Microsoft Video Editor.", "3", 3, false, false,1, "SearchPageCard3");
            Image image4 = new Image("CogettaPlain.png", null, 4, false, false, "SearchPageCardImage4");
            Card card4 = new Card(image4, "Cogetta", "A substitution cipher written in Python 3.", "4",4, false, false,0, "SearchPageCard4");
        }
        
    }
}

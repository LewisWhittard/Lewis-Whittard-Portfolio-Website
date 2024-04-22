using Infrastructure.Models.Data.Shared.Card;
using Infrastructure.Models.Data.Shared.Image;

namespace Infrastructure.Repository.Page
{
    public class MockSearchPageData
    {
        public MockSearchPageData()
        {
            Image image0 = new Image();
            Card card0 = new Card(image0, "", "", "", 0, false, false,0, "");
            Image image1 = new Image();
            Card card1 = new Card(image1, "", "", "", 1, false, false,1, "");
            Image image2 = new Image();
            Card card2 = new Card(image2, "", "", "", 2, false, false,2, "");
            Image image3 = new Image();
            Card card3 = new Card(image3, "", "", "", 3, false, false,3, "");
            Image image4 = new Image();
            Card card4 = new Card(image4, "", "", "", 4, false, false,4, "");
        }
        
    }
}
